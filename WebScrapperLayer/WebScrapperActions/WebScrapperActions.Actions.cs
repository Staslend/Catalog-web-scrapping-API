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
        private void CutAction(ref List<ProductTextDataModel> productData, ActionModel action)
        {
            int param1 = int.Parse(action.actionData1);
            int param2 = int.Parse(action.actionData2);

            string productPropertyData =  productData.Find(x => x.productPropertyName == action.productPropertyName).propertyValue;

            productPropertyData = productPropertyData.Substring(param1, param2 - param1);
        }

        private void MergeAction(ref List<ProductTextDataModel> productData, ActionModel action)
        {
            productData.Add(new ProductTextDataModel
            {
                productPropertyName = action.productPropertyName,
                propertyValue = productData.Find(x => x.productPropertyName == action.actionData1).propertyValue + 
                                productData.Find(x => x.productPropertyName == action.actionData2).propertyValue
            });
            productData.RemoveAll(x => x.productPropertyName == action.actionData1);
            productData.RemoveAll(x => x.productPropertyName == action.actionData2);

        }

        private void ConvertAction(ref List<ProductTextDataModel> productTextData, ref List<ProductNumericDataModel> productNumericData, ActionModel action)
        {
            productNumericData.Add(new ProductNumericDataModel
            {
                productPropertyName = action.productPropertyName,
                propertyValue = double.Parse(productTextData.Find(x => x.productPropertyName == action.actionData1).propertyValue)
            }) ;
        }
    }
}
