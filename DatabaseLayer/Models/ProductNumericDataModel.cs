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
        public int productId { get; set; }
        public ProductModel product { get; set; }

        [Key]
        public int productDataId { get; set; }
        public string productPropertyName { get; set; } = string.Empty;
        public double propertyValue { get; set; }
    }
}
