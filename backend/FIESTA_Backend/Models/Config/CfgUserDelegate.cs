
using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIESTA_Backend.Models.Common;
using System.Threading.Tasks;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgUserDelegate
    {
        public CfgUserDelegate()
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
            get { return "CFG_USER_DELEGATE"; }
        }
        #endregion
        #region Properties
        public decimal CFG_USER_DELEGATE_ID { get; set; }
        public string USER_ID { get; set; }
        public string DELEGATEE_USER_ID { get; set; }
        public DateTimeOffset START_DATETIME { get; set; }
        public DateTimeOffset END_DATETIME { get; set; }
        public string ACTIVE { get; set; }
        public DateTimeOffset INITIATE_DATE { get; set; }
        public TokenProperties? TokenObj { get; set; }

        public string DELEGATOR_REMARK { get; set; }

        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_USER_DELEGATE_ID = CfgUserDelegate.TableName + ".CFG_USER_DELEGATE_ID";
            public static string USER_ID = CfgUserDelegate.TableName + ".USER_ID";
            public static string DELEGATEE_USER_ID = CfgUserDelegate.TableName + ".DELEGATEE_USER_ID";
            public static string START_DATETIME = CfgUserDelegate.TableName + ".START_DATETIME";
            public static string END_DATETIME = CfgUserDelegate.TableName + ".END_DATETIME";
            public static string ACTIVE = CfgUserDelegate.TableName + ".ACTIVE";
            public static string INITIATE_DATE = CfgUserDelegate.TableName + ".INITIATE_DATE";
            public static string DELEGATOR_REMARK = CfgUserDelegate.TableName + ".DELEGATOR_REMARK";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_USER_DELEGATE_ID = "CFG_USER_DELEGATE_ID";
            public static string USER_ID = "USER_ID";
            public static string DELEGATEE_USER_ID = "DELEGATEE_USER_ID";
            public static string START_DATETIME = "START_DATETIME";
            public static string END_DATETIME = "END_DATETIME";
            public static string ACTIVE = "ACTIVE";
            public static string INITIATE_DATE = "INITIATE_DATE";
            public static string DELEGATOR_REMARK = "DELEGATOR_REMARK";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgUserDelegate.ColumnNames.CFG_USER_DELEGATE_ID, "CFG_USER_DELEGATE_ID");
            map.Add(CfgUserDelegate.ColumnNames.USER_ID, "USER_ID");
            map.Add(CfgUserDelegate.ColumnNames.DELEGATEE_USER_ID, "DELEGATEE_USER_ID");
            map.Add(CfgUserDelegate.ColumnNames.START_DATETIME, "START_DATETIME");
            map.Add(CfgUserDelegate.ColumnNames.END_DATETIME, "END_DATETIME");
            map.Add(CfgUserDelegate.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgUserDelegate.ColumnNames.INITIATE_DATE, "INITIATE_DATE");
            map.Add(CfgUserDelegate.ColumnNames.DELEGATOR_REMARK, "DELEGATOR_REMARK");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_USER_DELEGATE_ID = "CFG_USER_DELEGATE_ID";
            public static string USER_ID = "USER_ID";
            public static string DELEGATEE_USER_ID = "DELEGATEE_USER_ID";
            public static string START_DATETIME = "START_DATETIME";
            public static string END_DATETIME = "END_DATETIME";
            public static string ACTIVE = "ACTIVE";
            public static string INITIATE_DATE = "INITIATE_DATE";
            public static string DELEGATOR_REMARK = "DELEGATOR_REMARK";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_USER_DELEGATE_ID
        {
            get { return string.Format("'{0}'", CFG_USER_DELEGATE_ID); }
        }
        public string Formatted_USER_ID
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_ID)); }
        }
        public string Formatted_DELEGATEE_USER_ID
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(DELEGATEE_USER_ID)); }
        }

        public string Formatted_DELEGATOR_REMARK
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(DELEGATOR_REMARK)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
        }

        public string Formatted_START_DATETIME
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("{0}", DataConverter.ConvertTimezone(START_DATETIME, TokenObj.DEFAULT_TIMEZONE, "UTC"));
                else return null;
            }
        }
        public string Formatted_START_DATETIME_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgUserDelegate.ColumnNames.START_DATETIME, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }

        public string Formatted_END_DATETIME
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("{0}", DataConverter.ConvertTimezone(END_DATETIME, TokenObj.DEFAULT_TIMEZONE, "UTC"));
                else return null;
            }
        }

        public string Formatted_END_DATETIME_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgUserDelegate.ColumnNames.END_DATETIME, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }


        public string Formatted_INITIATE_DATE
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("{0}", DataConverter.ConvertTimezone(INITIATE_DATE, TokenObj.DEFAULT_TIMEZONE, "UTC"));
                else return null;
            }
        }
        public string Formatted_INITIATE_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgUserDelegate.ColumnNames.INITIATE_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_USER_DELEGATE_ID; }
        }
        #endregion
    }
}
