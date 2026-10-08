using FIESTA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace FIESTA_Backend.Models
{
    public class TokenProperties
    {
        private ClaimsIdentity claimsIdentity;

        public TokenProperties()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public decimal CFG_USER_ID { get; set; }
        public string USER_ID { get; set; }
        public string USER_DS_NUMBER { get; set; }
        public string USER_EMAIL { get; set; }
        public string USER_FULL_NAME { get; set; }
        public string USER_FIRST_NAME { get; set; }
        public string USER_LAST_NAME { get; set; }
        public string DEFAULT_COST_CENTER { get; set; }
        public string USER_COMPANY_CODE { get; set; }
        public string USER_LOCAL_GRADE { get; set; }
        public string USER_LOCAL_TITLE { get; set; }
        public string USER_GLOBAL_GRADE { get; set; }
        public string USER_GLOBAL_TITLE { get; set; }
        public string USER_GLOBAL_UNIT { get; set; }
        public string USER_GLOBAL_UNIT_CODE { get; set; }
        public string USER_GLOBAL_UNIT_NAME { get; set; }
        public string USER_GLOBAL_DIV { get; set; }
        public string USER_GLOBAL_DIV_CODE { get; set; }
        public string USER_GLOBAL_DIV_NAME { get; set; }
        public string USER_MANAGER_USER_ID { get; set; }
        public string ACTIVE { get; set; }
        public string DEFAULT_TIMEZONE { get; set; }
        public string DEFAULT_DISP_DATE_FORMAT { get; set; }
        public string DEFAULT_DISP_TIME_FORMAT { get; set; }
        public string DEFAULT_DISP_DATETIME_FORMAT { get; set; }
        public string DEFAULT_LANGUAGE { get; set; }
        public string DELEGATE_ID { get; set; }
        public List<string> USER_GROUPS { get; set; } = [];



        public TokenProperties(ClaimsIdentity claimsIdentity)
        {
            this.claimsIdentity = claimsIdentity;
        }

        public TokenProperties GetTokenObject()
        {
            //var identity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                IEnumerable<Claim> claims = claimsIdentity.Claims;
                //var tz_region = claims.Where(p => p.Type == "tz_region").FirstOrDefault()?.Value;
                //var userid = claims.Where(p => p.Type == "userid").FirstOrDefault()?.Value;
                //var name = claims.Where(p => p.Type == "name").FirstOrDefault()?.Value;


                TokenProperties token = new TokenProperties();
                token.ACTIVE = claims.Where(p => p.Type == "ACTIVE").FirstOrDefault()?.Value;
                token.CFG_USER_ID = Convert.ToDecimal( claims.Where(p => p.Type == "CFG_USER_ID").FirstOrDefault()?.Value);
                token.USER_ID = claims.Where(p => p.Type == "USER_ID").FirstOrDefault()?.Value;
                token.USER_EMAIL = claims.Where(p => p.Type == "USER_EMAIL").FirstOrDefault()?.Value;

                token.USER_FULL_NAME = claims.Where(p => p.Type == "USER_FULL_NAME").FirstOrDefault()?.Value;
                token.USER_COMPANY_CODE = claims.Where(p => p.Type == "USER_COMPANY_CODE").FirstOrDefault()?.Value;
                token.USER_DS_NUMBER = claims.Where(p => p.Type == "USER_DS_NUMBER").FirstOrDefault()?.Value;
                token.USER_FIRST_NAME = claims.Where(p => p.Type == "USER_FIRST_NAME").FirstOrDefault()?.Value;
                token.USER_LAST_NAME = claims.Where(p => p.Type == "USER_LAST_NAME").FirstOrDefault()?.Value;

                token.USER_GLOBAL_DIV = claims.Where(p => p.Type == "USER_GLOBAL_DIV").FirstOrDefault()?.Value;
                token.USER_GLOBAL_DIV_CODE = claims.Where(p => p.Type == "USER_GLOBAL_DIV_CODE").FirstOrDefault()?.Value;
                token.USER_GLOBAL_DIV_NAME = claims.Where(p => p.Type == "USER_GLOBAL_DIV_NAME").FirstOrDefault()?.Value;
                token.USER_GLOBAL_GRADE = claims.Where(p => p.Type == "USER_GLOBAL_GRADE").FirstOrDefault()?.Value;
                token.USER_GLOBAL_TITLE = claims.Where(p => p.Type == "USER_GLOBAL_TITLE").FirstOrDefault()?.Value;
                token.USER_GLOBAL_UNIT = claims.Where(p => p.Type == "USER_GLOBAL_UNIT").FirstOrDefault()?.Value;

                token.USER_GLOBAL_UNIT_NAME = claims.Where(p => p.Type == "USER_GLOBAL_UNIT_NAME").FirstOrDefault()?.Value;
                token.USER_LOCAL_GRADE = claims.Where(p => p.Type == "USER_LOCAL_GRADE").FirstOrDefault()?.Value;
                token.USER_LOCAL_TITLE = claims.Where(p => p.Type == "USER_LOCAL_TITLE").FirstOrDefault()?.Value;
                token.USER_MANAGER_USER_ID = claims.Where(p => p.Type == "USER_MANAGER_USER_ID").FirstOrDefault()?.Value;

                //token.USER_GROUPS = claims.Where(p => p.Type == "USER_GROUPS").FirstOrDefault()?.Value;
                token.DEFAULT_TIMEZONE = claims.Where(p => p.Type == "DEFAULT_TIMEZONE").FirstOrDefault()?.Value;
                token.DEFAULT_COST_CENTER = claims.Where(p => p.Type == "DEFAULT_COST_CENTER").FirstOrDefault()?.Value;
                token.DEFAULT_DISP_DATETIME_FORMAT = claims.Where(p => p.Type == "DEFAULT_DISP_DATETIME_FORMAT").FirstOrDefault()?.Value;
                token.DEFAULT_DISP_DATE_FORMAT = claims.Where(p => p.Type == "DEFAULT_DISP_DATE_FORMAT").FirstOrDefault()?.Value;
                token.DEFAULT_DISP_TIME_FORMAT = claims.Where(p => p.Type == "DEFAULT_DISP_TIME_FORMAT").FirstOrDefault()?.Value;
                token.DEFAULT_LANGUAGE = claims.Where(p => p.Type == "DEFAULT_LANGUAGE").FirstOrDefault()?.Value;
                token.DELEGATE_ID = claims.Where(p => p.Type == "DELEGATE_ID").FirstOrDefault()?.Value;
                token.USER_GROUPS = [.. claims.Where(c => c.Type == "USER_GROUPS").Select(c => c.Value)];





                return token;

            }
            
            return null;
        }

    }
}