using Microsoft.AspNetCore.Mvc;
using Tubrbokart.Presentation.Websites.TurbokartInternal.Models.Viewmodels;
using Turbokart.Application.Interfaces;
using Turbokart.Domain.Entities;

namespace Tubrbokart.Presentation.Websites.TurbokartInternal.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserUseCase userUseCase;

        public LoginController(
            IUserUseCase userUseCase)
        {
            this.userUseCase = userUseCase;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel model)
        {
            if (ModelState.IsValid && await userUseCase.IsUserInSystem(model.Username, model.Password))
            {
                Response.Cookies.Append("Username", model.Username, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(1) // Cookie expiration time
                });

                return RedirectToAction("Index", "Home");
            }
            model.ErrorMessage = "Invalid Credentials!!";
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("Username");
            return RedirectToAction("Index", "Login");
        }
    }
}
