
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
    public class CfgEprDirectDelivery
    {
        public CfgEprDirectDelivery()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string TableName
        {
            get { return "CFG_EPR_DIRECT_DELIVERY"; }
        }
        public decimal CFG_EPR_DIRECT_DELIVERY_ID { get; set; }
        public string EPR_DIRECT_DELIVERY_NAME { get; set; }
        public string EPR_DIRECT_DELIVERY_DESC { get; set; }
        public string ACTIVE { get; set; }
        public string COMPANY_CODE { get; set; }

        public struct DirectDelivery_Status
        {
            public static string Active = "Yes";
            public static string NonActive = "No ";
        }

        public TokenProperties? TokenObj { get; set; }

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_EPR_DIRECT_DELIVERY_ID = CfgEprDirectDelivery.TableName + ".CFG_EPR_DIRECT_DELIVERY_ID";
            public static string EPR_DIRECT_DELIVERY_NAME = CfgEprDirectDelivery.TableName + ".EPR_DIRECT_DELIVERY_NAME";
            public static string EPR_DIRECT_DELIVERY_DESC = CfgEprDirectDelivery.TableName + ".EPR_DIRECT_DELIVERY_DESC";
            public static string ACTIVE = CfgEprDirectDelivery.TableName + ".ACTIVE";
            public static string COMPANY_CODE = CfgEprDirectDelivery.TableName + ".COMPANY_CODE";
        }

        public class ColumnNamesOnly
        {
            public static string CFG_EPR_DIRECT_DELIVERY_ID = "CFG_EPR_DIRECT_DELIVERY_ID";
            public static string EPR_DIRECT_DELIVERY_NAME = "EPR_DIRECT_DELIVERY_NAME";
            public static string EPR_DIRECT_DELIVERY_DESC = "EPR_DIRECT_DELIVERY_DESC";
            public static string ACTIVE = "ACTIVE";
            public static string COMPANY_CODE = "COMPANY_CODE";

        }

        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgEprDirectDelivery.ColumnNames.CFG_EPR_DIRECT_DELIVERY_ID, "CFG_EPR_DIRECT_DELIVERY_ID");
            map.Add(CfgEprDirectDelivery.ColumnNames.EPR_DIRECT_DELIVERY_NAME, "EPR_DIRECT_DELIVERY_NAME");
            map.Add(CfgEprDirectDelivery.ColumnNames.EPR_DIRECT_DELIVERY_DESC, "EPR_DIRECT_DELIVERY_DESC");
            map.Add(CfgEprDirectDelivery.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgEprDirectDelivery.ColumnNames.COMPANY_CODE, "ACTIVE");

            return map;
        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_EPR_DIRECT_DELIVERY_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(EPR_DIRECT_DELIVERY_NAME)); }
        }
        public string Formatted_EPR_DIRECT_DELIVERY_DESC
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(EPR_DIRECT_DELIVERY_DESC)); }
        }
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_CODE)); }
        }


        #endregion

    }
}
