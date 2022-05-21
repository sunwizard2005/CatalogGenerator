using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.Json.Serialization;

namespace CatalogGenerator
{
    public class Catalog
    {
        [JsonPropertyName("cards")]
        public IEnumerable<CatalogCard> Cards { get; set; } = null!;
        [JsonPropertyName("labels")]
        public IEnumerable<CatalogLabel> Labels { get; set; } = null!;
        [JsonPropertyName("lists")]
        public IEnumerable<CatalogList> Lists { get; set; } = null!;
    }

    public class CatalogCard
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [JsonPropertyName("idList")]
        public string ListId { get; set; }
        [JsonPropertyName("idLabels")]
        public IEnumerable<string> LabelIds { get; set; }
        [JsonPropertyName("closed")]
        public bool Closed { get; set; }
        [JsonPropertyName("desc")]
        public string? Description { get; set; }
        [JsonPropertyName("attachments")]
        public IEnumerable<CatalogCardAttachment> Attachments { get; set; }
    }

    public class CatalogLabel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [JsonPropertyName("color")]
        public string Color { get; set; } = null!;
    }

    public class CatalogList
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

    }

    public class CatalogCardAttachment
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
