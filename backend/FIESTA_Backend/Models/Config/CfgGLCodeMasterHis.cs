
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
    public class CfgGLCodeMasterHis
    {
        public CfgGLCodeMasterHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_GL_CODE_MASTER_HIS"; }
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
            public static string CFG_GL_CODE_MASTER_HIS_ID = CfgGLCodeMasterHis.TableName + ".CFG_GL_CODE_MASTER_HIS_ID";
            public static string CFG_GL_CODE_MASTER_HIS_USER_ID = CfgGLCodeMasterHis.TableName + ".CFG_GL_CODE_MASTER_HIS_USER_ID";
            public static string GL_CODE_MASTER_HIS_DELEGATE = CfgGLCodeMasterHis.TableName + ".GL_CODE_MASTER_HIS_DELEGATE";
            public static string CFG_GL_CODE_MASTER_HIS_DATE = CfgGLCodeMasterHis.TableName + ".CFG_GL_CODE_MASTER_HIS_DATE";
            public static string CFG_GL_CODE_ID = CfgGLCodeMasterHis.TableName + ".CFG_GL_CODE_ID";
            public static string CFG_GL_CODE_NAME = CfgGLCodeMasterHis.TableName + ".CFG_GL_CODE_NAME";
            public static string CFG_GL_CODE_DESCRIPTION = CfgGLCodeMasterHis.TableName + ".CFG_GL_CODE_DESCRIPTION";
            public static string COMPANY_CODE = CfgGLCodeMasterHis.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgGLCodeMasterHis.TableName + ".ACTIVE";
            public static string CFG_GL_ACCOUNT_CATEGORY = CfgGLCodeMasterHis.TableName + ".CFG_GL_ACCOUNT_CATEGORY";

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
        public string Formatted_CFG_GL_CODE_MASTER_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgGLCodeMasterHis.ColumnNames.CFG_GL_CODE_MASTER_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgGLCodeMasterHis.ColumnNames.CFG_GL_CODE_MASTER_HIS_ID, "CFG_GL_CODE_MASTER_HIS_ID");
            map.Add(CfgGLCodeMasterHis.ColumnNames.CFG_GL_CODE_MASTER_HIS_USER_ID, "CFG_GL_CODE_MASTER_HIS_USER_ID");
            map.Add(CfgGLCodeMasterHis.ColumnNames.GL_CODE_MASTER_HIS_DELEGATE, "GL_CODE_MASTER_HIS_DELEGATE");
            map.Add(CfgGLCodeMasterHis.ColumnNames.CFG_GL_CODE_MASTER_HIS_DATE, "CFG_GL_CODE_MASTER_HIS_DATE");
            map.Add(CfgGLCodeMasterHis.ColumnNames.CFG_GL_CODE_ID, "CFG_GL_CODE_ID");
            map.Add(CfgGLCodeMasterHis.ColumnNames.CFG_GL_CODE_NAME, "CFG_GL_CODE_NAME");
            map.Add(CfgGLCodeMasterHis.ColumnNames.CFG_GL_CODE_DESCRIPTION, "CFG_GL_CODE_DESCRIPTION");
            map.Add(CfgGLCodeMasterHis.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgGLCodeMasterHis.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgGLCodeMasterHis.ColumnNames.CFG_GL_ACCOUNT_CATEGORY, "CFG_GL_ACCOUNT_CATEGORY");

            return map;
        }
        #endregion
    }
}
