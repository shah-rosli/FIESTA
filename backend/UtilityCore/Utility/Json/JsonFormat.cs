using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityCore.Utility.Json
{
    public static class JsonFormat
    {

        //To Format the json Object before passing to Stored Proc
        // For removing the unnecessary properties  like "tokenObj" or "Formatted"
        // expression should be startswith,contains
        public static string FormatJsonString(string jsonVal, string[] attrName, string expression)
        {
            var temp = JObject.Parse(jsonVal);
            foreach (string attrnam in attrName)
            {
                if (expression == Constants.CheckStartsWith)
                {

                    temp.Descendants()
                            .OfType<JProperty>()
                            .Where(attr => attr.Name.StartsWith(attrnam))
                            .ToList() // you should call ToList because you're about to changing the result, which is not possible if it is IEnumerable
                            .ForEach(attr => attr.Remove()); // removing unwanted attributes

                }
                else if (expression == Constants.CheckContains)
                {

                    temp.Descendants()
                            .OfType<JProperty>()
                            .Where(attr => attr.Name.Contains(attrnam))
                            .ToList() // you should call ToList because you're about to changing the result, which is not possible if it is IEnumerable
                            .ForEach(attr => attr.Remove()); // removing unwanted attributes

                }
            }

            return temp.ToString();
        }

        private static object DataTableToJson(DataTable table, object example)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JsonConvert.DeserializeAnonymousType<object>(JSONString, example);
        }
    }
}
