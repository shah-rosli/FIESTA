using FIESTA_Backend.Models;
using System;


namespace FIESTA_Backend.Models
{
    public class CfgInvAssetClassStaging
    {
        public CfgInvAssetClassStaging()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region TableName
        public static string TableName
        {
            get { return "CFG_INV_ASSET_CLASS_STAGING"; }
        }
        #endregion
        #region Properties

       
           
        public string INV_ASSET_CLASS_NAME { get; set; }
        public string INV_ASSET_CATEGORY { get; set; }

        public string INV_DEPRECIATION_YEAR { get; set; }
        public string COMPANY_CODE { get; set; }

        public string ACTIVE { get; set; }
        public string USER_ID { get; set; }




        public TokenProperties? TokenObj { get; set; }

        #endregion
    }
}
