using System.ComponentModel.DataAnnotations;

namespace PriceAPI.Models
{
    public class ProductModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string productName { get; set; } = "Def";


        [Required]
        public double productPrice { get; set; } = 1.0;
        public double newProductPrice { get; set; }

        //Shop reference
        public string? shopId { get; set; }
        public ShopModel? shop { get; set; }
    }
}
