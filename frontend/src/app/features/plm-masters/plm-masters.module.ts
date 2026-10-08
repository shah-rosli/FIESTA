import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { PlmMastersRoutingModule } from './plm-masters-routing.module'
import { SharedModule } from 'src/app/shared/shared.module'
import { PlmBlacklistedComponent } from './plm-masters/plm-blacklisted/plm-blacklisted.component'
import { PlmProductionComponent } from './plm-masters/plm-production/plm-production.component'
import { PlmProductOpnComponent } from './plm-masters/plm-product-opn/plm-product-opn.component'
import { PlmProductMpnComponent } from './plm-masters/plm-product-mpn/plm-product-mpn.component'
import { PlmProductOpnMpnComponent } from './plm-masters/plm-product-opn-mpn/plm-product-opn-mpn.component'
import { PlmProductOpnMaterialComponent } from './plm-masters/plm-product-opn-material/plm-product-opn-material.component'
import { PlmBomComponent } from './plm-masters/plm-bom/plm-bom.component'
import { PlmRoutingComponent } from './plm-masters/plm-routing/plm-routing.component'
import { PlmVersionComponent } from './plm-masters/plm-version/plm-version.component'
import { PlmMixRatioComponent } from './plm-masters/plm-mix-ratio/plm-mix-ratio.component'
import { PlmProductRmComponent } from './plm-masters/plm-product-rm/plm-product-rm.component'
import { PlmProductComponent } from './plm-masters/plm-product/plm-product.component'
import { PlmProductGoldenOpnComponent } from './plm-masters-golden-opn/plm-product-golden-opn/plm-product-golden-opn.component'
import { PlmProductionGoldenOpnComponent } from './plm-masters-golden-opn/plm-production-golden-opn/plm-production-golden-opn.component'
import { AgileBlacklistComponent } from './plm-masters/agile-blacklist/agile-blacklist.component'
import { PlmComponentsComponent } from './plm-masters/plm-components/plm-components.component'
import { PlmMastersPrevR3Itc1Component } from './plm-masters-prev-r3-itc1/plm-masters-prev-r3-itc1/plm-masters-prev-r3-itc1.component'
import { PlmProductionPrevR3Itc1Component } from './plm-masters-prev-r3-itc1/plm-production-prev-r3-itc1/plm-production-prev-r3-itc1.component'
import { DxSplitterModule } from 'devextreme-angular'

@NgModule({
  declarations: [
    PlmBlacklistedComponent,
    PlmProductionComponent,
    PlmProductOpnComponent,
    PlmProductMpnComponent,
    PlmProductOpnMpnComponent,
    PlmProductRmComponent,
    PlmProductOpnMaterialComponent,
    PlmBomComponent,
    PlmRoutingComponent,
    PlmVersionComponent,
    PlmMixRatioComponent,
    PlmProductComponent,
    PlmProductGoldenOpnComponent,
    PlmProductionGoldenOpnComponent,
    AgileBlacklistComponent,
    PlmComponentsComponent,
    PlmMastersPrevR3Itc1Component,
    PlmProductionPrevR3Itc1Component,
  ],
  imports: [
    CommonModule,
    SharedModule,
    PlmMastersRoutingModule,
    DxSplitterModule
  ]
})
export class PlmMastersModule { }
