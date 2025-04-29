using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancer.Data.Models
{
    public class ResponseModel
    {
        public ErrorCodes ErrorCodes { get; set; }

        public string Message { get; set; }

        public bool isSuccessful { get; set; }
    }
}
