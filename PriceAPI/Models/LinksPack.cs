using System.Text.Json.Serialization;

namespace PriceAPI.Models
{
    public class LinksPack
    {
        [JsonPropertyName("pages")]
        public List<PageModel> pages { get; set; }
    }
}
