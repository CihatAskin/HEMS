using HEMS.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEMS.Infrastructure.Common
{

    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection Create()
        {
            var connection = new SqlConnection
            {
                ConnectionString = _configuration.GetConnectionString("DefaultConnection")
            };

            connection.Open();
            return connection;
        }

    }

}
