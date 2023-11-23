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
            if (!int.TryParse(action.actionData1, out param1)) param1 = 0;
            if (!int.TryParse(action.actionData2, out param2)) param2 = 0;

            try
            {
                ProductTextDataModel textData = productData.Single(x => x.productPropertyName == action.productPropertyName);

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
                productPropertyName = action.productPropertyName,
                propertyValue = productData.Find(x => x.productPropertyName == action.actionData1).propertyValue + 
                                productData.Find(x => x.productPropertyName == action.actionData2).propertyValue
            });
            productData.RemoveAll(x => x.productPropertyName == action.actionData1);
            productData.RemoveAll(x => x.productPropertyName == action.actionData2);

        }

        protected void ConvertAction(ref List<ProductTextDataModel> productTextData, ref List<ProductNumericDataModel> productNumericData, ActionModel action)
        {
            productNumericData.Add(new ProductNumericDataModel
            {
                productPropertyName = action.productPropertyName,
                propertyValue = double.Parse(productTextData.Single(x => x.productPropertyName == action.productPropertyName).propertyValue)
            }) ;
        }
    }
}
