using FIESTA_Backend.DataAccess.Config;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UtilityCore.Utility.Encryption;

namespace FIESTA_Backend.Controllers.Login
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private FiestaDbContext _context;

        public TokenController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
        }

        [AllowAnonymous]
        [Route("api/encript/{plaintext}")]
        [HttpGet]
        public Object GetEncripted(string plaintext)
        {
            ClsCrypto objEncrpt = new ClsCrypto("1234");
            string encrypted = objEncrpt.Encrypt(plaintext);

            return encrypted;
        }

        [Route("api/jwt/key")]
        [HttpPost]
        public async Task<Object> GetToken(LoginProperties obj)
        {
            string jwtkey = _config.GetSection("Jwt:Key").Value; //Secret key which will be used later during validation    
            var issuer = _config.GetSection("Jwt:Issuer").Value;  //normally this will be your site URL    
            var audience = _config.GetSection("Jwt:Audience").Value;                                      //var issuer = "http://localhost:44331";  //normally this will be your site URL    

            //key = "pW/w4s7McksOTEHt3HUwtU0cK1/fz/fwfp7BOr5+dRBFE64ak8WV35iYYFYYvjFxnb/7DfJ9ELudIrdK6o/zWA==";
            string key = obj.key;
            string delegateid = obj.delegateid;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtkey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            //string dkey = "b14ca5898a4e4133bbce2ea2315a1916";
            //string userloginemail = EncryptString(dkey, "pohleng" );

            //key = "/Tw6NZLEd7SgWpDasW+W5A==";

            //ClsCrypto objEncrpt = new ClsCrypto("1234");
            //string useremail = objEncrpt.Decrypt(key);

            string useremail = Decrypt(key, "1234");
            permClaims = await UpdateClaimsWithUserProfile(useremail, delegateid);


            //need to return the default display date time format
            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(issuer, //Issure    
                            audience,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return new { data = jwt_token };



            //return string.Format("{0}", useremail);
        }

        private string Decrypt(string cipherText)
        {
            ClsCrypto objEncrpt = new ClsCrypto("1234");
            string decrypted = objEncrpt.Decrypt(cipherText);

            return decrypted;
        }

        private string Decrypt(string cipherText, string password)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                // extract salt (first 16 bytes)
                var salt = cipherBytes.Take(16).ToArray();
                // extract iv (next 16 bytes)
                var iv = cipherBytes.Skip(16).Take(16).ToArray();
                // the rest is encrypted data
                var encrypted = cipherBytes.Skip(32).ToArray();
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, salt, 100);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.Padding = PaddingMode.PKCS7;
                encryptor.Mode = CipherMode.CBC;
                encryptor.IV = iv;
                // you need to decrypt this way, not the way in your question
                using (MemoryStream ms = new MemoryStream(encrypted))
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(cs, Encoding.UTF8))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }
        //
        private async Task<List<Claim>> UpdateClaimsWithUserProfile(string userloginemail, string delegateid)
        {
            CfgUserDAL userDAL = new CfgUserDAL(_config, _httpContext);
            CfgUser tokenObj = new CfgUser();
            CfgUser objDelegatee = new CfgUser();
            CfgUser objUserLogin = new CfgUser();
            List<Claim> permClaims = new List<Claim>();

            objUserLogin = userDAL.SelectRowByUserEmail(userloginemail);

            if (delegateid != "0")
            {
                objDelegatee = userDAL.SelectRowByUserId(delegateid);


                tokenObj = objDelegatee;

                if (objDelegatee != null)
                {
                    tokenObj.DELEGATE_ID = objUserLogin.USER_ID;
                }
            }
            else
                tokenObj = objUserLogin;

            if (tokenObj != null)
            {
                var defaultPropertiesObj = GetDefaultProperties(tokenObj.USER_COMPANY_CODE);

                if(defaultPropertiesObj != null)
                {
                    if (tokenObj.DEFAULT_TIMEZONE == null)
                    {
                        tokenObj.DEFAULT_TIMEZONE = defaultPropertiesObj.DEFAULT_TIMEZONE;
                    }
                    if (tokenObj.DEFAULT_DISP_DATE_FORMAT == null)
                    {
                        tokenObj.DEFAULT_DISP_DATE_FORMAT = defaultPropertiesObj.DEFAULT_DISP_DATE_FORMAT;
                    }
                    if (tokenObj.DEFAULT_DISP_TIME_FORMAT == null)
                    {
                        tokenObj.DEFAULT_DISP_TIME_FORMAT = defaultPropertiesObj.DEFAULT_DISP_TIME_FORMAT;
                    }
                    if (tokenObj.DEFAULT_DISP_DATETIME_FORMAT == null)
                    {
                        tokenObj.DEFAULT_DISP_DATETIME_FORMAT = defaultPropertiesObj.DEFAULT_DISP_DATETIME_FORMAT;
                    }
                    if (tokenObj.DEFAULT_LANGUAGE == null)
                    {
                        tokenObj.DEFAULT_LANGUAGE = defaultPropertiesObj.DEFAULT_LANGUAGE;
                    }
                        
                    tokenObj.USER_GROUPS = await getUserGroupsByEmailAsync(userloginemail);
                 
                }

                permClaims = SetPermissionClaims(tokenObj);
            }

            return permClaims;
        }

        private async Task<List<string>> getUserGroupsByEmailAsync(string userloginemail)
        {

            var userIds = _context.CFG_USERs
                .Where(u => u.USER_EMAIL.ToUpper() == userloginemail.ToUpper())
                .Select(u => u.USER_ID);

            var groupIds = _context.CFG_USER_USER_GROUP_MAPs
                .Where(m => userIds.Contains(m.USER_ID))
                .Select(m => m.CFG_USER_GROUP_ID);

            return await _context.CFG_USER_GROUPs
                .Where(g => groupIds.Contains(g.CFG_USER_GROUP_ID) && g.ACTIVE == "Yes")
                .Select(g => g.USER_GROUP_NAME)
                .Distinct()
                .ToListAsync();

            //List<string> groupNames = new List<string>();

            //string sql = @"
            //SELECT USER_GROUP_NAME
            //FROM CFG_USER_GROUP
            //WHERE CFG_USER_GROUP_ID IN (
            //    SELECT CFG_USER_GROUP_ID
            //    FROM CFG_USER_USER_GROUP_MAP
            //    WHERE USER_ID IN (
            //        SELECT USER_ID
            //        FROM CFG_USER
            //        WHERE UPPER(USER_EMAIL) = UPPER(@USER_EMAIL)
            //    )
            //)
            //AND ACTIVE = 'Yes'";

        }

        private CfgUser GetDefaultProperties(string userCompanyCode)
        {
            CfgCompanyMasterDAL companyDAL = new CfgCompanyMasterDAL(_config, _httpContext);
            CfgCompanyMaster objCompany = companyDAL.SelectRowByCode(userCompanyCode);
            CfgUser objUser = new CfgUser();

            CfgSystemParamDAL dalParam = new CfgSystemParamDAL(_config, _httpContext);
            DataTable dtParam = dalParam.GetCfgSystemParam();
            DataRow[] draDefaultDisplayDateFormat = dtParam.Select(string.Format("{0}='{1}'", CfgSystemParam.ColumnNamesOnly.PARAM_KEY, CfgSystemParam.System_Format.DefaultDisplayDateFormat));
            DataRow[] draDefaultDisplayDateTimeFormat = dtParam.Select(string.Format("{0}='{1}'", CfgSystemParam.ColumnNamesOnly.PARAM_KEY, CfgSystemParam.System_Format.DefaultDisplayDateTimeFormat));
            DataRow[] draDefaultDisplayTimeFormat = dtParam.Select(string.Format("{0}='{1}'", CfgSystemParam.ColumnNamesOnly.PARAM_KEY, CfgSystemParam.System_Format.DefaultDisplayTimeFormat));
            DataRow[] draDefaultSystemTimezone = dtParam.Select(string.Format("{0}='{1}'", CfgSystemParam.ColumnNamesOnly.PARAM_KEY, CfgSystemParam.System_Format.DefaultSystemTimezone));
            DataRow[] draDefaultLanguage = dtParam.Select(string.Format("{0}='{1}'", CfgSystemParam.ColumnNamesOnly.PARAM_KEY, CfgSystemParam.System_Format.DefaultLanguage));
            if (objUser.DEFAULT_TIMEZONE == null)
            {
                if (objCompany.DEFAULT_TIMEZONE == null)
                    objUser.DEFAULT_TIMEZONE = draDefaultSystemTimezone[0][CfgSystemParam.ColumnNamesOnly.PARAM_VALUE].ToString();
                else
                    objUser.DEFAULT_TIMEZONE = objCompany.DEFAULT_TIMEZONE;
            }
            if (objUser.DEFAULT_DISP_DATE_FORMAT == null)
            {
                if (objCompany.DEFAULT_DISP_DATE_FORMAT == null)
                    objUser.DEFAULT_DISP_DATE_FORMAT = draDefaultDisplayDateFormat[0][CfgSystemParam.ColumnNamesOnly.PARAM_VALUE].ToString();
                else
                    objUser.DEFAULT_DISP_DATE_FORMAT = objCompany.DEFAULT_DISP_DATE_FORMAT;
            }
            if (objUser.DEFAULT_DISP_TIME_FORMAT == null)
            {
                if (objCompany.DEFAULT_DISP_TIME_FORMAT == null)
                    objUser.DEFAULT_DISP_TIME_FORMAT = draDefaultDisplayTimeFormat[0][CfgSystemParam.ColumnNamesOnly.PARAM_VALUE].ToString();
                else
                    objUser.DEFAULT_DISP_TIME_FORMAT = objCompany.DEFAULT_DISP_TIME_FORMAT;
            }
            if (objUser.DEFAULT_DISP_DATETIME_FORMAT == null)
            {
                if (objCompany.DEFAULT_DISP_DATETIME_FORMAT == null)
                    objUser.DEFAULT_DISP_DATETIME_FORMAT = draDefaultDisplayDateTimeFormat[0][CfgSystemParam.ColumnNamesOnly.PARAM_VALUE].ToString();
                else
                    objUser.DEFAULT_DISP_DATETIME_FORMAT = objCompany.DEFAULT_DISP_DATETIME_FORMAT;
            }
            if (objUser.DEFAULT_LANGUAGE == null)
            {
                if (objCompany.DEFAULT_LANGUAGE == null)
                    objUser.DEFAULT_LANGUAGE = draDefaultLanguage[0][CfgSystemParam.ColumnNamesOnly.PARAM_VALUE].ToString();
                else
                    objUser.DEFAULT_LANGUAGE = objCompany.DEFAULT_LANGUAGE;
            }

            return objUser;
        }

        private List<Claim> SetPermissionClaims(CfgUser objUser)
        {
            List<Claim> permClaims = new List<Claim>();

            permClaims.Add(new Claim("ACTIVE", objUser.ACTIVE));
            permClaims.Add(new Claim("CFG_USER_ID", objUser.CFG_USER_ID.ToString()));
            permClaims.Add(new Claim("USER_ID", objUser.USER_ID));
            permClaims.Add(new Claim("USER_EMAIL", objUser.USER_EMAIL));
            permClaims.Add(new Claim("USER_FULL_NAME", objUser.USER_FULL_NAME));
            permClaims.Add(new Claim("USER_COMPANY_CODE", objUser.USER_COMPANY_CODE));

            //permClaims.Add(new Claim("USER_DS_NUMBER", objUser.USER_DS_NUMBER));
            permClaims.Add(new Claim("USER_FIRST_NAME", objUser.USER_FIRST_NAME));
            permClaims.Add(new Claim("USER_LAST_NAME", objUser.USER_LAST_NAME));
            permClaims.Add(new Claim("USER_GLOBAL_DIV", (objUser.USER_GLOBAL_DIV == null ? "" : objUser.USER_GLOBAL_DIV)));
            permClaims.Add(new Claim("USER_GLOBAL_TITLE", (objUser.USER_GLOBAL_TITLE == null ? "" : objUser.USER_GLOBAL_TITLE)));
            permClaims.Add(new Claim("USER_LOCAL_TITLE", (objUser.USER_LOCAL_TITLE == null ? "" : objUser.USER_LOCAL_TITLE)));
            permClaims.Add(new Claim("DEFAULT_LANGUAGE", (objUser.DEFAULT_LANGUAGE == null ? "" : objUser.DEFAULT_LANGUAGE)));
            permClaims.Add(new Claim("DEFAULT_TIMEZONE", (objUser.DEFAULT_TIMEZONE == null ? "" : objUser.DEFAULT_TIMEZONE)));
            permClaims.Add(new Claim("DEFAULT_DISP_DATE_FORMAT", (objUser.DEFAULT_DISP_DATE_FORMAT == null ? "" : objUser.DEFAULT_DISP_DATE_FORMAT)));
            permClaims.Add(new Claim("DEFAULT_DISP_TIME_FORMAT", (objUser.DEFAULT_DISP_TIME_FORMAT == null ? "" : objUser.DEFAULT_DISP_TIME_FORMAT)));
            permClaims.Add(new Claim("DEFAULT_DISP_DATETIME_FORMAT", (objUser.DEFAULT_DISP_DATETIME_FORMAT == null ? "" : objUser.DEFAULT_DISP_DATETIME_FORMAT)));
            permClaims.Add(new Claim("DELEGATE_ID", (objUser.DELEGATE_ID == null ? "" : objUser.DELEGATE_ID)));

            foreach (var userGroup in objUser.USER_GROUPS) //added by Keith 20260928
            {
                permClaims.Add(new Claim("USER_GROUPS", userGroup));
            }

            return permClaims;
        }

        [Authorize]
        [Route("api/jwt/tokenproperties")]
        [HttpGet]
        public Object GetTokenProperties()
        {
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            return token.GetTokenObject();
        }
    }
}
