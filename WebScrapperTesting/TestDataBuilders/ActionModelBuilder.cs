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
        string productPropertyName = "productPropertyName";
        string actionData1 = "actionData1";
        string actionData2 = "actionData2";

        public ActionModelBuilder() { }

        public ActionModelBuilder WithAction(ActionName actionName, string productPropertyName, string actionData1, string actionData2)
        {
            this.actionName = actionName;
            this.productPropertyName = productPropertyName;
            this.actionData1 = actionData1;
            this.actionData2 = actionData2;
            return this;
        }

        public ActionModelBuilder WithActionName(ActionName actionName)
        {
            this.actionName = actionName;
            return this;
        }
        public ActionModelBuilder WithProductPropertyName(string productPropertyName)
        {
            this.productPropertyName = productPropertyName;
            return this;
        }
        public ActionModelBuilder WithActionData1(string actionData)
        {
            this.actionData1 = actionData;
            return this;
        }
        public ActionModelBuilder WithActionData2(string actionData)
        {
            this.actionData2 = actionData;
            return this;
        }

        public ActionModel Build()
        {
            return new ActionModel
            {
                actionId = 0,
                actionName = this.actionName,
                productPropertyName = this.productPropertyName,
                actionData1 = this.actionData1,
                actionData2 = this.actionData2
            };
        }
    }
}
