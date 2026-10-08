using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace FIESTA_Inbound_Console.Utility
{
    public class DatabaseOperation
    {
        string _connString = string.Empty;
        public DatabaseOperation(string databaseConn)
        {
            _connString = databaseConn;
        }

        public bool BulkCopyToStagingTable(DataTable dt, string prefix)
        {
            //get count from DT
            int count = dt.Rows.Count;

            try
            {
                using (var connection = new OracleConnection(_connString))
                {
                    connection.Open();
                    using (var bulkCopy = new OracleBulkCopy(connection))
                    {
                        bulkCopy.BulkCopyTimeout = 0;
                        bulkCopy.BatchSize = count;
                        OracleTransaction tran = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                        try
                        {
                            bulkCopy.DestinationTableName = prefix + dt.TableName;
                            bulkCopy.WriteToServer(dt);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            Program.AppendLog("Bulk Insert Rollback: " + ex.Message + "\n" + ex.StackTrace);
                            return false;
                        }
                    }
                }

                Program.AppendLog("Bulk Insert Successful: " + dt.Rows.Count.ToString() + " record(s)");
                return true;
            }
            catch (Exception ex)
            {
                Program.AppendLog("Bulk Insert Failed: " + ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        public bool TruncateTable(string tableName)
        {
            try
            {
                using (var connection = new OracleConnection(_connString))
                {
                    connection.Open();

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "TRUNCATE TABLE " + tableName;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
                Program.AppendLog("Truncate Table: "+tableName+" Successful!");
                return true;
            }
            catch (Exception ex)
            {
                Program.AppendError("Error truncate Table: " + tableName + " - " + ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        public bool ExecuteNonQuery(string sql)
        {
            try
            {
                using (var connection = new OracleConnection(_connString))
                {
                    connection.Open();

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
                Program.AppendLog("Execute SQL Successfully:");
                Program.AppendLog(sql);
                return true;
            }
            catch (Exception ex)
            {
                Program.AppendError("Error execute SQL statement: " + sql + " - " + ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        public bool ExecuteStoredProcedure(string sp)
        {
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
                        cmd.ExecuteNonQuery();
                    }
                }
                Program.AppendLog("Execute SQL Successfully:" + sp);

                return true;
            }
            catch (Exception ex)
            {
                Program.AppendError("Error execute Stored Procedure: " + sp + " - " + ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        public bool ExecuteStoredProcedureWithReturn(string sp)
        {
            bool isSuccess = true; //true by default
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

                        cmd.Parameters.Add("v_result", OracleDbType.Varchar2, 10);
                        cmd.Parameters["v_result"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("v_max_percent", OracleDbType.Decimal);
                        cmd.Parameters["v_max_percent"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("v_max_percent_enable", OracleDbType.Decimal);
                        cmd.Parameters["v_max_percent_enable"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("v_actual_percent", OracleDbType.Decimal);
                        cmd.Parameters["v_actual_percent"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();


                        string? result = cmd.Parameters["v_result"].Value != null ? cmd.Parameters["v_result"].Value.ToString() : "ROLLBACK";
                        decimal? v_max_percent = cmd.Parameters["v_max_percent"].Value != null ? decimal.Parse(cmd.Parameters["v_max_percent"].Value.ToString()) : -1;
                        decimal? v_max_percent_enable = cmd.Parameters["v_max_percent"].Value != null ? decimal.Parse(cmd.Parameters["v_max_percent_enable"].Value.ToString()) : 0;
                        decimal? v_actual_percent = cmd.Parameters["v_actual_percent"].Value != null ? decimal.Parse(cmd.Parameters["v_actual_percent"].Value.ToString()) : -1;

                        if (v_max_percent_enable.HasValue && v_max_percent_enable == 1)
                        {
                            Program.AppendLog("Max Percent Checking Enabled!");
                            Program.AppendLog("Max Allowed Percent: " + v_max_percent + "% | Actual Percent: " + v_actual_percent + "%");
                            if (result == "COMMIT")
                            {
                                isSuccess = true;
                            }
                            else
                            {
                                Program.AppendError("ROLLBACK! Error email should be sent!");
                                isSuccess = false;
                            }
                        }
                        Program.AppendLog("Execute SQL Successfully:" + sp + " with STATUS: " + result);
                    }
                }
                
                return isSuccess;
            }
            catch (Exception ex)
            {
                Program.AppendError("Error execute Stored Procedure: " + sp + " - " + ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        public bool ExecuteStoredProcedureWithStatusReturn(string sp)
        {
            bool isSuccess = true; //true by default
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

                        cmd.Parameters.Add("p_output_msg", OracleDbType.Varchar2, 1000);
                        cmd.Parameters["p_output_msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();


                        string? result = cmd.Parameters["p_output_msg"].Value != null ? cmd.Parameters["p_output_msg"].Value.ToString() : "ERROR";
                        
                        if(result?.Trim() == "SUCCESS")
                        {
                            Program.AppendLog("Execute SQL Successfully:" + sp + " with STATUS: " + result);
                        }
                        else
                        {
                            Program.AppendLog("Execute SQL Error:" + sp + " with STATUS: " + result);
                            isSuccess = false;
                        }
                    }
                }

                return isSuccess;
            }
            catch (Exception ex)
            {
                Program.AppendError("Error execute Stored Procedure: " + sp + " - " + ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        public DataTable ExecuteReader(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var connection = new OracleConnection(_connString))
                {
                    connection.Open();

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        var dataReader = cmd.ExecuteReader();
                        dt.Load(dataReader);
                    }
                }
                Program.AppendLog("Execute Reader Successfully:");
                Program.AppendLog(sql);
                
            }
            catch (Exception ex)
            {
                Program.AppendError("Error execute Reader SQL statement: " + sql + " - " + ex.Message + "\n" + ex.StackTrace);
            }

            return dt;
        }
    }
}
