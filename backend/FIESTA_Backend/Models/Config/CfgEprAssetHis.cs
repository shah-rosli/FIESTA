
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
    public class CfgEprAssetHis
    {
        public CfgEprAssetHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_EPR_ASSET_HIS"; }
        }

        #region Properties       

        public decimal CFG_EPR_ASSET_ID { get; set; }
        public string EPR_ASSET_NAME { get; set; }
        public string EPR_ASSET_DESCRIPTION { get; set; }
        public string COMPANY_CODE { get; set; }
        public string ACTIVE { get; set; }

        public TokenProperties? TokenObj { get; set; }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_EPR_ASSET_HIS_ID = CfgEprAssetHis.TableName + ".CFG_EPR_ASSET_HIS_ID";
            public static string CFG_EPR_ASSET_HIS_USER_ID = CfgEprAssetHis.TableName + ".CFG_EPR_ASSET_HIS_USER_ID";
            public static string CFG_EPR_ASSET_HIS_DELEGATE = CfgEprAssetHis.TableName + ".CFG_EPR_ASSET_HIS_DELEGATE";
            public static string CFG_EPR_ASSET_HIS_DATE = CfgEprAssetHis.TableName + ".CFG_EPR_ASSET_HIS_DATE";
            public static string CFG_EPR_ASSET_ID = CfgEprAssetHis.TableName + ".CFG_EPR_ASSET_ID";
            public static string EPR_ASSET_NAME = CfgEprAssetHis.TableName + ".EPR_ASSET_NAME";
            public static string EPR_ASSET_DESCRIPTION = CfgEprAssetHis.TableName + ".EPR_ASSET_DESCRIPTION";
            public static string COMPANY_CODE = CfgEprAssetHis.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgEprAssetHis.TableName + ".ACTIVE";
        }
        #endregion

       

        #region FormattedValueForSqlTransaction        
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_CODE)); }
        }

        public string Formatted_EPR_ASSET_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(EPR_ASSET_NAME)); }
        }

        public string Formatted_EPR_ASSET_DESCRIPTION
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(EPR_ASSET_DESCRIPTION)); }
        }

        public string Formatted_CFG_EPR_ASSET_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgEprAssetHis.ColumnNames.CFG_EPR_ASSET_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgEprAssetHis.ColumnNames.CFG_EPR_ASSET_HIS_ID, "CFG_EPR_ASSET_HIS_ID");
            map.Add(CfgEprAssetHis.ColumnNames.CFG_EPR_ASSET_HIS_USER_ID, "CFG_EPR_ASSET_HIS_USER_ID");
            map.Add(CfgEprAssetHis.ColumnNames.CFG_EPR_ASSET_HIS_DELEGATE, "CFG_EPR_ASSET_HIS_DELEGATE");
            map.Add(CfgEprAssetHis.ColumnNames.CFG_EPR_ASSET_HIS_DATE, "CFG_EPR_ASSET_HIS_DATE");
            map.Add(CfgEprAssetHis.ColumnNames.CFG_EPR_ASSET_ID, "CFG_EPR_ASSET_ID");
            map.Add(CfgEprAssetHis.ColumnNames.EPR_ASSET_NAME, "EPR_ASSET_NAME");
            map.Add(CfgEprAssetHis.ColumnNames.EPR_ASSET_DESCRIPTION, "EPR_ASSET_DESCRIPTION");
            map.Add(CfgEprAssetHis.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgEprAssetHis.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion
    }
}
