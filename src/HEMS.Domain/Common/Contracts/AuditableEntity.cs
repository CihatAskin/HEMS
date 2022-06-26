
namespace HEMS.Domain.Common.Contracts
{
    public abstract class AuditableEntity : BaseEntity, IAuditableEntity, ISoftDelete
    {
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        protected AuditableEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
