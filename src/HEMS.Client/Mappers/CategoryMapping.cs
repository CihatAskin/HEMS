using AutoMapper;
using HEMS.Client.Models.Category;
using HEMS.Shared.Dtos.Category;
using HEMS.Shared.Requests.Category;

namespace HEMS.Client.Mappers
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryDto, CategoryReadModel>();
            CreateMap<CategoryCreateModel, CategoryCreateRequest>();
            CreateMap<CategoryDto, CategoryEditModel>();
            CreateMap<CategoryEditModel, CategoryEditRequest>();
        }
    }
}
