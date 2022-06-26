
namespace HEMS.Shared.Dtos.ProductType
{
    public class ProductTypeDto:BaseDto
    {
        public string CategoryCode { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
