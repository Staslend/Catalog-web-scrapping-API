using System.ComponentModel.DataAnnotations;

namespace PriceAPI.Models
{
    public class XPathModel
    {
        [Required]
        public string shopId { get; set; } = String.Empty;
        [Required]
        public ShopModel shop { get; set; } = null!;

        [Key]  
        public string xPath { get; set; } = String.Empty;
        [Required]
        public string dataType { get; set; } = String.Empty;

        public int actionId { get; set; }
        public ActionModel? action { get; set; }
    }
}
