using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer.Models
{
    public class ShopModel
    {
        
        [Key]
        public int shopId { get; set; }
            
        //Shop data
        [Required]
        public string shopName { get; set; } = string.Empty;

        [Required]
        public string shopDomainName { get; set; } = string.Empty;


        //Reference to general actions and xPaths
        public List<ActionModel>? actions { get; set; }

        public List<XPathModel>? xPaths { get; set; }


    }
}
