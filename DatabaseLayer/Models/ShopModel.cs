using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer.Models
{
    public class ShopModel
    {
        [Key]
        public string shopName { get; set; } = "Default shop";

        [Required]
        public string shopDomainName { get; set; } = "google.com";


        public int actionId { get; set; }
        public ActionModel? action { get; set; }

    }
}
