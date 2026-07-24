using ecommerce.app.Authentication;
using ecommerce.app.common;
using ecommerce.app.contracts;
using ecommerce.infastructure.identity.entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infastructure.identity.Service
{
    public class IdentityService : IIDentityService
    {
        private readonly UserManager<APPUser> _userManager;

        public IdentityService(UserManager<APPUser>  userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result<bool>> CheckPasswordAsync(string email, string password, CancellationToken ct = default)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                return Result<bool>.Fail(error.NotFound("user not found"));
            }
            var isvalid = await _userManager.CheckPasswordAsync(user, password);
            return Result<bool>.OK(isvalid);
        }

        public async Task<Result<IdentityUserResult>> CreatUserAsync(RegisterDTO registerDTO, CancellationToken ct = default)
        {
            var user = new APPUser
            {
                Email = registerDTO.Email,
                UserName = registerDTO.UserName,
                PhoneNumber = registerDTO.PhoneNumber,
                DisplayName = registerDTO.DisplayName
            };
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                var rerrors = result.Errors
                    .Select(e => new error(e.Code, e.Description, errortype.failure))
                    .ToList();
                return Result<IdentityUserResult>.Fail(rerrors);
            }

            return Result<IdentityUserResult>.OK(new IdentityUserResult(user.Id, user.Email, user.UserName, user.DisplayName));
        
           
        }

        public async Task<Result<IdentityUserResult>> FindEmailAsync(string email, CancellationToken ct = default)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                return Result<IdentityUserResult>.Fail(error.NotFound("user not found"));
            }
            else return new IdentityUserResult(user.Id, user.Email, user.UserName, user.DisplayName);
        }
    }
}
