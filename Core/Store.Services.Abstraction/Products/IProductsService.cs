using Store.Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Abstraction.Products
{
    public  interface IProductsService
    {
        Task<IEnumerable<ProductResponse>> GetAllProductsAsync();
        Task<IEnumerable<ProductResponse>> GetProductById(int id);
        Task<IEnumerable<BrandTypeReponse>> GetAllBrands();
        Task<IEnumerable<BrandTypeReponse>> GetAllTypes();       
    }
}
