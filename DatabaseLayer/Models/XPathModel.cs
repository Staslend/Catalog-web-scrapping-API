using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer.Models
{
    public class XPathModel
    {

        [Key]
        public int xpath_id { get; set; }
        public string xpath { get; set; } = String.Empty;
        [Required]
        public string property_name { get; set; } = String.Empty;
        public string atribute { get; set; } = String.Empty;
    }
}
