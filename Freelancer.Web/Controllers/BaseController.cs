using Microsoft.AspNetCore.Mvc;

namespace Freelancer.Web.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
