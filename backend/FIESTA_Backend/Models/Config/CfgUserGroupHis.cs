
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
    public class CfgUserGroupHis
    {

        public CfgUserGroupHis()
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
            get { return "CFG_USER_GROUP_HIS"; }
        }
        #endregion
        #region Properties
        public decimal CFG_USER_GROUP_ID { get; set; }
        public string USER_GROUP_NAME { get; set; }
        public string USER_GROUP_DESCRIPTION { get; set; }
        public string ACTIVE { get; set; }
        public decimal CFG_USER_GROUP_HIS_ID { get; set; }
        public DateTimeOffset CFG_USER_GROUP_HIS_DATE { get; set; }
        public string CFG_USER_GROUP_HIS_USER_ID { get; set; }
        public string CFG_USER_GROUP_HIS_DELEGATE { get; set; }
        public string? MODIFIED_BY_EMAIL { get; set; }
        public string? MODIFIED_BY_NAME { get; set; }
        public string? MODIFIED_BY_DELNAME { get; set; }

        public TokenProperties? TokenObj { get; set; }


        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_USER_GROUP_HIS_ID = CfgUserGroupHis.TableName + ".CFG_USER_GROUP_HIS_ID";
            public static string CFG_USER_GROUP_HIS_USER_ID = CfgUserGroupHis.TableName + ".CFG_USER_GROUP_HIS_USER_ID";
            public static string CFG_USER_GROUP_HIS_DELEGATE = CfgUserGroupHis.TableName + ".CFG_USER_GROUP_HIS_DELEGATE";
            public static string CFG_USER_GROUP_HIS_DATE = CfgUserGroupHis.TableName + ".CFG_USER_GROUP_HIS_DATE";
            public static string CFG_USER_GROUP_ID = CfgUserGroupHis.TableName + ".CFG_USER_GROUP_ID";
            public static string USER_GROUP_NAME = CfgUserGroupHis.TableName + ".USER_GROUP_NAME";
            public static string USER_GROUP_DESCRIPTION = CfgUserGroupHis.TableName + ".USER_GROUP_DESCRIPTION";
            public static string ACTIVE = CfgUserGroupHis.TableName + ".ACTIVE";
        }
        #endregion

        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_ID, "CFG_USER_GROUP_HIS_ID");
            map.Add(CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_ID, "CFG_USER_GROUP_HIS_USER_ID");
            map.Add(CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_ID, "CFG_USER_GROUP_HIS_DELEGATE");
            map.Add(CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_ID, "CFG_USER_GROUP_HIS_DATE");
            map.Add(CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_ID, "CFG_USER_GROUP_ID");
            map.Add(CfgUserGroupHis.ColumnNames.USER_GROUP_NAME, "USER_GROUP_NAME");
            map.Add(CfgUserGroupHis.ColumnNames.USER_GROUP_DESCRIPTION, "USER_GROUP_DESCRIPTION");
            map.Add(CfgUserGroupHis.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_USER_GROUP_ID
        {
            get { return string.Format("'{0}'", CFG_USER_GROUP_ID); }
        }
        public string Formatted_USER_GROUP_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_GROUP_NAME)); }
        }
        public string Formatted_USER_GROUP_DESCRIPTION
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_GROUP_DESCRIPTION)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
        }
        public string Formatted_CFG_USER_GROUP_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion       
    }
}
