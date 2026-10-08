using FIESTA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Backend.Models
{
    public class CfgGlCodeMasterStaging
    {
        public CfgGlCodeMasterStaging()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string TableName
        {
            get { return "CFG_GL_CODE_MASTER_STAGING"; }
        }
        public string CFG_GL_CODE_NAME { get; set; }
        public string CFG_GL_CODE_DESCRIPTION { get; set; }
        public string COMPANY_CODE { get; set; }
        public string CFG_GL_ACCOUNT_CATEGORY { get; set; }        

        public string ACTIVE { get; set; }

        public string USER_ID { get; set; }



        public TokenProperties? TokenObj { get; set; }
        

    }
}
