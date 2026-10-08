using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Utility.DataAccess;
using FIESTA_Backend.Models.Common;

namespace FIESTA_Backend.DataAccess.Attachment
{
    public class AttachmentsDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public AttachmentsDAL(IConfiguration configuration, HttpContext httpContext)
        {
            //
            // TODO: Add constructor logic here
            //
            this._config = configuration;
            this._httpContext = httpContext;

            _envProperties = new EnvironmentProperties(_config, _httpContext);
            _connectionString = _envProperties.CONN_STRING();
            _providerType = _config.GetSection("ProviderName").Value;
            dbManager = new DBManager(_providerType);
            dbManager.ConnectionString = _connectionString;
            logger = log4net.LogManager.GetLogger("GeneralLog");
        }
        public string SelectAllRowsQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select distinct");
            sb.AppendFormat("   {0}, {1}, {2}, {3}, {4}, {5}, {6} ", Attachments.ColumnNames.ATTACHMENTS_ID, Attachments.ColumnNames.ATTACHMENT_DOCUMENT_TYPE, Attachments.ColumnNames.ATTACHMENT_DOCUMENT_ID, Attachments.ColumnNames.ATTACHMENT_ACTUAL_FILE_NAME, Attachments.ColumnNames.ATTACHMENT_SYSTEM_FILE_NAME, Attachments.ColumnNames.ATTACHMENT_FOLDER_PATH, Attachments.ColumnNames.ATTACHMENT_TYPE);
            sb.AppendFormat("  from  {0}  ", Attachments.TableName);
            return sb.ToString();
        }
        public DataTable SelectAllRows()
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectAllRowsQuery());
                dt = ds.Tables[0];
            }
            catch (Exception ce)
            {
                logger.Error(ce.Message);
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
            return dt;
        }
        public string InsertRowQuery(Attachments obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert into {0} ( ", Attachments.TableName);
            sb.AppendFormat("  {0}, {1}, {2}, {3},{4},{5} ", Attachments.ColumnNames.ATTACHMENT_DOCUMENT_TYPE, Attachments.ColumnNames.ATTACHMENT_DOCUMENT_ID, Attachments.ColumnNames.ATTACHMENT_ACTUAL_FILE_NAME, Attachments.ColumnNames.ATTACHMENT_SYSTEM_FILE_NAME, Attachments.ColumnNames.ATTACHMENT_FOLDER_PATH, Attachments.ColumnNames.ATTACHMENT_TYPE);
            sb.Append("  ) values (  ");
            sb.AppendFormat("  {0}, {1}, {2}, {3}, {4} ,{5}) ", obj.Formatted_ATTACHMENT_DOCUMENT_TYPE, obj.Formatted_ATTACHMENT_DOCUMENT_ID, obj.Formatted_ATTACHMENT_ACTUAL_FILE_NAME, obj.Formatted_ATTACHMENT_SYSTEM_FILE_NAME, obj.Formatted_ATTACHMENT_FOLDER_PATH, obj.Formatted_ATTACHMENT_TYPE);

            return sb.ToString();
        }
        public void InsertRow(Attachments paramsObj)
        {
            string query = string.Empty;
            try
            {
                dbManager.Open();
                query = InsertRowQuery(paramsObj);
                dbManager.ExecuteNonQuery(CommandType.Text, query);
            }
            catch (Exception ce)
            {
                logger.Error(ce.StackTrace);
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
        }
        private string UpdateRowQuery(int id, Attachments obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Update {0} set ", Attachments.TableName);
            sb.AppendFormat("  {0}={1} ", Attachments.ColumnNames.ATTACHMENTS_ID, obj.Formatted_ATTACHMENTS_ID);
            sb.AppendFormat("  ,  {0}={1} ", Attachments.ColumnNames.ATTACHMENT_DOCUMENT_TYPE, obj.Formatted_ATTACHMENT_DOCUMENT_TYPE);
            sb.AppendFormat("  ,  {0}={1} ", Attachments.ColumnNames.ATTACHMENT_DOCUMENT_ID, obj.Formatted_ATTACHMENT_DOCUMENT_ID);
            sb.AppendFormat("  ,  {0}={1} ", Attachments.ColumnNames.ATTACHMENT_ACTUAL_FILE_NAME, obj.Formatted_ATTACHMENT_ACTUAL_FILE_NAME);
            sb.AppendFormat("  ,  {0}={1} ", Attachments.ColumnNames.ATTACHMENT_SYSTEM_FILE_NAME, obj.Formatted_ATTACHMENT_SYSTEM_FILE_NAME);
            sb.AppendFormat("  ,  {0}={1} ", Attachments.ColumnNames.ATTACHMENT_FOLDER_PATH, obj.Formatted_ATTACHMENT_FOLDER_PATH);
            sb.AppendFormat(" where {0} = {1} ", Attachments.PrimaryKey, id);
            return sb.ToString();
        }
        public int UpdateRow(int id, Attachments paramsObj)
        {
            string query = string.Empty;
            try
            {
                dbManager.Open();
                query = UpdateRowQuery(id, paramsObj);
                return dbManager.ExecuteNonQuery(CommandType.Text, query);
            }
            catch (Exception ce)
            {
                logger.Error(ce.StackTrace);
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
        }
        public  string DeleteRowsByAttachmentsIdQuery(decimal id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Delete from  {0} where ", Attachments.TableName);
            sb.AppendFormat(" {0} = {1} ", Attachments.ColumnNames.ATTACHMENTS_ID, id);
            return sb.ToString();
        }

        private string DeleteRowQuery(int id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Delete from  {0} where ", Attachments.TableName);
            sb.AppendFormat(" {0} = {1} ", Attachments.PrimaryKey, id);
            return sb.ToString();
        }
        public int DeleteRow(int id)
        {
            string query = string.Empty;
            try
            {
                dbManager.Open();
                query = DeleteRowQuery(id);
                return dbManager.ExecuteNonQuery(CommandType.Text, query);
            }
            catch (Exception ce)
            {
                logger.Error(ce.StackTrace);
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
        }
        private string SelectRowByIdQuery(string id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1}, {2}, {3}, {4}, {5} ", Attachments.ColumnNames.ATTACHMENTS_ID, Attachments.ColumnNames.ATTACHMENT_DOCUMENT_TYPE, Attachments.ColumnNames.ATTACHMENT_DOCUMENT_ID, Attachments.ColumnNames.ATTACHMENT_ACTUAL_FILE_NAME, Attachments.ColumnNames.ATTACHMENT_SYSTEM_FILE_NAME, Attachments.ColumnNames.ATTACHMENT_FOLDER_PATH);
            sb.AppendFormat("  from  {0}  ", Attachments.TableName);
            sb.AppendFormat(" where {0} = '{1}' ", Attachments.ColumnNames.ATTACHMENT_SYSTEM_FILE_NAME, DataConverter.FormatSQL(id));
            return sb.ToString();
        }
        public Attachments SelectRowById(string id)
        {
            Attachments obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByIdQuery(id), new Attachments().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (Attachments)arr[0];
                }
            }
            catch (Exception ce)
            {
                logger.Error(ce.Message);
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
            return obj;
        }


        public string SelectRowByDocIdQuery(decimal id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SelectAllRowsQuery());

            sb.AppendFormat(" where {0} = {1} ", Attachments.ColumnNames.ATTACHMENT_DOCUMENT_ID, id);
            return sb.ToString();
        }

        public string SelectRowByDocIdAndTypeQuery(decimal id, string type)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SelectAllRowsQuery());

            sb.AppendFormat(" where {0} = {1} and {2} = '{3}' ", Attachments.ColumnNames.ATTACHMENT_DOCUMENT_ID, id, Attachments.ColumnNames.ATTACHMENT_DOCUMENT_TYPE, type);
            return sb.ToString();
        }

        public DataTable SelectRowByMultipleDocIdAndType(string id, string type)
        {
            
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectRowByMultipleDocIdAndTypeQuery(id, type));
                if (ds != null)
                    return ds.Tables[0];


                return null;
            }
            catch (Exception ce)
            {
                logger.Error(ce.Message);
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
            
        }

        private string SelectRowByMultipleDocIdAndTypeQuery(string id, string type)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SelectAllRowsQuery());

            sb.AppendFormat(" where {0} in ({1}) and {2} = '{3}' ", Attachments.ColumnNames.ATTACHMENT_DOCUMENT_ID, id, Attachments.ColumnNames.ATTACHMENT_DOCUMENT_TYPE, type);
            return sb.ToString();
        }

    }
}
