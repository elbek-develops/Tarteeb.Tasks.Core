using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace Tarteeb.Tasks.Core.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetConnection();
    }
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration config;

        public DbConnectionFactory(IConfiguration config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }
        public IDbConnection GetConnection()
        {
            return new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }
    }
}
