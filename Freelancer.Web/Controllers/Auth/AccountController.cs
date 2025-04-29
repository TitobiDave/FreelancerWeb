using Freelancer.Data.Models.Auth;
using Freelancer.Infrastructure;
using Freelancer.Services.Services.Auth.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Freelancer.Web.Controllers.Auth
{
    public class AccountController : BaseController
    {
        private readonly UserManager<Fuser> _freelancerManager;
        private readonly SignInManager<Fuser> _signInManagerHirer;
        private readonly FreelancerDbContext _dbcontext;
        private readonly ICreateUser _createUser;

        public AccountController(UserManager<Fuser> freelancerManager, SignInManager<Fuser> signInManagerHirer, FreelancerDbContext dbcontext, ICreateUser createUser)
        {
            _freelancerManager = freelancerManager;
            _signInManagerHirer = signInManagerHirer;
            _dbcontext = dbcontext;
            _createUser = createUser;
        }

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
    }
}
