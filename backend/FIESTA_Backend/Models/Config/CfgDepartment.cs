
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgDepartment
    {
        public CfgDepartment()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_DEPARTMENT"; }
        }

        #region Properties       

        public decimal CFG_DEPARTMENT_ID { get; set; }
        public string DEPARTMENT_NAME { get; set; }
        public string DEPARTMENT_DESCRIPTION { get; set; }
        public string COMPANY_CODE { get; set; }
        public string ACTIVE { get; set; }
        public string OPERATION { get; set; }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_DEPARTMENT_ID = CfgDepartment.TableName + ".CFG_DEPARTMENT_ID";
            public static string DEPARTMENT_NAME = CfgDepartment.TableName + ".DEPARTMENT_NAME";
            public static string DEPARTMENT_DESCRIPTION = CfgDepartment.TableName + ".DEPARTMENT_DESCRIPTION";
            public static string COMPANY_CODE = CfgDepartment.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgDepartment.TableName + ".ACTIVE";
        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_DEPARTMENT_ID = "CFG_DEPARTMENT_ID";
            public static string DEPARTMENT_NAME = "DEPARTMENT_NAME";
            public static string DEPARTMENT_DESCRIPTION = "DEPARTMENT_DESCRIPTION";
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string ACTIVE = "ACTIVE";

        }
        #endregion

        #region FormattedValueForSqlTransaction        
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_CODE)); }
        }

        public string Formatted_DEPARTMENT_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(DEPARTMENT_NAME)); }
        }

        public string Formatted_DEPARTMENT_DESCRIPTION
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(DEPARTMENT_DESCRIPTION)); }
        }
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgDepartment.ColumnNames.CFG_DEPARTMENT_ID, "CFG_DEPARTMENT_ID");
            map.Add(CfgDepartment.ColumnNames.DEPARTMENT_NAME, "DEPARTMENT_NAME");           
            map.Add(CfgDepartment.ColumnNames.DEPARTMENT_DESCRIPTION, "DEPARTMENT_DESCRIPTION");
            map.Add(CfgDepartment.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgDepartment.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion
    }
}
