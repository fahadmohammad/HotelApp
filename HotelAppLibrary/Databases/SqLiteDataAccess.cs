using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace HotelAppLibrary.Databases
{
    public class SqLiteDataAccess : ISqLiteDataAccess
    {
        private readonly IConfiguration _configuration;

        public SqLiteDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<T> LoadData<T, U>(string sqlStatement, U parameters,
            string connectionsStringName)
        {
            var connectionstring = _configuration.GetConnectionString(connectionsStringName);

            using (var connection = new SQLiteConnection(connectionstring))
            {
                var rows = connection.Query<T>(sqlStatement, parameters).ToList();
                return rows;
            }
        }

        public void SaveData<T>(string sqlStatement, T parameters,
            string connectionsStringName)
        {
            var connectionstring = _configuration.GetConnectionString(connectionsStringName);

            using (var connection = new SQLiteConnection(connectionstring))
            {
                connection.Execute(sqlStatement, parameters);
            }
        }
    }
}
