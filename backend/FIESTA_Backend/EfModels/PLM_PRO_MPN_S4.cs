using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class PLM_PRO_MPN_S4
{
    public decimal recordKey { get; set; }

    public string WIP_PN { get; set; } = null!;

    public string BIG_COST_CODE { get; set; } = null!;

    public string? PARENT_WIP_PN { get; set; }

    public string? PRD_CATEGORY1 { get; set; }

    public string? PRD_CATEGORY2 { get; set; }

    public string? PRD_CATEGORY3 { get; set; }

    public string? PRD_CATEGORY4 { get; set; }

    public string? PRD_CATEGORY5 { get; set; }

    public string? PB_FREE { get; set; }

    public string? RENESAS_PACKAGE { get; set; }

    public string? RENESAS_KBN { get; set; }

    public string? CUSTOMER1 { get; set; }

    public string? CUSTOMER2 { get; set; }

    public string? CUSTOMER3 { get; set; }

    public string? CUSTOMER4 { get; set; }

    public string? CUSTOMER5 { get; set; }

    public string? CUSTOMER6 { get; set; }

    public string? CUSTOMER7 { get; set; }

    public string? CUSTOMER8 { get; set; }

    public string? CUSTOMER9 { get; set; }

    public string? CUSTOMER10 { get; set; }

    public string? NICKNAME { get; set; }

    public string? KEYAS4 { get; set; }

    public string? WFCLASS { get; set; }

    public string? IWHCLASS { get; set; }

    public string? MAE_KYOTEN { get; set; }

    public string? ATO_KYOTEN { get; set; }

    public string? BASE_ROM_KBN { get; set; }

    public string? UEHKEI { get; set; }

    public string? PROCESS_NAME { get; set; }

    public string? PROCESS_NAME_OP { get; set; }

    public string? BOOKING_PN { get; set; }

    public decimal? SHUTOKU { get; set; }

    public string? REG_USER { get; set; }

    public string? REG_DATE { get; set; }

    public string? REG_TIME { get; set; }

    public string? UPD_USER { get; set; }

    public string? UPD_DATE { get; set; }

    public string? UPD_TIME { get; set; }

    public string? WIRE_TYPE { get; set; }

    public string? CHIP_VERSION { get; set; }

    public string? UPDATE_TYPE { get; set; }

    public string? DELETE_FLAG { get; set; }

    public DateTimeOffset? fiestaCreateDateAndTime { get; set; }

    public DateTimeOffset? fiestaUpdateDateAndTime { get; set; }
}
