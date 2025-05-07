using System.Text.Json.Serialization;

namespace SupabaseMockData.Models
{
    public class Item
    {
        [JsonPropertyName("item_id")]
        public string ItemId { get; set; }
        [JsonPropertyName("item_name")]
        public string ItemName { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("alert_level")]
        public int AlertLevel { get; set; }

        [JsonPropertyName("organization_name")]
        public string OrganizationName { get; set; }

        [JsonPropertyName("database_id")]
        public string DatabaseId { get; set; }
        [JsonPropertyName("database_name")]
        public string Databasename { get; set; }
    }
}
