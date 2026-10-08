
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class AttachmentsHis
    {
        public AttachmentsHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region static variable
        #endregion
        #region TableName
        public static string TableName
        {
            get { return "ATTACHMENTS_HIS"; }
        }
        #endregion
        #region Properties
        public decimal ATTACHMENTS_HIS_ID { get; set; }
        public decimal ATTACHMENTS_ID { get; set; }
        public decimal ATTACHMENTS_MASTER_HIS_ID { get; set; }
        public string ATTACHMENT_DOCUMENT_TYPE { get; set; }
        public string ATTACHMENT_DOCUMENT_ID { get; set; }
        public string ATTACHMENT_ACTUAL_FILE_NAME { get; set; }
        public string ATTACHMENT_SYSTEM_FILE_NAME { get; set; }
        public string ATTACHMENT_FOLDER_PATH { get; set; }
        public string ATTACHMENT_TYPE { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string ATTACHMENTS_HIS_ID = AttachmentsHis.TableName + ".ATTACHMENTS_HIS_ID";
            public static string ATTACHMENTS_ID = AttachmentsHis.TableName + ".ATTACHMENTS_ID";
            public static string ATTACHMENTS_MASTER_HIS_ID = AttachmentsHis.TableName + ".ATTACHMENTS_MASTER_HIS_ID";
            public static string ATTACHMENT_DOCUMENT_TYPE = AttachmentsHis.TableName + ".ATTACHMENT_DOCUMENT_TYPE";
            public static string ATTACHMENT_DOCUMENT_ID = AttachmentsHis.TableName + ".ATTACHMENT_DOCUMENT_ID";
            public static string ATTACHMENT_ACTUAL_FILE_NAME = AttachmentsHis.TableName + ".ATTACHMENT_ACTUAL_FILE_NAME";
            public static string ATTACHMENT_SYSTEM_FILE_NAME = AttachmentsHis.TableName + ".ATTACHMENT_SYSTEM_FILE_NAME";
            public static string ATTACHMENT_FOLDER_PATH = AttachmentsHis.TableName + ".ATTACHMENT_FOLDER_PATH";
            public static string ATTACHMENT_TYPE = AttachmentsHis.TableName + ".ATTACHMENT_TYPE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string ATTACHMENTS_HIS_ID = "ATTACHMENTS_HIS_ID";
            public static string ATTACHMENTS_ID = "ATTACHMENTS_ID";
            public static string ATTACHMENTS_MASTER_HIS_ID = "ATTACHMENTS_MASTER_HIS_ID";
            public static string ATTACHMENT_DOCUMENT_TYPE = "ATTACHMENT_DOCUMENT_TYPE";
            public static string ATTACHMENT_DOCUMENT_ID = "ATTACHMENT_DOCUMENT_ID";
            public static string ATTACHMENT_ACTUAL_FILE_NAME = "ATTACHMENT_ACTUAL_FILE_NAME";
            public static string ATTACHMENT_SYSTEM_FILE_NAME = "ATTACHMENT_SYSTEM_FILE_NAME";
            public static string ATTACHMENT_FOLDER_PATH = "ATTACHMENT_FOLDER_PATH";
            public static string ATTACHMENT_TYPE = "ATTACHMENT_TYPE";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(AttachmentsHis.ColumnNames.ATTACHMENTS_HIS_ID, "ATTACHMENTS_HIS_ID");
            map.Add(AttachmentsHis.ColumnNames.ATTACHMENTS_ID, "ATTACHMENTS_ID");
            map.Add(AttachmentsHis.ColumnNames.ATTACHMENTS_MASTER_HIS_ID, "ATTACHMENTS_MASTER_HIS_ID");
            map.Add(AttachmentsHis.ColumnNames.ATTACHMENT_DOCUMENT_TYPE, "ATTACHMENT_DOCUMENT_TYPE");
            map.Add(AttachmentsHis.ColumnNames.ATTACHMENT_DOCUMENT_ID, "ATTACHMENT_DOCUMENT_ID");
            map.Add(AttachmentsHis.ColumnNames.ATTACHMENT_ACTUAL_FILE_NAME, "ATTACHMENT_ACTUAL_FILE_NAME");
            map.Add(AttachmentsHis.ColumnNames.ATTACHMENT_SYSTEM_FILE_NAME, "ATTACHMENT_SYSTEM_FILE_NAME");
            map.Add(AttachmentsHis.ColumnNames.ATTACHMENT_FOLDER_PATH, "ATTACHMENT_FOLDER_PATH");
            map.Add(AttachmentsHis.ColumnNames.ATTACHMENT_TYPE, "ATTACHMENT_TYPE");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string ATTACHMENTS_HIS_ID = "ATTACHMENTS_HIS_ID";
            public static string ATTACHMENTS_ID = "ATTACHMENTS_ID";
            public static string ATTACHMENTS_MASTER_HIS_ID = "ATTACHMENTS_MASTER_HIS_ID";
            public static string ATTACHMENT_DOCUMENT_TYPE = "ATTACHMENT_DOCUMENT_TYPE";
            public static string ATTACHMENT_DOCUMENT_ID = "ATTACHMENT_DOCUMENT_ID";
            public static string ATTACHMENT_ACTUAL_FILE_NAME = "ATTACHMENT_ACTUAL_FILE_NAME";
            public static string ATTACHMENT_SYSTEM_FILE_NAME = "ATTACHMENT_SYSTEM_FILE_NAME";
            public static string ATTACHMENT_FOLDER_PATH = "ATTACHMENT_FOLDER_PATH";
            public static string ATTACHMENT_TYPE = "ATTACHMENT_TYPE";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_ATTACHMENTS_HIS_ID
        {
            get { return string.Format("'{0}'", ATTACHMENTS_HIS_ID); }
        }
        public string Formatted_ATTACHMENTS_ID
        {
            get { return string.Format("'{0}'", ATTACHMENTS_ID); }
        }
        public string Formatted_ATTACHMENTS_MASTER_HIS_ID
        {
            get { return string.Format("'{0}'", ATTACHMENTS_MASTER_HIS_ID); }
        }
        public string Formatted_ATTACHMENT_DOCUMENT_TYPE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ATTACHMENT_DOCUMENT_TYPE)); }
        }
        public string Formatted_ATTACHMENT_DOCUMENT_ID
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ATTACHMENT_DOCUMENT_ID)); }
        }
        public string Formatted_ATTACHMENT_ACTUAL_FILE_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ATTACHMENT_ACTUAL_FILE_NAME)); }
        }
        public string Formatted_ATTACHMENT_SYSTEM_FILE_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ATTACHMENT_SYSTEM_FILE_NAME)); }
        }
        public string Formatted_ATTACHMENT_FOLDER_PATH
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ATTACHMENT_FOLDER_PATH)); }
        }
        public string Formatted_ATTACHMENT_TYPE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ATTACHMENT_TYPE)); }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.ATTACHMENTS_HIS_ID; }
        }
        #endregion
    }
}
