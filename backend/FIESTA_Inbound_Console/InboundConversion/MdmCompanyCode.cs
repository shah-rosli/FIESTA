using FIESTA_Inbound_Console.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class MdmCompanyCode
    {
        public static DataTable ConvertObjToDT(CpiInboundObj obj)
        {
            DataTable dt = new DataTable("MDM_COMPANY_CODE");
            dt.Columns.Add("companyCode", typeof(string));
            dt.Columns.Add("companyName", typeof(string));
            dt.Columns.Add("city", typeof(string));
            dt.Columns.Add("countryRegionKey", typeof(string));
            dt.Columns.Add("currency", typeof(string));
            dt.Columns.Add("languageKey", typeof(string));
            dt.Columns.Add("chartOfAccounts", typeof(string));
            dt.Columns.Add("maxExchangeRateDeviation", typeof(decimal));
            dt.Columns.Add("fiscalYearVariant", typeof(string));
            dt.Columns.Add("coArea", typeof(string));
            dt.Columns.Add("company", typeof(string));
            dt.Columns.Add("address", typeof(string));
            dt.Columns.Add("vatRegistrationNo", typeof(string));
            dt.Columns.Add("fmArea", typeof(string));
            dt.Columns.Add("projectCashMgmtActive", typeof(string));
            dt.Columns.Add("cshBdgtMgtActive", typeof(string));
            dt.Columns.Add("updateFM", typeof(string));
            dt.Columns.Add("jurisdictionCode", typeof(string));
            dt.Columns.Add("fdsCtrActiveInHR", typeof(DateTime));
            dt.Columns.Add("template", typeof(string));
            dt.Columns.Add("transitPlant", typeof(string));
            dt.Columns.Add("documentEntryScreenVariant", typeof(string));
            dt.Columns.Add("cashManagementCompanyCode", typeof(string));
            dt.Columns.Add("cashManagementActivated", typeof(string));
            dt.Columns.Add("defineDefaultValueDate", typeof(string));
            dt.Columns.Add("discountBaseIsNetValue", typeof(string));
            dt.Columns.Add("creditControlArea", typeof(string));
            dt.Columns.Add("taxBaseIsNetValue", typeof(string));
            dt.Columns.Add("sampleAcctRulesVar", typeof(string));
            dt.Columns.Add("businessAreaFinStatements", typeof(string));
            dt.Columns.Add("proposeFiscalYear", typeof(string));
            dt.Columns.Add("postTranslation", typeof(string));
            dt.Columns.Add("companyCodeIsProductive", typeof(string));
            dt.Columns.Add("purchaseAccountProcessing", typeof(string));
            dt.Columns.Add("jvAccountingActive", typeof(string));
            dt.Columns.Add("financialAssetsMgmtActive", typeof(string));
            dt.Columns.Add("noExchRateDiffWhenClearingInLC", typeof(string));
            dt.Columns.Add("updateMMInCMF", typeof(string));
            dt.Columns.Add("updateSDInCMF", typeof(string));
            dt.Columns.Add("externalCoCode", typeof(string));
            dt.Columns.Add("originalKey", typeof(string));
            dt.Columns.Add("alternativeCOA", typeof(string));
            dt.Columns.Add("taxesOnSlsPurc", typeof(string));
            dt.Columns.Add("globalCoCde", typeof(string));
            dt.Columns.Add("fieldStatusVariant", typeof(string));
            dt.Columns.Add("pstngPeriodVariant", typeof(string));
            dt.Columns.Add("hedgeRequestActive", typeof(string));
            dt.Columns.Add("taxCrcyTranslation", typeof(string));
            dt.Columns.Add("workflowVariant", typeof(string));
            dt.Columns.Add("inventoryManagement", typeof(string));
            dt.Columns.Add("poSchedulingAgmt", typeof(string));
            dt.Columns.Add("purchaseRequisition", typeof(string));
            dt.Columns.Add("contract", typeof(string));
            dt.Columns.Add("taxDetermwithDocDate", typeof(string));
            dt.Columns.Add("inputTaxCode", typeof(string));
            dt.Columns.Add("outputTaxCode", typeof(string));
            dt.Columns.Add("importDataInPurchaseOrder", typeof(string));
            dt.Columns.Add("negativePostingsPermitted", typeof(string));
            dt.Columns.Add("controlAreaCanBeInput", typeof(string));
            dt.Columns.Add("extendedWithholdingTaxActive", typeof(string));
            dt.Columns.Add("postingDateForParking", typeof(string));
            dt.Columns.Add("inflationMethod", typeof(string));
            dt.Columns.Add("fundsReservationFieldStatusVariant", typeof(string));
            dt.Columns.Add("copyingControlGoodsReceipt", typeof(string));
            dt.Columns.Add("importDataGoodsReceipt", typeof(string));
            dt.Columns.Add("methodOffsttngAcct", typeof(decimal));
            dt.Columns.Add("baVariant", typeof(string));
            dt.Columns.Add("costOfSalesAccountingActv", typeof(string));
            dt.Columns.Add("acctsRecblePledActive", typeof(string));
            dt.Columns.Add("enableAmountSplit", typeof(string));
            dt.Columns.Add("surchargeMethod", typeof(string));
            dt.Columns.Add("documentTypeForProvisionsForTaxes", typeof(string));
            dt.Columns.Add("documentTypeForJVAmountCorrection", typeof(string));
            dt.Columns.Add("documentTypeForJVTaxCode", typeof(string));
            dt.Columns.Add("remittanceChallanDocumentType", typeof(string));
            dt.Columns.Add("deferredTaxRule", typeof(string));
            dt.Columns.Add("taxReportingDateActive", typeof(string));
            dt.Columns.Add("managePostingPeriodForCoCodeLedger", typeof(string));
            dt.Columns.Add("shoppingCart", typeof(string));
            dt.Columns.Add("hideEntryInInputHelp", typeof(string));
            dt.Columns.Add("activateAADerivation", typeof(string));
            dt.Columns.Add("activeFlag", typeof(string));
            dt.Columns.Add("updateDateAndTime", typeof(DateTime));
            dt.Columns.Add("updateType", typeof(string));
            dt.Columns.Add("isRecordActive", typeof(decimal));
            dt.Columns.Add("recordActiveChange", typeof(DateTime));

            foreach (CpiRow row in obj.rows)
            {
                object[] oRowDt = new object[86];

                CpiContent content;
                if (row.content != null)
                {
                    content = row.content;
                }
                else
                {
                    continue;
                }

                if (content.companyCode.content != null) oRowDt[0] = content.companyCode.content.ToString();
                if (content.companyName.content != null) oRowDt[1] = content.companyName.content.ToString();
                if (content.city.content != null) oRowDt[2] = content.city.content.ToString();
                if (content.countryRegionKey.content != null) oRowDt[3] = content.countryRegionKey.content.ToString();
                if (content.currency.content != null) oRowDt[4] = content.currency.content.ToString();
                if (content.languageKey.content != null) oRowDt[5] = content.languageKey.content.ToString();
                if (content.chartOfAccounts.content != null) oRowDt[6] = content.chartOfAccounts.content.ToString();
                
                if (content.maxExchangeRateDeviation.content != null)
                {
                    int s;
                    if (int.TryParse(content.maxExchangeRateDeviation.content.ToString(), out s))
                    {
                        oRowDt[7] = s;
                    }
                }

                if (content.fiscalYearVariant.content != null) oRowDt[8] = content.fiscalYearVariant.content.ToString();
                if (content.coArea.content != null) oRowDt[9] = content.coArea.content.ToString();
                if (content.company.content != null) oRowDt[10] = content.company.content.ToString();
                if (content.address.content != null) oRowDt[11] = content.address.content.ToString();
                if (content.vatRegistrationNo.content != null) oRowDt[12] = content.vatRegistrationNo.content.ToString();
                if (content.fmArea.content != null) oRowDt[13] = content.fmArea.content.ToString();
                if (content.projectCashMgmtActive.content != null) oRowDt[14] = content.projectCashMgmtActive.content.ToString();
                if (content.cshBdgtMgtActive.content != null) oRowDt[15] = content.cshBdgtMgtActive.content.ToString();
                if (content.updateFM.content != null) oRowDt[16] = content.updateFM.content.ToString();
                if (content.jurisdictionCode.content != null) oRowDt[17] = content.jurisdictionCode.content.ToString();
                
                    if (content.fdsCtrActiveInHR.content != null)
                    {
                        DateTimeOffset s;
                        if (DateTimeOffset.TryParse(content.fdsCtrActiveInHR.content.ToString() + "Z", out s))
                        {
                            oRowDt[18] = s.UtcDateTime;
                        }
                    }

                if (content.template.content != null) oRowDt[19] = content.template.content.ToString();
                if (content.transitPlant.content != null) oRowDt[20] = content.transitPlant.content.ToString();
                if (content.documentEntryScreenVariant.content != null) oRowDt[21] = content.documentEntryScreenVariant.content.ToString();
                if (content.cashManagementCompanyCode.content != null) oRowDt[22] = content.cashManagementCompanyCode.content.ToString();
                if (content.cashManagementActivated.content != null) oRowDt[23] = content.cashManagementActivated.content.ToString();
                if (content.defineDefaultValueDate.content != null) oRowDt[24] = content.defineDefaultValueDate.content.ToString();
                if (content.discountBaseIsNetValue.content != null) oRowDt[25] = content.discountBaseIsNetValue.content.ToString();
                if (content.creditControlArea.content != null) oRowDt[26] = content.creditControlArea.content.ToString();
                if (content.taxBaseIsNetValue.content != null) oRowDt[27] = content.taxBaseIsNetValue.content.ToString();
                if (content.sampleAcctRulesVar.content != null) oRowDt[28] = content.sampleAcctRulesVar.content.ToString();
                if (content.businessAreaFinStatements.content != null) oRowDt[29] = content.businessAreaFinStatements.content.ToString();
                if (content.proposeFiscalYear.content != null) oRowDt[30] = content.proposeFiscalYear.content.ToString();
                if (content.postTranslation.content != null) oRowDt[31] = content.postTranslation.content.ToString();
                if (content.companyCodeIsProductive.content != null) oRowDt[32] = content.companyCodeIsProductive.content.ToString();
                if (content.purchaseAccountProcessing.content != null) oRowDt[33] = content.purchaseAccountProcessing.content.ToString();
                if (content.jvAccountingActive.content != null) oRowDt[34] = content.jvAccountingActive.content.ToString();
                if (content.financialAssetsMgmtActive.content != null) oRowDt[35] = content.financialAssetsMgmtActive.content.ToString();
                if (content.noExchRateDiffWhenClearingInLC.content != null) oRowDt[36] = content.noExchRateDiffWhenClearingInLC.content.ToString();
                if (content.updateMMInCMF.content != null) oRowDt[37] = content.updateMMInCMF.content.ToString();
                if (content.updateSDInCMF.content != null) oRowDt[38] = content.updateSDInCMF.content.ToString();
                if (content.externalCoCode.content != null) oRowDt[39] = content.externalCoCode.content.ToString();
                if (content.originalKey.content != null) oRowDt[40] = content.originalKey.content.ToString();
                if (content.alternativeCOA.content != null) oRowDt[41] = content.alternativeCOA.content.ToString();
                if (content.taxesOnSlsPurc.content != null) oRowDt[42] = content.taxesOnSlsPurc.content.ToString();
                if (content.globalCoCde.content != null) oRowDt[43] = content.globalCoCde.content.ToString();
                if (content.fieldStatusVariant.content != null) oRowDt[44] = content.fieldStatusVariant.content.ToString();
                if (content.pstngPeriodVariant.content != null) oRowDt[45] = content.pstngPeriodVariant.content.ToString();
                if (content.hedgeRequestActive.content != null) oRowDt[46] = content.hedgeRequestActive.content.ToString();
                if (content.taxCrcyTranslation.content != null) oRowDt[47] = content.taxCrcyTranslation.content.ToString();
                if (content.workflowVariant.content != null) oRowDt[48] = content.workflowVariant.content.ToString();
                if (content.inventoryManagement.content != null) oRowDt[49] = content.inventoryManagement.content.ToString();
                if (content.poSchedulingAgmt.content != null) oRowDt[50] = content.poSchedulingAgmt.content.ToString();
                if (content.purchaseRequisition.content != null) oRowDt[51] = content.purchaseRequisition.content.ToString();
                if (content.contract.content != null) oRowDt[52] = content.contract.content.ToString();
                if (content.taxDetermwithDocDate.content != null) oRowDt[53] = content.taxDetermwithDocDate.content.ToString();
                if (content.inputTaxCode.content != null) oRowDt[54] = content.inputTaxCode.content.ToString();
                if (content.outputTaxCode.content != null) oRowDt[55] = content.outputTaxCode.content.ToString();
                if (content.importDataInPurchaseOrder.content != null) oRowDt[56] = content.importDataInPurchaseOrder.content.ToString();
                if (content.negativePostingsPermitted.content != null) oRowDt[57] = content.negativePostingsPermitted.content.ToString();
                if (content.controlAreaCanBeInput.content != null) oRowDt[58] = content.controlAreaCanBeInput.content.ToString();
                if (content.extendedWithholdingTaxActive.content != null) oRowDt[59] = content.extendedWithholdingTaxActive.content.ToString();
                if (content.postingDateForParking.content != null) oRowDt[60] = content.postingDateForParking.content.ToString();
                if (content.inflationMethod.content != null) oRowDt[61] = content.inflationMethod.content.ToString();
                if (content.fundsReservationFieldStatusVariant.content != null) oRowDt[62] = content.fundsReservationFieldStatusVariant.content.ToString();
                if (content.copyingControlGoodsReceipt.content != null) oRowDt[63] = content.copyingControlGoodsReceipt.content.ToString();
                if (content.importDataGoodsReceipt.content != null) oRowDt[64] = content.importDataGoodsReceipt.content.ToString();

                if (content.methodOffsttngAcct.content != null)
                {
                    int s;
                    if (int.TryParse(content.methodOffsttngAcct.content.ToString(), out s))
                    {
                        oRowDt[65] = s;
                    }
                }
                if (content.baVariant.content != null) oRowDt[66] = content.baVariant.content.ToString();
                if (content.costOfSalesAccountingActv.content != null) oRowDt[67] = content.costOfSalesAccountingActv.content.ToString();
                if (content.acctsRecblePledActive.content != null) oRowDt[68] = content.acctsRecblePledActive.content.ToString();
                if (content.enableAmountSplit.content != null) oRowDt[69] = content.enableAmountSplit.content.ToString();
                if (content.surchargeMethod.content != null) oRowDt[70] = content.surchargeMethod.content.ToString();
                if (content.documentTypeForProvisionsForTaxes.content != null) oRowDt[71] = content.documentTypeForProvisionsForTaxes.content.ToString();
                if (content.documentTypeForJVAmountCorrection.content != null) oRowDt[72] = content.documentTypeForJVAmountCorrection.content.ToString();
                if (content.documentTypeForJVTaxCode.content != null) oRowDt[73] = content.documentTypeForJVTaxCode.content.ToString();
                if (content.remittanceChallanDocumentType.content != null) oRowDt[74] = content.remittanceChallanDocumentType.content.ToString();
                if (content.deferredTaxRule.content != null) oRowDt[75] = content.deferredTaxRule.content.ToString();
                if (content.taxReportingDateActive.content != null) oRowDt[76] = content.taxReportingDateActive.content.ToString();
                if (content.managePostingPeriodForCoCodeLedger.content != null) oRowDt[77] = content.managePostingPeriodForCoCodeLedger.content.ToString();
                if (content.shoppingCart.content != null) oRowDt[78] = content.shoppingCart.content.ToString();
                if (content.hideEntryInInputHelp.content != null) oRowDt[79] = content.hideEntryInInputHelp.content.ToString();
                if (content.activateAADerivation.content != null) oRowDt[80] = content.activateAADerivation.content.ToString();if (content.activeFlag.content != null) oRowDt[81] = content.activeFlag.content.ToString();
                if (content.updateDateAndTime.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.updateDateAndTime.content.ToString() + "Z", out s))
                    {
                        oRowDt[82] = s.UtcDateTime;
                    }
                }

                if (content.updateType.content != null) oRowDt[83] = content.updateType.content.ToString();
                if (content.isRecordActive.content != null)
                {
                    bool s;
                    if (bool.TryParse(content.isRecordActive.content.ToString(), out s))
                    {
                        if (s) oRowDt[84] = 1;
                        else oRowDt[84] = 0;
                    }
                }
                if (content.recordActiveChange.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.recordActiveChange.content.ToString() + "Z", out s))
                    {
                        oRowDt[85] = s.UtcDateTime;
                    }
                }

                dt.Rows.Add(oRowDt);
            }

            return dt;
        }

        public static string GetColumnNames()
        {
            return "\"companyCode\",\"companyName\",\"city\",\"countryRegionKey\",\"currency\",\"languageKey\",\"chartOfAccounts\",\"maxExchangeRateDeviation\",\"fiscalYearVariant\",\"coArea\",\"company\",\"address\",\"vatRegistrationNo\",\"fmArea\",\"projectCashMgmtActive\",\"cshBdgtMgtActive\",\"updateFM\",\"jurisdictionCode\",\"fdsCtrActiveInHR\",\"template\",\"transitPlant\",\"documentEntryScreenVariant\",\"cashManagementCompanyCode\",\"cashManagementActivated\",\"defineDefaultValueDate\",\"discountBaseIsNetValue\",\"creditControlArea\",\"taxBaseIsNetValue\",\"sampleAcctRulesVar\",\"businessAreaFinStatements\",\"proposeFiscalYear\",\"postTranslation\",\"companyCodeIsProductive\",\"purchaseAccountProcessing\",\"jvAccountingActive\",\"financialAssetsMgmtActive\",\"noExchRateDiffWhenClearingInLC\",\"updateMMInCMF\",\"updateSDInCMF\",\"externalCoCode\",\"originalKey\",\"alternativeCOA\",\"taxesOnSlsPurc\",\"globalCoCde\",\"fieldStatusVariant\",\"pstngPeriodVariant\",\"hedgeRequestActive\",\"taxCrcyTranslation\",\"workflowVariant\",\"inventoryManagement\",\"poSchedulingAgmt\",\"purchaseRequisition\",\"contract\",\"taxDetermwithDocDate\",\"inputTaxCode\",\"outputTaxCode\",\"importDataInPurchaseOrder\",\"negativePostingsPermitted\",\"controlAreaCanBeInput\",\"extendedWithholdingTaxActive\",\"postingDateForParking\",\"inflationMethod\",\"fundsReservationFieldStatusVariant\",\"copyingControlGoodsReceipt\",\"importDataGoodsReceipt\",\"methodOffsttngAcct\",\"baVariant\",\"costOfSalesAccountingActv\",\"acctsRecblePledActive\",\"enableAmountSplit\",\"surchargeMethod\",\"documentTypeForProvisionsForTaxes\",\"documentTypeForJVAmountCorrection\",\"documentTypeForJVTaxCode\",\"remittanceChallanDocumentType\",\"deferredTaxRule\",\"taxReportingDateActive\",\"managePostingPeriodForCoCodeLedger\",\"shoppingCart\",\"hideEntryInInputHelp\",\"activateAADerivation\",\"activeFlag\",\"updateDateAndTime\",\"updateType\",\"isRecordActive\",\"recordActiveChange\"";
        }
    }
}
