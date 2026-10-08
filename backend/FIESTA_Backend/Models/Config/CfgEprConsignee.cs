
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
    public class CfgEprConsignee
    {
        public CfgEprConsignee()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_EPR_CONSIGNEE"; }
        }

        #region Properties       

        public decimal CFG_EPR_CONSIGNEE_ID { get; set; }
        public string EPR_CONSIGNEE_CODE { get; set; }

        public string EPR_CONSIGNEE_NAME { get; set; }
        public string EPR_CONSIGNEE_DESCRIPTION { get; set; }
        public string COMPANY_CODE { get; set; }
        public string ACTIVE { get; set; }
        public TokenProperties? TokenObj { get; set; }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_EPR_CONSIGNEE_ID = CfgEprConsignee.TableName + ".CFG_EPR_CONSIGNEE_ID";
            public static string EPR_CONSIGNEE_CODE = CfgEprConsignee.TableName + ".EPR_CONSIGNEE_CODE";
            public static string EPR_CONSIGNEE_NAME = CfgEprConsignee.TableName + ".EPR_CONSIGNEE_NAME";
            public static string EPR_CONSIGNEE_DESCRIPTION = CfgEprConsignee.TableName + ".EPR_CONSIGNEE_DESCRIPTION";
            public static string COMPANY_CODE = CfgEprConsignee.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgEprConsignee.TableName + ".ACTIVE";
        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_EPR_CONSIGNEE_ID = "CFG_EPR_CONSIGNEE_ID";
            public static string EPR_CONSIGNEE_CODE = "EPR_CONSIGNEE_CODE";
            public static string EPR_CONSIGNEE_NAME = "EPR_CONSIGNEE_NAME";
            public static string EPR_CONSIGNEE_DESCRIPTION = "EPR_CONSIGNEE_DESCRIPTION";
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string ACTIVE = "ACTIVE";

        }
        #endregion

        #region FormattedValueForSqlTransaction        
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_CODE)); }
        }

        public string Formatted_EPR_CONSIGNEE_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(EPR_CONSIGNEE_CODE)); }
        }

        public string Formatted_EPR_CONSIGNEE_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(EPR_CONSIGNEE_NAME)); }
        }

        public string Formatted_EPR_CONSIGNEE_DESCRIPTION
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(EPR_CONSIGNEE_DESCRIPTION)); }
        }
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgEprConsignee.ColumnNames.CFG_EPR_CONSIGNEE_ID, "CFG_EPR_CONSIGNEE_ID");
            map.Add(CfgEprConsignee.ColumnNames.EPR_CONSIGNEE_NAME, "EPR_CONSIGNEE_NAME");
            map.Add(CfgEprConsignee.ColumnNames.EPR_CONSIGNEE_DESCRIPTION, "EPR_CONSIGNEE_DESCRIPTION");
            map.Add(CfgEprConsignee.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgEprConsignee.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion
    }
}
