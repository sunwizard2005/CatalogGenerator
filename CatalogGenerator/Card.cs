using System.Collections.Generic;

namespace CatalogGenerator
{
    public class Card
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public IEnumerable<CardAttachment> Attachments { get; set; } = null!;
        public IEnumerable<string> LabelIds { get; set; } = null!;
    }
}