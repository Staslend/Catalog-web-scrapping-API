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
        bool errorOccured = false;

        protected ActionType GetActionType(ActionName actionName)
        {
            switch (actionName)
            {
                case ActionName.Cut:
                    return ActionType.Editing;
                case ActionName.Merge:
                    return ActionType.Merging;
                case ActionName.ConvertToNumeric:
                    return ActionType.Converting;
            }

            //TODO: Error handler
            return ActionType.Converting;
        }

        //Мне это кажется слишком упоротым, но ничего лучше я найти не могу. 
        //Все решения которые появлялись в голове либо не полные, либо ещё более топорные
        protected void ActionRunnder(ref List<ProductTextDataModel> productTextData, ref List<ProductNumericDataModel> productNumericData, ActionModel action)
        {
            try
            {
                switch (action.action_name)
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
                            ConvertToNumericAction(ref productTextData, ref productNumericData, action);
                            break;
                        }
                }

            }
            catch
            {
                errorOccured = true;
                return;
            }
        }

        protected List<ProductNumericDataModel> ProcessActions(ref List<ProductTextDataModel> productRawData, List<ActionModel> actions)
        {
            List<ProductNumericDataModel> numericProductData = new List<ProductNumericDataModel>();

            foreach(ActionModel action in actions.Where(x => GetActionType(x.action_name) == ActionType.Editing).ToList())
            {
                ActionRunnder(ref productRawData, ref numericProductData, action);
            }
            foreach (ActionModel action in actions.Where(x => GetActionType(x.action_name) == ActionType.Merging).ToList())
            {
                ActionRunnder(ref productRawData, ref numericProductData, action);

            }
            foreach (ActionModel action in actions.Where(x => GetActionType(x.action_name) == ActionType.Converting).ToList())
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

                if(errorOccured) return new List<ProductModel>();
            }
            return rawProducts;
        }


    }
}
