
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgStorageHis
    {
        public CfgStorageHis()
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
            get { return "CFG_STORAGE_HIS"; }
        }
        #endregion
        #region Properties
        public decimal CFG_STORAGE_ID { get; set; }
        public decimal CFG_PLANT_ID { get; set; }
        public string CFG_STORAGE_NAME { get; set; }
        public string CFG_STORAGE_DESCRIPTION { get; set; }
        public string ACTIVE { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_STORAGE_HIS_ID = CfgStorageHis.TableName + ".CFG_STORAGE_HIS_ID";
            public static string CFG_STORAGE_HIS_USER_ID = CfgStorageHis.TableName + ".CFG_STORAGE_HIS_USER_ID";
            public static string CFG_STORAGE_HIS_DELEGATE = CfgStorageHis.TableName + ".CFG_STORAGE_HIS_DELEGATE";
            public static string CFG_STORAGE_HIS_DATE = CfgStorageHis.TableName + ".CFG_STORAGE_HIS_DATE";            
            public static string CFG_STORAGE_ID = CfgStorageHis.TableName + ".CFG_STORAGE_ID";
            public static string CFG_PLANT_ID = CfgStorageHis.TableName + ".CFG_PLANT_ID";
            public static string CFG_STORAGE_NAME = CfgStorageHis.TableName + ".CFG_STORAGE_NAME";
            public static string CFG_STORAGE_DESCRIPTION = CfgStorageHis.TableName + ".CFG_STORAGE_DESCRIPTION";
            public static string ACTIVE = CfgStorageHis.TableName + ".ACTIVE";
        }
        #endregion
        
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgStorageHis.ColumnNames.CFG_STORAGE_HIS_ID, "CFG_STORAGE_HIS_ID");
            map.Add(CfgStorageHis.ColumnNames.CFG_STORAGE_HIS_USER_ID, "CFG_STORAGE_HIS_USER_ID");
            map.Add(CfgStorageHis.ColumnNames.CFG_STORAGE_HIS_DELEGATE, "CFG_STORAGE_HIS_DELEGATE");
            map.Add(CfgStorageHis.ColumnNames.CFG_STORAGE_HIS_DATE, "CFG_STORAGE_HIS_DATE");
            map.Add(CfgStorageHis.ColumnNames.CFG_STORAGE_ID, "CFG_STORAGE_ID");
            map.Add(CfgStorageHis.ColumnNames.CFG_PLANT_ID, "CFG_PLANT_ID");
            map.Add(CfgStorageHis.ColumnNames.CFG_STORAGE_NAME, "CFG_STORAGE_NAME");
            map.Add(CfgStorageHis.ColumnNames.CFG_STORAGE_DESCRIPTION, "CFG_STORAGE_DESCRIPTION");
            map.Add(CfgStorageHis.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }
        #endregion
       
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_STORAGE_ID
        {
            get { return string.Format("'{0}'", CFG_STORAGE_ID); }
        }
        public string Formatted_CFG_PLANT_ID
        {
            get { return string.Format("'{0}'", CFG_PLANT_ID); }
        }
        public string Formatted_CFG_STORAGE_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(CFG_STORAGE_NAME)); }
        }
        public string Formatted_CFG_STORAGE_DESCRIPTION
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(CFG_STORAGE_DESCRIPTION)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
        }
        #endregion
      
    }
}
