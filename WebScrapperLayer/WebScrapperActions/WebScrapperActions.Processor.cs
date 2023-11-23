using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapperLayer.WebScrapperActions
{

    public partial class WebScrapperActions : IWebScrapperActions
    {


        protected ActionType GetActionType(ActionName actionName)
        {
            switch (actionName)
            {
                case ActionName.Cut: case ActionName.CutLeft: case ActionName.CutRight:
                    return ActionType.Editing;
                case ActionName.Merge:
                    return ActionType.Merging;
                case ActionName.ConvertToNumeric:
                    return ActionType.Converting;
            }

            //TODO: Error handler
            return ActionType.Converting;
        }

        protected void ActionRunnder(ref List<ProductTextDataModel> productTextData, ref List<ProductNumericDataModel> productNumericData, ActionModel action)
        {
            switch (action.actionName)
            {
                case ActionName.Cut:
                    {
                        CutAction(ref productTextData, action);
                        break;
                    }
                case ActionName.Merge:
                    {
                        MergeAction(ref productTextData, action);
                        break;
                    }
                case ActionName.ConvertToNumeric:
                    {
                        ConvertAction(ref productTextData, ref productNumericData, action);
                        break;
                    }
            }           
        }

        protected List<ProductNumericDataModel> ProcessActions(ref List<ProductTextDataModel> productRawData, List<ActionModel> actions)
        {
            List<ProductNumericDataModel> numericProductData = new List<ProductNumericDataModel>();

            foreach(ActionModel action in actions.Where(x => GetActionType(x.actionName) == ActionType.Editing).ToList())
            {
                ActionRunnder(ref productRawData, ref numericProductData, action);
            }
            foreach (ActionModel action in actions.Where(x => GetActionType(x.actionName) == ActionType.Merging).ToList())
            {
                ActionRunnder(ref productRawData, ref numericProductData, action);

            }
            foreach (ActionModel action in actions.Where(x => GetActionType(x.actionName) == ActionType.Converting).ToList())
            {
                ActionRunnder(ref productRawData, ref numericProductData, action);
            }

            return numericProductData;
        }

        public List<ProductModel> ProcessProductData(List<ProductModel> rawProducts, List<ActionModel> actions)
        {
            foreach (var rawProduct in rawProducts)
            {
                rawProduct.productNumericData = ProcessActions(ref rawProduct.productTextData, actions);
            }
            return rawProducts;
        }


    }
}
