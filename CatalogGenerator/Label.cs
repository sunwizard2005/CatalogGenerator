namespace CatalogGenerator
{
    public class Label
    {
        public string TrelloName { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Id { get; internal set; }
        public string HTML { get; internal set; }
        public string Description { get; internal set; }
        public bool VisibleInIconKey { get; internal set; }
    }
}
