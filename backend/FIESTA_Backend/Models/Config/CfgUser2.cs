namespace FIESTA_Backend.Models.Config;

public class CfgUser2
{
    public decimal CFG_USER_ID { get; set; }
    public required string USER_ID { get; set; }
    public string? USER_EMAIL { get; set; }
    public required string USER_FULL_NAME { get; set; }
    public string? USER_FIRST_NAME { get; set; }
    public string? USER_LAST_NAME { get; set; }
    public string? USER_COMPANY_CODE { get; set; }
    public string? USER_LOCAL_TITLE { get; set; }
    public string? USER_GLOBAL_TITLE { get; set; }
    public string? ACTIVE { get; set; }
    public string? DEFAULT_TIMEZONE { get; set; }
    public string? DEFAULT_DISP_DATE_FORMAT { get; set; }
    public string? DEFAULT_DISP_TIME_FORMAT { get; set; }
    public string? DEFAULT_DISP_DATETIME_FORMAT { get; set; }
    public string? DEFAULT_LANGUAGE { get; set; }
    public string? USER_GLOBAL_DIV { get; set; }
    public string? USER_DEPT_CODE { get; set; }
    public string? USER_DEPT_NAME { get; set; }
    public string? USER_DEPT { get; set; }
    public required List<int> saUserGroupId { get; set; }
}

public class MassInsertUserSearch
{
    public required string Email { get; set; }
    public required bool Ok { get; set; }
    public required string Message { get; set; }
    public GadUserInfo UserInfo { get; set; } = new GadUserInfo();
}

public class GadUserInfo
{
    public string ExtensionAttribute11 { get; set; } = "";
    public string Mail { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public string GivenName { get; set; } = "";
    public string Surname { get; set; } = "";
}