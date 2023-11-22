using Microsoft.AspNetCore.Mvc;

namespace PriceAPI.Controllers
{
    public class ShopsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
