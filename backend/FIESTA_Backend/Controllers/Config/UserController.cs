using System.DirectoryServices.Protocols;
using System.Net;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models.Config;
using Newtonsoft.Json;

namespace FIESTA_Backend.Controllers.Config
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FiestaDbContext _context;
        private readonly ILogger<UserController> _logger;

        public UserController(FiestaDbContext context, ILogger<UserController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [Authorize]
        [Route("api/User/GetAll")]
        [HttpGet]
        public IActionResult Get([FromQuery] DataSourceLoadOptions loadOptions)
        {
            var result = _context.CFG_USERs.Select(s => new
            {
                s.CFG_USER_ID,
                s.USER_ID,
                s.USER_DS_NUMBER,
                s.USER_EMAIL,
                s.USER_FULL_NAME,
                s.USER_FIRST_NAME,
                s.USER_LAST_NAME,
                s.DEFAULT_COST_CENTER,
                s.USER_COMPANY_CODE,
                s.USER_LOCAL_GRADE,
                s.USER_LOCAL_TITLE,
                s.USER_GLOBAL_GRADE,
                s.USER_GLOBAL_TITLE,
                s.USER_GLOBAL_UNIT,
                s.USER_GLOBAL_UNIT_CODE,
                s.USER_GLOBAL_UNIT_NAME,
                s.USER_GLOBAL_DIV_CODE,
                s.USER_GLOBAL_DIV_NAME,
                s.USER_MANAGER_USER_ID,
                s.ACTIVE,
                s.DEFAULT_TIMEZONE,
                s.DEFAULT_DISP_DATE_FORMAT,
                s.DEFAULT_DISP_TIME_FORMAT,
                s.DEFAULT_DISP_DATETIME_FORMAT,
                s.DEFAULT_LANGUAGE,
                s.USER_DEPT_CODE,
                s.USER_DEPT_NAME,
                s.USER_DEPT,
                s.USER_GLOBAL_DIV,
                s.GPR_USER_TYPE,
                s.GLOBAL_JOB_TITLE_CODE,
                s.EMP_CLASSIFICATION_CODE,
                s.CAN_REQUEST,
                saUserGroupId = _context.CFG_USER_USER_GROUP_MAPs
                    .Where(x => x.USER_ID == s.USER_ID)
                    .Select(x => x.CFG_USER_GROUP_ID.ToString())
                    .ToList()
            });
            return new JsonResult(DataSourceLoader.Load(result, loadOptions));
        }

        [Authorize]
        [Route("api/User")]
        [HttpPost]
        public IActionResult Post([FromBody] CfgUser2 cfg)
        {
            //var cfg = JsonConvert.DeserializeObject<CfgUser2>(Uri.UnescapeDataString(values));

            var exist = _context.CFG_USERs
                .Any(x => x.USER_ID == cfg.USER_ID || x.USER_EMAIL == cfg.USER_EMAIL);

            if (exist)
            {
                return BadRequest(new
                {
                    Message = $"Record with USER_ID: {cfg.USER_ID} or USER_EMAIL: {cfg.USER_EMAIL} exist!"
                });
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.CFG_USERs.Add(new CFG_USER
                    {
                        USER_ID = cfg.USER_ID,
                        USER_EMAIL = cfg.USER_EMAIL,
                        USER_FULL_NAME = cfg.USER_FULL_NAME,
                        USER_FIRST_NAME = cfg.USER_FIRST_NAME,
                        USER_LAST_NAME = cfg.USER_LAST_NAME,
                        USER_COMPANY_CODE = cfg.USER_COMPANY_CODE,
                        USER_LOCAL_TITLE = cfg.USER_LOCAL_TITLE,
                        USER_GLOBAL_TITLE = cfg.USER_GLOBAL_TITLE,
                        ACTIVE = cfg.ACTIVE,
                        DEFAULT_TIMEZONE = cfg.DEFAULT_TIMEZONE,
                        DEFAULT_DISP_DATE_FORMAT = cfg.DEFAULT_DISP_DATE_FORMAT,
                        DEFAULT_DISP_TIME_FORMAT = cfg.DEFAULT_DISP_TIME_FORMAT,
                        DEFAULT_DISP_DATETIME_FORMAT = cfg.DEFAULT_DISP_DATETIME_FORMAT,
                        DEFAULT_LANGUAGE = cfg.DEFAULT_LANGUAGE,
                        USER_GLOBAL_DIV = cfg.USER_GLOBAL_DIV,
                        USER_DEPT_CODE = cfg.USER_DEPT_CODE,
                        USER_DEPT_NAME = cfg.USER_DEPT_NAME,
                        USER_DEPT = cfg.USER_DEPT,
                        CAN_REQUEST = "Yes"
                    });

                    _context.SaveChanges();

                    foreach (var userGroupId in cfg.saUserGroupId)
                    {
                        _context.CFG_USER_USER_GROUP_MAPs.Add(new CFG_USER_USER_GROUP_MAP
                        {
                            USER_ID = cfg.USER_ID,
                            CFG_USER_GROUP_ID = userGroupId
                        });
                    }

                    _context.SaveChanges();

                    var insertedRecord = _context.CFG_USERs.First(x => x.USER_ID == cfg.USER_ID);

                    _context.CFG_USER_HIs.Add(new CFG_USER_HI
                    {
                        CFG_USER_ID = insertedRecord.CFG_USER_ID,
                        CFG_USER_HIS_USER_ID = User.FindFirstValue("USER_ID"),
                        CFG_USER_HIS_DATE = DateTimeOffset.Now,
                        USER_ID = insertedRecord.USER_ID,
                        USER_EMAIL = insertedRecord.USER_EMAIL,
                        USER_FULL_NAME = insertedRecord.USER_FULL_NAME,
                        USER_FIRST_NAME = insertedRecord.USER_FIRST_NAME,
                        USER_LAST_NAME = insertedRecord.USER_LAST_NAME,
                        USER_COMPANY_CODE = insertedRecord.USER_COMPANY_CODE,
                        USER_LOCAL_TITLE = insertedRecord.USER_LOCAL_TITLE,
                        USER_GLOBAL_TITLE = insertedRecord.USER_GLOBAL_TITLE,
                        ACTIVE = insertedRecord.ACTIVE,
                        DEFAULT_TIMEZONE = insertedRecord.DEFAULT_TIMEZONE,
                        DEFAULT_DISP_DATE_FORMAT = insertedRecord.DEFAULT_DISP_DATE_FORMAT,
                        DEFAULT_DISP_TIME_FORMAT = insertedRecord.DEFAULT_DISP_TIME_FORMAT,
                        DEFAULT_DISP_DATETIME_FORMAT = insertedRecord.DEFAULT_DISP_DATETIME_FORMAT,
                        DEFAULT_LANGUAGE = insertedRecord.DEFAULT_LANGUAGE,
                        USER_GLOBAL_DIV = insertedRecord.USER_GLOBAL_DIV,
                        USER_DEPT_CODE = insertedRecord.USER_DEPT_CODE,
                        USER_DEPT_NAME = insertedRecord.USER_DEPT_NAME,
                        USER_DEPT = insertedRecord.USER_DEPT,
                    });

                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to insert user, rolling back transaction. {Message}", ex.Message);
                    transaction.Rollback();
                    return StatusCode(500, new { Message = "Failed to insert user" });
                }
            }

            return Ok(new
            {
                Message = "Record Created Successfully",
                Data = cfg
            });
        }

        [Authorize]
        [Route("api/User")]
        [HttpPut]
        public ActionResult Put([FromBody] CfgUser2 cfg)
        {
            //var cfg = JsonConvert.DeserializeObject<CfgUser2>(Uri.UnescapeDataString(values));

            var user = _context.CFG_USERs.FirstOrDefault(x => x.USER_ID == cfg.USER_ID);

            if (user == null)
            {
                return BadRequest(new
                {
                    Message = $"Record with USER_ID: {cfg.USER_ID} not exist!"
                });
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    user.USER_ID = cfg.USER_ID;
                    user.USER_EMAIL = cfg.USER_EMAIL;
                    user.USER_FULL_NAME = cfg.USER_FULL_NAME;
                    user.USER_FIRST_NAME = cfg.USER_FIRST_NAME;
                    user.USER_LAST_NAME = cfg.USER_LAST_NAME;
                    user.USER_COMPANY_CODE = cfg.USER_COMPANY_CODE;
                    user.USER_LOCAL_TITLE = cfg.USER_LOCAL_TITLE;
                    user.USER_GLOBAL_TITLE = cfg.USER_GLOBAL_TITLE;
                    user.ACTIVE = cfg.ACTIVE;
                    user.DEFAULT_TIMEZONE = cfg.DEFAULT_TIMEZONE;
                    user.DEFAULT_DISP_DATE_FORMAT = cfg.DEFAULT_DISP_DATE_FORMAT;
                    user.DEFAULT_DISP_TIME_FORMAT = cfg.DEFAULT_DISP_TIME_FORMAT;
                    user.DEFAULT_DISP_DATETIME_FORMAT = cfg.DEFAULT_DISP_DATETIME_FORMAT;
                    user.DEFAULT_LANGUAGE = cfg.DEFAULT_LANGUAGE;
                    user.USER_GLOBAL_DIV = cfg.USER_GLOBAL_DIV;
                    user.USER_DEPT_CODE = cfg.USER_DEPT_CODE;
                    user.USER_DEPT_NAME = cfg.USER_DEPT_NAME;
                    user.USER_DEPT = cfg.USER_DEPT;
                    user.CAN_REQUEST = "Yes";

                    _context.SaveChanges();

                    _context.CFG_USER_USER_GROUP_MAPs.RemoveRange(
                        _context.CFG_USER_USER_GROUP_MAPs.Where(x => x.USER_ID == cfg.USER_ID)
                    );

                    _context.SaveChanges();

                    foreach (var userGroupId in cfg.saUserGroupId)
                    {
                        _context.CFG_USER_USER_GROUP_MAPs.Add(new CFG_USER_USER_GROUP_MAP
                        {
                            USER_ID = cfg.USER_ID,
                            CFG_USER_GROUP_ID = userGroupId
                        });
                    }

                    _context.SaveChanges();

                    _context.CFG_USER_HIs.Add(new CFG_USER_HI
                    {
                        CFG_USER_ID = user.CFG_USER_ID,
                        CFG_USER_HIS_USER_ID = User.FindFirstValue("USER_ID"),
                        CFG_USER_HIS_DATE = DateTimeOffset.Now,
                        USER_ID = user.USER_ID,
                        USER_EMAIL = user.USER_EMAIL,
                        USER_FULL_NAME = user.USER_FULL_NAME,
                        USER_FIRST_NAME = user.USER_FIRST_NAME,
                        USER_LAST_NAME = user.USER_LAST_NAME,
                        USER_COMPANY_CODE = user.USER_COMPANY_CODE,
                        USER_LOCAL_TITLE = user.USER_LOCAL_TITLE,
                        USER_GLOBAL_TITLE = user.USER_GLOBAL_TITLE,
                        ACTIVE = user.ACTIVE,
                        DEFAULT_TIMEZONE = user.DEFAULT_TIMEZONE,
                        DEFAULT_DISP_DATE_FORMAT = user.DEFAULT_DISP_DATE_FORMAT,
                        DEFAULT_DISP_TIME_FORMAT = user.DEFAULT_DISP_TIME_FORMAT,
                        DEFAULT_DISP_DATETIME_FORMAT = user.DEFAULT_DISP_DATETIME_FORMAT,
                        DEFAULT_LANGUAGE = user.DEFAULT_LANGUAGE,
                        USER_GLOBAL_DIV = user.USER_GLOBAL_DIV,
                        USER_DEPT_CODE = user.USER_DEPT_CODE,
                        USER_DEPT_NAME = user.USER_DEPT_NAME,
                        USER_DEPT = user.USER_DEPT,
                    });

                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to update user, rolling back transaction. {Message}", ex.Message);
                    transaction.Rollback();
                    return StatusCode(500, new { Message = "Failed to update user" });
                }
            }

            return Ok(new
            {
                Message = "Record Modified Successfully",
                Data = cfg
            });
        }

        [Authorize]
        [HttpGet]
        [Route("api/CfgUser/GetHistory/{id}")]
        public IActionResult GetHistory(string id)
        {
            try
            {
                var result = _context.CFG_USER_HIs
                    .Where(x => x.USER_ID == id)
                    .Select(s => new
                    {
                        s.CFG_USER_HIS_ID,
                        s.CFG_USER_HIS_USER_ID,
                        MODIFIED_BY_EMAIL = _context.CFG_USERs
                            .First(x => x.USER_ID == s.CFG_USER_HIS_USER_ID).USER_EMAIL,
                        MODIFIED_BY_NAME = _context.CFG_USERs
                            .First(x => x.USER_ID == s.CFG_USER_HIS_USER_ID).USER_FULL_NAME,
                        s.CFG_USER_HIS_DELEGATE,
                        MODIFIED_BY_DELNAME = _context.CFG_USERs
                            .First(x => x.USER_ID == s.CFG_USER_HIS_DELEGATE).USER_FULL_NAME,
                        s.CFG_USER_ID,
                        s.USER_ID,
                        s.USER_DS_NUMBER,
                        s.USER_EMAIL,
                        s.USER_FULL_NAME,
                        s.USER_FIRST_NAME,
                        s.USER_LAST_NAME,
                        s.DEFAULT_COST_CENTER,
                        s.USER_COMPANY_CODE,
                        s.USER_LOCAL_GRADE,
                        s.USER_LOCAL_TITLE,
                        s.USER_GLOBAL_GRADE,
                        s.USER_GLOBAL_TITLE,
                        s.USER_GLOBAL_UNIT,
                        s.USER_GLOBAL_UNIT_CODE,
                        s.USER_GLOBAL_UNIT_NAME,
                        s.USER_GLOBAL_DIV_CODE,
                        s.USER_GLOBAL_DIV_NAME,
                        s.USER_MANAGER_USER_ID,
                        s.ACTIVE,
                        s.DEFAULT_TIMEZONE,
                        s.DEFAULT_DISP_DATE_FORMAT,
                        s.DEFAULT_DISP_TIME_FORMAT,
                        s.DEFAULT_DISP_DATETIME_FORMAT,
                        s.DEFAULT_LANGUAGE,
                        s.USER_DEPT_CODE,
                        s.USER_DEPT_NAME,
                        s.USER_DEPT,
                        s.USER_GLOBAL_DIV,
                        s.GPR_USER_TYPE,
                        s.CFG_USER_HIS_DATE,
                        s.CAN_REQUEST,
                        s.GLOBAL_JOB_TITLE_CODE,
                        s.EMP_CLASSIFICATION_CODE
                    })
                    .ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("api/User/[action]")]
        [HttpPost]
        public IActionResult MassInsertSearchUser([FromBody] List<string> emails)
        {
            var userSearchResult = new List<MassInsertUserSearch>();
            var ldapServer = "adwin.renesas.com";
            using var connection = new LdapConnection(ldapServer);
            foreach (var email in emails)
            {
                string searchBase = "DC=adwin,DC=renesas,DC=com";
                string searchFilter = $"(mail={email})";

                SearchRequest searchRequest = new SearchRequest(
                    searchBase,
                    searchFilter,
                    SearchScope.Subtree,
                    "*"
                );

                SearchResponse searchResponse = (SearchResponse)connection.SendRequest(searchRequest);

                if (searchResponse.Entries.Count < 1)
                {
                    userSearchResult.Add(new MassInsertUserSearch
                    {
                        Email = email,
                        Ok = false,
                        Message = "Did not found user",
                    });

                    continue;
                }

                if (searchResponse.Entries.Count > 1)
                {
                    userSearchResult.Add(new MassInsertUserSearch
                    {
                        Email = email,
                        Ok = false,
                        Message = "Multiple record found, should not be possible, please look into it",
                    });

                    continue;
                }

                var entry = searchResponse.Entries[0];

                var extensionAttribute11 = entry.Attributes["extensionattribute11"][0]?.ToString() ?? "";
                var mail = entry.Attributes["mail"][0]?.ToString() ?? "";
                var displayName = entry.Attributes["displayname"][0]?.ToString() ?? "";
                var givenName = entry.Attributes["givenname"][0]?.ToString() ?? "";
                var surname = entry.Attributes["sn"][0]?.ToString() ?? "";

                if (
                    string.IsNullOrWhiteSpace(extensionAttribute11) ||
                    string.IsNullOrWhiteSpace(mail) ||
                    string.IsNullOrWhiteSpace(displayName) ||
                    string.IsNullOrWhiteSpace(givenName) ||
                    string.IsNullOrWhiteSpace(surname)
                )
                {
                    userSearchResult.Add(new MassInsertUserSearch
                    {
                        Email = email,
                        Ok = true,
                        Message = "Skipped entry due to missing required attributes",
                    });

                    continue;
                }

                var userInfo = new GadUserInfo
                {
                    ExtensionAttribute11 = extensionAttribute11,
                    Mail = mail,
                    DisplayName = displayName,
                    GivenName = givenName,
                    Surname = surname
                };

                userSearchResult.Add(new MassInsertUserSearch
                {
                    Email = email,
                    Ok = true,
                    Message = "Found user and is valid for insert",
                    UserInfo = userInfo
                });
            }

            foreach (var userSearch in userSearchResult.Where(x => x.Ok))
            {
                var result = _context.CFG_USERs.FirstOrDefault(x => x.USER_EMAIL == userSearch.Email);
                if (result != null)
                {
                    userSearch.Ok = false;
                    userSearch.Message = "This user is already in CFG_USER";
                }
            }

            return Ok(new
            {
                Message = "Users search completed successfully",
                Data = userSearchResult.OrderBy(x => x.Email)
            });
        }

        [Authorize]
        [Route("api/User/[action]")]
        [HttpPost]
        public IActionResult MassInsert([FromBody] List<MassInsertUserSearch> users)
        {
            if (users.Any(x => x.Ok == false))
            {
                return BadRequest(new { Message = "All record must be 'ok'" });
            }

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                foreach (var user in users)
                {
                    var userId = user.UserInfo.ExtensionAttribute11.ToLower();
                    _context.CFG_USERs.Add(new CFG_USER
                    {
                        USER_ID = userId,
                        USER_EMAIL = user.UserInfo.Mail,
                        USER_FULL_NAME = user.UserInfo.DisplayName,
                        USER_FIRST_NAME = user.UserInfo.GivenName,
                        USER_LAST_NAME = user.UserInfo.Surname,
                        USER_COMPANY_CODE = "32A0",
                        USER_LOCAL_TITLE = "",
                        USER_GLOBAL_TITLE = "",
                        ACTIVE = "Yes",
                        DEFAULT_TIMEZONE = "",
                        DEFAULT_DISP_DATE_FORMAT = "",
                        DEFAULT_DISP_TIME_FORMAT = "",
                        DEFAULT_DISP_DATETIME_FORMAT = "",
                        DEFAULT_LANGUAGE = "",
                        USER_GLOBAL_DIV = "",
                        USER_DEPT_CODE = "",
                        USER_DEPT_NAME = "",
                        USER_DEPT = "",
                        CAN_REQUEST = "Yes"
                    });

                    _context.SaveChanges();

                    _context.CFG_USER_USER_GROUP_MAPs.RemoveRange(
                        _context.CFG_USER_USER_GROUP_MAPs.Where(x => x.USER_ID == userId)
                    );

                    _context.SaveChanges();

                    var defaultUserGroup = _context.CFG_USER_GROUPs.First(x => x.USER_GROUP_NAME == "Standard User");
                    _context.CFG_USER_USER_GROUP_MAPs.Add(new CFG_USER_USER_GROUP_MAP
                    {
                        USER_ID = userId,
                        CFG_USER_GROUP_ID = defaultUserGroup.CFG_USER_GROUP_ID
                    });

                    _context.SaveChanges();

                    var insertedRecord = _context.CFG_USERs.First(x => x.USER_ID == userId);

                    _context.CFG_USER_HIs.Add(new CFG_USER_HI
                    {
                        CFG_USER_ID = insertedRecord.CFG_USER_ID,
                        CFG_USER_HIS_USER_ID = User.FindFirstValue("USER_ID"),
                        CFG_USER_HIS_DATE = DateTimeOffset.Now,
                        USER_ID = insertedRecord.USER_ID,
                        USER_EMAIL = insertedRecord.USER_EMAIL,
                        USER_FULL_NAME = insertedRecord.USER_FULL_NAME,
                        USER_FIRST_NAME = insertedRecord.USER_FIRST_NAME,
                        USER_LAST_NAME = insertedRecord.USER_LAST_NAME,
                        USER_COMPANY_CODE = insertedRecord.USER_COMPANY_CODE,
                        USER_LOCAL_TITLE = insertedRecord.USER_LOCAL_TITLE,
                        USER_GLOBAL_TITLE = insertedRecord.USER_GLOBAL_TITLE,
                        ACTIVE = insertedRecord.ACTIVE,
                        DEFAULT_TIMEZONE = insertedRecord.DEFAULT_TIMEZONE,
                        DEFAULT_DISP_DATE_FORMAT = insertedRecord.DEFAULT_DISP_DATE_FORMAT,
                        DEFAULT_DISP_TIME_FORMAT = insertedRecord.DEFAULT_DISP_TIME_FORMAT,
                        DEFAULT_DISP_DATETIME_FORMAT = insertedRecord.DEFAULT_DISP_DATETIME_FORMAT,
                        DEFAULT_LANGUAGE = insertedRecord.DEFAULT_LANGUAGE,
                        USER_GLOBAL_DIV = insertedRecord.USER_GLOBAL_DIV,
                        USER_DEPT_CODE = insertedRecord.USER_DEPT_CODE,
                        USER_DEPT_NAME = insertedRecord.USER_DEPT_NAME,
                        USER_DEPT = insertedRecord.USER_DEPT,
                    });

                    _context.SaveChanges();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to insert user, rolling back transaction. {Message}", ex.Message);
                transaction.Rollback();
                return StatusCode(500, new { Message = "Failed to insert user, rolled back transaction" });
            }

            return Ok(new
            {
                Message = "Mass insert completed successfully"
            });
        }

        [Authorize]
        [Route("api/User/[action]")]
        [HttpPost]
        public ActionResult RefreshUserDetail()
        {
            var userInfos = new List<GadUserInfo>();
            var ldapServer = "adwin.renesas.com";
            using var connection = new LdapConnection(ldapServer);
            foreach (var CFG_USER in _context.CFG_USERs)
            {
                string searchBase = "DC=adwin,DC=renesas,DC=com";
                string searchFilter = $"(mail={CFG_USER.USER_EMAIL})";

                SearchRequest searchRequest = new SearchRequest(
                    searchBase,
                    searchFilter,
                    SearchScope.Subtree,
                    "*"
                );

                SearchResponse searchResponse = (SearchResponse)connection.SendRequest(searchRequest);

                if (searchResponse.Entries.Count < 1)
                {
                    _logger.LogInformation("Did not found user");
                    continue;
                }

                if (searchResponse.Entries.Count > 1)
                {
                    _logger.LogInformation("Multiple record found, should not be possible, please look into it.");
                    continue;
                }

                var entry = searchResponse.Entries[0];

                var extensionAttribute11 = entry.Attributes["extensionattribute11"][0]?.ToString() ?? "";
                var mail = entry.Attributes["mail"][0]?.ToString() ?? "";
                var displayName = entry.Attributes["displayname"][0]?.ToString() ?? "";
                var givenName = entry.Attributes["givenname"][0]?.ToString() ?? "";
                var surname = entry.Attributes["sn"][0]?.ToString() ?? "";

                if (
                    string.IsNullOrWhiteSpace(extensionAttribute11) ||
                    string.IsNullOrWhiteSpace(mail) ||
                    string.IsNullOrWhiteSpace(displayName) ||
                    string.IsNullOrWhiteSpace(givenName) ||
                    string.IsNullOrWhiteSpace(surname)
                )
                {
                    _logger.LogInformation("Skipped entry due to missing required attributes.");
                    continue;
                }

                userInfos.Add(new GadUserInfo
                {
                    ExtensionAttribute11 = extensionAttribute11,
                    Mail = mail,
                    DisplayName = displayName,
                    GivenName = givenName,
                    Surname = surname
                });
            }

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                foreach (var userInfo in userInfos)
                {
                    var user = _context.CFG_USERs.First(x => x.USER_EMAIL.ToLower() == userInfo.Mail.ToLower());

                    user.USER_EMAIL = userInfo.Mail;
                    user.USER_FULL_NAME = userInfo.DisplayName;
                    user.USER_FIRST_NAME = userInfo.GivenName;
                    user.USER_LAST_NAME = userInfo.Surname;

                    _context.SaveChanges();

                    _context.CFG_USER_HIs.Add(new CFG_USER_HI
                    {
                        CFG_USER_ID = user.CFG_USER_ID,
                        CFG_USER_HIS_USER_ID = User.FindFirstValue("USER_ID"),
                        CFG_USER_HIS_DATE = DateTimeOffset.Now,
                        USER_ID = user.USER_ID,
                        USER_EMAIL = user.USER_EMAIL,
                        USER_FULL_NAME = user.USER_FULL_NAME,
                        USER_FIRST_NAME = user.USER_FIRST_NAME,
                        USER_LAST_NAME = user.USER_LAST_NAME,
                        USER_COMPANY_CODE = user.USER_COMPANY_CODE,
                        USER_LOCAL_TITLE = user.USER_LOCAL_TITLE,
                        USER_GLOBAL_TITLE = user.USER_GLOBAL_TITLE,
                        ACTIVE = user.ACTIVE,
                        DEFAULT_TIMEZONE = user.DEFAULT_TIMEZONE,
                        DEFAULT_DISP_DATE_FORMAT = user.DEFAULT_DISP_DATE_FORMAT,
                        DEFAULT_DISP_TIME_FORMAT = user.DEFAULT_DISP_TIME_FORMAT,
                        DEFAULT_DISP_DATETIME_FORMAT = user.DEFAULT_DISP_DATETIME_FORMAT,
                        DEFAULT_LANGUAGE = user.DEFAULT_LANGUAGE,
                        USER_GLOBAL_DIV = user.USER_GLOBAL_DIV,
                        USER_DEPT_CODE = user.USER_DEPT_CODE,
                        USER_DEPT_NAME = user.USER_DEPT_NAME,
                        USER_DEPT = user.USER_DEPT,
                    });

                    _context.SaveChanges();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update user, rolling back transaction. {Message}", ex.Message);
                transaction.Rollback();
                return StatusCode(500, new { Message = "Failed to update user" });
            }

            return Ok(new { Message = "User detail refreshed successfully" });
        }
    }
}