using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models.Common;
using Oracle.ManagedDataAccess.Client;
using Org.BouncyCastle.Asn1.Cmp;
using System.Data;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.DataAccess.Log
{
    public class LogDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private string _oracleTimestampFormat_In_DatetimeToString = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;

        public LogDAL(string connString, string providerType)
        {
            dbManager = new DBManager(providerType);  //new DBManager(DataProvider.Odbc);
            dbManager.ConnectionString = connString;
        }

        public LOG_OUTBOUND PerformLogging(LOG_OUTBOUND outbound)
        {
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();

                dbManager.ClearParameters();
                dbManager.CreateParameters(8);
                OracleParameter p_logid = new OracleParameter();
                p_logid.OracleDbType = OracleDbType.Decimal;
                p_logid.Direction = ParameterDirection.InputOutput;
                p_logid.ParameterName = "p_logid";
                p_logid.Value = outbound.ID;
                p_logid.Scale = 0;
                p_logid.Precision = 10;
                dbManager.AddParameters(0, p_logid);
                dbManager.AddParameters(1, "p_payload", outbound.PAYLOAD);
                dbManager.AddParameters(2, "p_message", outbound.MESSAGE);
                dbManager.AddParameters(3, "p_object", outbound.OBJECT);
                dbManager.AddParameters(4, "p_rec_count", outbound.REC_COUNT);
                dbManager.AddParameters(5, "p_status", 0);
                dbManager.AddParameters(6, "p_exec_by", outbound.EXEC_BY);
                dbManager.AddParameters(7, "p_operation", "OUT");
                
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "SP_MAIN_LOG");
                dbManager.CommitTransaction();

                outbound.ID = Convert.ToDecimal(p_logid.Value.ToString());
                return outbound;
            }
            catch (Exception ce)
            {
                dbManager.RollbackTransaction();
                //logger.Error(ce.StackTrace);
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
        }
    }
}
