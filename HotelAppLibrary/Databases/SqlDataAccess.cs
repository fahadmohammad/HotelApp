using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace HotelAppLibrary.Databases
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<T> LoadData<T, U>(string sqlStatement, U parameters, 
            string connectionsStringName, bool isStoredProcedure = false)
        {
            var connectionstring = _configuration.GetConnectionString(connectionsStringName);
            var commandType = CommandType.Text;

            if (isStoredProcedure)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (var connection = new SqlConnection(connectionstring))
            {
                var rows = connection.Query<T>(sqlStatement, parameters, commandType: commandType).ToList();
                return rows;
            }
        }

        public void SaveData<T>(string sqlStatement, T parameters,
            string connectionsStringName, bool isStoredProcedure = false)
        {
            var connectionstring = _configuration.GetConnectionString(connectionsStringName);
            var commandType = CommandType.Text;

            if (isStoredProcedure)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(sqlStatement, parameters, commandType: commandType);
            }
        }
    }
}
