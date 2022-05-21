
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;

namespace CatalogGenerator
{

    public class CatalogSettings
    {
        public string TrelloId { get; set; } = null!;
        public SizeSettings Size { get; set; } = new SizeSettings();
        public BloomingSettings Blooming { get; set; } = new BloomingSettings();
        public TemperatureSettings Temperature { get; set; } = new TemperatureSettings();
        public WateringSettings Watering { get; set; } = new WateringSettings();
        public LightingSettings Lighting { get; set; } = new LightingSettings();
        public FormatSettings Format { get; set; } = new FormatSettings();
        public OtherSettings Other { get; set; } = new OtherSettings();
        public IEnumerable<string>? IgnoreLists { get; set; }
    }

    public class SizeSettings
    {
        public IEnumerable<LabelSetting> Labels { get; set; } = null!;
    }

    public class BloomingSettings
    {
        public IEnumerable<LabelSetting> Labels { get; set; } = null!;
    }

    public class TemperatureSettings
    {
        public IEnumerable<LabelSetting> Labels { get; set; } = null!;
    }

    public class WateringSettings
    {
        public IEnumerable<LabelSetting> Labels { get; set; } = null!;
    }

    public class LightingSettings
    {
        public IEnumerable<LabelSetting> Labels { get; set; } = null!;
    }

    public class FormatSettings
    {
        public IEnumerable<LabelSetting> Labels { get; set; } = null!;
    }

    public class OtherSettings
    {
        public IEnumerable<LabelSetting> Labels { get; set; } = null!;
    }

    public class LabelSetting
    {
        public string TrelloName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string HTML { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool HideInIconKey { get; set; }
    }
}