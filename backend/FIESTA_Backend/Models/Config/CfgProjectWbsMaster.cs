
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
    public class CfgProjectWbsMaster
    {
        public CfgProjectWbsMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_PROJECT_WBS_MASTER"; }
        }

        #region Properties       

        public decimal CFG_WBS_PROJECT_ID { get; set; }
        public string CFG_WBS_PROJECT_NAME { get; set; }
        public string CFG_WBS_PROJECT_DESCRIPTION { get; set; }
        public string COMPANY_CODE { get; set; }      
        public string ACTIVE { get; set; }

        public string USER_ID { get; set; }

        public TokenProperties? TokenObj { get; set; }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_WBS_PROJECT_ID = CfgProjectWbsMaster.TableName + ".CFG_WBS_PROJECT_ID";
            public static string CFG_WBS_PROJECT_NAME = CfgProjectWbsMaster.TableName + ".CFG_WBS_PROJECT_NAME";
            public static string CFG_WBS_PROJECT_DESCRIPTION = CfgProjectWbsMaster.TableName + ".CFG_WBS_PROJECT_DESCRIPTION";
            public static string COMPANY_CODE = CfgProjectWbsMaster.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgProjectWbsMaster.TableName + ".ACTIVE";

        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_WBS_PROJECT_ID = "CFG_WBS_PROJECT_ID";
            public static string CFG_WBS_PROJECT_NAME = "CFG_WBS_PROJECT_NAME";
            public static string CFG_WBS_PROJECT_DESCRIPTION = "CFG_WBS_PROJECT_DESCRIPTION";
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string ACTIVE = "ACTIVE";

        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_WBS_PROJECT_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CFG_WBS_PROJECT_NAME)); }
        }
        public string Formatted_CFG_WBS_PROJECT_DESCRIPTION
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CFG_WBS_PROJECT_DESCRIPTION)); }
        }
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_CODE)); }
        }
        
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgProjectWbsMaster.ColumnNames.CFG_WBS_PROJECT_ID, "CFG_WBS_PROJECT_ID");
            map.Add(CfgProjectWbsMaster.ColumnNames.CFG_WBS_PROJECT_NAME, "CFG_WBS_PROJECT_NAME");
            map.Add(CfgProjectWbsMaster.ColumnNames.CFG_WBS_PROJECT_DESCRIPTION, "CFG_WBS_PROJECT_DESCRIPTION");
            map.Add(CfgProjectWbsMaster.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgProjectWbsMaster.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion


       
    }
}