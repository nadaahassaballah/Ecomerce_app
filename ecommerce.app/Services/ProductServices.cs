using AutoMapper;
using ecomerce_domain.contract;
using ecomerce_domain.entities.product;
using ecommerce.app.common;
using ecommerce.app.contracts;
using ecommerce.app.DTOS.products;
using ecommerce.app.spessification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.Services
{
    public class ProductServices:IProductService
    {
        private readonly iunitofworks iunitofworks;
        private readonly IMapper mapper;

        public ProductServices(iunitofworks iunitofworks,IMapper mapper) {

            this.iunitofworks = iunitofworks;
              this.mapper = mapper;  
                
                }

        public async Task<Result<IReadOnlyList<BrandDTO>>> GetAllBrandAsync(CancellationToken ct = default)
        {
           var brand = await iunitofworks.GetRepository<Productbrand, int>().GetAllAsync(ct);
            return Result<IReadOnlyList<BrandDTO>>.OK(mapper.Map<IReadOnlyList<BrandDTO>>(brand));
        }
 
        public async Task<Result<Pagginationresult<ProductsDTO>>> GetAllProductAsync(Productquerryprams productquerryprams
            ,CancellationToken ct)
        {
            var spec = new ProductWithBrandTypeSpecification(productquerryprams);
            var repo = iunitofworks.GetRepository<Product, int>();

            var products = await repo.GetAllAsync(spec,ct);

            var data = mapper.Map<IReadOnlyList<ProductsDTO>>(products);
            var countspec = new productcountspesfication(productquerryprams);
            var countofallproducts = await iunitofworks.GetRepository<Product, int>().countasync(countspec);
            var result = new Pagginationresult<ProductsDTO>(
           productquerryprams.pageindex,
           productquerryprams.Pagesize,
           countofallproducts,
           data);

            return Result<Pagginationresult<ProductsDTO>>.OK(result);
        }

        public async Task<Result<IReadOnlyList<TypeDTO>>> GetAllTypeAsync(CancellationToken ct = default)
        {

var types=await iunitofworks.GetRepository<ProductType , int>().GetAllAsync(ct);
            return Result<IReadOnlyList<TypeDTO>>.OK(mapper.Map<IReadOnlyList<TypeDTO>>(types));
        }

       

        public async Task<Result<ProductsDTO>> GetProductAsync(int id, CancellationToken ct = default)
        {
            var spec=new ProductWithBrandTypeSpecification(id);
            var product = await iunitofworks.GetRepository<Product, int>().GetByIdAsync(spec, ct);
            if (product is null)
            {
                return Result<ProductsDTO>.Fail(error.NotFound("product.notfound", $"product with id :{id} was not found"));
            }
            var data = mapper.Map<ProductsDTO>(product);

            return Result<ProductsDTO>.OK(data);
        }
    }
}
