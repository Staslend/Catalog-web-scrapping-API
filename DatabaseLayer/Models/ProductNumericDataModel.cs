using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class ProductNumericDataModel
    {
        public int product_id { get; set; }
        public ProductModel product { get; set; }

        [Key]
        public int product_data_id { get; set; }
        public string product_property_name { get; set; } = string.Empty;
        public double property_value { get; set; }
    }
}
