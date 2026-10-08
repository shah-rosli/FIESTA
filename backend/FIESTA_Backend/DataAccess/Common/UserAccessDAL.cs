using FIESTA_Backend.DataAccess.Config;
using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Utility.DataAccess;
using FIESTA_Backend.Models.Common;

namespace FIESTA_Backend.DataAccess.Common
{
    public class UserAccessDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public UserAccessDAL(IConfiguration configuration, HttpContext httpContext)
        {
            //
            // TODO: Add constructor logic here
            //
            this._config = configuration;
            this._httpContext = httpContext;

            _envProperties = new EnvironmentProperties(_config, _httpContext);
            _connectionString = _envProperties.CONN_STRING();
            _providerType = _config.GetSection("ProviderName").Value;
            dbManager = new DBManager(_providerType);
            dbManager.ConnectionString = _connectionString;
            logger = log4net.LogManager.GetLogger("GeneralLog");
        }
        private string GetUserAccessMenu(string user_id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * ");
            sb.AppendFormat(" from  v_cfg_user_access ");
            sb.AppendFormat(" where user_id='{0}'", user_id);
            sb.Append(" order by seq");
            return sb.ToString();
        }
        public DataTable SelectUserAccessMenu(string user_id)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, GetUserAccessMenu(user_id));
                dt = ds.Tables[0];
            }
            catch (Exception ce)
            {
                logger.Error(ce.Message);
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
            return dt;
        }
        public UserAccess SelectUserAccess(string user_id)
        {
            UserAccess userObj = new UserAccess();
            UserMenu mnObj = null;

            DataTable dt = SelectUserAccessMenu(user_id);
            if (dt.Rows.Count == 0)
            {
                CfgUserDAL dal = new CfgUserDAL(_config, _httpContext);
                CfgUser user_obj = dal.SelectRowByUserId(user_id);
                if (user_obj != null)
                {
                    userObj.user_id = user_id;
                    userObj.user_name = user_obj.USER_FULL_NAME;
                    List<UserMenu> mn_list = new List<UserMenu>();
                    userObj.menu_list = mn_list;
                    return userObj;// return empty structure
                }
                else
                    return null;
            }
            DataRow dr = dt.Rows[0];
            userObj.user_id = (dr["user_id"]).ToString();
            userObj.user_name = (dr["full_name"]).ToString();

            List<UserMenu> menu_list = new List<UserMenu>();
            var distinct_menu_list = (from drUserAccess in dt.AsEnumerable()
                                      select drUserAccess.Field<decimal>("menu_id")).Distinct();
            foreach (var mn in distinct_menu_list)
            {
                decimal mnu_id = mn;
                mnObj = new UserMenu();
                var menu_record_list = (from drMenuList in dt.AsEnumerable()
                                        where drMenuList.Field<decimal>("menu_id") == mnu_id
                                        select new
                                        {
                                            mn_id = drMenuList.Field<decimal>("menu_id"),
                                            mn_name = drMenuList.Field<string>("menu_name"),
                                            mn_parent_id = drMenuList.Field<decimal>("parent_id"),
                                            mn_seq = drMenuList.Field<decimal>("seq"),
                                            mn_icon = drMenuList.Field<string>("icon"),
                                            mn_link = drMenuList.Field<string>("link")
                                        });
                foreach (var mn_record in menu_record_list)
                {
                    mnObj = new UserMenu();
                    mnObj.menu_id = mn_record.mn_id;
                    mnObj.menu_name = mn_record.mn_name;
                    mnObj.parent_id = mn_record.mn_parent_id;
                    mnObj.sequence = mn_record.mn_seq;
                    mnObj.icon = mn_record.mn_icon;
                    mnObj.link = mn_record.mn_link;

                    break; // fill in record enough
                }

                var access_list = (from drAccessList in dt.AsEnumerable()
                                   where drAccessList.Field<decimal>("menu_id") == mnu_id && drAccessList.Field<string>("user_id") == user_id
                                   select new
                                   {
                                       company = drAccessList.Field<string>("company_code"),
                                       access_right = drAccessList.Field<string>("user_access"),
                                   });
                mnObj.access_right = access_list;
                //foreach (var access_record in access_list)
                //{
                //    accessObj = new Company_Acess_Right();
                //    accessObj.company_code = access_record.company;
                //    accessObj.user_access = access_record.access_right;
                //    acc_list.Add(accessObj);
                //}
                //mnObj.access_right = acc_list;
                menu_list.Add(mnObj);
            }
            userObj.menu_list = menu_list;
            return userObj;
        }

        public string SelectUserCompanyCode(string user_id)
        {
            StringBuilder sb = new StringBuilder();
            //            sb.AppendFormat(" select {0} as user_id, {1} as group_name,{2} as company_code", CfgUser.ColumnNames.USER_ID, CfgUserGroup.ColumnNames.USER_GROUP_NAME, CfgUserGroupCompanyMap.ColumnNames.COMPANY_CODE);
            //sb.AppendFormat(" from {0} inner join {1} on {2} = {3} ", CfgUser.TableName, CfgUserUserGroupMap.TableName, CfgUser.ColumnNames.USER_ID, CfgUserUserGroupMap.ColumnNames.USER_ID);
            sb.AppendFormat(" select {0} as group_name,{1} as company_code", CfgUserGroup.ColumnNames.USER_GROUP_NAME, CfgUserGroupCompanyMap.ColumnNames.COMPANY_CODE);
            sb.AppendFormat(" from {0}  ", CfgUserUserGroupMap.TableName);
            sb.AppendFormat(" inner join {0} on {1} = {2}", CfgUserGroup.TableName, CfgUserUserGroupMap.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroup.ColumnNames.CFG_USER_GROUP_ID);
            sb.AppendFormat(" and {0} ='{1}'", CfgUserUserGroupMap.ColumnNames.USER_ID, user_id);
            sb.AppendFormat(" inner join {0} on {1} = {2}", CfgUserGroupCompanyMap.TableName, CfgUserGroupCompanyMap.ColumnNames.CFG_USER_GROUP_ID, CfgUserUserGroupMap.ColumnNames.CFG_USER_GROUP_ID);
            sb.AppendFormat(" where {0} = 'Yes' ", CfgUserGroup.ColumnNames.ACTIVE);
            return sb.ToString();
        }
        public DataTable GetUserCompanyCode(string user_id)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectUserCompanyCode(user_id));
                dt = ds.Tables[0];
            }
            catch (Exception ce)
            {
                logger.Error(ce.Message);
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
            return dt;
        }
    }
}


