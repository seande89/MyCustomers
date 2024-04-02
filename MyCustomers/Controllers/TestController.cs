using Microsoft.AspNetCore.Mvc;

namespace MyCustomers.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
