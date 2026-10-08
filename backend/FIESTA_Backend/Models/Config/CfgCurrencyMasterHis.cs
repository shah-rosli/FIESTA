
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
    public class CfgCurrencyMasterHis
    {
        public CfgCurrencyMasterHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string TableName
        {
            get { return "CFG_CURRENCY_MASTER_HIS"; }
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
            public static string CFG_CURRENCY_MASTER_HIS_ID = CfgCurrencyMasterHis.TableName + ".CFG_CURRENCY_MASTER_HIS_ID";
            public static string CFG_CURRENCY_HIS_USER_ID = CfgCurrencyMasterHis.TableName + ".CFG_CURRENCY_HIS_USER_ID";
            public static string CFG_CURRENCY_HIS_DELEGATE = CfgCurrencyMasterHis.TableName + ".CFG_CURRENCY_HIS_DELEGATE";
            public static string CFG_CURRENCY_HIS_DATE = CfgCurrencyMasterHis.TableName + ".CFG_CURRENCY_HIS_DATE";
            public static string CFG_CURRENCY_MASTER_ID = CfgCurrencyMasterHis.TableName + ".CFG_CURRENCY_MASTER_ID";
            public static string CURRENCY_NAME = CfgCurrencyMasterHis.TableName + ".CURRENCY_NAME";
            public static string CURRENCY_DESCRIPTION = CfgCurrencyMasterHis.TableName + ".CURRENCY_DESCRIPTION";

            public static string ACTIVE = CfgCurrencyMasterHis.TableName + ".ACTIVE";


        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_CURRENCY_MASTER_HIS_ID = "CFG_CURRENCY_MASTER_HIS_ID";
            public static string CFG_CURRENCY_HIS_USER_ID = "CFG_CURRENCY_HIS_USER_ID";
            public static string CFG_CURRENCY_HIS_DELEGATE = "CFG_CURRENCY_HIS_DELEGATE";
            public static string CFG_CURRENCY_HIS_DATE = "CFG_CURRENCY_HIS_DATE";
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

        public string Formatted_CFG_CURRENCY_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgCurrencyMasterHis.ColumnNames.CFG_CURRENCY_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgCurrencyMasterHis.ColumnNames.CFG_CURRENCY_MASTER_HIS_ID, "CFG_CURRENCY_MASTER_HIS_ID");
            map.Add(CfgCurrencyMasterHis.ColumnNames.CFG_CURRENCY_HIS_USER_ID, "CFG_CURRENCY_HIS_USER_ID");
            map.Add(CfgCurrencyMasterHis.ColumnNames.CFG_CURRENCY_HIS_DELEGATE, "CFG_CURRENCY_HIS_DELEGATE");
            map.Add(CfgCurrencyMasterHis.ColumnNames.CFG_CURRENCY_HIS_DATE, "CFG_CURRENCY_HIS_DATE");
            map.Add(CfgCurrencyMasterHis.ColumnNames.CFG_CURRENCY_MASTER_ID, "CFG_CURRENCY_MASTER_ID");
            map.Add(CfgCurrencyMasterHis.ColumnNames.CURRENCY_NAME, "CURRENCY_NAME");
            map.Add(CfgCurrencyMasterHis.ColumnNames.CURRENCY_DESCRIPTION, "CURRENCY_DESCRIPTION");
            map.Add(CfgCurrencyMasterHis.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion

    }
}
