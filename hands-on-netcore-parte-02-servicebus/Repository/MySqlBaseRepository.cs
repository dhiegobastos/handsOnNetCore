using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace hands_on_netcore.Repository
{
    public abstract class MySqlBaseRepository
    {
        protected readonly IConfiguration _configuration;

        public MySqlBaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        internal IDbConnection GetIDbConnection()
        {
            var connectionString = _configuration.GetConnectionString("ProdutoDatabase");
            IDbConnection dbConnection = null;
            try
            {
                dbConnection = new MySqlConnection(connectionString);
                dbConnection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criar conexão com o banco de dados.");
                throw ex;
            }

            return dbConnection;
        }

    }
}