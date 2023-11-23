using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapperLayer.WebScrapperActions
{
    public partial class WebScrapperActions
    {
        protected void CutAction(ref List<ProductTextDataModel> productData, ActionModel action)
        {
            int param1, param2;
            if (!int.TryParse(action.actionData.ElementAt(1).actionData, out param1)) param1 = 0;
            if (!int.TryParse(action.actionData.ElementAt(2).actionData, out param2)) param2 = 0;

            try
            {
                ProductTextDataModel textData = productData.Single(x => x.productPropertyName == action.actionData.ElementAt(0).actionData);

                string productPropertyData = textData.propertyValue;
                productPropertyData = productPropertyData.Substring(param1, textData.propertyValue.Length - (param2 - param1));
                textData.propertyValue = productPropertyData;
            }
            catch (NullReferenceException  ex)
            {
            }
        }

        protected void MergeAction(ref List<ProductTextDataModel> productData, ActionModel action)
        {
            productData.Add(new ProductTextDataModel
            {
                productPropertyName = action.actionData.ElementAt(0).actionData,
                propertyValue = productData.Find(x => x.productPropertyName == action.actionData.ElementAt(1).actionData).propertyValue + 
                                productData.Find(x => x.productPropertyName == action.actionData.ElementAt(2).actionData).propertyValue
            });
            productData.RemoveAll(x => x.productPropertyName == action.actionData.ElementAt(1).actionData);
            productData.RemoveAll(x => x.productPropertyName == action.actionData.ElementAt(2).actionData);

        }

        protected void ConvertToNumericAction(ref List<ProductTextDataModel> productTextData, ref List<ProductNumericDataModel> productNumericData, ActionModel action)
        {
            productNumericData.Add(new ProductNumericDataModel
            {
                productPropertyName = action.actionData.ElementAt(0).actionData,
                propertyValue = double.Parse(productTextData.Single(x => x.productPropertyName == action.actionData.ElementAt(0).actionData).propertyValue)
            }) ;
        }
    }
}
