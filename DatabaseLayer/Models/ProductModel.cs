using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DatabaseLayer.Models
{
    public class ProductComparer : IEqualityComparer<ProductModel>
    {
        public bool Equals(ProductModel p1, ProductModel p2)
        {
            if (p1 == null || p2 == null) return false;

            if(p1.product_text_data is not null && p2.product_text_data is not null)
            {
                if (p1.product_text_data is null || p2.product_text_data is null) return false;
                if (p1.product_text_data.Count == p2.product_text_data.Count)
                {
                    for (int i = 0; i < p1.product_text_data.Count; i++)
                    {
                        if (p1.product_text_data[i].product_property_name != p2.product_text_data[i].product_property_name ||
                            p1.product_text_data[i].property_value != p2.product_text_data[i].property_value) return false;
                    }
                }
                else return false;
            }
            if (p1.product_numeric_data is not null && p2.product_numeric_data is not null)
            {
                if (p1.product_numeric_data is null || p2.product_numeric_data is null) return false;
                if (p1.product_numeric_data.Count == p2.product_numeric_data.Count)
                {
                    for (int i = 0; i < p1.product_numeric_data.Count; i++)
                    {
                        if (p1.product_numeric_data[i].product_property_name != p2.product_numeric_data[i].product_property_name ||
                            p1.product_numeric_data[i].property_value != p2.product_numeric_data[i].property_value) return false;
                    }
                }
                else return false;
            }

            if (p1.shop_id != p2.shop_id) return false;

            return true;
        }

        public int GetHashCode([DisallowNull] ProductModel obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ProductModel
    {
        [Key]
        public int product_id { get; set; }

        //Reference to data relations
        public List<ProductNumericDataModel>? product_numeric_data { get; set; }
        public List<ProductTextDataModel>? product_text_data { get; set; }

        //Shop reference
        public string? shop_id { get; set; }
        public ShopModel? shop { get; set; }
    }
}
