
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
    public class CfgInternalOrderMasterHis
    {
        public CfgInternalOrderMasterHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_INTERNAL_ORDER_HIS"; }
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
            public static string CFG_INTERNAL_ORDER_HIS_ID = CfgInternalOrderMasterHis.TableName + ".CFG_INTERNAL_ORDER_HIS_ID";
            public static string CFG_INTERNAL_ORDER_HIS_USER_ID = CfgInternalOrderMasterHis.TableName + ".CFG_INTERNAL_ORDER_HIS_USER_ID";
            public static string CFG_INTER_ORDER_HIS_DELEGATE = CfgInternalOrderMasterHis.TableName + ".CFG_INTER_ORDER_HIS_DELEGATE";
            public static string CFG_INTERNAL_ORDER_HIS_DATE = CfgInternalOrderMasterHis.TableName + ".CFG_INTERNAL_ORDER_HIS_DATE";
            public static string CFG_INTERNAL_ORDER_ID = CfgInternalOrderMasterHis.TableName + ".CFG_INTERNAL_ORDER_ID";
            public static string CFG_INTERNAL_ORDER_NAME = CfgInternalOrderMasterHis.TableName + ".CFG_INTERNAL_ORDER_NAME";
            public static string CFG_INTERNAL_ORDER_DESCRIPTION = CfgInternalOrderMasterHis.TableName + ".CFG_INTERNAL_ORDER_DESCRIPTION";
            public static string COMPANY_CODE = CfgInternalOrderMasterHis.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgInternalOrderMasterHis.TableName + ".ACTIVE";

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

        public string Formatted_CFG_INTERNAL_ORDER_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgInternalOrderMasterHis.ColumnNames.CFG_INTERNAL_ORDER_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }

        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgInternalOrderMasterHis.ColumnNames.CFG_INTERNAL_ORDER_HIS_ID, "CFG_INTERNAL_ORDER_HIS_ID");
            map.Add(CfgInternalOrderMasterHis.ColumnNames.CFG_INTERNAL_ORDER_HIS_USER_ID, "CFG_INTERNAL_ORDER_HIS_USER_ID");
            map.Add(CfgInternalOrderMasterHis.ColumnNames.CFG_INTER_ORDER_HIS_DELEGATE, "CFG_INTER_ORDER_HIS_DELEGATE");
            map.Add(CfgInternalOrderMasterHis.ColumnNames.CFG_INTERNAL_ORDER_HIS_DATE, "CFG_INTERNAL_ORDER_HIS_DATE");
            map.Add(CfgInternalOrderMasterHis.ColumnNames.CFG_INTERNAL_ORDER_ID, "CFG_INTERNAL_ORDER_ID");
            map.Add(CfgInternalOrderMasterHis.ColumnNames.CFG_INTERNAL_ORDER_NAME, "CFG_INTERNAL_ORDER_NAME");
            map.Add(CfgInternalOrderMasterHis.ColumnNames.CFG_INTERNAL_ORDER_DESCRIPTION, "CFG_INTERNAL_ORDER_DESCRIPTION");
            map.Add(CfgInternalOrderMasterHis.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgInternalOrderMasterHis.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion
    }
}
