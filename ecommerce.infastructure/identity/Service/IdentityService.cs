using ecommerce.app.Authentication;
using ecommerce.app.common;
using ecommerce.app.contracts;
using ecommerce.infastructure.identity.entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Result<bool>> EmailExistingAsync(string email, CancellationToken ct = default)
       => await _userManager.FindByEmailAsync(email) is not null;

        public async Task<Result<IdentityUserResult>> FindEmailAsync(string email, CancellationToken ct = default)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                return Result<IdentityUserResult>.Fail(error.NotFound("user not found"));
            }
            else return new IdentityUserResult(user.Id, user.Email, user.UserName, user.DisplayName);
        }

        public async Task<Result<AdderssDto>> GetAddressbyEmailAsync(string email, CancellationToken ct = default)
        {
            var user = await _userManager.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Email == email, ct);

            if (user is null) return Result<AdderssDto>.Fail(error.NotFound("usernot found"));
            if (user?.Address == null) return Result<AdderssDto>.Fail(error.NotFound("address not found"));
            return new AdderssDto
            {
                FirstName = user.Address.firstname,


                LastName = user.Address.lastname,
                City = user.Address.city,
                Street = user.Address.street,
                Country = user.Address.country,

            };
        }

        public async Task<Result<IReadOnlyList<string>>> getRoleAsync(string email, CancellationToken ct = default)
        {
var user=await _userManager.FindByEmailAsync(email); 
            if (user is null) return Result<IReadOnlyList<string>>.Fail(error.NotFound("usernot found"));
var roles=await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }

        public async Task<Result<AdderssDto>> updateAddressbyEmailAsync(string email, AdderssDto adderssDto, CancellationToken ct = default)
        {
            var user = await _userManager.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Email == email, ct);

            if (user is null) return Result<AdderssDto>.Fail(error.NotFound("usernot found"));
            if (user.Address  is null) 
user.Address=new Address{

    firstname = user.Address.firstname,


                lastname = user.Address.lastname,
                city = user.Address.city,
                street = user.Address.street,
                country = user.Address.country,

            };
            else
            {
                user.Address.firstname= adderssDto.FirstName
                   ;
                user.Address.lastname = adderssDto.LastName;
                user.Address.city = adderssDto.City;
                user.Address.country = adderssDto.Country;
                user.Address.street = adderssDto.Street;




            }
            var result =await _userManager.UpdateAsync(user);
            if (!result.Succeeded) return Result<AdderssDto>.Fail(error.Failure("falure", string.Join(";", result.Errors.Select(e => e.Description))));
            return adderssDto; }
    }
}
