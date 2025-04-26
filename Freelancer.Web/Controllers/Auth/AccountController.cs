using Freelancer.Data.Models.Auth;
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

        [HttpGet("account/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("account/registerfreelancer")]
        public IActionResult Register([FromForm] RegisterDto<FreelancerUser> registerDto)
        {
            return View();
        }

        [HttpPost("account/registerhirer")]
        public IActionResult Register([FromForm] RegisterDto<Hirer> registerDto)
        {
            return View();
        }
    }
}
