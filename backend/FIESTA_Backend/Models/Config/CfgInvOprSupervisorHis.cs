using System;

using FIESTA_Backend.Models;
using System;
using System.Collections;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgInvOprSupervisorHis
    {
        public CfgInvOprSupervisorHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region TableName
        public static string TableName
        {
            get { return "CFG_INV_OPR_SUPERVISOR_HIS"; }
        }
        #endregion
        #region Properties
        public decimal CFG_INV_OPR_SUPERVISOR_ID { get; set; }
        public decimal CFG_INV_OPR_SUPERVISOR_HIS_ID { get; set; }
        public string GLOBAL_DIV { get; set; }
        public string OPR_SUPERVISOR { get; set; }

        public decimal CFG_DIVISION_HIS_ID { get; set; }
        

        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_INV_OPR_SUPERVISOR_ID = CfgInvOprSupervisorHis.TableName + ".CFG_INV_OPR_SUPERVISOR_ID";
            public static string CFG_DIVISION_HIS_ID = CfgInvOprSupervisorHis.TableName + ".CFG_DIVISION_HIS_ID";
            public static string CFG_INV_OPR_SUPERVISOR_HIS_ID = CfgInvOprSupervisorHis.TableName + ".CFG_INV_OPR_SUPERVISOR_HIS_ID";
            public static string GLOBAL_DIV = CfgInvOprSupervisorHis.TableName + ".GLOBAL_DIV";
            public static string OPR_SUPERVISOR = CfgInvOprSupervisorHis.TableName + ".OPR_SUPERVISOR";

        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_INV_OPR_SUPERVISOR_ID = "CFG_INV_OPR_SUPERVISOR_ID";
            public static string CFG_DIVISION_HIS_ID = "CFG_DIVISION_HIS_ID";
            public static string CFG_INV_OPR_SUPERVISOR_HIS_ID = "CFG_INV_OPR_SUPERVISOR_HIS_ID";
            public static string GLOBAL_DIV = "GLOBAL_DIV";
            public static string OPR_SUPERVISOR = "OPR_SUPERVISOR";

        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgInvOprSupervisorHis.ColumnNames.CFG_INV_OPR_SUPERVISOR_HIS_ID, "CFG_INV_OPR_SUPERVISOR_HIS_ID");
            map.Add(CfgInvOprSupervisorHis.ColumnNames.CFG_DIVISION_HIS_ID, "CFG_DIVISION_HIS_ID");
            map.Add(CfgInvOprSupervisorHis.ColumnNames.CFG_INV_OPR_SUPERVISOR_ID, "CFG_INV_OPR_SUPERVISOR_ID");
            map.Add(CfgInvOprSupervisorHis.ColumnNames.GLOBAL_DIV, "GLOBAL_DIV");
            map.Add(CfgInvOprSupervisorHis.ColumnNames.OPR_SUPERVISOR, "OPR_SUPERVISOR");
            return map;
        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_GLOBAL_DIV
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(GLOBAL_DIV)); }
        }
        public string Formatted_OPR_SUPERVISOR
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(OPR_SUPERVISOR)); }
        }

        #endregion
    }
}
