using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CatalogGenerator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Catalog _catalog;
        private readonly CatalogSettings _catalogSettings;
        private IEnumerable<Label>? _temperatureLabels;
        private IEnumerable<Label>? _visibleTemperatureLabels;
        private IEnumerable<Label>? _miscLabels;
        private IEnumerable<Label>? _visibleMiscLabels;
        private IEnumerable<Label>? _lightingLabels;
        private IEnumerable<Label>? _visibleLightingLabels;
        private IEnumerable<Label>? _wateringLabels;
        private IEnumerable<Label>? _visibleWateringLabels;
        private List<string>? _ignoreBoardLists;

        public IndexModel(ILogger<IndexModel> logger, Catalog catalog, IOptions<CatalogSettings> catalogSettings)
        {
            _logger = logger;
            _catalog = catalog;
            _catalogSettings = catalogSettings.Value;
        }

        public void OnGet()
        {

        }

        public string AuctionName => _catalogSettings.AuctionName;

        public IEnumerable<Label> TemperatureLabels => _temperatureLabels ??= GetTemperatureLabels();

        public IEnumerable<Label> VisibleTemperatureLabels =>
            _visibleTemperatureLabels ??= TemperatureLabels.Where(l => l.VisibleInIconKey);

        public IEnumerable<Label> MiscLabels => _miscLabels ??= GetMiscLabels();

        public IEnumerable<Label> VisibleMiscLabels =>
            _visibleMiscLabels ??= MiscLabels.Where(l => l.VisibleInIconKey);

        public IEnumerable<Label> LightingLabels => _lightingLabels ??= GetLightingLabels();

        public IEnumerable<Label> VisibleLightingLabels =>
            _visibleLightingLabels ??= LightingLabels.Where(l => l.VisibleInIconKey);

        public IEnumerable<Label> WateringLabels => _wateringLabels ??= GetWateringLabels();

        public IEnumerable<Label> VisibleWateringLabels =>
            _visibleWateringLabels ??= WateringLabels.Where(l => l.VisibleInIconKey);

        private IEnumerable<Label> GetMiscLabels()
        {
            var formats = GetFormatLabels().ToList();

            return
                GetBloomingLabels().Where(l => l.VisibleInIconKey)
                    .Union(GetOtherLabels().Where(l => l.VisibleInIconKey))
                    .Union(GetSizeLabels().Where(l => l.VisibleInIconKey))
                    .Union(new List<Label>
                    {
                        new Label
                        {
                            Description = "Size",
                            HTML = formats.First().HTML + "&nbsp;-" + formats.SkipLast(1).Last().HTML,
                            VisibleInIconKey = true
                        },
                        formats.Last()
                    });
        }

        public IEnumerable<Label> GetTemperatureLabels() => GetLabels(_catalogSettings.Temperature.Labels);
        public IEnumerable<Label> GetLightingLabels() => GetLabels(_catalogSettings.Lighting.Labels);
        public IEnumerable<Label> GetWateringLabels() => GetLabels(_catalogSettings.Watering.Labels);
        public IEnumerable<Label> GetBloomingLabels() => GetLabels(_catalogSettings.Blooming.Labels);
        public IEnumerable<Label> GetFormatLabels() => GetLabels(_catalogSettings.Format.Labels);
        public IEnumerable<Label> GetOtherLabels() => GetLabels(_catalogSettings.Other.Labels);
        public IEnumerable<Label> GetSizeLabels() => GetLabels(_catalogSettings.Size.Labels);

        private IEnumerable<Label> GetLabels(IEnumerable<LabelSetting> sourceLabels)
        {
            foreach (LabelSetting settingLabel in sourceLabels)
            {
                var catalogLabel = _catalog.Labels.FirstOrDefault(l => l.Name == settingLabel.TrelloName);
                if (catalogLabel is null) continue;

                yield return new Label
                {
                    TrelloName = catalogLabel.Name,
                    DisplayName = settingLabel.Name,
                    Id = catalogLabel.Id,
                    HTML = settingLabel.HTML,
                    Description = settingLabel.Description,
                    VisibleInIconKey = !settingLabel.HideInIconKey
                };
            }
        }

        public IEnumerable<Card> Cards => GetCatalogCards().OrderBy(c => c.Name);

        public IEnumerable<Card> GetCatalogCards()
        {
            foreach (var card in _catalog.Cards)
            {
                if (IgnoreBoardLists.Contains(card.ListId)) continue;
                if (card.Closed) continue;

                yield return new Card
                {
                    Name = card.Name,
                    Description = card.Description,
                    Attachments = from a in card.Attachments
                                  select new CardAttachment
                                  {
                                      Url = a.Url
                                  },
                    LabelIds = card.LabelIds ?? new List<string>()
                };
            }
        }

        public List<string> IgnoreBoardLists => _ignoreBoardLists ??= GetIgnoreBoardLists().ToList();

        private IEnumerable<string> GetIgnoreBoardLists()
        {
            foreach (var list in _catalogSettings.IgnoreLists ?? new List<string>())
            {
                var catalogList = from l in _catalog.Lists
                                  where l.Name == list
                                  select l;
                foreach (var l in catalogList)
                {
                    yield return l.Id;
                }
            }
        }

        public string IntroductionText => GetIntroductionText();
        public string AcknowledgementText => GetAcknowledgementText();
        public string DisclaimersText => GetDisclaimersText();
        public IEnumerable<string> AcknowledgementList => GetAcknowledgementList();

        public string GetIntroductionText()
        {
            return GetCardDescription(_catalogSettings.Overview.List, _catalogSettings.Overview.IntroductionCard);
        }

        public string GetAcknowledgementText()
        {
            return GetCardDescription(_catalogSettings.Overview.List, _catalogSettings.Overview.AcknowledgementCard);
        }

        public string GetDisclaimersText()
        {
            return GetCardDescription(_catalogSettings.Overview.List, _catalogSettings.Overview.IntroductionCard);
        }

        private CatalogCard GetCard(string listName, string cardName)
        {
            var listId = _catalog.Lists.First(l => l.Name == listName).Id;
            return _catalog.Cards.First(c => c.ListId == listId && c.Name == cardName);
        }

        private string GetCardDescription(string listName, string cardName)
        {
            var plain = GetCard(listName, cardName).Description;
            var list = plain.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            return "<p>" + string.Join("</p>\n\n<p>", list) + "</p>";
        }

        private IEnumerable<string> GetAcknowledgementList()
        {
            var card = GetCard(_catalogSettings.Overview.List, _catalogSettings.Overview.AcknowledgementCard);
            var checklist = GetChecklist(card.ChecklistIds.First());
            return checklist.ChecklistItems.Select(i => i.Name);
        }

        private CatalogChecklist GetChecklist(string checklistId) => _catalog.Checklists.First(l => l.Id == checklistId);
    }
}