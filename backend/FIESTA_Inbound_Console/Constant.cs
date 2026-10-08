using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console
{
    public class Constant
    {
    }

    public enum OperationType
    {
        #region MDM
        PRODUCTION_GROUP_STAGE,
        PRODUCTION_STAGE_CONVERSION,
        PRODUCTION_STAGE,
        PRODUCTION_GROUP_STAGE_CONVERSION,
        PRODUCTION_PLANT_CONVERSION,
        COMPANY_CODE,
        STORAGE_LOCATION,
        PLANTS,
        #endregion
        #region RETIS
        PN_STATUS,
        RAW_MATERIAL,
        #endregion
        #region PRIDES
        OPN,
        #endregion
        #region PROSTER
        YIELD_MINITS,
        YIELD_PROSTER,
        ROUTING,
        MPN_S4,
        ALT_MIX_RATIOS,
        VERSION,
        LEADTIME_MINITS, 
        LEADTIME_PROSTER,
        BOM,
        CYCLE_TIME,
        #endregion
        #region Agile
        PRODUCTION,
        PRODUCT,
        MATERIAL,
        COMPONENT,
        CHARACTERISTICS,
        PRODUCTION_FULL,
        PRODUCT_FULL,
        MATERIAL_FULL,
        COMPONENT_FULL,
        CHARACTERISTICS_FULL,
        #endregion
        #region MES
        STAGE_EXPANSION,
        #endregion
        #region S4
        CUS_SOLD_TO,
        CUS_BILL_TO,
        CUS_SHIP_TO,
        CUS_END_CUSTOMER,
        FIN_IP_CUSTOMER,
        FIN_IP_OPN,
        PRODUCT_STANDARD_COST,
        PRODUCT_WIP_SELL_PRICE,
        VEN_VENDOR,
        VEN_VENDOR_COMPANY,
        VEN_VENDOR_PURCHASE_INFO_REC,
        CUS_PARTNER_FUNCTION,
        PRODUCT_CAN_FLAGS4,
        FIN_COST_CENTER,
        NONPRODUCTION_PRODUCT,
        NONPRODUCTION_PRODUCT_PLANT,
        NONPRODUCTION_PRODUCT_SALES,
        PRODUCT_HIERARCHY,
        PROFIT_CENTER,
        PROFIT_CENTER_HIERARCHY,
        PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION,
        #endregion
        None
    }
}
