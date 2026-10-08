using FIESTA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Backend.Models
{
    public class CfgCpxMasterUpload
    {
        public CfgCpxMasterUpload()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string TableName
        {
            get { return "CFG_CPX_MASTER"; }
        }

        public decimal CFG_CPX_MASTER_ID { get; set; }
        public string CPX_NUMBER { get; set; }
        public string CPX_DESCRIPTION { get; set; }
        public string CPX_YEAR { get; set; }
        public string COMPANY_CODE { get; set; }
        
        public string CURRENCY_NAME { get; set; }
        public string CFG_COST_CENTER_NAME { get; set; }
        public decimal CPX_BUDGET_AMOUNT { get; set; }
        public string CPX_EQUIP_JIGTOOL { get; set; }
        public string CPX_APPROVAL_TARGET { get; set; }

        public string ACTIVE { get; set; }        
        public string USER_ID { get; set; }

        public string PROLONG_CAPEX_USE { get; set; }
        public string CPX_CATEGORY { get; set; }

        public TokenProperties? TokenObj { get; set; }


    }
}
