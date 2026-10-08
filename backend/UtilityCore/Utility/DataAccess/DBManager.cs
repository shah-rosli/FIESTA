using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UtilityCore.Utility.DataAccess
{
    public class DBManager : IDBManager, IDisposable
    {
        private IDbConnection idbConnection;
        private IDataReader idataReader;
        private IDbCommand idbCommand;
        private DataProvider providerType;
        private IDbTransaction idbTransaction = null;
        private IDbDataParameter[] idbParameters = null;
        private string strConnection;

        public DBManager()
        {

        }

        public DBManager(DataProvider providerType)
        {
            this.providerType = providerType;
        }



        //private DataProvider DataProvider()
        //{
        //     switch (this.providerName)
        //    {

        //        case "System.Data.Odbc":
        //            this.providerType = DataProvider.Odbc;
        //            break;
        //        case "System.Data.OracleClient":
        //            this.providerType = DataProvider.Oracle;
        //            break;
        //        case "System.Data.OleDb":
        //            this.providerType = DataProvider.OleDb;
        //            break;
        //        case "System.Data.SqlClient":
        //            this.providerType = DataProvider.SqlServer;
        //            break;
        //        case "System.Data.IBM.Data.Informix":
        //            this.providerType = DataProvider.Informix;
        //            break;
        //    }
        //    return this.providerType;

        //}
        public DBManager(string provider)
        {
            switch (provider)
            {

                case "System.Data.Odbc":
                    this.providerType = DataProvider.Odbc;
                    break;
                case "System.Data.OracleClient":
                    this.providerType = DataProvider.Oracle;
                    break;
                case "System.Data.OleDb":
                    this.providerType = DataProvider.OleDb;
                    break;
                case "System.Data.SqlClient":
                    this.providerType = DataProvider.SqlServer;
                    break;
                case "System.Data.IBM.Data.Informix":
                    this.providerType = DataProvider.Informix;
                    break;
            }

        }

        public DBManager(DataProvider providerType, string
         connectionString)
        {
            this.providerType = providerType;
            this.strConnection = connectionString;
        }

        public IDbConnection Connection
        {
            get
            {
                return idbConnection;
            }
        }

        public IDataReader DataReader
        {
            get
            {
                return idataReader;
            }
            set
            {
                idataReader = value;
            }
        }

        public DataProvider ProviderType
        {
            get
            {
                return providerType;
            }
            set
            {
                providerType = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return strConnection;
            }
            set
            {
                strConnection = value;
            }
        }

        public IDbCommand Command
        {
            get
            {
                return idbCommand;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return idbTransaction;
            }
        }

        public IDbDataParameter[] Parameters
        {
            get
            {
                return idbParameters;
            }
        }

        public void Open()
        {
            idbConnection =
            DBManagerFactory2.GetConnection(this.providerType);
            idbConnection.ConnectionString = this.ConnectionString;
            if (idbConnection.State != ConnectionState.Open)
                idbConnection.Open();
            this.idbCommand = DBManagerFactory2.GetCommand(this.ProviderType);
        }

        public void Close()
        {
            if (idbConnection != null && idbConnection.State != ConnectionState.Closed)
                idbConnection.Close();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            this.Close();
            this.idbCommand = null;
            this.idbTransaction = null;
            this.idbConnection = null;
        }

        public void CreateParameters(int paramsCount)
        {
            idbParameters = new IDbDataParameter[paramsCount];
            idbParameters = DBManagerFactory2.GetParameters(this.ProviderType,
              paramsCount);

        }

        public void ClearParameters()
        {
            idbParameters = null;
        }

        public void AddParameters(int index, string paramName, object objValue)
        {
            if (index < idbParameters.Length)
            {
                idbParameters[index].ParameterName = paramName;
                idbParameters[index].Value = objValue;
            }
        }

        public void AddParameters(int index, IDbDataParameter objParam)
        {
            if (index < idbParameters.Length)
            {
                idbParameters[index] = objParam;


            }
        }


        public void AddParameters(int index, string paramName, object objValue, ParameterDirection paramDirection, DbType dbType)
        {
            if (index < idbParameters.Length)
            {
                idbParameters[index].ParameterName = paramName;
                idbParameters[index].Value = objValue;
                idbParameters[index].Direction = paramDirection;
                idbParameters[index].DbType = dbType;

            }
        }


        public void BeginTransaction()
        {
            if (this.idbTransaction == null)
                idbTransaction =
                DBManagerFactory2.GetTransaction(this.ProviderType, this.idbConnection);
            this.idbCommand.Transaction = idbTransaction;
        }

        public void CommitTransaction()
        {
            if (this.idbTransaction != null)
                this.idbTransaction.Commit();
            idbTransaction = null;
        }


        public void RollbackTransaction()
        {
            if (this.idbTransaction != null)
                this.idbTransaction.Rollback();
            idbTransaction = null;
        }

        public IDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory2.GetCommand(this.ProviderType);
            idbCommand.Connection = this.Connection;
            PrepareCommand(idbCommand, this.Connection, this.Transaction,
             commandType,
              commandText, this.Parameters);
            this.DataReader = idbCommand.ExecuteReader();
            idbCommand.Parameters.Clear();
            return this.DataReader;
        }

        public void CloseReader()
        {
            if (this.DataReader != null)
                this.DataReader.Close();
        }

        private void AttachParameters(IDbCommand command,
          IDbDataParameter[] commandParameters)
        {
            foreach (IDbDataParameter idbParameter in commandParameters)
            {
                if ((idbParameter.Direction == ParameterDirection.InputOutput)
                &&
                  (idbParameter.Value == null))
                {
                    idbParameter.Value = DBNull.Value;
                }
                command.Parameters.Add(idbParameter);
            }
        }

        private void PrepareCommand(IDbCommand command, IDbConnection
          connection,
          IDbTransaction transaction, CommandType commandType, string
          commandText,
          IDbDataParameter[] commandParameters)
        {
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
        }

        public int ExecuteNonQuery(CommandType commandType, string
        commandText)
        {
            this.idbCommand = DBManagerFactory2.GetCommand(this.ProviderType);
            PrepareCommand(idbCommand, this.Connection, this.Transaction,
            commandType, commandText, this.Parameters);
            int returnValue = idbCommand.ExecuteNonQuery();
            idbCommand.Parameters.Clear();
            return returnValue;
        }

        public object ExecuteScalar(CommandType commandType, string
          commandText)
        {
            this.idbCommand = DBManagerFactory2.GetCommand(this.ProviderType);
            PrepareCommand(idbCommand, this.Connection, this.Transaction,
            commandType,
              commandText, this.Parameters);
            object returnValue = idbCommand.ExecuteScalar();

            idbCommand.Parameters.Clear();
            return returnValue;
        }

        public DataSet ExecuteDataSet(CommandType commandType, string
         commandText)
        {
            this.idbCommand = DBManagerFactory2.GetCommand(this.ProviderType);
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            IDbDataAdapter dataAdapter = DBManagerFactory2.GetDataAdapter
              (this.ProviderType);
            idbCommand.CommandTimeout = 200;
            dataAdapter.SelectCommand = idbCommand;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            idbCommand.Parameters.Clear();
            return dataSet;
        }



        public List<T> GetListOfObjects<T>(string commandText, System.Type className) where T : class, new()
        {
            IDataReader r = ExecuteReader(CommandType.Text, commandText);

            List<T> list = new List<T>();

            while (r.Read())
            {
                T obj = new T();
                Type objType = obj.GetType();

                string tableName = objType.InvokeMember("get_TableName", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { }).ToString();
                Hashtable mappingFields = (Hashtable)objType.InvokeMember("ColumnMappings", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { });

                for (int i = 0; i < r.FieldCount; i++)
                {
                    //string dbFieldName = tableName + "." + r.GetName(i);
                    string dbFieldName = r.GetName(i);

                    if (r.IsDBNull(i))
                    {
                        DataAccessAssistant.ResetEmptyObject(r.GetFieldType(i));
                    }
                    else
                    {
                        try
                        {
                            object dbValue = r.GetValue(i);

                            //if (mappingFields.ContainsKey(dbValue))
                            //  if (mappingFields.ContainsKey(dbFieldName.ToLower()))
                            if (mappingFields.ContainsKey(dbFieldName))
                            {
                                //string propField = (string)mappingFields[dbFieldName.ToLower()];
                                string propField = (string)mappingFields[dbFieldName];
                                objType.InvokeMember("set_" + propField, BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { dbValue });

                                //clean up
                                propField = null;
                            }

                            //clean up
                            dbValue = null;
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = string.Format("{0} - Can't find {1} method in {2}.", ex.ToString(), mappingFields[dbFieldName], objType.FullName);
                            //  throw new SysException(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, System.Reflection.MethodBase.GetCurrentMethod().Name, errorMsg);
                        }
                    }

                    //clean up
                    dbFieldName = null;
                }

                //clean up
                tableName = null;
                mappingFields = null;

                list.Add(obj);
            }

            if (r != null)
                ((IDisposable)r).Dispose();

            return list;
        }

        #region Extended methods
        public ArrayList GetArrayofObjects(string commandText, System.Type className)
        {
            IDataReader r = ExecuteReader(CommandType.Text, commandText);
            ArrayList arrObjects = new ArrayList();


            while (r.Read())
            {
                object obj = Activator.CreateInstance(className);
                Type objType = obj.GetType();

                string tableName = objType.InvokeMember("get_TableName", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { }).ToString();
                Hashtable mappingFields = (Hashtable)objType.InvokeMember("ColumnMappings", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { });

                for (int i = 0; i < r.FieldCount; i++)
                {
                    string dbFieldName = tableName + "." + r.GetName(i);

                    if (r.IsDBNull(i))
                    {
                        DataAccessAssistant.ResetEmptyObject(r.GetFieldType(i));
                    }
                    else
                    {
                        try
                        {
                            object dbValue = r.GetValue(i);

                            //if (mappingFields.ContainsKey(dbValue))
                            //  if (mappingFields.ContainsKey(dbFieldName.ToLower()))
                            if (mappingFields.ContainsKey(dbFieldName))
                            {
                                //string propField = (string)mappingFields[dbFieldName.ToLower()];
                                string propField = (string)mappingFields[dbFieldName];
                                objType.InvokeMember("set_" + propField, BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { dbValue });

                                //clean up
                                propField = null;
                            }

                            //clean up
                            dbValue = null;
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = string.Format("{0} - Can't find {1} method in {2}.", ex.ToString(), mappingFields[dbFieldName], objType.FullName);
                            //  throw new SysException(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, System.Reflection.MethodBase.GetCurrentMethod().Name, errorMsg);
                        }
                    }

                    //clean up
                    dbFieldName = null;
                }

                //clean up
                tableName = null;
                mappingFields = null;

                arrObjects.Add(obj);

            }

            if (r != null)
                ((IDisposable)r).Dispose();

            return arrObjects;
        }

        public ArrayList GetArrayofObjectsWithoutTable(string commandText, System.Type className)
        {
            IDataReader r = ExecuteReader(CommandType.Text, commandText);
            ArrayList arrObjects = new ArrayList();

            while (r.Read())
            {
                object obj = Activator.CreateInstance(className);
                Type objType = obj.GetType();

                //string tableName = objType.InvokeMember("get_TableName", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { }).ToString();
                Hashtable mappingFields = (Hashtable)objType.InvokeMember("ColumnMappings", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { });

                for (int i = 0; i < r.FieldCount; i++)
                {
                    //string dbFieldName = tableName + "." + r.GetName(i);
                    string dbFieldName = r.GetName(i);

                    if (r.IsDBNull(i))
                    {
                        DataAccessAssistant.ResetEmptyObject(r.GetFieldType(i));
                    }
                    else
                    {
                        try
                        {
                            object dbValue = r.GetValue(i);

                            //if (mappingFields.ContainsKey(dbValue))
                            //  if (mappingFields.ContainsKey(dbFieldName.ToLower()))
                            if (mappingFields.ContainsKey(dbFieldName))
                            {
                                //string propField = (string)mappingFields[dbFieldName.ToLower()];
                                string propField = (string)mappingFields[dbFieldName];
                                objType.InvokeMember("set_" + propField, BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { dbValue });

                                //clean up
                                propField = null;
                            }

                            //clean up
                            dbValue = null;
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = string.Format("{0} - Can't find {1} method in {2}.", ex.ToString(), mappingFields[dbFieldName], objType.FullName);
                            //  throw new SysException(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, System.Reflection.MethodBase.GetCurrentMethod().Name, errorMsg);
                        }
                    }

                    //clean up
                    dbFieldName = null;
                }

                //clean up
                //tableName = null;
                mappingFields = null;

                arrObjects.Add(obj);
            }

            if (r != null)
                ((IDisposable)r).Dispose();

            return arrObjects;
        }

        public int Delete(string tableName, Hashtable keySets)
        {
            int iResult = 0;
            int i = 0;
            // IDbConnection conn = new IDbConnection(_connectionString);
            this.idbCommand = DBManagerFactory2.GetCommand(this.ProviderType);
            StringBuilder sb = new StringBuilder();
            StringBuilder sbWhereCond = new StringBuilder();

            sb.AppendFormat(" DELETE {0} where ", tableName);
            CreateParameters(keySets.Count);

            foreach (string key in keySets.Keys)
            {
                if (!sbWhereCond.ToString().Equals(""))
                    sbWhereCond.Append(" AND ");
                sbWhereCond.AppendFormat("   {0} = ? ", key);

                AddParameters(i, null, keySets[key]);
                ++i;
            }

            sb.Append(sbWhereCond);

            PrepareCommand(idbCommand, idbConnection, idbTransaction, CommandType.Text, sb.ToString(), this.idbParameters);
            iResult = idbCommand.ExecuteNonQuery();

            return iResult;
        }
        public int Update(string tableName, Hashtable keySets, Hashtable updateSets)
        {
            int iResult = 0;
            // IDbConnection conn = new IDbConnection(_connectionString);
            this.idbCommand = DBManagerFactory2.GetCommand(this.ProviderType);
            StringBuilder sb = new StringBuilder();
            StringBuilder sbWhereCond = new StringBuilder();


            sb.AppendFormat(" Update {0} set ", tableName);

            CreateParameters(updateSets.Count + keySets.Count);
            int i = 0;
            foreach (string key in updateSets.Keys)
            {
                sb.AppendFormat("   {0} = ? ,", key);
                AddParameters(i, null, updateSets[key]);
                ++i;
                //command.Parameters.Add(new OdbcParameter(key, updateSets[key]));
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(" WHERE ");


            foreach (string key in keySets.Keys)
            {
                if (!sbWhereCond.ToString().Equals(""))
                    sbWhereCond.Append(" AND ");
                sbWhereCond.AppendFormat("   {0} = ? ", key);

                AddParameters(i, null, keySets[key]);
                ++i;
            }

            sb.Append(sbWhereCond);
            PrepareCommand(idbCommand, idbConnection, idbTransaction, CommandType.Text, sb.ToString(), this.idbParameters);
            iResult = idbCommand.ExecuteNonQuery();

            return iResult;
        }

        public int Update(string commandText)
        {
            int iResult = 0;
            iResult = ExecuteNonQuery(CommandType.Text, commandText);
            return iResult;
        }

        public int Create(string commandText)
        {
            int iResult = 0;
            //this.idbCommand = DBManagerFactory2.GetCommand(this.ProviderType);

            //PrepareCommand(idbCommand, idbConnection, idbTransaction, CommandType.Text, commandText, this.idbParameters);

            iResult = ExecuteNonQuery(CommandType.Text, commandText);

            //iResult = idbCommand.ExecuteNonQuery();

            return iResult;
        }
        public int Create(string tableName, Hashtable keySets, Hashtable updateSets)
        {
            int iResult = 0;
            int i = 0;
            // this.idbCommand = DBManagerFactory2.GetCommand(this.ProviderType);
            StringBuilder sb = new StringBuilder();
            StringBuilder sbWhereCond = new StringBuilder();

            CreateParameters(updateSets.Count + keySets.Count);
            sb.AppendFormat(" INSERT INTO {0} ( ", tableName);

            foreach (string key in keySets.Keys)
            {
                sb.AppendFormat("   {0}  ,", key);
                AddParameters(i, null, keySets[key]);
                i++;
            }

            foreach (string key in updateSets.Keys)
            {
                sb.AppendFormat("   {0}  ,", key);
                AddParameters(i, null, updateSets[key]);
                i++;
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append(" ) VALUES (");

            foreach (string key in updateSets.Keys)
            {
                sb.Append("?,");
            }
            foreach (string key in keySets.Keys)
            {
                sb.Append("?,");
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append(" )");

            //PrepareCommand(idbCommand, idbConnection, idbTransaction, CommandType.Text, sb.ToString(), this.idbParameters);

            iResult = ExecuteNonQuery(CommandType.Text, sb.ToString());
            return iResult;
        }


        #endregion


        #region
        public bool ExecuteTrans(string[] saQuery)
        {
            bool isSuccess = false;
            try
            {
                this.BeginTransaction();
                foreach (string query in saQuery)
                {
                    //if (ExecuteNonQuery(CommandType.Text, query)  <1 )
                    if (ExecuteNonQuery(CommandType.Text, query) < 0)
                    {
                        isSuccess = false;
                        RollbackTransaction();
                        break;
                    }
                    else
                        isSuccess = true;
                }

                if (isSuccess)
                    CommitTransaction();

            }
            catch (Exception ex)
            {
                this.RollbackTransaction();
                throw ex;

            }

            return isSuccess;
        }
        #endregion


        #region
        public bool ExecuteTrans(string[] saQuery, bool[] saflags)/*sa flags to indicate optional or not to commit*/
        {
            bool isSuccess = false;
            int dbRow = 0;
            try
            {
                int count = 0;
                this.BeginTransaction();

                foreach (string query in saQuery)
                {
                    {
                        dbRow = ExecuteNonQuery(CommandType.Text, query);
                        if (dbRow < 0)
                        {
                            isSuccess = false;
                            RollbackTransaction();
                            break;
                        }
                        else
                        {
                            if (dbRow == 0 && saflags[count] == false)
                            {
                                isSuccess = false;
                                RollbackTransaction();
                                break;
                            }
                            else
                            {
                                isSuccess = true;
                            }
                        }
                    }
                    count++;
                }

                if (isSuccess)
                    CommitTransaction();

            }
            catch (Exception ex)
            {
                this.RollbackTransaction();
                throw ex;

            }

            return isSuccess;
        }
        #endregion
    }
}
