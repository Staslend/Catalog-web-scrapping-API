using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapperTesting.TestDataBuilders
{
    public class ActionModelBuilder
    {
        int actionId = 0;
        ActionName actionName;
        List<ActionDataModel> actionData = new();

        public ActionModelBuilder() { }

        public ActionModelBuilder WithAction(ActionName actionName, List<ActionDataModel> actionData)
        {
            this.actionName = actionName;
            this.actionData = actionData;

            return this;
        }

        public ActionModelBuilder WithActionName(ActionName actionName)
        {
            this.actionName = actionName;
            return this;
        }
        public ActionModelBuilder WithActionData(List<ActionDataModel> actionData)
        {
            this.actionData = actionData;
            return this;
        }

        public ActionModel Build()
        {
            return new ActionModel
            {
                action_id = 0,
                action_name = this.actionName,
                action_data  = this.actionData
            };
        }
    }
}
