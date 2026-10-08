
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
    public class CfgGLCodeMaster
    {
        public CfgGLCodeMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_GL_CODE_MASTER"; }
        }

        #region Properties       

        public decimal CFG_GL_CODE_ID { get; set; }
        public string CFG_GL_CODE_NAME { get; set; }
        public string CFG_GL_CODE_DESCRIPTION { get; set; }
        public string COMPANY_CODE { get; set; }
        public string CFG_GL_ACCOUNT_CATEGORY { get; set; }
        
        public string ACTIVE { get; set; }

        public TokenProperties? TokenObj { get; set; }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_GL_CODE_ID = CfgGLCodeMaster.TableName + ".CFG_GL_CODE_ID";
            public static string CFG_GL_CODE_NAME = CfgGLCodeMaster.TableName + ".CFG_GL_CODE_NAME";
            public static string CFG_GL_CODE_DESCRIPTION = CfgGLCodeMaster.TableName + ".CFG_GL_CODE_DESCRIPTION";
            public static string COMPANY_CODE = CfgGLCodeMaster.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgGLCodeMaster.TableName + ".ACTIVE";
            public static string CFG_GL_ACCOUNT_CATEGORY = CfgGLCodeMaster.TableName + ".CFG_GL_ACCOUNT_CATEGORY";

        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_GL_CODE_ID = "CFG_GL_CODE_ID";
            public static string CFG_GL_CODE_NAME = "CFG_GL_CODE_NAME";
            public static string CFG_GL_CODE_DESCRIPTION = "CFG_GL_CODE_DESCRIPTION";
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string ACTIVE = "ACTIVE";

        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_GL_CODE_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CFG_GL_CODE_NAME)); }
        }
        public string Formatted_CFG_GL_CODE_DESCRIPTION
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CFG_GL_CODE_DESCRIPTION)); }
        }
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_CODE)); }
        }


        public string Formatted_CFG_GL_ACCOUNT_CATEGORY
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CFG_GL_ACCOUNT_CATEGORY)); }
        }

        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgGLCodeMaster.ColumnNames.CFG_GL_CODE_ID, "CFG_GL_CODE_ID");
            map.Add(CfgGLCodeMaster.ColumnNames.CFG_GL_CODE_NAME, "CFG_GL_CODE_NAME");
            map.Add(CfgGLCodeMaster.ColumnNames.CFG_GL_CODE_DESCRIPTION, "CFG_GL_CODE_DESCRIPTION");
            map.Add(CfgGLCodeMaster.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgGLCodeMaster.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgGLCodeMaster.ColumnNames.CFG_GL_ACCOUNT_CATEGORY, "CFG_GL_ACCOUNT_CATEGORY");

            return map;
        }
        #endregion


       
    }
}