using ecommerce.app.common;
using ecommerce.app.DTOS.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.contracts
{
    public interface IProductService
    {
        Task<Result<Pagginationresult<ProductsDTO>>> GetAllProductAsync( Productquerryprams querry
 ,CancellationToken ct);
        Task<Result<ProductsDTO>> GetProductAsync(int id, CancellationToken ct = default);
        Task<Result<IReadOnlyList <BrandDTO>>>GetAllBrandAsync(CancellationToken ct = default);
        Task<Result<IReadOnlyList<TypeDTO>>>GetAllTypeAsync(CancellationToken ct = default);

    }
}
