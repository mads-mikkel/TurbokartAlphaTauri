using Microsoft.AspNetCore.Mvc;
using Tubrbokart.Presentation.Websites.TurbokartInternal.Models.Viewmodels;
using Turbokart.Application.Interfaces;

namespace Tubrbokart.Presentation.Websites.TurbokartInternal.Controllers
{
    public class LoginController : Controller
    {
        public LoginController(
            IUserUseCase userUseCase)
        {
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}
