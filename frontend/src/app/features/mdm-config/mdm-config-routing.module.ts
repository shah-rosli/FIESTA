import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
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
import { ProductEccnConversionComponent } from './pages/product-eccn-conversion/product-eccn-conversion.component';
import { ProductEccnConversionReviewComponent } from './pages/product-eccn-conversion-review/product-eccn-conversion-review.component';
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

const routes: Routes = [
  {
    path: 'AppApplication1',
    component: AppApplication1Component,
  },
  {
    path: 'AppApplication2',
    component: AppApplication2Component,
  },
  {
    path: 'AppApplication3',
    component: AppApplication3Component,
  },
  {
    path: 'AppApplication1Review',
    component: AppApplication1ReviewComponent,
  },
  {
    path: 'AppApplication2Review',
    component: AppApplication2ReviewComponent,
  },
  {
    path: 'AppApplication3Review',
    component: AppApplication3ReviewComponent,
  },
  {
    path: 'ProductionGroupStage',
    component: ProductionGroupStageComponent,
  },
  {
    path: 'ProductionGroupStageReview',
    component: ProductionGroupStageReviewComponent,
  },
  {
    path: 'ProductionGroupStageConversion',
    component: ProductionGroupStageConversionComponent,
  },
  {
    path: 'ProductionGroupStageConversionReview',
    component: ProductionGroupStageConversionReviewComponent,
  },
  {
    path: 'ProductionPlantConversion',
    component: ProductionPlantConversionComponent,
  },
  {
    path: 'ProductionPlantConversionReview',
    component: ProductionPlantConversionReviewComponent,
  },
  {
    path: 'StorageLocation',
    component: StorageLocationComponent,
  },
  {
    path: 'StorageLocationReview',
    component: StorageLocationReviewComponent,
  },
  {
    path: 'Plants',
    component: PlantsComponent,
  },
  {
    path: 'PlantsReview',
    component: PlantsReviewComponent,
  },
  {
    path: 'CompanyCode',
    component: CompanyCodeComponent,
  },
  {
    path: 'CompanyCodeReview',
    component: CompanyCodeReviewComponent,
  },
  {
    path: 'ProductEccnConversion',
    component: ProductEccnConversionComponent,
  },
  {
    path: 'ProductEccnConversionReview',
    component: ProductEccnConversionReviewComponent,
  },
  {
    path: 'ProductHsConversion',
    component: ProductHsConversionComponent,
  },
  {
    path: 'ProductHsConversionReview',
    component: ProductHsConversionReviewComponent,
  },
  {
    path: 'ProductHistorical',
    component: ProductHistoricalComponent,
  },
  {
    path: 'ProductHistoricalReview',
    component: ProductHistoricalReviewComponent,
  },
  {
    path: 'ProductSalesRootPartnumber',
    component: ProductSalesRootPartnumberComponent,
  },
  {
    path: 'ProductSalesRootPartnumberReview',
    component: ProductSalesRootPartnumberReviewComponent,
  },
  {
    path: 'ProductLine',
    component: ProductLineComponent,
  },
  {
    path: 'ProductLineReview',
    component: ProductLineReviewComponent,
  },
  {
    path: 'ProductType',
    component: ProductTypeComponent,
  },
  {
    path: 'ProductTypeReview',
    component: ProductTypeReviewComponent,
  },
  {
    path: 'FinIpOpn',
    component: FinIpOpnComponent,
  },
  {
    path: 'FinIpOpnReview',
    component: FinIpOpnReviewComponent,
  },
  {
    path: 'ProductV2',// old /config/ProductConfig
    component: ProductV2Component,
  },
  {
    path: 'ProductV2Review',
    component: ProductV2ReviewComponent,
  },
  {
    path: 'ProductCanflag',
    component: ProductCanflagComponent,
  },
  {
    path: 'ProductCanflagPattern',
    component: ProductCanflagPatternComponent,
  },

  { path: '**', redirectTo: '/PageError404' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MdmConfigRoutingModule { }
