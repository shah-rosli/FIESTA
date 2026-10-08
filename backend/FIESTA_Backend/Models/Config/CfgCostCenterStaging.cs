using FIESTA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Backend.Models
{
    public class CfgCostCenterStaging
    {
        public CfgCostCenterStaging()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string TableName
        {
            get { return "CFG_COST_CENTER_STAGING"; }
        }
        public string CFG_COST_CENTER_NAME { get; set; }
        public string CFG_COST_CENTER_DESC { get; set; }
        public string COMPANY_CODE { get; set; }
        public string COST_CENTER_OWNER { get; set; }
        public string COST_CENTER_FINANCE_OWNER { get; set; }

        public string CC_ACD_SENIOR_MGR { get; set; }

        public string CC_ACD_DIRECTOR { get; set; }
        public string CC_ACD_VP { get; set; }
        public string CC_ASSET_REVIEWER { get; set; }

        public TokenProperties? TokenObj { get; set; }

        public string ACTIVE { get; set; }

        public string USER_ID { get; set; }

    }
}
