namespace OrchidSocietyAuctions;

public class AuctionSettings
{
    public string SocietyName { get; set; } = null!;
    public AuctionBoard[] Auctions { get; set; } = [];
    public SizeSettings Size { get; set; } = new SizeSettings();
    public BloomingSettings Blooming { get; set; } = new BloomingSettings();
    public TemperatureSettings Temperature { get; set; } = new TemperatureSettings();
    public WateringSettings Watering { get; set; } = new WateringSettings();
    public LightingSettings Lighting { get; set; } = new LightingSettings();
    public FormatSettings Format { get; set; } = new FormatSettings();
    public OtherSettings Other { get; set; } = new OtherSettings();
}

public class AuctionBoard
{
    public string Title { get; set; } = null!;
    public string Key { get; set; } = null!;
    public string[] IgnoreLists { get; set; } = [];
    public OverviewSettings Overview { get; set; } = new OverviewSettings();
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
    public string Description { get; set; } = null!;
    public string[] Classes { get; set; } = [];
    public string? Text { get; set; } = null!;
    public string? AltText { get; set; } = null!;
    public string[] ImageFiles { get; set; } = [];
    public bool HideInIconKey { get; set; }
}

public class OverviewSettings
{
    public string List { get; set; } = null!;
    public string IntroductionCard { get; set; } = null!;
    public string AcknowledgementCard { get; set; } = null!;
    public string DisclaimerCard { get; set; } = null!;
}