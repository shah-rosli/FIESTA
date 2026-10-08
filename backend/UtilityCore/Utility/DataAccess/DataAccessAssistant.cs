using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityCore.Utility.DataAccess
{
    public class DataAccessAssistant
    {
        public DataAccessAssistant()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string OracleSystimestampToUTC()
        {
            return "SYSTIMESTAMP AT TIME ZONE 'UTC'";
        }

        public static object ResetEmptyObject(System.Type readerType)
        {
            if (readerType == typeof(System.String))
                return "";
            else if (readerType == typeof(int))
                return 0;
            else return null;
        }

        //remove string before dot
        public static string GetColumnName(string columnName)
        {
            int dotIndex = columnName.IndexOf('.');
            if (dotIndex != -1)
                return columnName.Substring(dotIndex + 1, columnName.Length - (dotIndex + 1));

            return columnName;
        }
    }
}
