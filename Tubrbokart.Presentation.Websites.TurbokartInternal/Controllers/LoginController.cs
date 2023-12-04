using Microsoft.AspNetCore.Mvc;
using Tubrbokart.Presentation.Websites.TurbokartInternal.Models.Viewmodels;

namespace Tubrbokart.Presentation.Websites.TurbokartInternal.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {

            return View();
        }
    }
}
