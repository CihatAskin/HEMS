using Dapper;
using HEMS.Application.Common.Interfaces;
using HEMS.Domain.Common.Contracts;
using System.Data;

namespace HEMS.Infrastructure.Common
{
    public class RepositoryAsync : IRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public RepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> CreateAsync<T>(string sql, DynamicParameters param) where T : AuditableEntity
        {
            using (var connection = _connectionFactory.Create())
            {
                await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);

                return param.Get<int>("Id");
            }
        }

        public async Task<T> GetByIdAsync<T>(string sql, int id) where T : AuditableEntity
        {
            using (var connection = _connectionFactory.Create())
            {
                var result = await connection.QueryFirstOrDefaultAsync<T>(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<T>> GetListAsync<T>(string sql) where T : AuditableEntity
        {
            using (var connection = _connectionFactory.Create())
            {
                var result = await connection.QueryAsync<T>(sql, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public async Task<List<T>> GetListAsync<T>(string sql,object param) where T : AuditableEntity
        {
            using (var connection = _connectionFactory.Create())
            {
                var result = await connection.QueryAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<bool> IsExistsAsync(string sql, string code)
        {
            using (var connection = _connectionFactory.Create())
            {
                var result = await connection.QueryFirstOrDefaultAsync<bool>(sql, new { Code = code }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task RemoveByCodeAsync(string sql, string code)
        {
            using (var connection = _connectionFactory.Create())
            {
                var result = await connection.ExecuteAsync(sql, new { Code = code, UpdatedAt = DateTime.UtcNow }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateAsync<T>(string sql, object entity) where T : AuditableEntity
        {
            using (var connection = _connectionFactory.Create())
            {
                var result = await connection.ExecuteAsync(sql, entity, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
