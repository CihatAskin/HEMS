using System.Data.Common;
using System.Data.SqlClient;

namespace HEMS.Application.Common.Interfaces
{
    public interface IConnectionFactory
    {
        SqlConnection Create();
    }
}
