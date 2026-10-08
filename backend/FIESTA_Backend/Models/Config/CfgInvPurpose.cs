
using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Threading.Tasks;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgInvPurpose
    {
        public CfgInvPurpose()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region TableName
        public static string TableName
        {
            get { return "CFG_INV_PURPOSE"; }
        }
        #endregion
        #region Properties
        public decimal CFG_INV_OPR_PURPOSE_ID { get; set; }
        public string GLOBAL_DIV { get; set; }
        public string INV_PURPOSE { get; set; }

        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_INV_OPR_PURPOSE_ID = CfgInvPurpose.TableName + ".CFG_INV_OPR_PURPOSE_ID";
            public static string GLOBAL_DIV = CfgInvPurpose.TableName + ".GLOBAL_DIV";
            public static string INV_PURPOSE = CfgInvPurpose.TableName + ".INV_PURPOSE";

        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_INV_OPR_PURPOSE_ID = "CFG_INV_OPR_PURPOSE_ID";
            public static string GLOBAL_DIV = "GLOBAL_DIV";
            public static string INV_PURPOSE = "INV_PURPOSE";

        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgInvPurpose.ColumnNames.CFG_INV_OPR_PURPOSE_ID, "CFG_INV_OPR_PURPOSE_ID");
            map.Add(CfgInvPurpose.ColumnNames.GLOBAL_DIV, "GLOBAL_DIV");
            map.Add(CfgInvPurpose.ColumnNames.INV_PURPOSE, "INV_PURPOSE");
            return map;
        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_GLOBAL_DIV
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(GLOBAL_DIV)); }
        }
        public string Formatted_INV_PURPOSE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(INV_PURPOSE)); }
        }

        #endregion
    }
}
