
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
    public class CfgEprConsigneeHis
    {

        public CfgEprConsigneeHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_EPR_CONSIGNEE_HIS"; }
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
            public static string CFG_EPR_CONSIGNEE_HIS_ID = CfgEprConsigneeHis.TableName + ".CFG_EPR_CONSIGNEE_HIS_ID";
            public static string CFG_EPR_CONSIGNEE_HIS_USER_ID = CfgEprConsigneeHis.TableName + ".CFG_EPR_CONSIGNEE_HIS_USER_ID";
            public static string CFG_EPR_CONSIGNEE_HIS_DELEGATE = CfgEprConsigneeHis.TableName + ".CFG_EPR_CONSIGNEE_HIS_DELEGATE";
            public static string CFG_EPR_CONSIGNEE_HIS_DATE = CfgEprConsigneeHis.TableName + ".CFG_EPR_CONSIGNEE_HIS_DATE";
            public static string CFG_EPR_CONSIGNEE_ID = CfgEprConsigneeHis.TableName + ".CFG_EPR_CONSIGNEE_ID";
            public static string EPR_CONSIGNEE_CODE = CfgEprConsigneeHis.TableName + ".EPR_CONSIGNEE_CODE";
            public static string EPR_CONSIGNEE_NAME = CfgEprConsigneeHis.TableName + ".EPR_CONSIGNEE_NAME";
            public static string EPR_CONSIGNEE_DESCRIPTION = CfgEprConsigneeHis.TableName + ".EPR_CONSIGNEE_DESCRIPTION";
            public static string COMPANY_CODE = CfgEprConsigneeHis.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgEprConsigneeHis.TableName + ".ACTIVE";
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

        public string Formatted_CFG_EPR_CONSIGNEE_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgEprConsigneeHis.ColumnNames.CFG_EPR_CONSIGNEE_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgEprConsigneeHis.ColumnNames.CFG_EPR_CONSIGNEE_HIS_ID, "CFG_EPR_CONSIGNEE_HIS_ID");
            map.Add(CfgEprConsigneeHis.ColumnNames.CFG_EPR_CONSIGNEE_HIS_USER_ID, "CFG_EPR_CONSIGNEE_HIS_USER_ID");
            map.Add(CfgEprConsigneeHis.ColumnNames.CFG_EPR_CONSIGNEE_HIS_DELEGATE, "CFG_EPR_CONSIGNEE_HIS_DELEGATE");
            map.Add(CfgEprConsigneeHis.ColumnNames.CFG_EPR_CONSIGNEE_HIS_DATE, "CFG_EPR_CONSIGNEE_HIS_DATE");
            map.Add(CfgEprConsigneeHis.ColumnNames.CFG_EPR_CONSIGNEE_ID, "CFG_EPR_CONSIGNEE_ID");
            map.Add(CfgEprConsigneeHis.ColumnNames.EPR_CONSIGNEE_NAME, "EPR_CONSIGNEE_NAME");
            map.Add(CfgEprConsigneeHis.ColumnNames.EPR_CONSIGNEE_DESCRIPTION, "EPR_CONSIGNEE_DESCRIPTION");
            map.Add(CfgEprConsigneeHis.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgEprConsigneeHis.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion
    }
}
