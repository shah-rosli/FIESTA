import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { FiestaOutboundModule } from '../fiesta-outbound/fiesta-outbound.module';
//import { OutboundComponent } from '../fiesta-outbound/component/outbound/outbound.component';

import { MdmMastersRoutingModule } from './mdm-masters-routing.module'
import { SharedModule } from 'src/app/shared/shared.module'
import { DxResizableModule } from 'devextreme-angular';
import { OutCusBillToComponent } from './out-cus-bill-to/out-cus-bill-to.component'
import { OutCusEndCustomerComponent } from './out-cus-end-customer/out-cus-end-customer.component'
import { OutCusShipToComponent } from './out-cus-ship-to/out-cus-ship-to.component'
import { OutCusSoldToComponent } from './out-cus-sold-to/out-cus-sold-to.component';
import { OutCusPartnerFunctionComponent } from './out-cus-partner-function/out-cus-partner-function.component';
import { OutAppApplication1Component } from './out-app-application1/out-app-application1.component';
import { OutAppApplication2Component } from './out-app-application2/out-app-application2.component';
import { OutAppApplication3Component } from './out-app-application3/out-app-application3.component';
import { OutProductEccnConversionComponent } from './out-product-eccn-conversion/out-product-eccn-conversion.component';
import { OutProductHistoricalComponent } from './out-product-historical/out-product-historical.component';
import { OutProductHsConversionComponent } from './out-product-hs-conversion/out-product-hs-conversion.component';
import { OutProductLineComponent } from './out-product-line/out-product-line.component';
import { OutProductSalesRootPartnumberComponent } from './out-product-sales-root-partnumber/out-product-sales-root-partnumber.component';
import { OutProductTypeComponent } from './out-product-type/out-product-type.component';
import { MdmProductionGroupStageComponent } from './mdm-production-group-stage/mdm-production-group-stage.component';
import { MdmProductionGroupStageConversionComponent } from './mdm-production-group-stage-conversion/mdm-production-group-stage-conversion.component';
import { MdmProductionPlantConversionComponent } from './mdm-production-plant-conversion/mdm-production-plant-conversion.component';
import { MdmStorageLocationComponent } from './mdm-storage-location/mdm-storage-location.component';
import { MdmPlantsComponent } from './mdm-plants/mdm-plants.component';
import { MdmCompanyCodeComponent } from './mdm-company-code/mdm-company-code.component';
import { OutFinCostCenterComponent } from './out-fin-cost-center/out-fin-cost-center.component';
import { OutFinIpCustomerComponent } from './out-fin-ip-customer/out-fin-ip-customer.component';
import { OutFinIpOpnComponent } from './out-fin-ip-opn/out-fin-ip-opn.component';
import { OutProductStandardCostComponent } from './out-product-standard-cost/out-product-standard-cost.component';
import { OutProductWipSellPriceComponent } from './out-product-wip-sell-price/out-product-wip-sell-price.component';
import { OutVenVendorComponent } from './out-ven-vendor/out-ven-vendor.component';
import { OutVenVendorCompanyComponent } from './out-ven-vendor-company/out-ven-vendor-company.component';
import { OutVenVendorPurchaseInfoRecComponent } from './out-ven-vendor-purchase-info-rec/out-ven-vendor-purchase-info-rec.component';
import { OutProductCanFlags4Component } from './out-product-can-flags4/out-product-can-flags4.component';
import { MdmProfitCenterComponent } from './mdm-profit-center/mdm-profit-center.component';
import { MdmProfitCenterHierarchyComponent } from './mdm-profit-center-hierarchy/mdm-profit-center-hierarchy.component';
import { MdmProductHierarchyComponent } from './mdm-product-hierarchy/mdm-product-hierarchy.component';
import { MdmProductHierarchyProfitcenterConversionComponent } from './mdm-product-hierarchy-profitcenter-conversion/mdm-product-hierarchy-profitcenter-conversion.component';
import { OutNonproductionProductComponent } from './out-nonproduction-product/out-nonproduction-product.component';
import { OutNonproductionProductPlantComponent } from './out-nonproduction-product-plant/out-nonproduction-product-plant.component';
import { OutNonproductionProductSalesComponent } from './out-nonproduction-product-sales/out-nonproduction-product-sales.component';
import { OutProductConsolidateComponent } from './out-product-consolidate/out-product-consolidate.component';
import { OutProductPlantConsolidateComponent } from './out-product-plant-consolidate/out-product-plant-consolidate.component';
import { OutProductSalesConsolidateComponent } from './out-product-sales-consolidate/out-product-sales-consolidate.component';
import { MdmGlmSlocPlantCompanyComponent } from './mdm-glm-sloc-plant-company/mdm-glm-sloc-plant-company.component'

@NgModule({
  declarations: [
    OutCusBillToComponent,
    OutCusEndCustomerComponent,
    OutCusShipToComponent,
    OutCusSoldToComponent,
    OutAppApplication1Component,
    OutAppApplication2Component,
    OutAppApplication3Component,
    OutProductEccnConversionComponent,
    OutProductHistoricalComponent,
    OutProductHsConversionComponent,
    OutProductLineComponent,
    OutProductSalesRootPartnumberComponent,
    OutProductTypeComponent,
    MdmProductionGroupStageComponent,
    MdmProductionGroupStageConversionComponent,
    MdmProductionPlantConversionComponent,
    MdmStorageLocationComponent,
    MdmPlantsComponent,
    MdmCompanyCodeComponent,
    OutCusPartnerFunctionComponent,
    OutFinCostCenterComponent,
    OutFinIpCustomerComponent,
    OutFinIpOpnComponent,
    OutProductStandardCostComponent,
    OutProductWipSellPriceComponent,
    OutVenVendorComponent,
    OutVenVendorCompanyComponent,
    OutVenVendorPurchaseInfoRecComponent,
    OutProductCanFlags4Component,
    MdmProfitCenterComponent,
    MdmProfitCenterHierarchyComponent,
    MdmProductHierarchyComponent,
    MdmProductHierarchyProfitcenterConversionComponent,
    OutNonproductionProductComponent,
    OutNonproductionProductPlantComponent,
    OutNonproductionProductSalesComponent,
    OutProductConsolidateComponent,
    OutProductPlantConsolidateComponent,
    OutProductSalesConsolidateComponent,
    MdmGlmSlocPlantCompanyComponent,


  ],
  imports: [
    CommonModule,
    SharedModule,
    DxResizableModule,
    MdmMastersRoutingModule

    , FiestaOutboundModule

  ]
})
export class MdmMastersModule { }
