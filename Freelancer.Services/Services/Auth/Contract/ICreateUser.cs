using Freelancer.Data.Models;
using Freelancer.Data.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancer.Services.Services.Auth.Contract
{
    public interface ICreateUser
    {
        public Task<ResponseModel> CreateNewUser(RegisterDto<Fuser> user);
    }
}
