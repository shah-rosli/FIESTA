using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Backend.Models
{
    public class CfgEprCatalogStaging
    {
        public CfgEprCatalogStaging()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string TableName
        {
            get { return "CFG_EPR_CATALOG_STAGING"; }
        }
        #region Properties       


        public string SAP_SUPPLIER_ID { get; set; }
        public string SUPPLIER_PART_ID { get; set; }
        public string MANUFACTURING_PART_ID { get; set; }
        public string ITEM_DESCRIPTION { get; set; }
        public string SPSC_CODE  { get; set; }
        public string UNIT_PRICE { get; set; }
        public string UNIT_OF_MEASUREMENT_NAME { get; set; }
        public string LEAD_TIME { get; set; }
        public string MANUFACTURER_NAME { get; set; }
        public string SUPPLIER_URL { get; set; }
        public string MANUFACTURER_URL { get; set; }
        public string MARKET_PRICE { get; set; }
        public string CURRENCY_NAME { get; set; }
        public string PUNCH_OUT_ENABLED { get; set; }
        public string SUPPLIER_PART_AUX_ID { get; set; }
        public string LANG { get; set; }
        public string PARAMETRIC_NAME { get; set; }
        public string PARAMETRIC_DATA { get; set; }
        public string EFFECTIVE_DATE  { get; set; }
        public string EXPIRATION_DATE { get; set; }
        public string CLASSIFICATION_CODES { get; set; }
        public string TERRITORY_AVAILABLE { get; set; }
        public string SHORT_NAME { get; set; }
        public string ISPARTIAL { get; set; }
        public string IS_INTERNAL_PARTID { get; set; }
        public string DELETE_1 { get; set; }

        public string IMAGE { get; set; }
        public string THUMBNAIL { get; set; }
        public string IN_KIT_ONLY { get; set; }
        public string PUNCHOUT_LEVEL { get; set; }
        public string DEFAULT_RELEVANCE { get; set; }
        public string PRICE_UNIT_QUANTITY { get; set; }
        public string PRICE_UNIT { get; set; }

        public string UNIT_CONVERSION { get; set; }
        public string PRICE_UNIT_QTY_DESC { get; set; }
        public string PROMOTION_RANK { get; set; }
        public string IS_PREFERRED_ITEM { get; set; }

        public string HAZARDOUS_MATERIALS { get; set; }
        public string BEST_PRICE { get; set; }
        public string GREEN { get; set; }

        //public string ACTIVE { get; set; }
        public string SYS_OR_USER_ID { get; set; }
        public TokenProperties? TokenObj { get; set; }


        
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string SAP_SUPPLIER_ID = CfgEprCatalogStaging.TableName + ".SAP_SUPPLIER_ID";
            public static string SUPPLIER_PART_ID = CfgEprCatalogStaging.TableName + ".SUPPLIER_PART_ID";
            public static string MANUFACTURING_PART_ID = CfgEprCatalogStaging.TableName + ".MANUFACTURING_PART_ID";
            public static string ITEM_DESCRIPTION = CfgEprCatalogStaging.TableName + ".ITEM_DESCRIPTION";
            public static string SPSC_CODE = CfgEprCatalogStaging.TableName + ".SPSC_CODE";
            public static string UNIT_PRICE = CfgEprCatalogStaging.TableName + ".UNIT_PRICE";
            public static string UNIT_OF_MEASUREMENT_NAME = CfgEprCatalogStaging.TableName + ".UNIT_OF_MEASUREMENT_NAME";
            public static string LEAD_TIME = CfgEprCatalogStaging.TableName + ".LEAD_TIME";
            public static string MANUFACTURER_NAME = CfgEprCatalogStaging.TableName + ".MANUFACTURER_NAME";
            public static string SUPPLIER_URL = CfgEprCatalogStaging.TableName + ".SUPPLIER_URL";
            public static string MANUFACTURER_URL = CfgEprCatalogStaging.TableName + ".MANUFACTURER_URL";
            public static string MARKET_PRICE = CfgEprCatalogStaging.TableName + ".MARKET_PRICE";
            public static string CURRENCY_NAME = CfgEprCatalogStaging.TableName + ".CURRENCY_NAME";
            public static string PUNCH_OUT_ENABLED = CfgEprCatalogStaging.TableName + ".PUNCH_OUT_ENABLED";
            public static string SUPPLIER_PART_AUX_ID = CfgEprCatalogStaging.TableName + ".SUPPLIER_PART_AUX_ID";
            public static string LANG = CfgEprCatalogStaging.TableName + ".LANG";
            public static string PARAMETRIC_NAME = CfgEprCatalogStaging.TableName + ".PARAMETRIC_NAME";
            public static string PARAMETRIC_DATA = CfgEprCatalogStaging.TableName + ".PARAMETRIC_DATA";
            public static string EXPIRATION_DATE = CfgEprCatalogStaging.TableName + ".EXPIRATION_DATE";
            public static string EFFECTIVE_DATE = CfgEprCatalogStaging.TableName + ".EFFECTIVE_DATE";
            public static string CLASSIFICATION_CODES = CfgEprCatalogStaging.TableName + ".CLASSIFICATION_CODES";
            public static string TERRITORY_AVAILABLE = CfgEprCatalogStaging.TableName + ".TERRITORY_AVAILABLE";
            public static string SHORT_NAME = CfgEprCatalogStaging.TableName + ".SHORT_NAME";
            public static string ISPARTIAL = CfgEprCatalogStaging.TableName + ".ISPARTIAL";
            public static string IS_INTERNAL_PARTID = CfgEprCatalogStaging.TableName + ".IS_INTERNAL_PARTID";
            public static string DELETE_1 = CfgEprCatalogStaging.TableName + ".DELETE_1";
            public static string IMAGE = CfgEprCatalogStaging.TableName + ".IMAGE";
            public static string THUMBNAIL = CfgEprCatalogStaging.TableName + ".THUMBNAIL";
            public static string IN_KIT_ONLY = CfgEprCatalogStaging.TableName + ".IN_KIT_ONLY";
            public static string PUNCHOUT_LEVEL = CfgEprCatalogStaging.TableName + ".PUNCHOUT_LEVEL";
            public static string DEFAULT_RELEVANCE = CfgEprCatalogStaging.TableName + ".DEFAULT_RELEVANCE";
            public static string PRICE_UNIT_QUANTITY = CfgEprCatalogStaging.TableName + ".PRICE_UNIT_QUANTITY";
            public static string PRICE_UNIT = CfgEprCatalogStaging.TableName + ".PRICE_UNIT";
            public static string UNIT_CONVERSION = CfgEprCatalogStaging.TableName + ".UNIT_CONVERSION";
            public static string PRICE_UNIT_QTY_DESC = CfgEprCatalogStaging.TableName + ".PRICE_UNIT_QTY_DESC";
            public static string PROMOTION_RANK = CfgEprCatalogStaging.TableName + ".PROMOTION_RANK";
            public static string IS_PREFERRED_ITEM = CfgEprCatalogStaging.TableName + ".IS_PREFERRED_ITEM";
            public static string HAZARDOUS_MATERIALS = CfgEprCatalogStaging.TableName + ".HAZARDOUS_MATERIALS";
            public static string BEST_PRICE = CfgEprCatalogStaging.TableName + ".BEST_PRICE";
            public static string GREEN = CfgEprCatalogStaging.TableName + ".GREEN";
            public static string SYS_OR_USER_ID = CfgEprCatalogStaging.TableName + ".SYS_OR_USER_ID";
            
        }
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgEprCatalogStaging.ColumnNames.SAP_SUPPLIER_ID, "SAP_SUPPLIER_ID");
            map.Add(CfgEprCatalogStaging.ColumnNames.SUPPLIER_PART_ID, "SUPPLIER_PART_ID");
            map.Add(CfgEprCatalogStaging.ColumnNames.MANUFACTURING_PART_ID, "MANUFACTURING_PART_ID");
            map.Add(CfgEprCatalogStaging.ColumnNames.ITEM_DESCRIPTION, "ITEM_DESCRIPTION");
            map.Add(CfgEprCatalogStaging.ColumnNames.SPSC_CODE, "SPSC_CODE");
            map.Add(CfgEprCatalogStaging.ColumnNames.UNIT_PRICE, "UNIT_PRICE");
            map.Add(CfgEprCatalogStaging.ColumnNames.UNIT_OF_MEASUREMENT_NAME, "UNIT_OF_MEASUREMENT_NAME");
            map.Add(CfgEprCatalogStaging.ColumnNames.LEAD_TIME, "LEAD_TIME");
            map.Add(CfgEprCatalogStaging.ColumnNames.MANUFACTURER_NAME, "MANUFACTURER_NAME");
            map.Add(CfgEprCatalogStaging.ColumnNames.SUPPLIER_URL, "SUPPLIER_URL");
            map.Add(CfgEprCatalogStaging.ColumnNames.MANUFACTURER_URL, "MANUFACTURER_URL");
            map.Add(CfgEprCatalogStaging.ColumnNames.MARKET_PRICE, "MARKET_PRICE");
            map.Add(CfgEprCatalogStaging.ColumnNames.CURRENCY_NAME, "CURRENCY_NAME");
            map.Add(CfgEprCatalogStaging.ColumnNames.PUNCH_OUT_ENABLED, "PUNCH_OUT_ENABLED");
            map.Add(CfgEprCatalogStaging.ColumnNames.SUPPLIER_PART_AUX_ID, "SUPPLIER_PART_AUX_ID");
            map.Add(CfgEprCatalogStaging.ColumnNames.LANG, "LANG");
            map.Add(CfgEprCatalogStaging.ColumnNames.PARAMETRIC_NAME, "PARAMETRIC_NAME");
            map.Add(CfgEprCatalogStaging.ColumnNames.PARAMETRIC_DATA, "PARAMETRIC_DATA");
            map.Add(CfgEprCatalogStaging.ColumnNames.EXPIRATION_DATE, "EXPIRATION_DATE");
            map.Add(CfgEprCatalogStaging.ColumnNames.EFFECTIVE_DATE, "EFFECTIVE_DATE");
            map.Add(CfgEprCatalogStaging.ColumnNames.CLASSIFICATION_CODES, "CLASSIFICATION_CODES");
            map.Add(CfgEprCatalogStaging.ColumnNames.TERRITORY_AVAILABLE, "TERRITORY_AVAILABLE");
            map.Add(CfgEprCatalogStaging.ColumnNames.SHORT_NAME, "SHORT_NAME");
            map.Add(CfgEprCatalogStaging.ColumnNames.ISPARTIAL, "ISPARTIAL");
            map.Add(CfgEprCatalogStaging.ColumnNames.IS_INTERNAL_PARTID, "IS_INTERNAL_PARTID");
            map.Add(CfgEprCatalogStaging.ColumnNames.DELETE_1, "DELETE_1");
            map.Add(CfgEprCatalogStaging.ColumnNames.IMAGE, "IMAGE");
            map.Add(CfgEprCatalogStaging.ColumnNames.THUMBNAIL, "THUMBNAIL");
            map.Add(CfgEprCatalogStaging.ColumnNames.IN_KIT_ONLY, "IN_KIT_ONLY");
            map.Add(CfgEprCatalogStaging.ColumnNames.PUNCHOUT_LEVEL, "PUNCHOUT_LEVEL");
            map.Add(CfgEprCatalogStaging.ColumnNames.DEFAULT_RELEVANCE, "DEFAULT_RELEVANCE");
            map.Add(CfgEprCatalogStaging.ColumnNames.PRICE_UNIT_QUANTITY, "PRICE_UNIT_QUANTITY");
            map.Add(CfgEprCatalogStaging.ColumnNames.PRICE_UNIT, "PRICE_UNIT");
            map.Add(CfgEprCatalogStaging.ColumnNames.UNIT_CONVERSION, "UNIT_CONVERSION");
            map.Add(CfgEprCatalogStaging.ColumnNames.PRICE_UNIT_QTY_DESC, "PRICE_UNIT_QTY_DESC");
            map.Add(CfgEprCatalogStaging.ColumnNames.PROMOTION_RANK, "PROMOTION_RANK");
            map.Add(CfgEprCatalogStaging.ColumnNames.IS_PREFERRED_ITEM, "IS_PREFERRED_ITEM");
            map.Add(CfgEprCatalogStaging.ColumnNames.HAZARDOUS_MATERIALS, "HAZARDOUS_MATERIALS");
            map.Add(CfgEprCatalogStaging.ColumnNames.BEST_PRICE, "BEST_PRICE");
            map.Add(CfgEprCatalogStaging.ColumnNames.GREEN, "GREEN");
            map.Add(CfgEprCatalogStaging.ColumnNames.SYS_OR_USER_ID, "SYS_OR_USER_ID");            
            return map;
        }
        #endregion

    }
}
