using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Backend.Models
{
    public class CfgSystemMenuHis
    {
        public CfgSystemMenuHis()
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
            get { return "CFG_SYSTEM_MENU_HIS"; }
        }
        #endregion
        #region Properties
        public decimal CFG_SYSTEM_MENU_HIS_ID { get; set; }
        public string? CFG_SYSTEM_MENU_HIS_USER_ID { get; set; }
        public string? CFG_SYSTEM_MENU_HIS_DELEGATE { get; set; }
        public DateTimeOffset CFG_SYSTEM_MENU_HIS_DATE { get; set; }
        public decimal CFG_SYSTEM_MENU_ID { get; set; }
        public string MENU_NAME { get; set; }
        public decimal MENU_PARENT_ID { get; set; }
        public decimal MENU_SEQUENCE { get; set; }
        public string MENU_ICON { get; set; }
        public string MENU_LINK { get; set; }
        public string ACTIVE { get; set; }
        public string[] saOperationMap { get; set; }
        public string? MODIFIED_BY_EMAIL { get; set; }
        public string? MODIFIED_BY_NAME { get; set; }
        public string? MODIFIED_BY_DELNAME { get; set; }
        public TokenProperties? TokenObj { get; set; }


        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_SYSTEM_MENU_HIS_ID = CfgSystemMenuHis.TableName + ".CFG_SYSTEM_MENU_HIS_ID";
            public static string CFG_SYSTEM_MENU_HIS_USER_ID = CfgSystemMenuHis.TableName + ".CFG_SYSTEM_MENU_HIS_USER_ID";
            public static string CFG_SYSTEM_MENU_HIS_DELEGATE = CfgSystemMenuHis.TableName + ".CFG_SYSTEM_MENU_HIS_DELEGATE";
            public static string CFG_SYSTEM_MENU_HIS_DATE = CfgSystemMenuHis.TableName + ".CFG_SYSTEM_MENU_HIS_DATE";
            public static string CFG_SYSTEM_MENU_ID = CfgSystemMenuHis.TableName + ".CFG_SYSTEM_MENU_ID";
            public static string MENU_NAME = CfgSystemMenuHis.TableName + ".MENU_NAME";
            public static string MENU_PARENT_ID = CfgSystemMenuHis.TableName + ".MENU_PARENT_ID";
            public static string MENU_SEQUENCE = CfgSystemMenuHis.TableName + ".MENU_SEQUENCE";
            public static string MENU_ICON = CfgSystemMenuHis.TableName + ".MENU_ICON";
            public static string MENU_LINK = CfgSystemMenuHis.TableName + ".MENU_LINK";
            public static string ACTIVE = CfgSystemMenuHis.TableName + ".ACTIVE";
        }
        #endregion
    
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_HIS_ID, "CFG_SYSTEM_MENU_HIS_ID");
            map.Add(CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_HIS_USER_ID, "CFG_SYSTEM_MENU_HIS_USER_ID");
            map.Add(CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_HIS_DELEGATE, "CFG_SYSTEM_MENU_HIS_DELEGATE");
            map.Add(CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_HIS_DATE, "CFG_SYSTEM_MENU_HIS_DATE");
            map.Add(CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_ID, "CFG_SYSTEM_MENU_ID");
            map.Add(CfgSystemMenuHis.ColumnNames.MENU_NAME, "MENU_NAME");
            map.Add(CfgSystemMenuHis.ColumnNames.MENU_PARENT_ID, "MENU_PARENT_ID");
            map.Add(CfgSystemMenuHis.ColumnNames.MENU_SEQUENCE, "MENU_SEQUENCE");
            map.Add(CfgSystemMenuHis.ColumnNames.MENU_ICON, "MENU_ICON");
            map.Add(CfgSystemMenuHis.ColumnNames.MENU_LINK, "MENU_LINK");
            map.Add(CfgSystemMenuHis.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }
        #endregion

        public string Formatted_CFG_SYSTEM_MENU_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
    }
}
