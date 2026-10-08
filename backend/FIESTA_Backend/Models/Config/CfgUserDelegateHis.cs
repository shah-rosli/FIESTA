
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
    public class CfgUserDelegateHis
    {
        public CfgUserDelegateHis()
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
            get { return "CFG_USER_DELEGATE_HIS"; }
        }
        #endregion
        #region Properties
        public decimal CFG_USER_DELEGATE_HIS_ID { get; set; }
        public string CFG_USER_DELEGATE_HIS_USER_ID { get; set; }
        public string CFG_USER_DELEGATE_HIS_DELEGATE { get; set; }
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
            public static string CFG_USER_DELEGATE_HIS_ID = CfgUserDelegateHis.TableName + ".CFG_USER_DELEGATE_HIS_ID";
            public static string CFG_USER_DELEGATE_HIS_USER_ID = CfgUserDelegateHis.TableName + ".CFG_USER_DELEGATE_HIS_USER_ID";
            public static string CFG_USER_DELEGATE_HIS_DELEGATE = CfgUserDelegateHis.TableName + ".CFG_USER_DELEGATE_HIS_DELEGATE";
            public static string CFG_USER_DELEGATE_ID = CfgUserDelegateHis.TableName + ".CFG_USER_DELEGATE_ID";
            public static string USER_ID = CfgUserDelegateHis.TableName + ".USER_ID";
            public static string DELEGATEE_USER_ID = CfgUserDelegateHis.TableName + ".DELEGATEE_USER_ID";
            public static string START_DATETIME = CfgUserDelegateHis.TableName + ".START_DATETIME";
            public static string END_DATETIME = CfgUserDelegateHis.TableName + ".END_DATETIME";
            public static string ACTIVE = CfgUserDelegateHis.TableName + ".ACTIVE";
            public static string INITIATE_DATE = CfgUserDelegateHis.TableName + ".INITIATE_DATE";
            public static string DELEGATOR_REMARK = CfgUserDelegateHis.TableName + ".DELEGATOR_REMARK";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_USER_DELEGATE_HIS_ID = "CFG_USER_DELEGATE_HIS_ID";
            public static string CFG_USER_DELEGATE_HIS_USER_ID = "CFG_USER_DELEGATE_HIS_USER_ID";
            public static string CFG_USER_DELEGATE_HIS_DELEGATE = "CFG_USER_DELEGATE_HIS_DELEGATE";
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
            map.Add(CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_ID, "CFG_USER_DELEGATE_HIS_ID");
            map.Add(CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_USER_ID, "CFG_USER_DELEGATE_HIS_USER_ID");
            map.Add(CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_DELEGATE, "CFG_USER_DELEGATE_HIS_DELEGATE");
            map.Add(CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_ID, "CFG_USER_DELEGATE_ID");
            map.Add(CfgUserDelegateHis.ColumnNames.USER_ID, "USER_ID");
            map.Add(CfgUserDelegateHis.ColumnNames.DELEGATEE_USER_ID, "DELEGATEE_USER_ID");
            map.Add(CfgUserDelegateHis.ColumnNames.START_DATETIME, "START_DATETIME");
            map.Add(CfgUserDelegateHis.ColumnNames.END_DATETIME, "END_DATETIME");
            map.Add(CfgUserDelegateHis.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgUserDelegateHis.ColumnNames.INITIATE_DATE, "INITIATE_DATE");
            map.Add(CfgUserDelegateHis.ColumnNames.DELEGATOR_REMARK, "DELEGATOR_REMARK");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_USER_DELEGATE_HIS_ID = "CFG_USER_DELEGATE_HIS_ID";
            public static string CFG_USER_DELEGATE_HIS_USER_ID = "CFG_USER_DELEGATE_HIS_USER_ID";
            public static string CFG_USER_DELEGATE_HIS_DELEGATE = "CFG_USER_DELEGATE_HIS_DELEGATE";
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
        public string Formatted_CFG_USER_DELEGATE_HIS_ID
        {
            get { return string.Format("'{0}'", CFG_USER_DELEGATE_HIS_ID); }
        }
        public string Formatted_CFG_USER_DELEGATE_HIS_USER_ID
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(CFG_USER_DELEGATE_HIS_USER_ID)); }
        }
        public string Formatted_CFG_USER_DELEGATE_HIS_DELEGATE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(CFG_USER_DELEGATE_HIS_DELEGATE)); }
        }
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
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ",CfgUserDelegateHis.ColumnNames.START_DATETIME, TokenObj.DEFAULT_TIMEZONE);
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
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgUserDelegateHis.ColumnNames.END_DATETIME, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }


        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
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
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgUserDelegateHis.ColumnNames.INITIATE_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }

        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_USER_DELEGATE_HIS_ID; }
        }
        #endregion
    }
}
