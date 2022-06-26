
namespace HEMS.Domain.Common.Contracts
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
