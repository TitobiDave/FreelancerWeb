using Freelancer.Data;
using Freelancer.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;


namespace Freelancer.Web.Controllers
{
    public class BaseController : Controller
    {


        public  void Response(ResponseModel response)
        {
            switch (response.ErrorCodes)
            {
                case ErrorCodes.Successful:

                    TempData["Result"] = JsonConvert.SerializeObject(new
                    {
                        title = "",
                        message = response.Message,
                        success = response.isSuccessful,
                        error = "success"
                    });
                    break;

                case ErrorCodes.Failed:
                    TempData["Result"] = JsonConvert.SerializeObject(new
                    {
                        title = "Ooops...",
                        message = response.Message,
                        success = response.isSuccessful,
                        error = "error"
                    });
                    break;

                case ErrorCodes.Created:
                    TempData["Result"] = JsonConvert.SerializeObject(new
                    {
                        title = "Success",
                        message = response.Message,
                        success = response.isSuccessful,
                        error = "success"
                    });
                    break;
                default:
                    TempData["Result"] = JsonConvert.SerializeObject(new
                    {
                        title = "Ooops...",
                        message = response.Message,
                        success = response.isSuccessful,
                        error = "error"
                    });
                    break;
            }
        }


    }


  
}
