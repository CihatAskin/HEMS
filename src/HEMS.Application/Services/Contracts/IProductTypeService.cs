using HEMS.Shared.Requests.ProductType;
using HEMS.Shared.Response.ProductType;

namespace HEMS.Application.Services.Contracts
{
    public interface IProductTypeService
    {
        Task<ProductTypeCreateResponse> Create(ProductTypeCreateRequest request);
        Task<ProductTypeReadListResponse> List(ProductTypeReadListRequest request);
        Task<ProductTypeReadListResponse> GetByCategory(ProductTypeReadListRequest request);
        Task<ProductTypeReadResponse> Get(ProductTypeReadRequest request);
        Task<ProductTypeEditResponse> Edit(ProductTypeEditRequest request);
        Task<ProductTypeDeleteResponse> Delete(ProductTypeDeleteRequest request);
        Task<ProductTypeExistsResponse> IsExists(ProductTypeExistsRequest request);


    }
}
