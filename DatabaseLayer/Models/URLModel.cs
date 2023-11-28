using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class URLModel
    {
        [Key]
        public int url_id { get; set; }
        public string url { get; set; }

        public string url_name { get; set; } = string.Empty;

        //Reference to URL specific actions and xPaths
        public List<ActionModel>? actions { get; set; }

        public List<XPathModel>? xPaths { get; set; }
    }
}
