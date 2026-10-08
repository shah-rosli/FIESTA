using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_PRI_OPN
    {
        public string? BOOKING_PN { get; set; }
        public bool? SYS_STATUS { get; set; }
        public string? RENESAS_PN { get; set; }
        public string? BOOKING_PN_BASE { get; set; }
        public string? PRODUCT_KBN { get; set; }
        public string? ITEM_CD { get; set; }
        public string? TS_FLAG { get; set; }
        public string? EXPIRY_DATE_PRINTING_FLAG { get; set; }
        public string? SEAL_DATE_PRINTING_FLAG { get; set; }
        public string? HALOGEN_FREE_PRINTING_FLAG { get; set; }
        public string? PB_FREE { get; set; }
        public string? PB_FREE_DETAIL_SPEC_RANK { get; set; }
        public string? ROHS_EXEMPT_PRINTING_FLAG { get; set; }
        public string? REACH_PRINTING_FLAG { get; set; }
        public string? REFLOW_PEAK_TEMPERATURE { get; set; }
        public string? BASE_KBN { get; set; }
        public string? PROCESS_KBN { get; set; }
        public decimal? COMPONENT_WEIGHT { get; set; }
        public string? STORAGE_PERIOD_OF_STOCKS { get; set; }
        public string? IC_DISC_KBN { get; set; }
        public string? MSL { get; set; }
        public string? REL_RENESAS_PROSESS_NAME { get; set; }
        public string? R_PACKAGE_CODE { get; set; }
        public string? PACKAGE_TYPE { get; set; }
        public string? REMARKS { get; set; }
        public string? REG_USER { get; set; }
        public DateTime? REG_DATE { get; set; }
        public string? UPD_USER { get; set; }
        public DateTime? UPD_DATE { get; set; }
        public string? ORIGIN_KBN { get; set; }
        public string? MODEL_GROUP_CD { get; set; }
        public string? PRODUCT_CATEGORY_CD { get; set; }
        public string? QUALITY_LEVEL { get; set; }
        public string? PN_CODE_NAME { get; set; }
        public string? PACKING_TYPE { get; set; }
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
    }
}
