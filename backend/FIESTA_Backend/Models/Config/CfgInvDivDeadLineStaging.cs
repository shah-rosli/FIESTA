
using FIESTA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Backend.Models
{
    public class CfgInvDivDeadLineStaging
    {
        public CfgInvDivDeadLineStaging()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region TableName
        public static string TableName
        {
            get { return "CFG_INV_DIV_DEADLINE_STAGING"; }
        }
        #endregion
        #region Properties



       
        public decimal  INV_AOP_YEAR { get; set; }
        public string GLOBAL_DIV { get; set; }
        public string ACTIVE { get; set; }
        public string USER_ID { get; set; }
        public string INV_DIV_DEADLINE { get; set; }




        public TokenProperties? TokenObj { get; set; }
       
        #endregion
    }
}
