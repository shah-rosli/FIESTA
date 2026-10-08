
using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgSystemParam
    {
        public CfgSystemParam()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public struct System_DocumentStatus
        {
            public static string Pending_Approval = "Pending Approval";
            public static string Pending_Submission = "Pending Submission";
            public static string Rejected = "Rejected";
            public static string Cancelled = "Cancelled";
            public static string Completed = "Completed";
            public static string NA = "Not Applicable";
            public static string Pending_Procurement = "Pending Procurement";
            public static string Approved = "Approved";
            //public static string Procurement_Fixed = "Procurement Fixed";
            public static string Pending_ApprovalOnly_Review = "Pending Approval Only Review";
            public static string Pending_PD_Review = "Pending PD Review";
            public static string Pending_Asset_Review = "Pending Asset Review";
            public static string PD_To_Fix = "PD To Fix";
            public static string Pending_IF = "Pending IF";
            public static string Objected = "Objected";
            public static string Investment_Processing = "Investment Processing";
            public static string Staging_AOP = "Staging AOP";
            public static string AOP_Rejected = "AOP Rejected";
            public static string Review = "Review";
            public static string Reconsidered = "Reconsidered";


        }

        public struct System_DocumentType
        {
            public static string BPMS = "BPMS";           

        }

        public struct System_Format
        {
            public static string DefaultDisplayDateFormat = "DefaultDisplayDateFormat";
            public static string DefaultDisplayDateTimeFormat = "DefaultDisplayDateTimeFormat";
            public static string DefaultDisplayTimeFormat = "DefaultDisplayTimeFormat";
            public static string DefaultHeaderDateTimeFormat = "DefaultHeaderDateTimeFormat";
            public static string DefaultSystemTimezone = "DefaultSystemTimezone";

            public static string DefaultLanguage = "DefaultLanguage";
        }
        public static string TableName
        {
            get { return "CFG_SYSTEM_PARAM"; }
        }

        
        public struct System_ApprovalStatus
        {
            public static string Reconsidered = "Reconsidered";
            public static string Pending_Approval = "Pending Approval";
            public static string Approved = "Approved";
            public static string Rejected = "Rejected";
            public static string Objected = "Objected";
            public static string AOP_Rejected = "AOP Rejected";
            public static string Review = "Review";
            public static string Staging_AOP = "Staging AOP";
            public static string Completed = "Completed";
            public static string Investment_Processing = "Investment Processing";
        }

        #region Properties      
        public decimal CFG_SYSTEM_PARAM_ID { get; set; }
        public string PARAM_KEY { get; set; }
        public string PARAM_VALUE { get; set; }
        public string PARAM_CATEGORY { get; set; }
        public TokenProperties? TokenObj { get; set; }

        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_SYSTEM_PARAM_ID = CfgSystemParam.TableName + ".CFG_SYSTEM_PARAM_ID";
            public static string PARAM_KEY = CfgSystemParam.TableName + ".PARAM_KEY";
            public static string PARAM_VALUE = CfgSystemParam.TableName + ".PARAM_VALUE";
            public static string PARAM_CATEGORY = CfgSystemParam.TableName + ".PARAM_CATEGORY";
        }

        
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_SYSTEM_PARAM_ID = "CFG_SYSTEM_PARAM_ID";
            public static string PARAM_KEY = "PARAM_KEY";
            public static string PARAM_VALUE = "PARAM_VALUE";
            public static string PARAM_CATEGORY = "PARAM_CATEGORY";

        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_PARAM_KEY
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(PARAM_KEY)); }
        }
        public string Formatted_PARAM_VALUE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(PARAM_VALUE)); }
        }
        public string Formatted_PARAM_CATEGORY
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(PARAM_CATEGORY)); }
        }
        #endregion
        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgSystemParam.ColumnNames.CFG_SYSTEM_PARAM_ID, "CFG_SYSTEM_PARAM_ID");
            map.Add(CfgSystemParam.ColumnNames.PARAM_KEY, "PARAM_KEY");
            map.Add(CfgSystemParam.ColumnNames.PARAM_VALUE, "PARAM_VALUE");
            map.Add(CfgSystemParam.ColumnNames.PARAM_CATEGORY, "PARAM_CATEGORY");

            return map;
        }
        #endregion


       
    }
}