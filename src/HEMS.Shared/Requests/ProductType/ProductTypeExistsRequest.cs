
namespace HEMS.Shared.Requests.ProductType
{
    public class ProductTypeExistsRequest
    {
        public string Code { get; set; }

        public ProductTypeExistsRequest(string code)
        {
            Code = code;
        }
    }
}
