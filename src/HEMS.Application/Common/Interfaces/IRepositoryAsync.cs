using System.Data.Common;
using System.Linq.Expressions;
using Dapper;
using HEMS.Domain.Common.Contracts;

namespace HEMS.Application.Common.Interfaces
{

    public interface IRepositoryAsync
    {
        Task<T?> GetByIdAsync<T>(string sql, int id)
        where T : AuditableEntity;

        Task<List<T>> GetListAsync<T>(string sql)
        where T : AuditableEntity;

        Task<List<T>> GetListAsync<T>(string sql, object param)
        where T : AuditableEntity;

        Task UpdateAsync<T>(string sql, object entity)
        where T : AuditableEntity;

        Task<int> CreateAsync<T>(string sql, DynamicParameters param)
        where T : AuditableEntity;

        Task RemoveByCodeAsync(string sql, string code);
        Task<bool> IsExistsAsync(string sql, string code);


    }
}
