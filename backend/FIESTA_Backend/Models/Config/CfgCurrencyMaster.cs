
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
    public class CfgCurrencyMaster
    {
        public CfgCurrencyMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_CURRENCY_MASTER"; }
        }

        #region Properties       

        public decimal CFG_CURRENCY_MASTER_ID { get; set; }
        public string CURRENCY_NAME { get; set; }
        public string CURRENCY_DESCRIPTION { get; set; }        
        public string ACTIVE { get; set; }
        public TokenProperties? TokenObj { get; set; }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_CURRENCY_MASTER_ID = CfgCurrencyMaster.TableName + ".CFG_CURRENCY_MASTER_ID";
            public static string CURRENCY_NAME = CfgCurrencyMaster.TableName + ".CURRENCY_NAME";
            public static string CURRENCY_DESCRIPTION = CfgCurrencyMaster.TableName + ".CURRENCY_DESCRIPTION";
            
            public static string ACTIVE = CfgCurrencyMaster.TableName + ".ACTIVE";


        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_CURRENCY_MASTER_ID = "CFG_CURRENCY_MASTER_ID";
            public static string CURRENCY_NAME = "CURRENCY_NAME";
            public static string CURRENCY_DESCRIPTION = "CURRENCY_DESCRIPTION";            
            public static string ACTIVE = "ACTIVE";

        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_CURRENCY_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CURRENCY_NAME)); }
        }
        public string Formatted_CURRENCY_DESCRIPTION
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CURRENCY_DESCRIPTION)); }
        }
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgCurrencyMaster.ColumnNames.CFG_CURRENCY_MASTER_ID, "CFG_CURRENCY_MASTER_ID");
            map.Add(CfgCurrencyMaster.ColumnNames.CURRENCY_NAME, "CURRENCY_NAME");            
            map.Add(CfgCurrencyMaster.ColumnNames.CURRENCY_DESCRIPTION, "CURRENCY_DESCRIPTION");            
            map.Add(CfgCurrencyMaster.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion


       
    }
}