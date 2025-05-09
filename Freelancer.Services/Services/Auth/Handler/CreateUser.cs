using Freelancer.Data;
using Freelancer.Data.Models;
using Freelancer.Data.Models.Auth;
using Freelancer.Infrastructure;
using Freelancer.Services.Services.Auth.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancer.Services.Services.Auth.Handler
{
    public class CreateUser : ICreateUser
    {
        private readonly UserManager<Fuser> _userManager;
        private readonly FreelancerDbContext _dbcontext;


        public CreateUser(UserManager<Fuser> freelancerManager, FreelancerDbContext dbcontext)
        {
            _userManager = freelancerManager;
            _dbcontext = dbcontext;
        }
        public async Task<ResponseModel> CreateNewUser(RegisterDto<Fuser> user)
        {
            try
            {
                var checkUser =  _userManager.Users.Where(x => x.Email == user.Email);
                if (checkUser.Any())
                {
                    return new ResponseModel
                    {
                        ErrorCodes = ErrorCodes.Failed,
                        isSuccessful = false,
                        Message = "User Already Exists"
                    };
                }

                var resultuser = new Fuser
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    FreelancerUser = user.User.FreelancerUser,
                };

                _dbcontext.fuser.Add(resultuser);
                var result = await _userManager.CreateAsync(resultuser, user.Password);
                if (!result.Succeeded)
                {
                    return new ResponseModel
                    {
                        ErrorCodes = ErrorCodes.Failed,
                        isSuccessful = false,
                        Message = "An error occured"
                    };
                }
                await _dbcontext.SaveChangesAsync();
                return new ResponseModel
                {
                    ErrorCodes = ErrorCodes.Created,
                    isSuccessful = result.Succeeded,
                    Message = "User Created Successfully"
                };
            } 
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    ErrorCodes = ErrorCodes.Failed,
                    isSuccessful = false,
                    Message = ex.InnerException.Message
                };
            }
            

        }

        public async Task<ResponseModel> LoginNewUser(LoginDto userModel)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userModel.username);
                if (user == null)
                {
                    return new ResponseModel
                    {
                        ErrorCodes = ErrorCodes.NotFound,
                        isSuccessful = false,
                        Message = "User name or password is Incorrect"

                    };
                }
                return new ResponseModel
                {
                    ErrorCodes = ErrorCodes.Successful,
                    isSuccessful = true,
                    Message = "Login Successful",
                    data = (Fuser)user,
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    ErrorCodes = ErrorCodes.Failed,
                    isSuccessful = false,
                    Message = ex.InnerException.Message

                };
            }
           
        }
    }
}
