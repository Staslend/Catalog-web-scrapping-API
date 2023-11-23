using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class ActionDataModel
    {
        public int actionDataId { get; set; }
        public int actionId { get; set; }
        public ActionModel action { get; set; }

        public string actionData { get; set; } = string.Empty;
    }
}
