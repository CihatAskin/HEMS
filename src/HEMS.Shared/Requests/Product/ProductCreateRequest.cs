
namespace HEMS.Shared.Requests.Product
{
    public class ProductCreateRequest
    {
        public string CategoryCode { get; set; }
        public string ProductTypeCode { get; set; }
        public string Code { get; set; }

        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ProductCreateRequest(string categoryCode, string productTypeCode, string code, string status, string name, string description)
        {
            ProductTypeCode = productTypeCode;
            CategoryCode = categoryCode;
            Code = code;
            Status = status;
            Name = name;
            Description = description;
        }

    }
}
