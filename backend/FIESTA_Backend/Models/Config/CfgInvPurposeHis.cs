
using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Threading.Tasks;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgInvPurposeHis
    {
        public CfgInvPurposeHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region TableName
        public static string TableName
        {
            get { return "CFG_INV_PURPOSE_HIS"; }
        }
        #endregion
        #region Properties
        public decimal CFG_INV_OPR_PURPOSE_ID { get; set; }
        public decimal CFG_INV_OPR_PURPOSE_HIS_ID { get; set; }
        public string GLOBAL_DIV { get; set; }
        public string INV_PURPOSE { get; set; }

        public decimal CFG_DIVISION_HIS_ID { get; set; }


        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_INV_OPR_PURPOSE_ID = CfgInvPurposeHis.TableName + ".CFG_INV_OPR_PURPOSE_ID";
            public static string CFG_DIVISION_HIS_ID = CfgInvPurposeHis.TableName + ".CFG_DIVISION_HIS_ID";
            public static string CFG_INV_OPR_PURPOSE_HIS_ID = CfgInvPurposeHis.TableName + ".CFG_INV_OPR_PURPOSE_HIS_ID";
            public static string GLOBAL_DIV = CfgInvPurposeHis.TableName + ".GLOBAL_DIV";
            public static string INV_PURPOSE = CfgInvPurposeHis.TableName + ".INV_PURPOSE";

        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_INV_OPR_PURPOSE_ID = "CFG_INV_OPR_PURPOSE_ID";
            public static string CFG_DIVISION_HIS_ID = "CFG_DIVISION_HIS_ID";
            public static string CFG_INV_OPR_PURPOSE_HIS_ID = "CFG_INV_OPR_PURPOSE_HIS_ID";
            public static string GLOBAL_DIV = "GLOBAL_DIV";
            public static string INV_PURPOSE = "INV_PURPOSE";

        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgInvPurposeHis.ColumnNames.CFG_INV_OPR_PURPOSE_HIS_ID, "CFG_INV_OPR_PURPOSE_HIS_ID");
            map.Add(CfgInvPurposeHis.ColumnNames.CFG_DIVISION_HIS_ID, "CFG_DIVISION_HIS_ID");
            map.Add(CfgInvPurposeHis.ColumnNames.CFG_INV_OPR_PURPOSE_ID, "CFG_INV_OPR_PURPOSE_ID");
            map.Add(CfgInvPurposeHis.ColumnNames.GLOBAL_DIV, "GLOBAL_DIV");
            map.Add(CfgInvPurposeHis.ColumnNames.INV_PURPOSE, "INV_PURPOSE");
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
