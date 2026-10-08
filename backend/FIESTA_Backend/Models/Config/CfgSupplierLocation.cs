using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Backend.Models
{
    public class CfgSupplierLocation
    {
        public CfgSupplierLocation()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string TableName
        {
            get { return "CFG_SUPPLIER_LOCATIONS"; }
        }

        #region Properties       

        public decimal CFG_LOCATION_ID { get; set; }

        public string SAP_LOCATION_ID { get; set; }
        public string SAP_SUPPLIER_ID { get; set; }
        
        public string ADDRESS { get; set; }

        public string ACTIVE { get; set; }
        public string IS_SYS_OR_USER_ID { get; set; }

        
        public TokenProperties? TokenObj { get; set; }

        #endregion

        public class ColumnNames
        {
            public static string CFG_LOCATION_ID = CfgSupplierLocation.TableName + ".CFG_LOCATION_ID";
            public static string SAP_LOCATION_ID = CfgSupplierLocation.TableName + ".SAP_LOCATION_ID";
            public static string SAP_SUPPLIER_ID = CfgSupplierLocation.TableName + ".SAP_SUPPLIER_ID";
            public static string ADDRESS = CfgSupplierLocation.TableName + ".ADDRESS";
            public static string ACTIVE = CfgSupplierLocation.TableName + ".ACTIVE";
        }

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_LOCATION_ID = "CFG_LOCATION_ID";
            public static string SAP_LOCATION_ID = "SAP_LOCATION_ID";
            public static string SAP_SUPPLIER_ID = "SAP_SUPPLIER_ID";
            public static string ADDRESS = "ADDRESS";
            public static string ACTIVE = "ACTIVE";           
        }
        #endregion
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgSupplierLocation.ColumnNames.CFG_LOCATION_ID, "CFG_LOCATION_ID");
            map.Add(CfgSupplierLocation.ColumnNames.SAP_LOCATION_ID, "SAP_LOCATION_ID");
            map.Add(CfgSupplierLocation.ColumnNames.SAP_SUPPLIER_ID, "SAP_SUPPLIER_ID");
            map.Add(CfgSupplierLocation.ColumnNames.ADDRESS, "ADDRESS");
            map.Add(CfgSupplierLocation.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }

    }
}
