using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer.Models
{
    public class ProductModel
    {
        [Key]
        public int id { get; set; }

        //Reference to data relations
        public List<ProductNumericDataModel>? productNumericData;
        public List<ProductTextDataModel>? productTextData;

        //Shop reference
        public string? shopId { get; set; }
        public ShopModel? shop { get; set; }
    }
}
