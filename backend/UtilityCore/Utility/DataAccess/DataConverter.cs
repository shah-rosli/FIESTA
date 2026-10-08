using NPOI.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UtilityCore.Utility.DataAccess
{
    public static class DataConverter
    {
        private static string _userDefineCultureInfo = System.Globalization.CultureInfo.CurrentCulture.ToString();
        //public DataConverter()
        //{
        //    //
        //    // TODO: Add constructor logic here
        //    //
        //}

        public static System.DateTime DateConvertor(string dateString, string provider)
        {
            string[] dateFormat = dateString.Split('/');
            if ((dateFormat[0]).Length < 2)
            {
                dateFormat[0] = string.Format("0{0}", dateFormat[0]);
            }
            if ((dateFormat[1]).Length < 2)
            {
                dateFormat[1] = string.Format("0{0}", dateFormat[1]);
            }
            dateString = string.Format("{0}/{1}/{2}", dateFormat[0], dateFormat[1], dateFormat[2]);
            System.IFormatProvider format = new System.Globalization.CultureInfo(_userDefineCultureInfo, true);
            System.DateTime dateTime = System.DateTime.ParseExact(dateString,
                provider, format,
                System.Globalization.DateTimeStyles.AllowWhiteSpaces);

            return dateTime;
        }

        /// <summary>
        /// Return converted string format from DateConvertor
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        private static string _userDefineDateFormat = System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
        //private static string _userDefineCultureInfo = System.Globalization.CultureInfo.CurrentCulture.ToString();

        public static string DateHtmlConvertor(System.DateTime dateString)
        {
            string _myHtmlDateTime = dateString.ToString(_userDefineDateFormat);

            //DateTimeFormatInfo myDTFI = new CultureInfo(_userDefineCultureInfo, false).DateTimeFormat;
            //_myHtmlDateTime = System.DateTime.Parse();

            return _myHtmlDateTime;
        }
        //public static string ToHtmlString(object inData)
        //{
        //    string outData = "";
        //    if (inData != null)
        //    {
        //        System.Type readerType = inData.GetType();
        //        if (readerType == typeof(System.String))
        //        {
        //            if (!"".Equals(inData))
        //            {
        //                outData = DataConverter.HtmlEncode(inData.ToString());
        //            }
        //        }
        //        else if (readerType == typeof(System.DateTime))
        //        {
        //            outData = DataConverter.DateHtmlConvertor(System.Convert.ToDateTime(inData));
        //        }
        //        else
        //        {
        //            outData = inData.ToString();
        //        }
        //    }
        //    return outData;
        //}


        /// <summary>
        /// Return converted data value for display through web
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string HtmlEncode(string inputString)
        {

            System.Text.StringBuilder retVal = new System.Text.StringBuilder();

            // check incoming parameters for null or blank string
            if ((inputString != null) && (inputString != string.Empty))
            {
                inputString = inputString.Trim();

                //convert some harmful symbols incase the regular
                //expression validators are changed
                for (int i = 0; i < inputString.Length; i++)
                {
                    switch (inputString[i])
                    {
                        case '"':
                            retVal.Append("&quot;");
                            break;
                        case '<':
                            retVal.Append("&lt;");
                            break;
                        case '>':
                            retVal.Append("&gt;");
                            break;
                        default:
                            retVal.Append(inputString[i]);
                            break;
                    }
                }
            }

            return retVal.ToString();

        }

        //return 0 if null or empty, else return the input
        public static int ConvertStringToInt(string inputString)
        {
            if (inputString == null || inputString.Equals(""))
                return 0;
            return Convert.ToInt32(inputString);
        }

        //return 0 if null or empty, else return the input
        public static decimal ConvertStringToDecimal(string inputString)
        {
            if (inputString == null || inputString.Equals(""))
                return 0;
            return Convert.ToDecimal(inputString);
        }

        public static DateTime GetCurrentCorporateDateTime()
        {
            return TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"));
        }

        //public static string GetOracleInsertDateString( DateTime inputValue)
        //{
        //    return string.Format("  to_date({0},'{1}') ", DataConverter.GetDBDate(inputValue, AppProperties.DBDateTimeFormat), AppProperties.OracleDateTime24HrFormat);
        //}
        //return null if input is 2001/01/01, else convert to dbdate format base on the input format
        public static string GetDBDate(DateTime inputDate, string dbDateFormat)
        {
            string returnDate = "null";
            if (inputDate != DateTime.MinValue)
                returnDate = string.Format("'{0}'", inputDate.ToString(dbDateFormat));
            else
                returnDate = "null";

            return returnDate;
        }

        public static string FormatSQLForString(string? inputData)
        {
            if (inputData != null && inputData.Trim().Length > 0)
            {
                //replace all single quote with 2 single quote
                inputData = inputData.Replace("'", "''");
                return string.Format("'{0}'", inputData);
            }

            return "null";
        }

        public static string FormatSQLForDecimal(decimal? inputData)
        {
            if (inputData.HasValue)
            {
                return string.Format("'{0}'", inputData);
            }

            return "null";
        }

        public static string FormatSQLForDate(DateTime? inputData)
        {
            if (inputData.HasValue)
            {
                return string.Format("'{0}'", inputData.Value.ToString("yyyy-MM-dd"));
            }

            return "null";
        }

        public static string FormatSQLForDateOnly(DateOnly? inputData)
        {
            if (inputData.HasValue)
            {
                return string.Format("TO_DATE('{0}','YYYY-MM-DD')", inputData.Value.ToString("yyyy-MM-dd"));
            }

            return "null";
        }

        public static string FormatSQLForTimestamp(DateTime? inputData)
        {
            if (inputData.HasValue)
            {
                return string.Format("to_timestamp('{0}', 'dd-mm-yyyy hh24:mi:ss')", inputData.Value.ToString("dd-MM-yyyy HH:mm:ss"));
            }

            return "null";
        }

        public static string FormatSQL(string inputData)
        {
            if (inputData != null)
            {
                if (inputData.IndexOf("'") > -1)
                {
                    int position = inputData.IndexOf("'");
                    if (position == 0)
                        inputData = string.Format("'{0}", inputData);
                    else if (position == inputData.Length - 1)
                        inputData = string.Format("{0}'", inputData);
                    else
                        inputData = inputData.Replace("'", "''");
                    //    inputData = string.Format("{0}'{1}", inputData.Substring(0, position), inputData.Substring(position, inputData.Length - position));

                }
            }

            return inputData;
        }
        public static string FormatSQLForUOM(string inputData)
        {
            if (inputData != null)
            {
                if (inputData.IndexOf("'") > -1)
                {
                    int position = inputData.IndexOf("'");
                    if (position == 0)
                        inputData = string.Format("''{0}", inputData);
                    else if (position == inputData.Length - 1)
                        inputData = string.Format("{0}'", inputData);
                    else
                        inputData = inputData.Replace("'", "''");
                    //    inputData = string.Format("{0}'{1}", inputData.Substring(0, position), inputData.Substring(position, inputData.Length - position));

                }
            }

            return inputData;
        }

        public static string ConvertTimezone(DateTimeOffset? strDateTime, string from_region, string to_region)
        {
            //DateTimeOffset univDateTime;            
            //string region = "Asia/Tokyo";

            try
            {
                if (strDateTime != DateTime.MinValue)
                {
                    //string dbDateFormatString = strDateTime.Value.ToString("dd-MMM-yy hh.mm.ss tt");

                    //string dbTimestampFormat = System.Configuration.ConfigurationManager.AppSettings["OracleTimestampFormat_In_DatetimeToString"];
                    //string formatted_date_string = string.Format(" FROM_TZ(CAST('{0}' AS TIMESTAMP), '{1}') AT TIME ZONE '{2}' ", dbTimestampFormat, from_region, to_region);

                    string dbTimestampFormat = System.Configuration.ConfigurationManager.AppSettings["OracleTimestampFormat_In_DatetimeToString"];
                    string dbDateFormatString = strDateTime.Value.ToString(dbTimestampFormat); // Japan - 2016?1?9?  
                    string formatted_date_string = string.Format(" FROM_TZ(CAST('{0}' AS TIMESTAMP), '{1}') AT TIME ZONE '{2}' ", dbDateFormatString, from_region, to_region);


                    //localDateTime = DateTime.Parse(strDateTime);
                    //localDateTime = strDateTime;
                    //DateTimeOffset univDateTime = strDateTime.ToUniversalTime();

                    //string to_string_u = string.Format("'{0}'", strDateTime.ToString("u")); /* this return "'2020-05-31 17:00:00Z'" */
                    //string to_universaltime = strDateTime.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");//this return "2020-05-31 17:00:00"
                    //return to_string_u;
                    //return string.Format("TIMESTAMP '{0} +00:00'", to_universaltime);

                    return formatted_date_string;
                    //return string.Format("'{0}'", univDateTime.ToString("yyyy-MM-dd HH:mm:ss"));

                }
                else
                    return null;
                //return "''"; /* this return value will insert null to db */
            }
            catch (FormatException ex)
            {
                throw ex;
            }

        }
        public static string ConvertTimezone(DateTime strDateTime, string from_region, string to_region)
        {
            //DateTimeOffset univDateTime;            
            //string region = "Asia/Tokyo";

            try
            {
                if (strDateTime != DateTime.MinValue)
                {
                    //string dbDateFormatString = strDateTime.ToString("dd-MMM-yy hh.mm.ss tt", new CultureInfo("en-US")); // Japan - 2016?1?9?  
                    //string dbDateFormatString = strDateTime.ToString("yy-MM-dd hh.mm.ss tt", new CultureInfo("en-US")); // Japan - 2016?1?9?  
                    //string dbDateFormatString = strDateTime.ToString("yy-MM-dd HH:mm:ss"); // Japan - 2016?1?9?  
                    string dbTimestampFormat = System.Configuration.ConfigurationManager.AppSettings["OracleTimestampFormat_In_DatetimeToString"];
                    string dbDateFormatString = strDateTime.ToString(dbTimestampFormat); // Japan - 2016?1?9?  
                    string formatted_date_string = string.Format(" FROM_TZ(CAST('{0}' AS TIMESTAMP), '{1}') AT TIME ZONE '{2}' ", dbDateFormatString, from_region, to_region);

                    //localDateTime = DateTime.Parse(strDateTime);
                    //localDateTime = strDateTime;
                    //DateTimeOffset univDateTime = strDateTime.ToUniversalTime();

                    //string to_string_u = string.Format("'{0}'", strDateTime.ToString("u")); /* this return "'2020-05-31 17:00:00Z'" */
                    //string to_universaltime = strDateTime.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");//this return "2020-05-31 17:00:00"
                    //return to_string_u;

                    //return string.Format("TIMESTAMP '{0} +00:00'", to_universaltime);               


                    return formatted_date_string;
                    //return string.Format("'{0}'", univDateTime.ToString("yyyy-MM-dd HH:mm:ss"));

                }
                else
                    return null;
                //return "''"; /* this return value will insert null to db */
            }
            catch (FormatException ex)
            {
                throw ex;
            }

        }


        public static string[] DataTableToStringArray(this DataTable dt, string colname)
        {
            string[] arrray = dt.Rows.OfType<DataRow>().Select(k => k[colname].ToString()).ToArray();

            return arrray;
        }

        public static string[] DataRowArrayToStringArray(this DataRow[] dra, string colname)
        {
            string[] arrray = dra.Select(k => k[colname].ToString()).ToArray();

            return arrray;
        }

        /// <summary>
        /// Convert DataTable to List Of Class
        /// </summary>        

        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch (Exception ex)
            {
                //return null;
                throw ex;
            }
        }

        public static List<T> DataRowArrayToList<T>(this DataRow[] dra) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in dra.AsEnumerable())
                {
                    T obj = new T();




                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch (Exception ex)
            {
                //return null;
                throw ex;
            }
        }

        public static DataTable ListToDataTable<T>(List<T> items, string createdBy = "", string insertOrUpdate = "", decimal haveError = -1, decimal haveDifference = -1)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    var val = Props[i].GetValue(item, null);
                    //if object is boolean convertable,change to 0 or 1
                    bool actual;
                    DateTime actualDT;
                    if (val != null && bool.TryParse(val.ToString(), out actual))
                    {
                        if (actual)
                            values[i] = 1;
                        else
                            values[i] = 0;
                    }
                    else
                    {
                        values[i] = val;
                    }

                    if (Props[i].Name == "createdBy" && !string.IsNullOrEmpty(createdBy))
                    {
                        values[i] = createdBy;
                    }
                    else if (Props[i].Name == "insertOrUpdate" && !string.IsNullOrEmpty(insertOrUpdate))
                    {
                        values[i] = insertOrUpdate;
                    }
                    else if (Props[i].Name == "haveError" && haveError != -1)
                    {
                        values[i] = haveError;
                    }
                    else if (Props[i].Name == "haveDifference" && haveDifference != -1)
                    {
                        values[i] = haveDifference;
                    }
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        //public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        //{
        //    try
        //    {
        //        List<T> list = new List<T>();

        //        foreach (var row in table.AsEnumerable())
        //        {
        //            T obj = new T();




        //            foreach (var prop in obj.GetType().GetProperties())
        //            {
        //                try
        //                {
        //                    PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
        //                    propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
        //                }
        //                catch
        //                {
        //                    continue;
        //                }
        //            }

        //            list.Add(obj);
        //        }

        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        //return null;
        //        throw ex;
        //    }
        //}


        //In progress code
        //private void ConvertTime()
        //{
        //    DateTime localDateTime, univDateTime;

        //    //Console.WriteLine("Enter a date and time.");
        //    string strDateTime = "2020-05-15T14:20:00"; //Console.ReadLine();

        //    try
        //    {
        //        localDateTime = DateTime.Parse(strDateTime);
        //        univDateTime = localDateTime.ToUniversalTime();

        //        //Console.WriteLine("{0} local time is {1} universal time.",
        //        //                    localDateTime,
        //        //                        univDateTime);
        //    }
        //    catch (FormatException)
        //    {
        //        //Console.WriteLine("Invalid format.");
        //        return;
        //    }

        //    //Console.WriteLine("Enter a date and time in universal time.");
        //    strDateTime = Console.ReadLine();

        //    try
        //    {
        //        univDateTime = DateTime.Parse(strDateTime);
        //        localDateTime = univDateTime.ToLocalTime();

        //        //Console.WriteLine("{0} universal time is {1} local time.",
        //        //                         univDateTime,
        //        //                         localDateTime);
        //    }
        //    catch (FormatException)
        //    {
        //        //Console.WriteLine("Invalid format.");
        //        return;
        //    }
        //}

    }
}
