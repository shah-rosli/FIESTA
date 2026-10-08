import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { PlmBlacklistedComponent } from './plm-masters/plm-blacklisted/plm-blacklisted.component'
import { PlmProductionComponent } from './plm-masters/plm-production/plm-production.component'
import { PlmBomComponent } from './plm-masters/plm-bom/plm-bom.component'
import { PlmMixRatioComponent } from './plm-masters/plm-mix-ratio/plm-mix-ratio.component'
import { PlmProductMpnComponent } from './plm-masters/plm-product-mpn/plm-product-mpn.component'
import { PlmProductOpnMaterialComponent } from './plm-masters/plm-product-opn-material/plm-product-opn-material.component'
import { PlmProductOpnMpnComponent } from './plm-masters/plm-product-opn-mpn/plm-product-opn-mpn.component'
import { PlmProductOpnComponent } from './plm-masters/plm-product-opn/plm-product-opn.component'
import { PlmRoutingComponent } from './plm-masters/plm-routing/plm-routing.component'
import { PlmVersionComponent } from './plm-masters/plm-version/plm-version.component'
import { PlmProductRmComponent } from './plm-masters/plm-product-rm/plm-product-rm.component'
import { PlmProductComponent } from './plm-masters/plm-product/plm-product.component'
import { PlmProductGoldenOpnComponent } from './plm-masters-golden-opn/plm-product-golden-opn/plm-product-golden-opn.component'
import { PlmProductionGoldenOpnComponent } from './plm-masters-golden-opn/plm-production-golden-opn/plm-production-golden-opn.component'
import { AgileBlacklistComponent } from './plm-masters/agile-blacklist/agile-blacklist.component'
import { PlmComponentsComponent } from './plm-masters/plm-components/plm-components.component'
import { PlmProductionPrevR3Itc1Component } from './plm-masters-prev-r3-itc1/plm-production-prev-r3-itc1/plm-production-prev-r3-itc1.component'
import { PlmMastersPrevR3Itc1Component } from './plm-masters-prev-r3-itc1/plm-masters-prev-r3-itc1/plm-masters-prev-r3-itc1.component'

const routes: Routes = [
  {
    path: 'PlmBlacklisted',
    component: PlmBlacklistedComponent,
  },
  {
    path: 'PlmProduction',
    component: PlmProductionComponent,
  },
  {
    path: 'PlmProductOpn',
    component: PlmProductOpnComponent,
  },
  {
    path: 'PlmProductMpn',
    component: PlmProductMpnComponent,
  },
  {
    path: 'PlmProductOpnMpn',
    component: PlmProductOpnMpnComponent,
  },
  {
    path: 'PlmProductRm',
    component: PlmProductRmComponent,
  },
  {
    path: 'PlmProductOpnMaterial',
    component: PlmProductOpnMaterialComponent,
  },
  {
    path: 'PlmBom',
    component: PlmBomComponent,
  },
  {
    path: 'PlmRouting',
    component: PlmRoutingComponent,
  },
  {
    path: 'PlmVersion',
    component: PlmVersionComponent,
  },
  {
    path: 'PlmMixRatio',
    component: PlmMixRatioComponent,
  },
  {
    path: 'PlmProduct',
    component: PlmProductComponent,
  },
  {
    path: 'PlmProductGoldenOpn',
    component: PlmProductGoldenOpnComponent,
  },
  {
    path: 'PlmProductionGoldenOpn',
    component: PlmProductionGoldenOpnComponent,
  },
  {
    path: 'AgileBlacklist',
    component: AgileBlacklistComponent,
  },
  {
    path: 'PlmComponents',
    component: PlmComponentsComponent,
  },
  {
    path: 'PlmMastersPrevR3Itc1',
    component: PlmMastersPrevR3Itc1Component,
  },
  {
    path: 'PlmProductionPrevR3Itc1',
    component: PlmProductionPrevR3Itc1Component,
  },

  { path: '**', redirectTo: '/PageError404' }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlmMastersRoutingModule { }
