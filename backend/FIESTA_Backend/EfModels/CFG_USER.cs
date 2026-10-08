using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class CFG_USER
{
    public decimal CFG_USER_ID { get; set; }

    public string USER_ID { get; set; } = null!;

    public string? USER_DS_NUMBER { get; set; }

    public string? USER_EMAIL { get; set; }

    public string USER_FULL_NAME { get; set; } = null!;

    public string? USER_FIRST_NAME { get; set; }

    public string? USER_LAST_NAME { get; set; }

    public string? DEFAULT_COST_CENTER { get; set; }

    public string? USER_COMPANY_CODE { get; set; }

    public string? USER_LOCAL_GRADE { get; set; }

    public string? USER_LOCAL_TITLE { get; set; }

    public string? USER_GLOBAL_GRADE { get; set; }

    public string? USER_GLOBAL_TITLE { get; set; }

    public string? USER_GLOBAL_UNIT { get; set; }

    public string? USER_GLOBAL_UNIT_CODE { get; set; }

    public string? USER_GLOBAL_UNIT_NAME { get; set; }

    public string? USER_GLOBAL_DIV_CODE { get; set; }

    public string? USER_GLOBAL_DIV_NAME { get; set; }

    public string? USER_MANAGER_USER_ID { get; set; }

    public string? ACTIVE { get; set; }

    public string? DEFAULT_TIMEZONE { get; set; }

    public string? DEFAULT_DISP_DATE_FORMAT { get; set; }

    public string? DEFAULT_DISP_TIME_FORMAT { get; set; }

    public string? DEFAULT_DISP_DATETIME_FORMAT { get; set; }

    public string? DEFAULT_LANGUAGE { get; set; }

    public string? USER_DEPT_CODE { get; set; }

    public string? USER_DEPT_NAME { get; set; }

    public string? USER_DEPT { get; set; }

    public string? USER_GLOBAL_DIV { get; set; }

    public string? GPR_USER_TYPE { get; set; }

    public string CAN_REQUEST { get; set; } = null!;

    public string? GLOBAL_JOB_TITLE_CODE { get; set; }

    public string? EMP_CLASSIFICATION_CODE { get; set; }
}
