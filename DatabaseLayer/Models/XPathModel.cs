using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer.Models
{
    public class XPathModel
    {

        [Key]
        public int xPathId { get; set; }
        public string xPath { get; set; } = String.Empty;
        [Required]
        public string propertyName { get; set; } = String.Empty;
        public string atribute { get; set; } = String.Empty;
    }
}
