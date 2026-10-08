import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { TrnMastersRoutingModule } from './trn-masters-routing.module'
import { SharedModule } from 'src/app/shared/shared.module'
import { TrnProductionComponent } from './trn-production/trn-production.component'
import { TrnProductComponent } from './trn-product/trn-product.component'
import { TrnBomComponent } from './trn-bom/trn-bom.component'
import { TrnRoutingComponent } from './trn-routing/trn-routing.component'
import { TrnVersionComponent } from './trn-version/trn-version.component'
import { TrnMixRatioComponent } from './trn-mix-ratio/trn-mix-ratio.component'
import { DxResizableModule } from 'devextreme-angular';
import { TrnProductPlantComponent } from './trn-product-plant/trn-product-plant.component';
import { TrnProductSalesComponent } from './trn-product-sales/trn-product-sales.component';
import { TrnProductComponentsComponent } from './trn-product-components/trn-product-components.component';
import { TrnProductVendorCharComponent } from './trn-product-vendor-char/trn-product-vendor-char.component';
import { TrnProductMatrixComponent } from './trn-product-matrix/trn-product-matrix.component';
import { TrnProductionRoutingS4Component } from './trn-production-routing-s4/trn-production-routing-s4.component';
import { TrnProductionLeadtimeComponent } from './trn-production-leadtime/trn-production-leadtime.component';
import { TrnProductionYieldComponent } from './trn-production-yield/trn-production-yield.component';
import { TrnProductionLotsizeComponent } from './trn-production-lotsize/trn-production-lotsize.component';
import { TrnProductionCycletimeComponent } from './trn-production-cycletime/trn-production-cycletime.component'


@NgModule({
  declarations: [
    TrnProductionComponent,
    TrnProductComponent,
    TrnBomComponent,
    TrnRoutingComponent,
    TrnVersionComponent,
    TrnMixRatioComponent,
    TrnProductPlantComponent,
    TrnProductSalesComponent,
    TrnProductComponentsComponent,
    TrnProductVendorCharComponent,
    TrnProductMatrixComponent,
    TrnProductionRoutingS4Component,
    TrnProductionLeadtimeComponent,
    TrnProductionYieldComponent,
    TrnProductionLotsizeComponent,
    TrnProductionCycletimeComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    DxResizableModule,
    TrnMastersRoutingModule
  ]
})
export class TrnMastersModule { }
