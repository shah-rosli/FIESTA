using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class MDM_PLANT
{
    public decimal recordKey { get; set; }

    public string plant { get; set; } = null!;

    public string? name1 { get; set; }

    public string? valuationArea { get; set; }

    public string? customerNumberOfPlant { get; set; }

    public string? supplierNumberOfPlant { get; set; }

    public string? factoryCalendar { get; set; }

    public string? name2 { get; set; }

    public string? streetAndHouseNumber { get; set; }

    public string? poBox { get; set; }

    public string? postalCode { get; set; }

    public string? city { get; set; }

    public string? purchOrganization { get; set; }

    public string? salesOrganization { get; set; }

    public string? batchStatusMgmt { get; set; }

    public string? condsAtPlantLevel { get; set; }

    public string? sourceList { get; set; }

    public string? reqmtsPlanning { get; set; }

    public string? countryRegionKey { get; set; }

    public string? region { get; set; }

    public string? countyCode { get; set; }

    public string? cityCode { get; set; }

    public string? address { get; set; }

    public string? planningPlant { get; set; }

    public string? taxJurisdiction { get; set; }

    public string? distribchannel { get; set; }

    public string? intCOBillingDiv { get; set; }

    public string? languageKey { get; set; }

    public string? sopPlant { get; set; }

    public string? varianceKey { get; set; }

    public string? batchStatusMgmtOld { get; set; }

    public string? plantCat { get; set; }

    public string? salesDistrict { get; set; }

    public string? supplyRegion { get; set; }

    public string? taxIndicatorPlant { get; set; }

    public string? regularSupplier { get; set; }

    public decimal? firstReminderExped { get; set; }

    public decimal? secondReminderExped { get; set; }

    public decimal? thirdReminderExped { get; set; }

    public string? text1stDunning { get; set; }

    public string? text2ndDunning { get; set; }

    public string? text3rdDunning { get; set; }

    public decimal? poTolerance { get; set; }

    public string? businessPlace { get; set; }

    public string? salesAreaDetrm { get; set; }

    public string? distribProfileOfPlant { get; set; }

    public string? archivingMarker { get; set; }

    public string? batchRecDMSType { get; set; }

    public string? nodeTypesupplyChain { get; set; }

    public string? namingStructure { get; set; }

    public string? costObjControlling { get; set; }

    public string? mixedCosting { get; set; }

    public string? actualCosting { get; set; }

    public string? shippingPointReceivingPt { get; set; }

    public string? actualActivitiesUpdated { get; set; }

    public string? controlOfCreditOfCostCenters { get; set; }

    public string? afSrceDetViaATP { get; set; }

    public string? batchManagementNotActiveByDefault { get; set; }

    public string? supplyAssignmentARun { get; set; }

    public string? seasonActiveInInventoryManagement { get; set; }

    public string? controlDataForBOM { get; set; }

    public string? activateVariantGrouping { get; set; }

    public string? assignBatchesInARun { get; set; }

    public string? exchangeValuation { get; set; }

    public string? vendorType { get; set; }

    public string? credIPI { get; set; }

    public string? storeCat { get; set; }

    public string? superiorDeptStore { get; set; }

    public string? ownership { get; set; }

    public string? company { get; set; }

    public string activeFlag { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string processStatus { get; set; } = null!;
}
