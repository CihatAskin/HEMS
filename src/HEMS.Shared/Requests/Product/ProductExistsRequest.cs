
namespace HEMS.Shared.Requests.Product
{
    public class ProductExistsRequest
    {
        public string Code { get; set; }

        public ProductExistsRequest(string code)
        {
            Code = code;
        }
    }
}
