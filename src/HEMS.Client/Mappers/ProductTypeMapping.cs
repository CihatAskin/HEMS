using AutoMapper;
using HEMS.Client.Models.ProductType;
using HEMS.Shared.Dtos.ProductType;
using HEMS.Shared.Requests.ProductType;

namespace HEMS.Client.Mappers
{
    public class ProductTypeMapping : Profile
    {
        public ProductTypeMapping()
        {
            CreateMap<ProductTypeDto, ProductTypeReadModel>();
            CreateMap<ProductTypeCreateModel, ProductTypeCreateRequest>();
            CreateMap<ProductTypeDto, ProductTypeEditModel>();
            CreateMap<ProductTypeEditModel, ProductTypeEditRequest>();
        }
    }
}
