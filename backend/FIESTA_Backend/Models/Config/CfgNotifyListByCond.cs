
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
    public class CfgNotifyListByCond
    {
        //Constructor
        public CfgNotifyListByCond()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_NOTIFY_LIST_BY_COND"; }
        }

        #region Properties       

        public decimal CFG_NOTIFY_LIST_BY_COND_ID { get; set; }
        public string CFG_NOTIFY_LIST_BY_COND_DESC { get; set; }
        public string CFG_NOTIFY_LIST { get; set; }
        public string ACTIVE { get; set; }

        public TokenProperties? TokenObj { get; set; }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_NOTIFY_LIST_BY_COND_ID = CfgNotifyListByCond.TableName + ".CFG_NOTIFY_LIST_BY_COND_ID";
            public static string CFG_NOTIFY_LIST_BY_COND_DESC = CfgNotifyListByCond.TableName + ".CFG_NOTIFY_LIST_BY_COND_DESC";
            public static string CFG_NOTIFY_LIST = CfgNotifyListByCond.TableName + ".CFG_NOTIFY_LIST";
            public static string ACTIVE = CfgNotifyListByCond.TableName + ".ACTIVE";
        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_NOTIFY_LIST_BY_COND_DESC
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CFG_NOTIFY_LIST_BY_COND_DESC)); }
        }

       

        #endregion


        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_NOTIFY_LIST_BY_COND_ID = "CFG_NOTIFY_LIST_BY_COND_ID";
            public static string CFG_NOTIFY_LIST_BY_COND_DESC = "CFG_NOTIFY_LIST_BY_COND_DESC";
            public static string CFG_NOTIFY_LIST = "CFG_NOTIFY_LIST";
            public static string ACTIVE = "ACTIVE";

        }
        #endregion
        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgNotifyListByCond.ColumnNames.CFG_NOTIFY_LIST_BY_COND_ID, "CFG_NOTIFY_LIST_BY_COND_ID");
            map.Add(CfgNotifyListByCond.ColumnNames.CFG_NOTIFY_LIST_BY_COND_DESC, "CFG_NOTIFY_LIST_BY_COND_DESC");
            map.Add(CfgNotifyListByCond.ColumnNames.CFG_NOTIFY_LIST, "CFG_NOTIFY_LIST");
            map.Add(CfgNotifyListByCond.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion

        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_NOTIFY_LIST_BY_COND_ID; }
        }
        #endregion
    }
}
