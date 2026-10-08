using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Backend.Models
{
    public class CfgSupplierLocationHis
    {
        public CfgSupplierLocationHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string TableName
        {
            get { return "CFG_SUPPLIER_LOCATIONS_HIS"; }
        }

        #region Properties       

        public decimal CFG_LOCATION_ID { get; set; }

        public string SAP_LOCATION_ID { get; set; }
        public string SAP_SUPPLIER_ID { get; set; }

        public string ADDRESS { get; set; }
        public string IS_SYS_OR_USER_ID { get; set; }

        public string ACTIVE { get; set; }
        public TokenProperties? TokenObj { get; set; }

        #endregion

        public class ColumnNames
        {
            public static string CFG_SUPP_LOCATION_HIS_ID = CfgSupplierLocationHis.TableName + ".CFG_SUPP_LOCATION_HIS_ID";
            public static string CFG_SUPP_LOCATION_HIS_USER_ID = CfgSupplierLocationHis.TableName + ".CFG_SUPP_LOCATION_HIS_USER_ID";
            public static string CFG_SUPP_LOCATION_HIS_DELEGATE = CfgSupplierLocationHis.TableName + ".CFG_SUPP_LOCATION_HIS_DELEGATE";
            public static string CFG_SUPP_LOCATION_HIS_DATE = CfgSupplierLocationHis.TableName + ".CFG_SUPP_LOCATION_HIS_DATE";
            public static string CFG_LOCATION_ID = CfgSupplierLocationHis.TableName + ".CFG_LOCATION_ID";
            public static string SAP_LOCATION_ID = CfgSupplierLocationHis.TableName + ".SAP_LOCATION_ID";
            public static string SAP_SUPPLIER_ID = CfgSupplierLocationHis.TableName + ".SAP_SUPPLIER_ID";
            public static string ADDRESS = CfgSupplierLocationHis.TableName + ".ADDRESS";
            public static string ACTIVE = CfgSupplierLocationHis.TableName + ".ACTIVE";
        }

       
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgSupplierLocationHis.ColumnNames.CFG_SUPP_LOCATION_HIS_ID, "CFG_SUPP_LOCATION_HIS_ID");
            map.Add(CfgSupplierLocationHis.ColumnNames.CFG_SUPP_LOCATION_HIS_USER_ID, "CFG_SUPP_LOCATION_HIS_USER_ID");
            map.Add(CfgSupplierLocationHis.ColumnNames.CFG_SUPP_LOCATION_HIS_DELEGATE, "CFG_SUPP_LOCATION_HIS_DELEGATE");
            map.Add(CfgSupplierLocationHis.ColumnNames.CFG_SUPP_LOCATION_HIS_DATE, "CFG_SUPP_LOCATION_HIS_DATE");
            map.Add(CfgSupplierLocationHis.ColumnNames.CFG_LOCATION_ID, "CFG_LOCATION_ID");
            map.Add(CfgSupplierLocationHis.ColumnNames.SAP_LOCATION_ID, "SAP_LOCATION_ID");
            map.Add(CfgSupplierLocationHis.ColumnNames.SAP_SUPPLIER_ID, "SAP_SUPPLIER_ID");
            map.Add(CfgSupplierLocationHis.ColumnNames.ADDRESS, "ADDRESS");
            map.Add(CfgSupplierLocationHis.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }
        public string Formatted_CFG_SUPP_LOCATION_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgSupplierLocationHis.ColumnNames.CFG_SUPP_LOCATION_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
    }
}
