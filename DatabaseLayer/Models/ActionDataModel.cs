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
        public int action_id { get; set; }
        public ActionModel action { get; set; }


        [Key]
        public int action_data_id { get; set; }

        public string action_data { get; set; } = string.Empty;
    }
}
