using System.Collections.Generic;

namespace HotelAppLibrary.Databases
{
    public interface ISqLiteDataAccess
    {
        List<T> LoadData<T, U>(string sqlStatement, U parameters,
            string connectionsStringName);

        void SaveData<T>(string sqlStatement, T parameters,
            string connectionsStringName);
    }
}