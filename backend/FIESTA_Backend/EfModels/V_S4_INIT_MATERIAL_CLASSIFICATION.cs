using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_S4_INIT_MATERIAL_CLASSIFICATION
{
    public string KSSK_OBJEK { get; set; } = null!;

    public string MARA_MTART { get; set; } = null!;

    public string MARA_MATKL { get; set; } = null!;

    public string? LEGACY_MPN { get; set; }

    public string MARKET_GRP { get; set; } = null!;

    public string MARK_FAMILY { get; set; } = null!;

    public string MARK_FAM_DETL { get; set; } = null!;

    public string MARK_SEGMENT { get; set; } = null!;

    public string? GRADE_CODE { get; set; }

    public string? PRIORITY_1OPN { get; set; }

    public string? MOIS_SENS_LEV { get; set; }

    public string? FINAL_TERM_FINISH { get; set; }

    public string? REF_PACK_TYPE { get; set; }

    public string? PACK_CODE { get; set; }

    public string? PACK_CODE_DES { get; set; }

    public string? PBFREE_IND { get; set; }

    public string? PACK_TYPE { get; set; }

    public string? PACK_GROUP { get; set; }

    public string? PACK_CATEGORY { get; set; }

    public long? PACK_PIN_COUNT { get; set; }

    public long? NUMBER_OF_DIE { get; set; }

    public string? SING_PROCESS { get; set; }

    public long? TOL_NUM_OF_ALL_WIRE { get; set; }

    public decimal? WIRE_DIAMETER { get; set; }

    public string? WIRE_TYPE { get; set; }

    public string? CHIP_VERSION { get; set; }

    public long? THICKNESS { get; set; }

    public string? BUMP_TYPE { get; set; }

    public string? PROCESS_TECH { get; set; }

    public string? FOUD_PART_NUMBER { get; set; }

    public long? GROSS_WAFER { get; set; }

    public string? WAFER_SIZE { get; set; }

    public string? PACK_CARRIER { get; set; }

    public string? PACK_SPEC { get; set; }

    public string? PACK_BODY_SIZE { get; set; }

    public decimal? NET_WEIGHT { get; set; }

    public long? LOT_SEQ_CODE { get; set; }

    public string? ASSEMBLY_PACK_TYPE { get; set; }

    public decimal? PACK_PITCH { get; set; }

    public decimal? PACK_LEN { get; set; }

    public decimal? PACK_WIDTH { get; set; }

    public decimal? PACK_BODY_THICKNESS { get; set; }

    public string? DIE_POS_FOR_MULTIDIE { get; set; }

    public string? MATERIAL_DETAIL { get; set; }

    public string? ISPART_ASIC { get; set; }

    public string? ISPART_ITAR { get; set; }

    public string? ISPART_CAPABLE { get; set; }

    public string? BASE_PART_NUM { get; set; }

    public string? ISPART_ACTIVE { get; set; }

    public decimal? EXPDATE_PRINT_FLAG { get; set; }

    public decimal? SEALDATE_FLAG { get; set; }

    public decimal? HALOGEN_PRINT_FLAG { get; set; }

    public decimal? ROHS_EXEMPT_PRINT_FLAG { get; set; }

    public decimal? REACH_PRINT_FLAG { get; set; }

    public decimal? UL_REG_FLAG { get; set; }

    public string? UL_RATINGS_TEXT { get; set; }

    public string? PDN_ISSUE_DATE { get; set; }

    public string? PDN_LAST_BUYDATE { get; set; }

    public string? PDN_LAST_SHIPDATE { get; set; }

    public string? COMPANY_OF_ORIGIN { get; set; }

    public string? WHITE_PART_NUM { get; set; }

    public string? GOLDEN_ALL { get; set; }

    public string? PCB_ONBOARD_FLOW_TEMP { get; set; }

    public string? PCB_ONBOAR_STR_CONDITION { get; set; }

    public string? PCB_ONBOAR_REBAKE_CONDITION { get; set; }

    public decimal? ROHS_CHINA_EXM_PRINT_FLAG { get; set; }

    public string? MATRIX_WAFER { get; set; }

    public string? FINAL_TEST_PROGRAM { get; set; }

    public string BUSINESS_UNIT { get; set; } = null!;

    public string BUSINESS_DIVISION { get; set; } = null!;

    public string? LEADTIME { get; set; }

    public string? REGISTER { get; set; }

    public string? SOLE_SOURCE { get; set; }

    public string? CAN_SAMPLE { get; set; }

    public string? CAN_QUOTE { get; set; }

    public string? CAN_CONTRACT { get; set; }

    public string? CAN_ORDER { get; set; }

    public string? CAN_SEARCH { get; set; }

    public string? CAN_DEBIT { get; set; }

    public string? CAN_OPP { get; set; }

    public string? CAN_REGISTER { get; set; }

    public string? CAN_ROTATE { get; set; }

    public string? CAN_FORECAST { get; set; }

    public string? CAN_KIT { get; set; }

    public string? NRND { get; set; }

    public string? IS_NCNR { get; set; }

    public string? IS_PUBLISHED { get; set; }

    public string? Comments { get; set; }

    public string? AAFocusSales { get; set; }

    public string? AAnFocusSales { get; set; }

    public string? AAFocusPL { get; set; }

    public string? AAnFocusPL { get; set; }

    public string? SmplAutoApprQtyThreshold { get; set; }

    public string? SmplAutoApprTotalValThreshold { get; set; }

    public string? TacticalMktgMgr { get; set; }

    public string? MarketingMgr { get; set; }

    public string? APPLICATION_CODE3 { get; set; }

    public long? P3_QUANTITY_LIMIT { get; set; }

    public DateOnly? P3_EXPIRATION_DATE { get; set; }

    public string? RESPONSIBLE_PRODUCT_ENGINEER { get; set; }

    public string? MTSP_NAME { get; set; }

    public string? MTSP_REVISION { get; set; }

    public string? MTSP_DESCRIPTION { get; set; }

    public string HAS_MULTIPLE_MPN_COMPONENTS { get; set; } = null!;

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }
}
