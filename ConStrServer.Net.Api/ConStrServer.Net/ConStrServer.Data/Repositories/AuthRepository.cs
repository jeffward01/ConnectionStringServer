using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using ConStrServer.Data.Infrastructure;
using ConStrServer.Models.Dto;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ConStrServer.Data.Repositories
{

    public class AuthRepository : IAuthRepository
    {
        private readonly ConStrContext _conStrContext;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _conStrContext = new ConStrContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_conStrContext));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser();
            user.UserName = userModel.UserName;

            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _conStrContext.Dispose();
            _userManager.Dispose();
        }
    }
}
