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
        private readonly ITokenService _tokenService;


        public AuthentacationService(IIDentityService identityService , ITokenService tokenService)
        {
            _identityService = identityService;
            _tokenService = tokenService;

        }

        public async Task<Result<bool>> CheckEmailAsync(string email, CancellationToken ct = default)
          => await _identityService.EmailExistingAsync(email, ct);
        public async Task<Result<UserDTO>> GetCurrentUserAsync(string email, CancellationToken ct = default)
        {
            var result = await _identityService.FindEmailAsync(email, ct);
            if (!result.IsSuccess)
                return Result<UserDTO>.Fail(result.Errors);

            var user = result.data;

            var rolesResult = await _identityService.getRoleAsync(email, ct);
            if (!rolesResult.IsSuccess)
                return Result<UserDTO>.Fail(rolesResult.Errors);

            var roles = rolesResult.data;

            var generatedToken = _tokenService.creatToken(user.id, user.email, user.username, roles);

            return new UserDTO
            {
                DisplayName = user.DisplayName,
                Email = user.email,
                Token = generatedToken
            };
        }

        public async Task<Result<AdderssDto>> GetUserAddressAsync(string email, CancellationToken ct = default)
        {
            var result = await _identityService.GetAddressbyEmailAsync(email, ct);
            if (!result.IsSuccess)
                return Result<AdderssDto>.Fail(result.Errors);
            return Result<AdderssDto>.OK(result.data);
        }

        public async Task<Result<UserDTO>> LoginAsync(LoginDTO loginDto, CancellationToken ct = default)
        {
            var userResult = await _identityService.FindEmailAsync(loginDto.Email, ct);
            if (!userResult.IsSuccess)
                return Result<UserDTO>.Fail(userResult.Errors);

            var passwordResult = await _identityService.CheckPasswordAsync(loginDto.Email, loginDto.Password, ct);
            if (!passwordResult.IsSuccess)
                return Result<UserDTO>.Fail(error.Unauthorized("Invalid Email Or Password"));

            var rolesResult = await _identityService.getRoleAsync(loginDto.Email, ct);
            if (!rolesResult.IsSuccess)
                return Result<UserDTO>.Fail(rolesResult.Errors);

            var roles = rolesResult.data;
            var user = userResult.data;
            var generatedToken = _tokenService.creatToken(user.id, user.email, user.username, roles);

            return new UserDTO
            {
                DisplayName = user.DisplayName,
                Email = user.email,
                Token = generatedToken
            };
        }


        public async Task<Result<UserDTO>> RsgisterAsync(RegisterDTO registerDTO, CancellationToken ct = default)
        {
            var result = await _identityService.CreatUserAsync(registerDTO, ct);

            if (!result.IsSuccess || result.data is null)
                return Result<UserDTO>.Fail(result.Errors);

            var user = result.data;

            var rolesResult = await _identityService.getRoleAsync(user.email, ct);

            if (!rolesResult.IsSuccess)
                return Result<UserDTO>.Fail(rolesResult.Errors);

            var token = _tokenService.creatToken(
                user.id,
                user.email,
                user.username,
                rolesResult.data);

            return new UserDTO
            {
                DisplayName = user.DisplayName,
                Email = user.email,
                Token = token
            };
        }

        public async Task<Result<AdderssDto>> UpdateUserAddressAsync(AdderssDto addressDto, string email, CancellationToken ct = default)
      =>await _identityService.updateAddressbyEmailAsync(email,addressDto,ct);
    }
}
