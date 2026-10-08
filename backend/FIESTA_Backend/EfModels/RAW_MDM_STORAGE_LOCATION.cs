using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_MDM_STORAGE_LOCATION
    {
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
        public string? resion { get; set; }
        public string? timeZone { get; set; }
        public string? glmPlantCode { get; set; }
        public string? activeFlag { get; set; }
        public DateTime? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public long? isRecordActive { get; set; }
        public DateTimeOffset? recordActiveChange { get; set; }
    }
}
