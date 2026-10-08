using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.S4
{
    public class CSV_S4_PRODUCT_CAN_FLAGS4
    {
        public string? partNumberKey { get; set; }
        public string? partNumber { get; set; }
        public string? publishedLeadTimeInWeeks { get; set; }
        public string? isPartRegisterable { get; set; }
        public string? isPartSoleSource { get; set; }
        public string? canSample { get; set; }
        public string? canQuote { get; set; }
        public string? canContract { get; set; }
        public string? canOrder { get; set; }
        public string? canSearch { get; set; }
        public string? canDebit { get; set; }
        public string? canOpportunity { get; set; }
        public string? canRegister { get; set; }
        public string? canRotate { get; set; }
        public string? canForecast { get; set; }
        public string? canKit { get; set; }
        public string? isPartNotRecommendNewDesign { get; set; }
        public string? isPartNonCancelableNonReschedule { get; set; }
        public string? isPartPublish { get; set; }
        public string? canFlagMasterComments { get; set; }
        public string? autoApprThresholdFocusSales { get; set; }
        public string? autoApprThresholdNonFocusSales { get; set; }
        public string? autoApprThresholdFocusPL { get; set; }
        public string? autoApprThresholdNonFocusPL { get; set; }
        public string? sampleAutoApprQtyThreshold { get; set; }
        public string? sampleAutoApprTotalValThreshold { get; set; }
        public string? tacticalMarketingMgr { get; set; }
        public string? marketingMgr { get; set; }
        public string? applicationCode3Default { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public string? fileName { get; set; }

    }
}
