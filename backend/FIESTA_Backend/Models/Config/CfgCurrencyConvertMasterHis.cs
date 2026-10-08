
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
   public class CfgCurrencyConvertMasterHis
    {
        public CfgCurrencyConvertMasterHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_CURRENCY_CONVERT_MSTR_HIS"; }
        }

        #region Properties       

        public decimal CFG_CURRENCY_CONVERT_MASTER_ID { get; set; }
        public string CURRENCY_RATE { get; set; }
        public string FROM_CURRENCY_NAME { get; set; }
        public string TO_CURRENCY_NAME { get; set; }
        public DateTime FROM_DATETIME { get; set; }
        public DateTime TO_DATETIME { get; set; }

        public string ACTIVE { get; set; }

        public TokenProperties? TokenObj { get; set; }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_CURRENCY_CONVERT_HIS_ID = CfgCurrencyConvertMasterHis.TableName + ".CFG_CURRENCY_CONVERT_HIS_ID";
            public static string CFG_CURRENCY_CONVERT_USER_ID = CfgCurrencyConvertMasterHis.TableName + ".CFG_CURRENCY_CONVERT_USER_ID";
            public static string CFG_CURRENCY_CNVT_HIS_DELEGATE = CfgCurrencyConvertMasterHis.TableName + ".CFG_CURRENCY_CNVT_HIS_DELEGATE";
            public static string CFG_CURRENCY_CNVRT_HIS_DATE = CfgCurrencyConvertMasterHis.TableName + ".CFG_CURRENCY_CNVRT_HIS_DATE";
            public static string CFG_CURRENCY_CONVERT_MASTER_ID = CfgCurrencyConvertMasterHis.TableName + ".CFG_CURRENCY_CONVERT_MASTER_ID";
            public static string CURRENCY_RATE = CfgCurrencyConvertMasterHis.TableName + ".CURRENCY_RATE";
            public static string FROM_CURRENCY_NAME = CfgCurrencyConvertMasterHis.TableName + ".FROM_CURRENCY_NAME";
            public static string TO_CURRENCY_NAME = CfgCurrencyConvertMasterHis.TableName + ".TO_CURRENCY_NAME";
            public static string FROM_DATETIME = CfgCurrencyConvertMasterHis.TableName + ".FROM_DATETIME";
            public static string TO_DATETIME = CfgCurrencyConvertMasterHis.TableName + ".TO_DATETIME";
            public static string ACTIVE = CfgCurrencyConvertMasterHis.TableName + ".ACTIVE";



        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_CURRENCY_CONVERT_HIS_ID = "CFG_CURRENCY_CONVERT_HIS_ID";
            public static string CFG_CURRENCY_CONVERT_USER_ID = "CFG_CURRENCY_CONVERT_USER_ID";
            public static string CFG_CURRENCY_CNVT_HIS_DELEGATE = "CFG_CURRENCY_CNVT_HIS_DELEGATE";
            public static string CFG_CURRENCY_CNVRT_HIS_DATE = "CFG_CURRENCY_CNVRT_HIS_DATE";
            public static string CFG_CURRENCY_CONVERT_MASTER_ID = "CFG_CURRENCY_CONVERT_MASTER_ID";
            public static string CURRENCY_RATE = "CURRENCY_RATE";
            public static string FROM_CURRENCY_NAME = "FROM_CURRENCY_NAME";
            public static string TO_CURRENCY_NAME = "TO_CURRENCY_NAME";
            public static string FROM_DATETIME = "FROM_DATETIME";
            public static string TO_DATETIME = "TO_DATETIME";
            public static string ACTIVE = "ACTIVE";

        }
        #endregion



        #region FormattedValueForSqlTransaction
        public string Formatted_CURRENCY_RATE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CURRENCY_RATE)); }
        }
        public string Formatted_FROM_CURRENCY_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(FROM_CURRENCY_NAME)); }
        }
        public string Formatted_TO_CURRENCY_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(TO_CURRENCY_NAME)); }
        }
        public string Formatted_TO_DATETIME
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("{0}", DataConverter.ConvertTimezone(TO_DATETIME, TokenObj.DEFAULT_TIMEZONE, "UTC"));
                else return null;
            }
            //get { return string.Format("{0}", TO_DATETIME); }
        }

        public string Formatted_FROM_DATETIME
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("{0}", DataConverter.ConvertTimezone(FROM_DATETIME, TokenObj.DEFAULT_TIMEZONE, "UTC"));
                else return null;
            }

            //get { return string.Format("{0}", FROM_DATETIME); }
        }

        public string Formatted_ACTIVE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(ACTIVE)); }
        }
        public string Formatted_TO_DATETIME_FOR_DISPLAY
        {
            get
            {
                //if (TokenObj != null)
                //    return string.Format(" TO_CHAR( FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' , 'YYYY/MM/DD HH24:MI:SS')", CfgCurrencyConvertMasterHis.ColumnNames.TO_DATETIME, TokenObj.TZ_REGION);
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgCurrencyConvertMasterHis.ColumnNames.TO_DATETIME, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
            //return string.Format("TO_CHAR({0}, 'YYYY/MM/DD HH24:MI:SS')", DataConverter.ConvertTimezone(CfgCurrencyConvertMasterHis.ColumnNames.FROM_DATETIME, "UTC", TokenObj.TZ_REGION)); }
            //get { return string.Format("{0}", TO_DATETIME); }
        }

        public string Formatted_FROM_DATETIME_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgCurrencyConvertMasterHis.ColumnNames.FROM_DATETIME, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        public string Formatted_CFG_CURRENCY_CNVRT_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgCurrencyConvertMasterHis.ColumnNames.CFG_CURRENCY_CNVRT_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }


        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgCurrencyConvertMasterHis.ColumnNames.CFG_CURRENCY_CONVERT_HIS_ID, "CFG_CURRENCY_CONVERT_HIS_ID");
            map.Add(CfgCurrencyConvertMasterHis.ColumnNames.CFG_CURRENCY_CONVERT_USER_ID, "CFG_CURRENCY_CONVERT_USER_ID");
            map.Add(CfgCurrencyConvertMasterHis.ColumnNames.CFG_CURRENCY_CNVT_HIS_DELEGATE, "CFG_CURRENCY_CNVT_HIS_DELEGATE");
            map.Add(CfgCurrencyConvertMasterHis.ColumnNames.CFG_CURRENCY_CNVRT_HIS_DATE, "CFG_CURRENCY_CNVRT_HIS_DATE");
            map.Add(CfgCurrencyConvertMasterHis.ColumnNames.CFG_CURRENCY_CONVERT_MASTER_ID, "CFG_CURRENCY_CONVERT_MASTER_ID");
            map.Add(CfgCurrencyConvertMasterHis.ColumnNames.CURRENCY_RATE, "CURRENCY_RATE");
            map.Add(CfgCurrencyConvertMasterHis.ColumnNames.FROM_CURRENCY_NAME, "FROM_CURRENCY_NAME");
            map.Add(CfgCurrencyConvertMasterHis.ColumnNames.TO_CURRENCY_NAME, "TO_CURRENCY_NAME");
            map.Add(CfgCurrencyConvertMasterHis.ColumnNames.FROM_DATETIME, "FROM_DATETIME");
            map.Add(CfgCurrencyConvertMasterHis.ColumnNames.TO_DATETIME, "TO_DATETIME");
            map.Add(CfgCurrencyConvertMasterHis.ColumnNames.ACTIVE, "ACTIVE");


            return map;
        }
        #endregion

    }
}

