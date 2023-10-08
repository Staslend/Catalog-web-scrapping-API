using PriceAPI.Services.LinksService;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PriceAPI.Models
{
    public class PageModel
    {
        [JsonPropertyName("shop")]
        public string shop { get; set; }
        [JsonPropertyName("link")]
        public string link { get; set; }
        [JsonPropertyName("pages")]
        public int pages { get; set; }
    }
}
