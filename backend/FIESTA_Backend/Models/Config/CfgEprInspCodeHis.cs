
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
    public class CfgEprInspCodeHis
    {
        public CfgEprInspCodeHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region static variable
        #endregion
        #region TableName
        public static string TableName
        {
            get { return "CFG_EPR_INSP_CODE_HIS"; }
        }
        #endregion
        #region Properties
        public decimal CFG_EPR_INSP_CODE_ID { get; set; }
        public string EPR_INSP_CODE_NAME { get; set; }
        public string EPR_INSP_CODE_DESCRIPTION { get; set; }
        public string ACTIVE { get; set; }

        public TokenProperties? TokenObj { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_EPR_INSP_CODE_HIS_ID = CfgEprInspCodeHis.TableName + ".CFG_EPR_INSP_CODE_HIS_ID";
            public static string CFG_EPR_INSP_CODE_HIS_USER_ID = CfgEprInspCodeHis.TableName + ".CFG_EPR_INSP_CODE_HIS_USER_ID";
            public static string CFG_EPR_INSP_CODE_HIS_DELEGATE = CfgEprInspCodeHis.TableName + ".CFG_EPR_INSP_CODE_HIS_DELEGATE";
            public static string CFG_EPR_INSP_CODE_HIS_DATE = CfgEprInspCodeHis.TableName + ".CFG_EPR_INSP_CODE_HIS_DATE";
            public static string CFG_EPR_INSP_CODE_ID = CfgEprInspCodeHis.TableName + ".CFG_EPR_INSP_CODE_ID";
            public static string EPR_INSP_CODE_NAME = CfgEprInspCodeHis.TableName + ".EPR_INSP_CODE_NAME";
            public static string EPR_INSP_CODE_DESCRIPTION = CfgEprInspCodeHis.TableName + ".EPR_INSP_CODE_DESCRIPTION";
            public static string ACTIVE = CfgEprInspCodeHis.TableName + ".ACTIVE";
        }
        #endregion
       
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgEprInspCodeHis.ColumnNames.CFG_EPR_INSP_CODE_HIS_ID, "CFG_EPR_INSP_CODE_HIS_ID");
            map.Add(CfgEprInspCodeHis.ColumnNames.CFG_EPR_INSP_CODE_HIS_USER_ID, "CFG_EPR_INSP_CODE_HIS_USER_ID");
            map.Add(CfgEprInspCodeHis.ColumnNames.CFG_EPR_INSP_CODE_HIS_DELEGATE, "CFG_EPR_INSP_CODE_HIS_DELEGATE");
            map.Add(CfgEprInspCodeHis.ColumnNames.CFG_EPR_INSP_CODE_HIS_DATE, "CFG_EPR_INSP_CODE_HIS_DATE");
            map.Add(CfgEprInspCodeHis.ColumnNames.CFG_EPR_INSP_CODE_ID, "CFG_EPR_INSP_CODE_ID");
            map.Add(CfgEprInspCodeHis.ColumnNames.EPR_INSP_CODE_NAME, "EPR_INSP_CODE_NAME");
            map.Add(CfgEprInspCodeHis.ColumnNames.EPR_INSP_CODE_DESCRIPTION, "EPR_INSP_CODE_DESCRIPTION");
            map.Add(CfgEprInspCodeHis.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_EPR_INSP_CODE_ID
        {
            get { return string.Format("'{0}'", CFG_EPR_INSP_CODE_ID); }
        }
        public string Formatted_EPR_INSP_CODE_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(EPR_INSP_CODE_NAME)); }
        }
        public string Formatted_EPR_INSP_CODE_DESCRIPTION
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(EPR_INSP_CODE_DESCRIPTION)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
        }
        public string Formatted_CFG_EPR_INSP_CODE_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgEprInspCodeHis.ColumnNames.CFG_EPR_INSP_CODE_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion
    }
}
