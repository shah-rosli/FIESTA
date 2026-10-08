
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
    public class CfgEprCatalogMaster
    {
        public CfgEprCatalogMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_EPR_CATALOG_MASTER"; }
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
            public static string CFG_EPR_CATALOG_ID = CfgEprCatalogMaster.TableName + ".CFG_EPR_CATALOG_ID";
            public static string SAP_SUPPLIER_ID = CfgEprCatalogMaster.TableName + ".SAP_SUPPLIER_ID";
            public static string SHORT_NAME = CfgEprCatalogMaster.TableName + ".SHORT_NAME";
            public static string SUPPLIER_PART_ID = CfgEprCatalogMaster.TableName + ".SUPPLIER_PART_ID";
            public static string MANUFACTURING_PART_ID = CfgEprCatalogMaster.TableName + ".MANUFACTURING_PART_ID";
            public static string ITEM_DESCRIPTION = CfgEprCatalogMaster.TableName + ".ITEM_DESCRIPTION";
            public static string UNIT_PRICE = CfgEprCatalogMaster.TableName + ".UNIT_PRICE";
            public static string UNIT_OF_MEASUREMENT_NAME = CfgEprCatalogMaster.TableName + ".UNIT_OF_MEASUREMENT_NAME";
            public static string CURRENCY_NAME = CfgEprCatalogMaster.TableName + ".CURRENCY_NAME";
            public static string PRICE_UNIT_QUANTITY = CfgEprCatalogMaster.TableName + ".PRICE_UNIT_QUANTITY";
            public static string PRICE_UNIT = CfgEprCatalogMaster.TableName + ".PRICE_UNIT";
            public static string UNIT_CONVERSION = CfgEprCatalogMaster.TableName + ".UNIT_CONVERSION";
            public static string ACTIVE = CfgEprCatalogMaster.TableName + ".ACTIVE";
            public static string SUPPLIER_PART_AUX_ID = CfgEprCatalogMaster.TableName + ".SUPPLIER_PART_AUX_ID";
            public static string CLASSIFICATION_CODES = CfgEprCatalogMaster.TableName + ".CLASSIFICATION_CODES";           

        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
            {
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
            get { return string.Format("{0}", DataConverter.FormatSQLForUOM(UNIT_OF_MEASUREMENT_NAME)); }
        }

        public string Formatted_SUPPLIER_PART_AUX_ID
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(SUPPLIER_PART_AUX_ID)); }
        }

        public string Formatted_CLASSIFICATION_CODES
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CLASSIFICATION_CODES)); }
        }




        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgEprCatalogMaster.ColumnNames.CFG_EPR_CATALOG_ID, "CFG_EPR_CATALOG_ID");
            map.Add(CfgEprCatalogMaster.ColumnNames.SAP_SUPPLIER_ID, "SAP_SUPPLIER_ID");
            map.Add(CfgEprCatalogMaster.ColumnNames.SHORT_NAME, "SHORT_NAME");
            map.Add(CfgEprCatalogMaster.ColumnNames.SAP_SUPPLIER_ID, "SAP_SUPPLIER_ID");
            map.Add(CfgEprCatalogMaster.ColumnNames.SUPPLIER_PART_ID, "SUPPLIER_PART_ID");
            map.Add(CfgEprCatalogMaster.ColumnNames.MANUFACTURING_PART_ID, "MANUFACTURING_PART_ID");
            map.Add(CfgEprCatalogMaster.ColumnNames.ITEM_DESCRIPTION, "ITEM_DESCRIPTION");
            map.Add(CfgEprCatalogMaster.ColumnNames.UNIT_PRICE, "UNIT_PRICE");
            map.Add(CfgEprCatalogMaster.ColumnNames.UNIT_OF_MEASUREMENT_NAME, "UNIT_OF_MEASUREMENT_NAME");
            map.Add(CfgEprCatalogMaster.ColumnNames.CURRENCY_NAME, "CURRENCY_NAME");
            map.Add(CfgEprCatalogMaster.ColumnNames.PRICE_UNIT_QUANTITY, "PRICE_UNIT_QUANTITY");
            map.Add(CfgEprCatalogMaster.ColumnNames.PRICE_UNIT, "PRICE_UNIT");
            map.Add(CfgEprCatalogMaster.ColumnNames.UNIT_CONVERSION, "UNIT_CONVERSION");
            map.Add(CfgEprCatalogMaster.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgEprCatalogMaster.ColumnNames.SUPPLIER_PART_AUX_ID, "SUPPLIER_PART_AUX_ID");
            map.Add(CfgEprCatalogMaster.ColumnNames.CLASSIFICATION_CODES, "CLASSIFICATION_CODES");
            return map;
        }
        #endregion


       
    }
}