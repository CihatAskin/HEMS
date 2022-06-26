using AutoMapper;
using HEMS.Client.Models.Product;
using HEMS.Shared.Dtos.Product;
using HEMS.Shared.Requests.Product;

namespace HEMS.Client.Mappers
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductDto, ProductReadModel>();
            CreateMap<ProductCreateModel, ProductCreateRequest>();
            CreateMap<ProductDto, ProductEditModel>();
            CreateMap<ProductEditModel, ProductEditRequest>();
        }
    }
}
