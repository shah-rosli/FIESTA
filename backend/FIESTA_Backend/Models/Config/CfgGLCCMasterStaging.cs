using FIESTA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Backend.Models
{
    public class CfgGLCCMasterStaging
    {
        public CfgGLCCMasterStaging()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string TableName
        {
            get { return "CFG_CC_GL_STAGING"; }
        }
        public string GL_CODE_NAME { get; set; }
        public string COST_CENTER_NAME { get; set; }
        public string GL_CODE_DESC { get; set; }
        public string COST_CENTER_DESC { get; set; }        
        public string SYS_OR_USER_ID { get; set; }
        public TokenProperties? TokenObj { get; set; }
        public string COMPANY_CODE { get; set; }

    }
}
