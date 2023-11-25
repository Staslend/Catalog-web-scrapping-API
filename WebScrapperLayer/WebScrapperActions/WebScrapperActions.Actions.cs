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
            if (!int.TryParse(action.action_data.ElementAt(1).action_data, out param1)) param1 = 0;
            if (!int.TryParse(action.action_data.ElementAt(2).action_data, out param2)) param2 = 0;

            try
            {
                ProductTextDataModel textData = productData.Single(x => x.product_property_name == action.action_data.ElementAt(0).action_data);

                string productPropertyData = textData.property_value;
                productPropertyData = productPropertyData.Substring(param1, textData.property_value.Length - (param2 + param1));
                textData.property_value = productPropertyData;
            }
            catch (NullReferenceException  ex)
            {
            }
        }

        protected void MergeAction(ref List<ProductTextDataModel> productData, ActionModel action)
        {
            productData.Add(new ProductTextDataModel
            {
                product_property_name = action.action_data.ElementAt(0).action_data,
                property_value = productData.Find(x => x.product_property_name == action.action_data.ElementAt(1).action_data).property_value + 
                                productData.Find(x => x.product_property_name == action.action_data.ElementAt(2).action_data).property_value
            });
            productData.RemoveAll(x => x.product_property_name == action.action_data.ElementAt(1).action_data);
            productData.RemoveAll(x => x.product_property_name == action.action_data.ElementAt(2).action_data);

        }

        protected void ConvertToNumericAction(ref List<ProductTextDataModel> productTextData, ref List<ProductNumericDataModel> productNumericData, ActionModel action)
        {
            productNumericData.Add(new ProductNumericDataModel
            {
                product_property_name = action.action_data.ElementAt(0).action_data,
                property_value = double.Parse(productTextData.Single(x => x.product_property_name == action.action_data.ElementAt(0).action_data).property_value)
            }) ;
        }
    }
}
