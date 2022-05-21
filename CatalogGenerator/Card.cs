using System.Collections.Generic;

namespace CatalogGenerator
{
    public class Card
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<CardAttachment> Attachments { get; set; }
        public IEnumerable<string> LabelIds { get; set; }
    }
}