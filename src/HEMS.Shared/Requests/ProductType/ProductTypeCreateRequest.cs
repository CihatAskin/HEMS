
namespace HEMS.Shared.Requests.ProductType
{
    public class ProductTypeCreateRequest
    {
        public string CategoryCode { get; set; }
        public string Code { get; set; }

        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ProductTypeCreateRequest(string categoryCode, string code, string status, string name, string description)
        {
            CategoryCode = categoryCode;
            Code = code;
            Status = status;
            Name = name;
            Description = description;
        }

    }
}
