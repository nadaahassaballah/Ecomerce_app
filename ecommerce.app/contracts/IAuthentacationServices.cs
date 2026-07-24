using ecommerce.app.Authentication;
using ecommerce.app.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.contracts
{
    public interface IAuthentacationServices
    {
        Task<Result<UserDTO>>LoginAsync(LoginDTO loginDTO,CancellationToken ct =default);
        Task<Result<UserDTO>> RsgisterAsync(RegisterDTO registerDTO, CancellationToken ct = default);

    }
}
