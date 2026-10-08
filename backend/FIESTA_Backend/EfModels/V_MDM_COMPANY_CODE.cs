using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_MDM_COMPANY_CODE
{
    public decimal recordKey { get; set; }

    public string companyCode { get; set; } = null!;

    public string? companyName { get; set; }

    public string? city { get; set; }

    public string? countryRegionKey { get; set; }

    public string? currency { get; set; }

    public string? languageKey { get; set; }

    public string? chartOfAccounts { get; set; }

    public decimal? maxExchangeRateDeviation { get; set; }

    public string? fiscalYearVariant { get; set; }

    public string? coArea { get; set; }

    public string? company { get; set; }

    public string? address { get; set; }

    public string? vatRegistrationNo { get; set; }

    public string? fmArea { get; set; }

    public string? projectCashMgmtActive { get; set; }

    public string? cshBdgtMgtActive { get; set; }

    public string? updateFM { get; set; }

    public string? jurisdictionCode { get; set; }

    public DateTime? fdsCtrActiveInHR { get; set; }

    public string? template { get; set; }

    public string? transitPlant { get; set; }

    public string? documentEntryScreenVariant { get; set; }

    public string? cashManagementCompanyCode { get; set; }

    public string? cashManagementActivated { get; set; }

    public string? defineDefaultValueDate { get; set; }

    public string? discountBaseIsNetValue { get; set; }

    public string? creditControlArea { get; set; }

    public string? taxBaseIsNetValue { get; set; }

    public string? sampleAcctRulesVar { get; set; }

    public string? businessAreaFinStatements { get; set; }

    public string? proposeFiscalYear { get; set; }

    public string? postTranslation { get; set; }

    public string? companyCodeIsProductive { get; set; }

    public string? purchaseAccountProcessing { get; set; }

    public string? jvAccountingActive { get; set; }

    public string? financialAssetsMgmtActive { get; set; }

    public string? noExchRateDiffWhenClearingInLC { get; set; }

    public string? updateMMInCMF { get; set; }

    public string? updateSDInCMF { get; set; }

    public string? externalCoCode { get; set; }

    public string? originalKey { get; set; }

    public string? alternativeCOA { get; set; }

    public string? taxesOnSlsPurc { get; set; }

    public string? globalCoCde { get; set; }

    public string? fieldStatusVariant { get; set; }

    public string? pstngPeriodVariant { get; set; }

    public string? hedgeRequestActive { get; set; }

    public string? taxCrcyTranslation { get; set; }

    public string? workflowVariant { get; set; }

    public string? inventoryManagement { get; set; }

    public string? poSchedulingAgmt { get; set; }

    public string? purchaseRequisition { get; set; }

    public string? contract { get; set; }

    public string? taxDetermwithDocDate { get; set; }

    public string? inputTaxCode { get; set; }

    public string? outputTaxCode { get; set; }

    public string? importDataInPurchaseOrder { get; set; }

    public string? negativePostingsPermitted { get; set; }

    public string? controlAreaCanBeInput { get; set; }

    public string? extendedWithholdingTaxActive { get; set; }

    public string? postingDateForParking { get; set; }

    public string? inflationMethod { get; set; }

    public string? fundsReservationFieldStatusVariant { get; set; }

    public string? copyingControlGoodsReceipt { get; set; }

    public string? importDataGoodsReceipt { get; set; }

    public decimal? methodOffsttngAcct { get; set; }

    public string? baVariant { get; set; }

    public string? costOfSalesAccountingActv { get; set; }

    public string? acctsRecblePledActive { get; set; }

    public string? enableAmountSplit { get; set; }

    public string? surchargeMethod { get; set; }

    public string? documentTypeForProvisionsForTaxes { get; set; }

    public string? documentTypeForJVAmountCorrection { get; set; }

    public string? documentTypeForJVTaxCode { get; set; }

    public string? remittanceChallanDocumentType { get; set; }

    public string? deferredTaxRule { get; set; }

    public string? taxReportingDateActive { get; set; }

    public string? managePostingPeriodForCoCodeLedger { get; set; }

    public string? shoppingCart { get; set; }

    public string? hideEntryInInputHelp { get; set; }

    public string? activateAADerivation { get; set; }

    public string activeFlag { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string processStatus { get; set; } = null!;
}
