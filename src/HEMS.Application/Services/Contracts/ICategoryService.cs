using HEMS.Shared.Requests.Category;
using HEMS.Shared.Response.Category;

namespace HEMS.Application.Services.Contracts
{
    public interface ICategoryService
    {
        Task<CategoryCreateResponse> Create(CategoryCreateRequest request);
        Task<CategoryReadListResponse> List(CategoryReadListRequest request);
        Task<CategoryReadResponse> Get(CategoryReadRequest request);
        Task<CategoryEditResponse> Edit(CategoryEditRequest request);
        Task<CategoryDeleteResponse> Delete(CategoryDeleteRequest request);
        Task<CategoryExistsResponse> IsExists(CategoryExistsRequest request);

    }
}
