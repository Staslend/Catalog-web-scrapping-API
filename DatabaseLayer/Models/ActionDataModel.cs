using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class ActionDataModel
    {
        //Reference to the action
        public int actionId { get; set; }
        public ActionModel action { get; set; }


        [Key]
        public int actionDataId { get; set; }

        public string actionData { get; set; } = string.Empty;
    }
}
