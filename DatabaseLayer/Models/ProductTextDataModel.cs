using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class ProductTextDataModel
    {
        public int productDataId { get; set; }
        public string productPropertyName { get; set; } = string.Empty;
        public string propertyValue { get; set; } = string.Empty;
    }
}
