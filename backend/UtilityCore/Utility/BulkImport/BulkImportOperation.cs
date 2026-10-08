using NPOI.Util;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Models;

namespace UtilityCore.Utility.BulkImport
{
    public class BulkImportOperation
    {
        string _connString = string.Empty;
        public BulkImportOperation(string databaseConn)
        {
            _connString = databaseConn;
        }

        public DatabaseOperationStatus BulkCopyToStagingTable(DataTable dt)
        {
            DatabaseOperationStatus status = new DatabaseOperationStatus()
            {
                isSuccessful = false,
                recordCount = dt.Rows.Count
            };

            try
            {
                using (var connection = new OracleConnection(_connString))
                {
                    connection.Open();
                    using (var bulkCopy = new OracleBulkCopy(connection))
                    {
                        bulkCopy.BulkCopyTimeout = 0;
                        bulkCopy.BatchSize = status.recordCount;
                        OracleTransaction tran = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                        try
                        {
                            bulkCopy.DestinationTableName = dt.TableName;
                            bulkCopy.WriteToServer(dt);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            status.message = "Bulk Insert Rollback: " + ex.Message + "\n" + ex.StackTrace;

                            return status;
                        }
                    }
                }

                status.isSuccessful = true;
                status.message = "Bulk Insert Successful: " + dt.Rows.Count.ToString() + " record(s)";

                return status;
            }
            catch (Exception ex)
            {
                status.message = "Bulk Insert Failed: " + ex.Message + "\n" + ex.StackTrace;
                return status;
            }
        }

        public DatabaseOperationStatus TruncateTable(string tableName, string p_createdby)
        {
            DatabaseOperationStatus status = new DatabaseOperationStatus()
            {
                isSuccessful = false
            };

            try
            {
                using (var connection = new OracleConnection(_connString))
                {
                    connection.Open();

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "DELETE FROM " + tableName + " WHERE \"createdBy\" = '" + p_createdby +"'";
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
                status.isSuccessful = true;
                status.message = "Truncate Table: " + tableName + " Successful!";
                return status;
            }
            catch (Exception ex)
            {
                status.isSuccessful = false;
                status.message = "Error truncate Table: " + tableName + " - " + ex.Message + "\n" + ex.StackTrace;
                return status;
            }
        }

        public DatabaseOperationStatus ExecuteStoredProcedure(string sp, string p_createdby)
        {
            DatabaseOperationStatus status = new DatabaseOperationStatus()
            {
                isSuccessful = false
            };

            try
            {
                using (var connection = new OracleConnection(_connString))
                {
                    connection.Open();

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = sp;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_createdby", OracleDbType.Varchar2).Value = p_createdby;
                        cmd.ExecuteNonQuery();
                    }
                }

                status.isSuccessful = true;
                status.message = "Execute SQL Successfully:" + sp;

                return status;
            }
            catch (Exception ex)
            {
                status.message = "Error execute Stored Procedure: " + sp + " - " + ex.Message + "\n" + ex.StackTrace;
                return status;
            }
        }
    }
}
