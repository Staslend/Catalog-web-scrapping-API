using System.ComponentModel.DataAnnotations;

namespace PriceAPI.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "Def";
        public double Price { get; set; } = 1;
    }
}
