using Microsoft.AspNetCore.Mvc;

namespace Freelancer.Web.Controllers.Auth
{
    public class AccountController : BaseController
    {

        [HttpGet]
        public IActionResult Login(string returnUrl )
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
