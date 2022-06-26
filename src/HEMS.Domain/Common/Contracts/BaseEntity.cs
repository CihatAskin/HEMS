
namespace HEMS.Domain.Common.Contracts
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Status { get; private set; }

        
    }
}
