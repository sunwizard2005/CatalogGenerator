namespace OrchidSocietyAuctions.Trello
{
    public class Label
    {
        public string TrelloName { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Id { get; set; } = null!;
        public string[] Classes { get; set; } = [];
        public string? Text { get; set; }
        public string? AltText { get; set; }
        public string[] ImageFiles { get; set; } = [];
        public string? Description { get; set; }
        public bool VisibleInIconKey { get; set; }
    }
}
