using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_STORAGE_LOCATION_HI
{
    public decimal CFG_STORAGE_LOCATION_HIS_ID { get; set; }

    public DateTimeOffset? CFG_STORAGE_LOCATION_HIS_DATE { get; set; }

    public string? CFG_STORAGE_LOCATION_HIS_USERID { get; set; }

    public string? CFG_STORAGE_LOCATION_HIS_DELEGATE { get; set; }

    public decimal? recordKey { get; set; }

    public string? plant { get; set; }

    public string? storageLocation { get; set; }

    public string? descrOfStorageLoc { get; set; }

    public string? division { get; set; }

    public string? negStocksInSLoc { get; set; }

    public string? freezeBookInvSLoc { get; set; }

    public string? sLocMRPIndicator { get; set; }

    public string? authorizationCheck { get; set; }

    public string? storageResource { get; set; }

    public string? huReqmnt { get; set; }

    public string? partnerStorLoc { get; set; }

    public string? salesOrganization { get; set; }

    public string? distributionChannel { get; set; }

    public string? shippingPointReceivingPt { get; set; }

    public string? supplier { get; set; }

    public string? customer { get; set; }

    public string? businessSystemOfMES { get; set; }

    public string? inventoryManagementType { get; set; }

    public string? validity { get; set; }

    public string? licenseNumber { get; set; }

    public string? inTransitAssignment { get; set; }

    public string? tankAssgn { get; set; }

    public string? storageLocationType { get; set; }

    public string? countryCode { get; set; }

    public string? region { get; set; }

    public string? timeZone { get; set; }

    public string? glmPlantCode { get; set; }

    public string activeFlag { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public string? lastUpdateBy { get; set; }

    public string? reviewBy { get; set; }

    public DateTimeOffset? reviewDateAndTime { get; set; }

    public string? reviewStatus { get; set; }

    public string processStatus { get; set; } = null!;
}
