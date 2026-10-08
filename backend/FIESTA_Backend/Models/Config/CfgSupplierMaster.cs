
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
    public class CfgSupplierMaster
    {
        public CfgSupplierMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_SUPPLIER_MASTER"; }
        }

        #region Properties       

        public decimal CFG_SUPPLIER_ID { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public string SUPPLIER_DESCRIPTION { get; set; }
        public string SAP_SUPPLIER_ID { get; set; }
        public string COMPANY_CODE { get; set; }
        public string PAYMETHOD { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        public string FAX { get; set; }
        public string ADDRESS { get; set; }

        public string ZTERM { get; set; }

        public string ACTIVE { get; set; }
        public string USER_ID { get; set; }

        

        public TokenProperties? TokenObj { get; set; }

        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_SUPPLIER_ID = CfgSupplierMaster.TableName + ".CFG_SUPPLIER_ID";
            public static string SUPPLIER_NAME = CfgSupplierMaster.TableName + ".SUPPLIER_NAME";
            public static string SUPPLIER_DESCRIPTION = CfgSupplierMaster.TableName + ".SUPPLIER_DESCRIPTION";
            public static string COMPANY_CODE = CfgSupplierMaster.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgSupplierMaster.TableName + ".ACTIVE";
            public static string SAP_SUPPLIER_ID = CfgSupplierMaster.TableName + ".SAP_SUPPLIER_ID";
            public static string PAYMETHOD = CfgSupplierMaster.TableName + ".PAYMETHOD";
            public static string EMAIL = CfgSupplierMaster.TableName + ".EMAIL";
            public static string PHONE = CfgSupplierMaster.TableName + ".PHONE";
            public static string FAX = CfgSupplierMaster.TableName + ".FAX";
            public static string ADDRESS = CfgSupplierMaster.TableName + ".ADDRESS";
            public static string ZTERM = CfgSupplierMaster.TableName + ".ZTERM";
        }
            #endregion

        #region ColumnNamesOnly
            public class ColumnNamesOnly
            {
                public static string CFG_SUPPLIER_ID = "CFG_SUPPLIER_ID";
                public static string SUPPLIER_NAME = "SUPPLIER_NAME";
                public static string SUPPLIER_DESCRIPTION = "SUPPLIER_DESCRIPTION";
                public static string COMPANY_CODE = "COMPANY_CODE";
                public static string ACTIVE = "ACTIVE";
                public static string SAP_SUPPLIER_ID = "SAP_SUPPLIER_ID";
                public static string PAYMETHOD ="PAYMETHOD";
                public static string EMAIL ="EMAIL";
                public static string PHONE = "PHONE";
                public static string FAX = "FAX";
                public static string ADDRESS = "ADDRESS";
                public static string ZTERM = "ZTERM";


        }
            #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_SUPPLIER_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(SUPPLIER_NAME)); }
        }
        public string Formatted_SUPPLIER_DESCRIPTION
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(SUPPLIER_DESCRIPTION)); }
        }
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_CODE)); }
        }

        public string Formatted_PHONE
            {
                get { return string.Format("{0}", DataConverter.FormatSQL(PHONE)); }
        }

        public string Formatted_EMAIL
        {
                get { return string.Format("{0}", DataConverter.FormatSQL(EMAIL)); }
        }

        public string Formatted_FAX
            {
            get { return string.Format("{0}", DataConverter.FormatSQL(FAX)); }
        }

        public string Formatted_ZTERM
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(ZTERM)); }
        }
        public string Formatted_ADDRESS
            {
            get { return string.Format("{0}", DataConverter.FormatSQL(ADDRESS)); }
        }

        public string Formatted_SAP_SUPPLIER_ID
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(SAP_SUPPLIER_ID)); }
        }

        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgSupplierMaster.ColumnNames.CFG_SUPPLIER_ID, "CFG_SUPPLIER_ID");
            map.Add(CfgSupplierMaster.ColumnNames.SUPPLIER_NAME, "SUPPLIER_NAME");
            map.Add(CfgSupplierMaster.ColumnNames.SUPPLIER_DESCRIPTION, "SUPPLIER_DESCRIPTION");
            map.Add(CfgSupplierMaster.ColumnNames.SAP_SUPPLIER_ID, "SAP_SUPPLIER_ID");
            map.Add(CfgSupplierMaster.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgSupplierMaster.ColumnNames.PAYMETHOD, "PAYMETHOD");
            map.Add(CfgSupplierMaster.ColumnNames.EMAIL, "EMAIL");
            map.Add(CfgSupplierMaster.ColumnNames.PHONE, "PHONE");
            map.Add(CfgSupplierMaster.ColumnNames.FAX, "FAX");
            map.Add(CfgSupplierMaster.ColumnNames.ADDRESS, "ADDRESS");
            map.Add(CfgSupplierMaster.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion


       
    }
}