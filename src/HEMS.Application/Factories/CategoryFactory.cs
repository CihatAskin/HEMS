using AutoMapper;
using HEMS.Domain.Entities;
using HEMS.Shared.Dtos.Category;
using HEMS.Shared.Dtos.Product;
using HEMS.Shared.Dtos.ProductType;
using HEMS.Shared.Requests.Category;

namespace HEMS.Application.Factories
{
    internal class CategoryFactory : Profile
    {
        public CategoryFactory()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CategoryCreateRequest, Category>();
            CreateMap<CategoryEditRequest, Category>();
        }
    }
}
