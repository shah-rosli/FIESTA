
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
    public class CfgInternalOrderMaster
    {
        public CfgInternalOrderMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_INTERNAL_ORDER_MASTER"; }
        }

        #region Properties       

        public decimal CFG_INTERNAL_ORDER_ID { get; set; }
        public string CFG_INTERNAL_ORDER_NAME { get; set; }
        public string CFG_INTERNAL_ORDER_DESCRIPTION { get; set; }
        public string COMPANY_CODE { get; set; }      
        public string ACTIVE { get; set; }

        public string USER_ID { get; set; }

        public TokenProperties? TokenObj { get; set; }

        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_INTERNAL_ORDER_ID = CfgInternalOrderMaster.TableName + ".CFG_INTERNAL_ORDER_ID";
            public static string CFG_INTERNAL_ORDER_NAME = CfgInternalOrderMaster.TableName + ".CFG_INTERNAL_ORDER_NAME";
            public static string CFG_INTERNAL_ORDER_DESCRIPTION = CfgInternalOrderMaster.TableName + ".CFG_INTERNAL_ORDER_DESCRIPTION";
            public static string COMPANY_CODE = CfgInternalOrderMaster.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgInternalOrderMaster.TableName + ".ACTIVE";

        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_INTERNAL_ORDER_ID = "CFG_INTERNAL_ORDER_ID";
            public static string CFG_INTERNAL_ORDER_NAME = "CFG_INTERNAL_ORDER_NAME";
            public static string CFG_INTERNAL_ORDER_DESCRIPTION = "CFG_INTERNAL_ORDER_DESCRIPTION";
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string ACTIVE = "ACTIVE";

        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_INTERNAL_ORDER_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CFG_INTERNAL_ORDER_NAME)); }
        }
        public string Formatted_CFG_INTERNAL_ORDER_DESCRIPTION
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CFG_INTERNAL_ORDER_DESCRIPTION)); }
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
            map.Add(CfgInternalOrderMaster.ColumnNames.CFG_INTERNAL_ORDER_ID, "CFG_INTERNAL_ORDER_ID");
            map.Add(CfgInternalOrderMaster.ColumnNames.CFG_INTERNAL_ORDER_NAME, "CFG_INTERNAL_ORDER_NAME");
            map.Add(CfgInternalOrderMaster.ColumnNames.CFG_INTERNAL_ORDER_DESCRIPTION, "CFG_INTERNAL_ORDER_DESCRIPTION");
            map.Add(CfgInternalOrderMaster.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgInternalOrderMaster.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion


       
    }
}