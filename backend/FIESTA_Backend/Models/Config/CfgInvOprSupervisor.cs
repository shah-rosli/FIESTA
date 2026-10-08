
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
    public class CfgInvOprSupervisor
    {
        public CfgInvOprSupervisor()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region TableName
        public static string TableName
        {
            get { return "CFG_INV_OPR_SUPERVISOR"; }
        }
        #endregion
        #region Properties
        public decimal CFG_INV_OPR_SUPERVISOR_ID { get; set; }
        public string GLOBAL_DIV { get; set; }
        public string OPR_SUPERVISOR { get; set; }
     
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_INV_OPR_SUPERVISOR_ID = CfgInvOprSupervisor.TableName + ".CFG_INV_OPR_SUPERVISOR_ID";
            public static string GLOBAL_DIV = CfgInvOprSupervisor.TableName + ".GLOBAL_DIV";
            public static string OPR_SUPERVISOR = CfgInvOprSupervisor.TableName + ".OPR_SUPERVISOR";
           
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_INV_OPR_SUPERVISOR_ID = "CFG_INV_OPR_SUPERVISOR_ID";
            public static string GLOBAL_DIV = "GLOBAL_DIV";
            public static string OPR_SUPERVISOR = "OPR_SUPERVISOR";
            
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgInvOprSupervisor.ColumnNames.CFG_INV_OPR_SUPERVISOR_ID, "CFG_INV_OPR_SUPERVISOR_ID");
            map.Add(CfgInvOprSupervisor.ColumnNames.GLOBAL_DIV, "GLOBAL_DIV");
            map.Add(CfgInvOprSupervisor.ColumnNames.OPR_SUPERVISOR, "OPR_SUPERVISOR");           
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
