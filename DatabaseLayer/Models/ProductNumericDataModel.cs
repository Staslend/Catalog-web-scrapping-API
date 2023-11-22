using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class ProductNumericDataModel
    {
        public int productDataId { get; set; }
        public string productPropertyName { get; set; } = string.Empty;
        public double propertyValue { get; set; }
    }
}
