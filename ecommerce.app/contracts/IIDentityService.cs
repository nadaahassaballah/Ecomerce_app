using ecommerce.app.Authentication;
using ecommerce.app.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.contracts
{
    public interface IIDentityService
    {
        Task<Result<IdentityUserResult>> FindEmailAsync(string email, CancellationToken ct = default);
           Task<Result<bool>> CheckPasswordAsync(string email ,string password, CancellationToken ct = default);
        Task<Result<IdentityUserResult>> CreatUserAsync(RegisterDTO registerDTO, CancellationToken ct = default);
       Task<Result<IReadOnlyList<string>>> getRoleAsync(string email, CancellationToken ct = default);
        Task<Result< AdderssDto>> GetAddressbyEmailAsync(string email, CancellationToken ct = default);
        Task<Result<AdderssDto>> updateAddressbyEmailAsync(string email,AdderssDto adderssDto, CancellationToken ct = default);
        Task<Result<bool>> EmailExistingAsync(string email, CancellationToken ct = default);


    }
}
