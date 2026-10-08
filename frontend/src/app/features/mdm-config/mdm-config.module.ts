import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module'
import { DxResizableModule } from 'devextreme-angular';
import { DxPopupModule, DxLoadPanelModule, DxFileUploaderModule } from 'devextreme-angular'
// import { ConfigHistoryPopupComponent } from '../fiesta-config/components/config-history-popup/config-history-popup.component';
// import { DeltaUploadComponent } from '../fiesta-config/components/delta-upload/delta-upload.component'
import { ConfigHistoryPopupComponent } from '../mdm-config/components/config-history-popup/config-history-popup.component';
import { DeltaUploadComponent } from '../mdm-config/components/delta-upload/delta-upload.component'
import { MdmConfigRoutingModule } from './mdm-config-routing.module';
import { AppApplication1Component } from './pages/app-application1/app-application1.component';
import { AppApplication2Component } from './pages/app-application2/app-application2.component';
import { AppApplication3Component } from './pages/app-application3/app-application3.component';
import { AppApplication1ReviewComponent } from './pages/app-application1-review/app-application1-review.component';
import { AppApplication2ReviewComponent } from './pages/app-application2-review/app-application2-review.component';
import { AppApplication3ReviewComponent } from './pages/app-application3-review/app-application3-review.component';
import { ProductionGroupStageComponent } from './pages/production-group-stage/production-group-stage.component';
import { ProductionGroupStageReviewComponent } from './pages/production-group-stage-review/production-group-stage-review.component';
import { ProductionGroupStageConversionComponent } from './pages/production-group-stage-conversion/production-group-stage-conversion.component';
import { ProductionGroupStageConversionReviewComponent } from './pages/production-group-stage-conversion-review/production-group-stage-conversion-review.component';
import { ProductionPlantConversionComponent } from './pages/production-plant-conversion/production-plant-conversion.component';
import { ProductionPlantConversionReviewComponent } from './pages/production-plant-conversion-review/production-plant-conversion-review.component';
import { StorageLocationComponent } from './pages/storage-location/storage-location.component';
import { StorageLocationReviewComponent } from './pages/storage-location-review/storage-location-review.component';
import { PlantsComponent } from './pages/plants/plants.component';
import { PlantsReviewComponent } from './pages/plants-review/plants-review.component';
import { CompanyCodeComponent } from './pages/company-code/company-code.component';
import { CompanyCodeReviewComponent } from './pages/company-code-review/company-code-review.component';
import { ProductEccnConversionReviewComponent } from './pages/product-eccn-conversion-review/product-eccn-conversion-review.component';
import { ProductEccnConversionComponent } from './pages/product-eccn-conversion/product-eccn-conversion.component';
import { ProductHsConversionComponent } from './pages/product-hs-conversion/product-hs-conversion.component';
import { ProductHsConversionReviewComponent } from './pages/product-hs-conversion-review/product-hs-conversion-review.component';
import { ProductHistoricalComponent } from './pages/product-historical/product-historical.component';
import { ProductHistoricalReviewComponent } from './pages/product-historical-review/product-historical-review.component';
import { ProductSalesRootPartnumberComponent } from './pages/product-sales-root-partnumber/product-sales-root-partnumber.component';
import { ProductSalesRootPartnumberReviewComponent } from './pages/product-sales-root-partnumber-review/product-sales-root-partnumber-review.component';
import { ProductLineComponent } from './pages/product-line/product-line.component';
import { ProductLineReviewComponent } from './pages/product-line-review/product-line-review.component';
import { ProductTypeComponent } from './pages/product-type/product-type.component';
import { ProductTypeReviewComponent } from './pages/product-type-review/product-type-review.component';
import { FinIpOpnComponent } from './pages/fin-ip-opn/fin-ip-opn.component';
import { FinIpOpnReviewComponent } from './pages/fin-ip-opn-review/fin-ip-opn-review.component';
import { ProductV2Component } from './pages/product-v2/product-v2.component';
import { ProductV2ReviewComponent } from './pages/product-v2-review/product-v2-review.component';
import { ProductCanflagComponent } from './pages/product-canflag/product-canflag.component';
import { ProductCanflagPatternComponent } from './pages/product-canflag-pattern/product-canflag-pattern.component';

@NgModule({
  declarations: [
    AppApplication1Component,
    AppApplication2Component,
    AppApplication3Component,
    ConfigHistoryPopupComponent,
    DeltaUploadComponent,
    AppApplication1ReviewComponent,
    AppApplication2ReviewComponent,
    AppApplication3ReviewComponent,
    ProductionGroupStageComponent,
    ProductionGroupStageReviewComponent,
    ProductionGroupStageConversionComponent,
    ProductionGroupStageConversionReviewComponent,
    ProductionPlantConversionComponent,
    ProductionPlantConversionReviewComponent,
    StorageLocationComponent,
    StorageLocationReviewComponent,
    PlantsComponent,
    PlantsReviewComponent,
    CompanyCodeComponent,
    CompanyCodeReviewComponent,
    ProductEccnConversionReviewComponent,
    ProductEccnConversionComponent,
    ProductHsConversionComponent,
    ProductHsConversionReviewComponent,
    ProductHistoricalComponent,
    ProductHistoricalReviewComponent,
    ProductSalesRootPartnumberComponent,
    ProductSalesRootPartnumberReviewComponent,
    ProductLineComponent,
    ProductLineReviewComponent,
    ProductTypeComponent,
    ProductTypeReviewComponent,
    FinIpOpnComponent,
    FinIpOpnReviewComponent,
    ProductV2Component,
    ProductV2ReviewComponent,
    ProductCanflagComponent,
    ProductCanflagPatternComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    DxPopupModule,
    DxLoadPanelModule,
    DxFileUploaderModule,
    MdmConfigRoutingModule
  ]
})
export class MdmConfigModule { }
