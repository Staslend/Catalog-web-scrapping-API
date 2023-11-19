using Python.Runtime;

namespace PriceAPI.Services.PythonProcessor
{
    public class PythonProcessor
    {
        string currentShop { get; set; } = string.Empty;
        string productName { get; set; } = string.Empty;
        double price { get; set; }

        public PythonProcessor()
        {
            Runtime.PythonDLL = Environment.GetEnvironmentVariable("PythonDLLPath");

            PythonEngine.Initialize();
        }

        public void Process(List<string> scrappedData)
        {
            using (Py.GIL())
            {
                using (PyModule scope = Py.CreateScope())
                {
                    PyObject pyProductName = productName.ToPython();
                    PyObject pyPrice = price.ToPython();

                    scope.Set("productName", pyProductName);
                    scope.Set("price", pyPrice);

                    //var script = Py.Import(currentShop);
                    //pyProductName = script.InvokeMethod("getProductName", scrappedData.ToPython());
                    //pyPrice = script.InvokeMethod("getProductPrice", scrappedData.ToPython());
                    string code = "productName = 'Test product name from Python'";
                    scope.Exec(code);
                    code = "price = '228'";
                    scope.Exec(code);

                }
            }

        }

    }
}
