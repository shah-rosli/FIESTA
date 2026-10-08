
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
    public class CfgEprAsset
    {

        public CfgEprAsset()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_EPR_ASSET"; }
        }

        #region Properties       

        public decimal CFG_EPR_ASSET_ID { get; set; }
        public string EPR_ASSET_NAME { get; set; }
        public string EPR_ASSET_DESCRIPTION { get; set; }
        public string COMPANY_CODE { get; set; }
        public string ACTIVE { get; set; }
        public string USER_ID { get; set; }
        public TokenProperties? TokenObj { get; set; }

        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_EPR_ASSET_ID = CfgEprAsset.TableName + ".CFG_EPR_ASSET_ID";
            public static string EPR_ASSET_NAME = CfgEprAsset.TableName + ".EPR_ASSET_NAME";
            public static string EPR_ASSET_DESCRIPTION = CfgEprAsset.TableName + ".EPR_ASSET_DESCRIPTION";
            public static string COMPANY_CODE = CfgEprAsset.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgEprAsset.TableName + ".ACTIVE";
        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_EPR_ASSET_ID = "CFG_EPR_ASSET_ID";
            public static string EPR_ASSET_NAME = "EPR_ASSET_NAME";
            public static string EPR_ASSET_DESCRIPTION = "EPR_ASSET_DESCRIPTION";
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string ACTIVE = "ACTIVE";

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
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgEprAsset.ColumnNames.CFG_EPR_ASSET_ID, "CFG_DEPARTMENT_ID");
            map.Add(CfgEprAsset.ColumnNames.EPR_ASSET_NAME, "EPR_ASSET_NAME");           
            map.Add(CfgEprAsset.ColumnNames.EPR_ASSET_DESCRIPTION, "EPR_ASSET_DESCRIPTION");
            map.Add(CfgEprAsset.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgEprAsset.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion
    }
}
