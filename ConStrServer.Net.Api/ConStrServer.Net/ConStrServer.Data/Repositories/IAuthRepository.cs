using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConStrServer.Models.Dto;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ConStrServer.Data.Repositories
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUser(UserModel userModel);
        Task<IdentityUser> FindUser(string userName, string password);
        void Dispose();
    }
}
