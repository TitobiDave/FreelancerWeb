using Freelancer.Data;
using Freelancer.Data.Models;
using Freelancer.Data.Models.Auth;
using Freelancer.Infrastructure;
using Freelancer.Services.Services.Auth.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Freelancer.Web.Controllers.Auth
{
    public class AccountController : BaseController
    {
        private readonly UserManager<Fuser> _freelancerManager;
        private readonly SignInManager<Fuser> _signInManager;
        private readonly FreelancerDbContext _dbcontext;
        private readonly ICreateUser _createUser;

        public AccountController(UserManager<Fuser> freelancerManager, SignInManager<Fuser> signInManager, FreelancerDbContext dbcontext, ICreateUser createUser)
        {
            _freelancerManager = freelancerManager;
            _signInManager = signInManager;
            _dbcontext = dbcontext;
            _createUser = createUser;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null )
        {
            if (User.Identity.IsAuthenticated)
            {
                if(returnUrl == null)
                {
                    return Redirect("/home");
                }
                return Redirect(returnUrl);
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto userModel, string? returnUrl = null)
        {
            var user = await _createUser.LoginNewUser(userModel);
            if (user.isSuccessful)
            {
                var result = await _signInManager.PasswordSignInAsync((Fuser)user.data, userModel.password, true, false);
                if (result.Succeeded)
                {
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return Redirect("/home");

                }
                else{
                    Response(new ResponseModel
                    {
                        Message = "Invalid Username or Password",
                        isSuccessful = false,
                        ErrorCodes = ErrorCodes.Failed
                    });
                    return View();
                }
            }
            Response(user);
            return View();
        }

        [HttpGet("account/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("account/registerfreelancer")]
        public async Task<IActionResult> Register([FromForm] RegisterDto<Fuser> registerDto)
        {
            var result = await _createUser.CreateNewUser(registerDto);
            Response(result);
            return View();
        }

        [HttpPost("account/registerhirer")]
        public IActionResult Register([FromForm] RegisterDto<Hirer> registerDto)
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            _signInManager.SignOutAsync();
            return Redirect("/home");
        }
    }
}
