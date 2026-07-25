using ecommerce.app.Authentication;
using ecommerce.app.contracts;
using ecommerce.app.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.api.Controllers
{
  
    public class AuthentacitionContoller :APIbasecontoller

    {
        private readonly IAuthentacationServices authenticationService;

        public AuthentacitionContoller(IAuthentacationServices authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDTO>> LoginAsync(LoginDTO loginDto, CancellationToken ct)
        {
            var result = await authenticationService.LoginAsync(loginDto, ct);

            return ToActionResult(result);
        }
        [HttpPost("Register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto, CancellationToken ct)
    => ToActionResult(await authenticationService.RsgisterAsync(registerDto, ct));

        #region EmailExists
        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmail([FromQuery] string email, CancellationToken ct)
            => ToActionResult(await authenticationService.CheckEmailAsync(email, ct));
        #endregion
        #region Get Current User
        [Authorize]
        [HttpGet("currentuser")]
        public async Task<ActionResult<UserDTO>> GetCurrentUser(CancellationToken ct)
            => ToActionResult(await authenticationService.GetCurrentUserAsync(GetEmailFromToken(), ct));
        #endregion

        #region User Address
        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AdderssDto>> GetUserAddress(CancellationToken ct)
            => ToActionResult(await authenticationService.GetUserAddressAsync(GetEmailFromToken(), ct));
        #endregion
        #region Update Address
        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AdderssDto>> UpdateUserAddress(AdderssDto addressDto, CancellationToken cancellationToken)
            => ToActionResult(await authenticationService.UpdateUserAddressAsync(addressDto, GetEmailFromToken(), cancellationToken));
        #endregion
    }
}

    

