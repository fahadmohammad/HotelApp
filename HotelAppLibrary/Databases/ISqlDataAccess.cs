using System.Collections.Generic;

namespace HotelAppLibrary.Databases
{
    public interface ISqlDataAccess
    {
        List<T> LoadData<T, U>(string sqlStatement, U parameters, 
            string connectionsStringName, bool isStoredProcedure = false);

        void SaveData<T>(string sqlStatement, T parameters,
            string connectionsStringName, bool isStoredProcedure = false);
    }
}