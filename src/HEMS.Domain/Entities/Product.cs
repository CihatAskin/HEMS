using HEMS.Domain.Common.Contracts;

namespace HEMS.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string CategoryCode { get; set; }
        public string ProductTypeCode { get; set; }

       
    }
}
