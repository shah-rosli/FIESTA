
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
    public class CfgPlantHis
    {
        public CfgPlantHis()
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
            get { return "CFG_PLANT_HIS"; }
        }
        #endregion
        #region Properties
        public decimal CFG_PLANT_ID { get; set; }
        public string COMPANY_CODE { get; set; }
        public string CFG_PLANT_NAME { get; set; }
        public string CFG_PLANT_DESCRIPTION { get; set; }
        public string ACTIVE { get; set; }

        public string CTRY_CODE { get; set; }
        public TokenProperties? TokenObj { get; set; }

        public System.Data.EnumerableRowCollection enStorage { get; set; }


        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_PLANT_HIS_ID = CfgPlantHis.TableName + ".CFG_PLANT_HIS_ID";
            public static string CFG_PLANT_HIS_USER_ID = CfgPlantHis.TableName + ".CFG_PLANT_HIS_USER_ID";
            public static string CFG_PLANT_HIS_DELEGATE = CfgPlantHis.TableName + ".CFG_PLANT_HIS_DELEGATE";
            public static string CFG_PLANT_HIS_DATE = CfgPlantHis.TableName + ".CFG_PLANT_HIS_DATE";
            public static string CFG_PLANT_ID = CfgPlantHis.TableName + ".CFG_PLANT_ID";
            public static string COMPANY_CODE = CfgPlantHis.TableName + ".COMPANY_CODE";
            public static string CFG_PLANT_NAME = CfgPlantHis.TableName + ".CFG_PLANT_NAME";
            public static string CFG_PLANT_DESCRIPTION = CfgPlantHis.TableName + ".CFG_PLANT_DESCRIPTION";
            public static string ACTIVE = CfgPlantHis.TableName + ".ACTIVE";
            public static string CTRY_CODE = CfgPlantHis.TableName + ".CTRY_CODE";
        }
        #endregion
      
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgPlantHis.ColumnNames.CFG_PLANT_HIS_ID, "CFG_PLANT_HIS_ID");
            map.Add(CfgPlantHis.ColumnNames.CFG_PLANT_HIS_USER_ID, "CFG_PLANT_HIS_USER_ID");
            map.Add(CfgPlantHis.ColumnNames.CFG_PLANT_HIS_DELEGATE, "CFG_PLANT_HIS_DELEGATE");
            map.Add(CfgPlantHis.ColumnNames.CFG_PLANT_HIS_DATE, "CFG_PLANT_HIS_DATE");
            map.Add(CfgPlantHis.ColumnNames.CFG_PLANT_ID, "CFG_PLANT_ID");
            map.Add(CfgPlantHis.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgPlantHis.ColumnNames.CFG_PLANT_NAME, "CFG_PLANT_NAME");
            map.Add(CfgPlantHis.ColumnNames.CFG_PLANT_DESCRIPTION, "CFG_PLANT_DESCRIPTION");
            map.Add(CfgPlantHis.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgPlantHis.ColumnNames.CTRY_CODE, "CTRY_CODE");
            return map;
        }
        #endregion
      
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_PLANT_ID
        {
            get { return string.Format("'{0}'", CFG_PLANT_ID); }
        }
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(COMPANY_CODE)); }
        }
        public string Formatted_CFG_PLANT_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(CFG_PLANT_NAME)); }
        }
        public string Formatted_CFG_PLANT_DESCRIPTION
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(CFG_PLANT_DESCRIPTION)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
        }
        public string Formatted_CTRY_CODE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(CTRY_CODE)); }
        }
        public string Formatted_CFG_PLANT_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgPlantHis.ColumnNames.CFG_PLANT_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion

    }
}
