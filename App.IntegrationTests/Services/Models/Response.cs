using System.Text.Json.Serialization;

namespace App.IntegrationTests.Services.Models
{
	public class Response
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("Start")]
        public int start { get; set; }

        [JsonPropertyName("items")]
        public List<Item>? Items { get; set; }
    }

    public class Item
    {
        public string? ID { get; set; }

        public Content? Content { get; set; }
    }

    public class Headers
    {
        public List<string>? Subject { get; set; }
    }

    public class Content
    {
        public Headers? Headers { get; set; }
        public string? Body { get; set; }
        public int Size { get; set; }
        public object? MIME { get; set; }
    }
}

