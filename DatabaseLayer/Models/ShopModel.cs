using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer.Models
{
    public class ShopModel
    {
        
        [Key]
        public int shop_id { get; set; }
            
        //Shop data
        public string shop_name { get; set; } = string.Empty;

        [Required]
        public string shop_domain_name { get; set; } = string.Empty;


        //Reference to general actions and xPaths
        public List<ActionModel>? actions { get; set; }

        public List<XPathModel>? xPaths { get; set; }

        public string pageProperty { get; set; } = "?page=";

    }
}
