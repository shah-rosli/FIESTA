using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityCore.Utility.DataAccess
{
    public interface IDBManager
    {
        DataProvider ProviderType
        {
            get;
            set;
        }

        string ConnectionString
        {
            get;
            set;
        }

        IDbConnection Connection
        {
            get;
        }
        IDbTransaction Transaction
        {
            get;
        }

        IDataReader DataReader
        {
            get;
        }
        IDbCommand Command
        {
            get;
        }

        IDbDataParameter[] Parameters
        {
            get;
        }

        void Open();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void CreateParameters(int paramsCount);
        void ClearParameters();
        void AddParameters(int index, IDbDataParameter objParam);
        void AddParameters(int index, string paramName, object objValue);
        void AddParameters(int index, string paramName, object objValue, ParameterDirection paramDirection, DbType dbType);
        IDataReader ExecuteReader(CommandType commandType, string commandText);
        DataSet ExecuteDataSet(CommandType commandType, string commandText);
        object ExecuteScalar(CommandType commandType, string commandText);
        int ExecuteNonQuery(CommandType commandType, string commandText);
        void CloseReader();
        void Close();
        void Dispose();

        #region Extended method        
        List<T> GetListOfObjects<T>(string commandText, System.Type className) where T : class, new();
        ArrayList GetArrayofObjects(string commandText, System.Type className);
        ArrayList GetArrayofObjectsWithoutTable(string commandText, System.Type className);
        int Update(string tableName, Hashtable keySets, Hashtable updateSets);
        int Update(string commandText);
        int Delete(string tableName, Hashtable keySets);
        int Create(string tableName, Hashtable keySets, Hashtable updateSets);
        int Create(string commandText);
        bool ExecuteTrans(string[] saQuery);
        bool ExecuteTrans(string[] saQuery, bool[] saFlag);

        #endregion


    }
}
