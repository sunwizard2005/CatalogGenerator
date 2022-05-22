namespace CatalogGenerator
{
    public class Label
    {
        public string TrelloName { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Id { get; set; } = null!;
        public string HTML { get; set; } = null!;
        public string? Description { get; set; }
        public bool VisibleInIconKey { get; set; }
    }
}
