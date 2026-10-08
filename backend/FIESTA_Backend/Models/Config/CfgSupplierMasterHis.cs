
using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Backend.Models
{
    public class CfgSupplierMasterHis
    {
        public CfgSupplierMasterHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_SUPPLIER_MASTER_HIS"; }
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
        public string ACTIVE { get; set; }

        public string ZTERM { get; set; }
        public string USER_ID { get; set; }

        public TokenProperties? TokenObj { get; set; }

        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_SUPPLIER_MASTER_HIS_ID = CfgSupplierMasterHis.TableName + ".CFG_SUPPLIER_MASTER_HIS_ID";
            public static string CFG_SUPPLIER_HIS_DELEGATE = CfgSupplierMasterHis.TableName + ".CFG_SUPPLIER_HIS_DELEGATE";
            public static string CFG_SUPPLIER_HIS_USER_ID = CfgSupplierMasterHis.TableName + ".CFG_SUPPLIER_HIS_USER_ID";
            public static string CFG_SUPPLIER_HIS_DATE = CfgSupplierMasterHis.TableName + ".CFG_SUPPLIER_HIS_DATE";
            public static string CFG_SUPPLIER_ID = CfgSupplierMasterHis.TableName + ".CFG_SUPPLIER_ID";
            public static string SUPPLIER_NAME = CfgSupplierMasterHis.TableName + ".SUPPLIER_NAME";
            public static string SUPPLIER_DESCRIPTION = CfgSupplierMasterHis.TableName + ".SUPPLIER_DESCRIPTION";
            public static string COMPANY_CODE = CfgSupplierMasterHis.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgSupplierMasterHis.TableName + ".ACTIVE";
            public static string SAP_SUPPLIER_ID = CfgSupplierMasterHis.TableName + ".SAP_SUPPLIER_ID";
            public static string PAYMETHOD = CfgSupplierMasterHis.TableName + ".PAYMETHOD";
            public static string EMAIL = CfgSupplierMasterHis.TableName + ".EMAIL";
            public static string PHONE = CfgSupplierMasterHis.TableName + ".PHONE";
            public static string FAX = CfgSupplierMasterHis.TableName + ".FAX";
            public static string ADDRESS = CfgSupplierMasterHis.TableName + ".ADDRESS";
            public static string ZTERM = CfgSupplierMasterHis.TableName + ".ZTERM";
        }
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgSupplierMasterHis.ColumnNames.CFG_SUPPLIER_MASTER_HIS_ID, "CFG_SUPPLIER_MASTER_HIS_ID");
            map.Add(CfgSupplierMasterHis.ColumnNames.CFG_SUPPLIER_HIS_DELEGATE, "CFG_SUPPLIER_HIS_DELEGATE");
            map.Add(CfgSupplierMasterHis.ColumnNames.CFG_SUPPLIER_HIS_USER_ID, "CFG_SUPPLIER_HIS_USER_ID");
            map.Add(CfgSupplierMasterHis.ColumnNames.CFG_SUPPLIER_HIS_DATE, "CFG_SUPPLIER_HIS_DATE");
            map.Add(CfgSupplierMasterHis.ColumnNames.CFG_SUPPLIER_ID, "CFG_SUPPLIER_ID");
            map.Add(CfgSupplierMasterHis.ColumnNames.SUPPLIER_NAME, "SUPPLIER_NAME");
            map.Add(CfgSupplierMasterHis.ColumnNames.SUPPLIER_DESCRIPTION, "SUPPLIER_DESCRIPTION");
            map.Add(CfgSupplierMasterHis.ColumnNames.SAP_SUPPLIER_ID, "SAP_SUPPLIER_ID");
            map.Add(CfgSupplierMasterHis.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgSupplierMasterHis.ColumnNames.PAYMETHOD, "PAYMETHOD");
            map.Add(CfgSupplierMasterHis.ColumnNames.EMAIL, "EMAIL");
            map.Add(CfgSupplierMasterHis.ColumnNames.PHONE, "PHONE");
            map.Add(CfgSupplierMasterHis.ColumnNames.FAX, "FAX");
            map.Add(CfgSupplierMasterHis.ColumnNames.ADDRESS, "ADDRESS");
            map.Add(CfgSupplierMasterHis.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion

        public string Formatted_CFG_SUPPLIER_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgSupplierMasterHis.ColumnNames.CFG_SUPPLIER_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
    }
}
