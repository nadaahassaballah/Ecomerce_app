using ecommerce.app.Authentication;
using ecommerce.app.common;
using ecommerce.app.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ecommerce.app.Services
{
    public class AuthentacationService : IAuthentacationServices
    {
        private readonly IIDentityService _identityService;


public AuthentacationService(IIDentityService identityService)
        {
            _identityService = identityService;
        }


public async Task<Result<UserDTO>> LoginAsync(LoginDTO loginDto, CancellationToken ct = default)
        {
            var userResult = await _identityService.FindEmailAsync(loginDto.Email, ct);
            if (!userResult.IsSuccess)
                return Result<UserDTO>.Fail(userResult.Errors);

            var passwordResult = await _identityService.CheckPasswordAsync(loginDto.Email, loginDto.Password, ct);
            if (!passwordResult.IsSuccess)
                return Result<UserDTO>.Fail(error.Unauthorized("Invalid Email Or Password"));

            return new  UserDTO
            {
                Email = userResult.data.email,
                DisplayName = userResult.data.DisplayName,
                Token = "Token"
            };
        }


        public async Task<Result<UserDTO>> RsgisterAsync(RegisterDTO registerDTO, CancellationToken ct = default)
        {
            var result = await _identityService.CreatUserAsync(registerDTO, ct);
            if (!result.IsSuccess || result.data is null)
            {
                return Result<UserDTO>.Fail(result.Errors);
            }

            return new UserDTO
            {
                Email = result.data.email,
                DisplayName = result.data.DisplayName,
                Token = "Token"
            };
        }
    }
}
