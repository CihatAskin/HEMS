using AutoMapper;
using HEMS.Domain.Entities;
using HEMS.Shared.Dtos.Product;
using HEMS.Shared.Requests.Product;

namespace HEMS.Application.Factories
{
    internal class ProductFactory : Profile
    {
        public ProductFactory()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductCreateRequest, Product>();
            CreateMap<ProductEditRequest, Product>();
        }
    }
}
