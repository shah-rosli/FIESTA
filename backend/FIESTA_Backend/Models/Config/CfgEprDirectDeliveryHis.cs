
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
    public class CfgEprDirectDeliveryHis
    {
        public CfgEprDirectDeliveryHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string TableName
        {
            get { return "CFG_EPR_DIRECT_DELIVERY_HIS"; }
        }
        public decimal CFG_EPR_DIRECT_DELIVERY_ID { get; set; }
        public string EPR_DIRECT_DELIVERY_NAME { get; set; }
        public string EPR_DIRECT_DELIVERY_DESC { get; set; }
        public string ACTIVE { get; set; }
        public string COMPANY_CODE { get; set; }

        public TokenProperties? TokenObj { get; set; }



        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_EPR_DIRECT_DELIVERY_HIS_ID = CfgEprDirectDeliveryHis.TableName + ".CFG_EPR_DIRECT_DELIVERY_HIS_ID";
            public static string CFG_DIR_DELIVERY_HIS_USER_ID = CfgEprDirectDeliveryHis.TableName + ".CFG_DIR_DELIVERY_HIS_USER_ID";
            public static string CFG_DIR_DELIVERY_HIS_DELEGATE = CfgEprDirectDeliveryHis.TableName + ".CFG_DIR_DELIVERY_HIS_DELEGATE";
            public static string CFG_DIR_DELIVERY_HIS_DATE = CfgEprDirectDeliveryHis.TableName + ".CFG_DIR_DELIVERY_HIS_DATE";
            public static string CFG_EPR_DIRECT_DELIVERY_ID = CfgEprDirectDeliveryHis.TableName + ".CFG_EPR_DIRECT_DELIVERY_ID";
            public static string EPR_DIRECT_DELIVERY_NAME = CfgEprDirectDeliveryHis.TableName + ".EPR_DIRECT_DELIVERY_NAME";
            public static string EPR_DIRECT_DELIVERY_DESC = CfgEprDirectDeliveryHis.TableName + ".EPR_DIRECT_DELIVERY_DESC";
            public static string ACTIVE = CfgEprDirectDeliveryHis.TableName + ".ACTIVE";
            public static string COMPANY_CODE = CfgEprDirectDeliveryHis.TableName + ".COMPANY_CODE";
        }

        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgEprDirectDeliveryHis.ColumnNames.CFG_EPR_DIRECT_DELIVERY_ID, "CFG_EPR_DIRECT_DELIVERY_HIS_ID");
            map.Add(CfgEprDirectDeliveryHis.ColumnNames.CFG_DIR_DELIVERY_HIS_USER_ID, "CFG_DIR_DELIVERY_HIS_USER_ID");
            map.Add(CfgEprDirectDeliveryHis.ColumnNames.CFG_DIR_DELIVERY_HIS_DELEGATE, "CFG_DIR_DELIVERY_HIS_DELEGATE");
            map.Add(CfgEprDirectDeliveryHis.ColumnNames.CFG_DIR_DELIVERY_HIS_DATE, "CFG_DIR_DELIVERY_HIS_DATE");
            map.Add(CfgEprDirectDeliveryHis.ColumnNames.CFG_EPR_DIRECT_DELIVERY_ID, "CFG_EPR_DIRECT_DELIVERY_ID");
            map.Add(CfgEprDirectDeliveryHis.ColumnNames.EPR_DIRECT_DELIVERY_NAME, "EPR_DIRECT_DELIVERY_NAME");
            map.Add(CfgEprDirectDeliveryHis.ColumnNames.EPR_DIRECT_DELIVERY_DESC, "EPR_DIRECT_DELIVERY_DESC");
            map.Add(CfgEprDirectDeliveryHis.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgEprDirectDeliveryHis.ColumnNames.COMPANY_CODE, "ACTIVE");

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
        public string Formatted_CFG_DIR_DELIVERY_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgEprDirectDeliveryHis.ColumnNames.CFG_DIR_DELIVERY_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }

        #endregion
    }
}
