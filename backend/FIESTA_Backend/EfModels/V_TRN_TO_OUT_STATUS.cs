using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_TRN_TO_OUT_STATUS
{
    public decimal LOG_ID { get; set; }

    public string? JOB_NAME { get; set; }

    public DateTime? START_DATE { get; set; }

    public DateTime? END_DATE { get; set; }

    public decimal? DURATION_HOURS { get; set; }

    public string? STATUS { get; set; }

    public decimal? rn { get; set; }

    public DateTime? st_START_TIME { get; set; }

    public string? START_TIME_STR { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCTION_SPID { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCT_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCT_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCT_SPID { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCT_MATRIX_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCT_MATRIX_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCT_MATRIX_SPID { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCT_SALES_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCT_SALES_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCT_SALES_SPID { get; set; }

    public string? SP_TRN_TO_OUT_COMPONENTS_ST { get; set; }

    public string? SP_TRN_TO_OUT_COMPONENTS_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_COMPONENTS_SPID { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_BOM_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_BOM_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCTION_BOM_SPID { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_LOTSIZE_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_LOTSIZE_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCTION_LOTSIZE_SPID { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_ALT_MIX_RATIOS_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_ALT_MIX_RATIOS_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCTION_ALT_MIX_RATIOS_SPID { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCT_VENDOR_CHAR_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCT_VENDOR_CHAR_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCT_VENDOR_CHAR_SPID { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_ROUTING_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_ROUTING_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCTION_ROUTING_SPID { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_ROUTING_S4_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_ROUTING_S4_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCTION_ROUTING_S4_SPID { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_VERSION_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_VERSION_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCTION_VERSION_SPID { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_YIELD_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_YIELD_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCTION_YIELD_SPID { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_LEADTIME_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_LEADTIME_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCTION_LEADTIME_SPID { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_CYCLETIME_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCTION_CYCLETIME_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCTION_CYCLETIME_SPID { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCT_PLANT_ST { get; set; }

    public string? SP_TRN_TO_OUT_PRODUCT_PLANT_RC { get; set; }

    public decimal? SP_TRN_TO_OUT_PRODUCT_PLANT_SPID { get; set; }

    public string? SP_PLM_PRODUCTION_ST { get; set; }

    public string? SP_TRN_PRODUCT_ST { get; set; }

    public string? SP_PLM_TR4_TO_TRN_ST { get; set; }

    public string? SP_TRN_PRODUCT_MATRIX_ST { get; set; }

    public string? SP_TRN_PRODUCT_SALES_ST { get; set; }

    public string? SP_TRN_COMPONENTS_ST { get; set; }

    public string? SP_TRAN_PRODUCTION_BOM_ST { get; set; }

    public string? SP_TRN_PRODUCTION_LOTSIZE_ST { get; set; }

    public string? SP_TRAN_PRODUCTION_ALTERNATIVES_MIX_RATIOS_ST { get; set; }

    public string? SP_TRN_PRODUCT_VENDOR_CHAR_ST { get; set; }

    public string? SP_TRAN_PRODUCTION_ROUTING_ST { get; set; }

    public string? SP_TRAN_PRODUCTION_ROUTING_S4_ST { get; set; }

    public string? SP_TRAN_PRODUCTION_VERSION_ST { get; set; }

    public string? SP_TRN_PRODUCTION_YIELD_LEADTIME_ST { get; set; }

    public string? SP_TRN_PRODUCTION_CYCLETIME_ST { get; set; }

    public string? SP_TRN_PRODUCT_PLANT_ST { get; set; }

    public string? SP_PLM_PRODUCTION_RC { get; set; }

    public decimal? SP_PLM_PRODUCTION_SPID { get; set; }

    public string? SP_TRN_PRODUCT_RC { get; set; }

    public decimal? SP_TRN_PRODUCT_SPID { get; set; }

    public string? SP_PLM_TR4_TO_TRN_RC { get; set; }

    public decimal? SP_PLM_TR4_TO_TRN_SPID { get; set; }

    public string? SP_TRN_PRODUCT_MATRIX_RC { get; set; }

    public decimal? SP_TRN_PRODUCT_MATRIX_SPID { get; set; }

    public string? SP_TRN_PRODUCT_SALES_RC { get; set; }

    public decimal? SP_TRN_PRODUCT_SALES_SPID { get; set; }

    public string? SP_TRN_COMPONENTS_RC { get; set; }

    public decimal? SP_TRN_COMPONENTS_SPID { get; set; }

    public string? SP_TRAN_PRODUCTION_BOM_RC { get; set; }

    public decimal? SP_TRAN_PRODUCTION_BOM_SPID { get; set; }

    public string? SP_TRN_PRODUCTION_LOTSIZE_RC { get; set; }

    public decimal? SP_TRN_PRODUCTION_LOTSIZE_SPID { get; set; }

    public string? SP_TRAN_PRODUCTION_ALTERNATIVES_MIX_RATIOS_RC { get; set; }

    public decimal? SP_TRAN_PRODUCTION_ALTERNATIVES_MIX_RATIOS_SPID { get; set; }

    public string? SP_TRN_PRODUCT_VENDOR_CHAR_RC { get; set; }

    public decimal? SP_TRN_PRODUCT_VENDOR_CHAR_SPID { get; set; }

    public string? SP_TRAN_PRODUCTION_ROUTING_RC { get; set; }

    public decimal? SP_TRAN_PRODUCTION_ROUTING_SPID { get; set; }

    public string? SP_TRAN_PRODUCTION_ROUTING_S4_RC { get; set; }

    public decimal? SP_TRAN_PRODUCTION_ROUTING_S4_SPID { get; set; }

    public string? SP_TRAN_PRODUCTION_VERSION_RC { get; set; }

    public decimal? SP_TRAN_PRODUCTION_VERSION_SPID { get; set; }

    public string? SP_TRN_PRODUCTION_YIELD_LEADTIME_RC { get; set; }

    public decimal? SP_TRN_PRODUCTION_YIELD_LEADTIME_SPID { get; set; }

    public string? SP_TRN_PRODUCTION_CYCLETIME_RC { get; set; }

    public decimal? SP_TRN_PRODUCTION_CYCLETIME_SPID { get; set; }

    public string? SP_TRN_PRODUCT_PLANT_RC { get; set; }

    public decimal? SP_TRN_PRODUCT_PLANT_SPID { get; set; }
}
