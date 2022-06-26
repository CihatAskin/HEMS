using HEMS.Shared.Requests.Product;
using HEMS.Shared.Response.Product;

namespace HEMS.Application.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductCreateResponse> Create(ProductCreateRequest request);
        Task<ProductReadListResponse> List(ProductReadListRequest request);
        Task<ProductReadResponse> Get(ProductReadRequest request);
        Task<ProductEditResponse> Edit(ProductEditRequest request);
        Task<ProductDeleteResponse> Delete(ProductDeleteRequest request);
        Task<ProductExistsResponse> IsExists(ProductExistsRequest request);

    }
}
