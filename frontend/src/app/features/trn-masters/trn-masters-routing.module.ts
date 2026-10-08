import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { TrnBomComponent } from './trn-bom/trn-bom.component'
import { TrnMixRatioComponent } from './trn-mix-ratio/trn-mix-ratio.component'
import { TrnProductComponent } from './trn-product/trn-product.component'
import { TrnProductionComponent } from './trn-production/trn-production.component'
import { TrnRoutingComponent } from './trn-routing/trn-routing.component'
import { TrnVersionComponent } from './trn-version/trn-version.component'
import { TrnProductComponentsComponent } from './trn-product-components/trn-product-components.component'
import { TrnProductMatrixComponent } from './trn-product-matrix/trn-product-matrix.component'
import { TrnProductPlantComponent } from './trn-product-plant/trn-product-plant.component'
import { TrnProductSalesComponent } from './trn-product-sales/trn-product-sales.component'
import { TrnProductVendorCharComponent } from './trn-product-vendor-char/trn-product-vendor-char.component'
import { TrnProductionCycletimeComponent } from './trn-production-cycletime/trn-production-cycletime.component'
import { TrnProductionLeadtimeComponent } from './trn-production-leadtime/trn-production-leadtime.component'
import { TrnProductionLotsizeComponent } from './trn-production-lotsize/trn-production-lotsize.component'
import { TrnProductionRoutingS4Component } from './trn-production-routing-s4/trn-production-routing-s4.component'
import { TrnProductionYieldComponent } from './trn-production-yield/trn-production-yield.component'

const routes: Routes = [
  {
    path: 'TrnProduction',
    component: TrnProductionComponent,
  },
  {
    path: 'TrnProduct',
    component: TrnProductComponent,
  },
  {
    path: 'TrnBom',
    component: TrnBomComponent,
  },
  {
    path: 'TrnRouting',
    component: TrnRoutingComponent,
  },
  {
    path: 'TrnVersion',
    component: TrnVersionComponent,
  },
  {
    path: 'TrnMixRatio',
    component: TrnMixRatioComponent,
  },
  {
    path: 'TrnProductPlant',
    component: TrnProductPlantComponent,
  },
  {
    path: 'TrnProductSales',
    component: TrnProductSalesComponent,
  },
  {
    path: 'TrnProductComponents',
    component: TrnProductComponentsComponent,
  },
  {
    path: 'TrnProductVendorChar',
    component: TrnProductVendorCharComponent,
  },
  {
    path: 'TrnProductMatrix',
    component: TrnProductMatrixComponent,
  },
  {
    path: 'TrnProductionRoutingS4',
    component: TrnProductionRoutingS4Component,
  },
  {
    path: 'TrnProductionLeadtime',
    component: TrnProductionLeadtimeComponent,
  },
  {
    path: 'TrnProductionYield',
    component: TrnProductionYieldComponent,
  },
  {
    path: 'TrnProductionLotsize',
    component: TrnProductionLotsizeComponent,
  },
  {
    path: 'TrnProductionCycletime',
    component: TrnProductionCycletimeComponent,
  },

  { path: '**', redirectTo: '/PageError404' }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TrnMastersRoutingModule { }
