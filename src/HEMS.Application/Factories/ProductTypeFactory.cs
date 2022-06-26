using AutoMapper;
using HEMS.Domain.Entities;
using HEMS.Shared.Dtos.ProductType;
using HEMS.Shared.Requests.ProductType;

namespace HEMS.Application.Factories
{
    internal class ProductTypeFactory : Profile
    {
        public ProductTypeFactory()
        {
            CreateMap<ProductTypeDto, ProductType>().ReverseMap();
            CreateMap<ProductTypeCreateRequest, ProductType>();
            CreateMap<ProductTypeEditRequest, ProductType>();
        }
    }
}
