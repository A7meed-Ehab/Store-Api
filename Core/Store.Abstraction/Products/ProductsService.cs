using AutoMapper;
using Store.Domain.Entities.Products;
using Store.Domain.Repository_interfaces;
using Store.Services.Abstraction.Products;
using Store.Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<BrandTypeReponse>> GetAllBrands()
        {
            var brands = await _unitOfWork.GetGenericRepository<int, ProductBrand>().GetAllAsync();
            return _mapper.Map<IEnumerable<BrandTypeReponse>>(brands);
        }

        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
        {
            var products =await _unitOfWork.GetGenericRepository<int,Product>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductResponse>>(products); 
        }

        public async Task<IEnumerable<BrandTypeReponse>> GetAllTypes()
        {
            var types = await _unitOfWork.GetGenericRepository<int, ProductType>().GetAllAsync();
            return _mapper.Map<IEnumerable<BrandTypeReponse>>(types);
        }

        public async Task<IEnumerable<ProductResponse>> GetProductById(int id)
        {
            var product = await _unitOfWork.GetGenericRepository<int, Product>().GetByIdsync(id);
            return _mapper.Map<IEnumerable<ProductResponse>>(product);
        }
    }
}
