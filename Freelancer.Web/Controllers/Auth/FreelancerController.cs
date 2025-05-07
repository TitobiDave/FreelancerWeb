using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Freelancer.Web.Controllers.Auth
{
    [Authorize]
    public class FreelancerController : BaseController
    {
        public IActionResult SkillRating()
        {

            return View();
        }
    }
}
