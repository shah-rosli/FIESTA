
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
    public class CfgEprCatalogMasterHis
    {
        public CfgEprCatalogMasterHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_EPR_CATALOG_MASTER_HIS"; }
        }

        #region Properties       

        public decimal CFG_EPR_CATALOG_ID { get; set; }
        public string SAP_SUPPLIER_ID { get; set; }
        public string SHORT_NAME { get; set; }
        public string SUPPLIER_PART_ID { get; set; }
        public string MANUFACTURING_PART_ID { get; set; }
        public string ITEM_DESCRIPTION { get; set; }
        public decimal UNIT_PRICE { get; set; }
        public string UNIT_OF_MEASUREMENT_NAME { get; set; }
        public string CURRENCY_NAME { get; set; }
        public decimal PRICE_UNIT_QUANTITY { get; set; }
        public string PRICE_UNIT { get; set; }
        public decimal UNIT_CONVERSION { get; set; }
        public string ACTIVE { get; set; }
        public string SUPPLIER_PART_AUX_ID { get; set; }
        public string CLASSIFICATION_CODES { get; set; }
        public TokenProperties? TokenObj { get; set; }




        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_EPR_CATALOG_MASTER_HIS = CfgEprCatalogMasterHis.TableName + ".CFG_EPR_CATALOG_MASTER_HIS";
            public static string EPR_CATALOG_MASTER_HIS_USER_ID = CfgEprCatalogMasterHis.TableName + ".EPR_CATALOG_MASTER_HIS_USER_ID";
            public static string EPR_CAT_MASTER_HIS_DELEGATE = CfgEprCatalogMasterHis.TableName + ".EPR_CAT_MASTER_HIS_DELEGATE";
            public static string EPR_CATALOG_MASTER_HIS_DATE = CfgEprCatalogMasterHis.TableName + ".EPR_CATALOG_MASTER_HIS_DATE";
            public static string CFG_EPR_CATALOG_ID = CfgEprCatalogMasterHis.TableName + ".CFG_EPR_CATALOG_ID";
            public static string SAP_SUPPLIER_ID = CfgEprCatalogMasterHis.TableName + ".SAP_SUPPLIER_ID";
            public static string SHORT_NAME = CfgEprCatalogMasterHis.TableName + ".SHORT_NAME";
            public static string SUPPLIER_PART_ID = CfgEprCatalogMasterHis.TableName + ".SUPPLIER_PART_ID";
            public static string MANUFACTURING_PART_ID = CfgEprCatalogMasterHis.TableName + ".MANUFACTURING_PART_ID";
            public static string ITEM_DESCRIPTION = CfgEprCatalogMasterHis.TableName + ".ITEM_DESCRIPTION";
            public static string UNIT_PRICE = CfgEprCatalogMasterHis.TableName + ".UNIT_PRICE";
            public static string UNIT_OF_MEASUREMENT_NAME = CfgEprCatalogMasterHis.TableName + ".UNIT_OF_MEASUREMENT_NAME";
            public static string CURRENCY_NAME = CfgEprCatalogMasterHis.TableName + ".CURRENCY_NAME";
            public static string PRICE_UNIT_QUANTITY = CfgEprCatalogMasterHis.TableName + ".PRICE_UNIT_QUANTITY";
            public static string PRICE_UNIT = CfgEprCatalogMasterHis.TableName + ".PRICE_UNIT";
            public static string UNIT_CONVERSION = CfgEprCatalogMasterHis.TableName + ".UNIT_CONVERSION";
            public static string ACTIVE = CfgEprCatalogMasterHis.TableName + ".ACTIVE";
            public static string SUPPLIER_PART_AUX_ID = CfgEprCatalogMasterHis.TableName + ".SUPPLIER_PART_AUX_ID";
            public static string CLASSIFICATION_CODES = CfgEprCatalogMasterHis.TableName + ".CLASSIFICATION_CODES";

        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_EPR_CATALOG_MASTER_HIS = "CFG_EPR_CATALOG_MASTER_HIS";
            public static string EPR_CATALOG_MASTER_HIS_USER_ID = "EPR_CATALOG_MASTER_HIS_USER_ID";
            public static string EPR_CAT_MASTER_HIS_DELEGATE = "EPR_CAT_MASTER_HIS_DELEGATE";
            public static string EPR_CATALOG_MASTER_HIS_DATE = "EPR_CATALOG_MASTER_HIS_DATE";
            public static string CFG_EPR_CATALOG_ID = "CFG_EPR_CATALOG_ID";
            public static string SAP_SUPPLIER_ID = "SAP_SUPPLIER_ID";
            public static string SHORT_NAME = "SHORT_NAME";
            public static string SUPPLIER_PART_ID = "SUPPLIER_PART_ID";
            public static string MANUFACTURING_PART_ID = "MANUFACTURING_PART_ID";
            public static string ITEM_DESCRIPTION = "ITEM_DESCRIPTION";
            public static string UNIT_PRICE = "UNIT_PRICE";
            public static string UNIT_OF_MEASUREMENT_NAME = "UNIT_OF_MEASUREMENT_NAME";
            public static string CURRENCY_NAME = "CURRENCY_NAME";
            public static string PRICE_UNIT_QUANTITY = "PRICE_UNIT_QUANTITY";
            public static string PRICE_UNIT = "PRICE_UNIT";
            public static string UNIT_CONVERSION = "UNIT_CONVERSION";
            public static string ACTIVE = "ACTIVE";
            public static string SUPPLIER_PART_AUX_ID = "SUPPLIER_PART_AUX_ID";
            public static string CLASSIFICATION_CODES = "CLASSIFICATION_CODES";

        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_SHORT_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(SHORT_NAME)); }
        }
        public string Formatted_ITEM_DESCRIPTION
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(ITEM_DESCRIPTION)); }
        }
        public string Formatted_UNIT_OF_MEASUREMENT_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(UNIT_OF_MEASUREMENT_NAME)); }
        }

        public string Formatted_SUPPLIER_PART_AUX_ID
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(SUPPLIER_PART_AUX_ID)); }
        }

        public string Formatted_CLASSIFICATION_CODES
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CLASSIFICATION_CODES)); }
        }

        public string Formatted_EPR_CATALOG_MASTER_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgEprCatalogMasterHis.ColumnNames.EPR_CATALOG_MASTER_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }


        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgEprCatalogMasterHis.ColumnNames.CFG_EPR_CATALOG_MASTER_HIS, "CFG_EPR_CATALOG_MASTER_HIS");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.EPR_CATALOG_MASTER_HIS_USER_ID, "EPR_CATALOG_MASTER_HIS_USER_ID");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.EPR_CAT_MASTER_HIS_DELEGATE, "EPR_CAT_MASTER_HIS_DELEGATE");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.EPR_CATALOG_MASTER_HIS_DATE, "EPR_CATALOG_MASTER_HIS_DATE");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.CFG_EPR_CATALOG_ID, "CFG_EPR_CATALOG_ID");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.SAP_SUPPLIER_ID, "SAP_SUPPLIER_ID");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.SHORT_NAME, "SHORT_NAME");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.SAP_SUPPLIER_ID, "SAP_SUPPLIER_ID");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.SUPPLIER_PART_ID, "SUPPLIER_PART_ID");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.MANUFACTURING_PART_ID, "MANUFACTURING_PART_ID");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.ITEM_DESCRIPTION, "ITEM_DESCRIPTION");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.UNIT_PRICE, "UNIT_PRICE");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.UNIT_OF_MEASUREMENT_NAME, "UNIT_OF_MEASUREMENT_NAME");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.CURRENCY_NAME, "CURRENCY_NAME");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.PRICE_UNIT_QUANTITY, "PRICE_UNIT_QUANTITY");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.PRICE_UNIT, "PRICE_UNIT");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.UNIT_CONVERSION, "UNIT_CONVERSION");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.SUPPLIER_PART_AUX_ID, "SUPPLIER_PART_AUX_ID");
            map.Add(CfgEprCatalogMasterHis.ColumnNames.CLASSIFICATION_CODES, "CLASSIFICATION_CODES");
            return map;
        }
        #endregion



    }
}
