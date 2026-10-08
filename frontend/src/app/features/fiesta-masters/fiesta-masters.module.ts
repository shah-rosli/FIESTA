import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { DxPopupModule } from 'devextreme-angular';

import { FiestaMastersRoutingModule } from './fiesta-masters-routing.module'
import { DxDataGridModule, DxResizableModule } from 'devextreme-angular'
import { FiestaMasterComponent } from './component/fiesta-master/fiesta-master.component'
import { PrevProductPlantComponent } from './fiesta-masters-prev-4/prev-product-plant/prev-product-plant.component'
import { PrevProductProductionComponent } from './fiesta-masters-prev-4/prev-product-production/prev-product-production.component'
import { PrevProductSalesComponent } from './fiesta-masters-prev-4/prev-product-sales/prev-product-sales.component'
import { PrevProductComponent } from './fiesta-masters-prev-4/prev-product/prev-product.component'
import { PrevProductionAlternativesComponent } from './fiesta-masters-prev-4/prev-production-alternatives/prev-production-alternatives.component'
import { PrevProductionBomComponent } from './fiesta-masters-prev-4/prev-production-bom/prev-production-bom.component'
import { PrevProductionRoutingS4Component } from './fiesta-masters-prev-4/prev-production-routing-s4/prev-production-routing-s4.component'
import { PrevProductionRoutingComponent } from './fiesta-masters-prev-4/prev-production-routing/prev-production-routing.component'
import { PrevProductionVersionComponent } from './fiesta-masters-prev-4/prev-production-version/prev-production-version.component'
import { PrevFiveProductPlantComponent } from './fiesta-masters-prev-5/prev-five-product-plant/prev-five-product-plant.component'
import { PrevFiveProductProductionComponent } from './fiesta-masters-prev-5/prev-five-product-production/prev-five-product-production.component'
import { PrevFiveProductSalesComponent } from './fiesta-masters-prev-5/prev-five-product-sales/prev-five-product-sales.component'
import { PrevFiveProductComponent } from './fiesta-masters-prev-5/prev-five-product/prev-five-product.component'
import { PrevFiveProductionAlternativesComponent } from './fiesta-masters-prev-5/prev-five-production-alternatives/prev-five-production-alternatives.component'
import { PrevFiveProductionBomComponent } from './fiesta-masters-prev-5/prev-five-production-bom/prev-five-production-bom.component'
import { PrevFiveProductionRoutingS4Component } from './fiesta-masters-prev-5/prev-five-production-routing-s4/prev-five-production-routing-s4.component'
import { PrevFiveProductionRoutingComponent } from './fiesta-masters-prev-5/prev-five-production-routing/prev-five-production-routing.component'
import { PrevFiveProductionVersionComponent } from './fiesta-masters-prev-5/prev-five-production-version/prev-five-production-version.component'
import { FiestaProductProductionComponent } from './fiesta-masters/fiesta-product-production/fiesta-product-production.component'
import { SharedModule } from 'src/app/shared/shared.module'
import { PrevSixProductProductionComponent } from './fiesta-masters-prev-6/prev-six-product-production/prev-six-product-production.component'
import { PrevSixProductComponent } from './fiesta-masters-prev-6/prev-six-product/prev-six-product.component'
import { PrevSixProductPlantComponent } from './fiesta-masters-prev-6/prev-six-product-plant/prev-six-product-plant.component'
import { PrevSixProductSalesComponent } from './fiesta-masters-prev-6/prev-six-product-sales/prev-six-product-sales.component'
import { PrevSixProductionBomComponent } from './fiesta-masters-prev-6/prev-six-production-bom/prev-six-production-bom.component'
import { PrevSixProductionRoutingComponent } from './fiesta-masters-prev-6/prev-six-production-routing/prev-six-production-routing.component'
import { PrevSixProductionRoutingS4Component } from './fiesta-masters-prev-6/prev-six-production-routing-s4/prev-six-production-routing-s4.component'
import { PrevSixProductionVersionComponent } from './fiesta-masters-prev-6/prev-six-production-version/prev-six-production-version.component'
import { PrevSixProductionAlternativesComponent } from './fiesta-masters-prev-6/prev-six-production-alternatives/prev-six-production-alternatives.component'
import { PrevSixProductionLeadtimeComponent } from './fiesta-masters-prev-6/prev-six-production-leadtime/prev-six-production-leadtime.component'
import { PrevSixProductionYieldComponent } from './fiesta-masters-prev-6/prev-six-production-yield/prev-six-production-yield.component'
import { PrevSixProductionLotsizeComponent } from './fiesta-masters-prev-6/prev-six-production-lotsize/prev-six-production-lotsize.component'
import { PrevSixDevProductProductionComponent } from './fiesta-masters-prev-6-dev/prev-six-dev-product-production/prev-six-dev-product-production.component'
import { PrevSixDevProductComponent } from './fiesta-masters-prev-6-dev/prev-six-dev-product/prev-six-dev-product.component'
import { PrevSixDevProductPlantComponent } from './fiesta-masters-prev-6-dev/prev-six-dev-product-plant/prev-six-dev-product-plant.component'
import { PrevSixDevProductSalesComponent } from './fiesta-masters-prev-6-dev/prev-six-dev-product-sales/prev-six-dev-product-sales.component'
import { PrevSixDevProductionBomComponent } from './fiesta-masters-prev-6-dev/prev-six-dev-production-bom/prev-six-dev-production-bom.component'
import { PrevSixDevProductionRoutingComponent } from './fiesta-masters-prev-6-dev/prev-six-dev-production-routing/prev-six-dev-production-routing.component'
import { PrevSixDevProductionRoutingS4Component } from './fiesta-masters-prev-6-dev/prev-six-dev-production-routing-s4/prev-six-dev-production-routing-s4.component'
import { PrevSixDevProductionVersionComponent } from './fiesta-masters-prev-6-dev/prev-six-dev-production-version/prev-six-dev-production-version.component'
import { PrevSixDevProductionAlternativesComponent } from './fiesta-masters-prev-6-dev/prev-six-dev-production-alternatives/prev-six-dev-production-alternatives.component'
import { PrevSixDevProductionLeadtimeComponent } from './fiesta-masters-prev-6-dev/prev-six-dev-production-leadtime/prev-six-dev-production-leadtime.component'
import { PrevSixDevProductionYieldComponent } from './fiesta-masters-prev-6-dev/prev-six-dev-production-yield/prev-six-dev-production-yield.component'
import { PrevSixDevProductionLotsizeComponent } from './fiesta-masters-prev-6-dev/prev-six-dev-production-lotsize/prev-six-dev-production-lotsize.component'
import { MastersOverviewComponent } from './fiesta-masters/masters-overview/masters-overview.component'
import { PrevR4Mc2ProductProductionComponent } from './fiesta-masters-prev-r4-mc2/prev-r4-mc2-product-production/prev-r4-mc2-product-production.component'
import { PrevR4Mc2ProductComponent } from './fiesta-masters-prev-r4-mc2/prev-r4-mc2-product/prev-r4-mc2-product.component'
import { PrevR4Mc2ProductPlantComponent } from './fiesta-masters-prev-r4-mc2/prev-r4-mc2-product-plant/prev-r4-mc2-product-plant.component'
import { PrevR4Mc2ProductSalesComponent } from './fiesta-masters-prev-r4-mc2/prev-r4-mc2-product-sales/prev-r4-mc2-product-sales.component'
import { PrevR4Mc2ProductionBomComponent } from './fiesta-masters-prev-r4-mc2/prev-r4-mc2-production-bom/prev-r4-mc2-production-bom.component'
import { PrevR4Mc2ProductionRoutingComponent } from './fiesta-masters-prev-r4-mc2/prev-r4-mc2-production-routing/prev-r4-mc2-production-routing.component'
import { PrevR4Mc2ProductionRoutingS4Component } from './fiesta-masters-prev-r4-mc2/prev-r4-mc2-production-routing-s4/prev-r4-mc2-production-routing-s4.component'
import { PrevR4Mc2ProductionVersionComponent } from './fiesta-masters-prev-r4-mc2/prev-r4-mc2-production-version/prev-r4-mc2-production-version.component'
import { PrevR4Mc2ProductionAlternativesComponent } from './fiesta-masters-prev-r4-mc2/prev-r4-mc2-production-alternatives/prev-r4-mc2-production-alternatives.component'
import { PrevR4Mc2ProductionLeadtimeComponent } from './fiesta-masters-prev-r4-mc2/prev-r4-mc2-production-leadtime/prev-r4-mc2-production-leadtime.component'
import { PrevR4Mc2ProductionYieldComponent } from './fiesta-masters-prev-r4-mc2/prev-r4-mc2-production-yield/prev-r4-mc2-production-yield.component'
import { PrevR4Mc2ProductionLotsizeComponent } from './fiesta-masters-prev-r4-mc2/prev-r4-mc2-production-lotsize/prev-r4-mc2-production-lotsize.component'
import { PrevR4Mc2ProductionCycletimeComponent } from './fiesta-masters-prev-r4-mc2/prev-r4-mc2-production-cycletime/prev-r4-mc2-production-cycletime.component'
import { FiestaMastersPrevR3DryrunComponent } from './fiesta-masters-prev-r3-dryrun/fiesta-masters-prev-r3-dryrun.component'
import { FiestaMastersGoldenOpnComponent } from './fiesta-masters-golden-opn/fiesta-masters-golden-opn.component'
import { FiestaMastersPrevR3Itc1Component } from './fiesta-masters-prev-r3-itc1/fiesta-masters-prev-r3-itc1.component'
import { FiestaMastersPrevR3Itc2Component } from './fiesta-masters-prev-r3-itc2/fiesta-masters-prev-r3-itc2.component'
import { UserBuyoffComponent } from './fiesta-masters/user-buyoff/user-buyoff.component';
import { FiestaUserBuyoffComponent } from './fiesta-masters/fiesta-user-buyoff/fiesta-user-buyoff.component';
import { ByoProductionComponent } from './components/byo-production/byo-production.component';
import { ByoProductionHistoryComponent } from './byo-production-history/byo-production-history.component';
import { ByoHistoryPopupComponent } from './components/byo-history-popup/byo-history-popup.component';
import { ByoVersionCompareComponent } from './components/byo-version-compare/byo-version-compare.component';


@NgModule({
  declarations: [
    FiestaMasterComponent,
    FiestaProductProductionComponent,
    PrevProductProductionComponent,
    PrevProductComponent,
    PrevProductPlantComponent,
    PrevProductSalesComponent,
    PrevProductionBomComponent,
    PrevProductionRoutingComponent,
    PrevProductionRoutingS4Component,
    PrevProductionVersionComponent,
    PrevProductionAlternativesComponent,
    PrevFiveProductComponent,
    PrevFiveProductionAlternativesComponent,
    PrevFiveProductionBomComponent,
    PrevFiveProductionRoutingComponent,
    PrevFiveProductionRoutingS4Component,
    PrevFiveProductionVersionComponent,
    PrevFiveProductPlantComponent,
    PrevFiveProductProductionComponent,
    PrevFiveProductSalesComponent,
    PrevSixProductProductionComponent,
    PrevSixProductComponent,
    PrevSixProductPlantComponent,
    PrevSixProductSalesComponent,
    PrevSixProductionBomComponent,
    PrevSixProductionRoutingComponent,
    PrevSixProductionRoutingS4Component,
    PrevSixProductionVersionComponent,
    PrevSixProductionAlternativesComponent,
    PrevSixProductionLeadtimeComponent,
    PrevSixProductionYieldComponent,
    PrevSixProductionLotsizeComponent,
    PrevSixDevProductProductionComponent,
    PrevSixDevProductComponent,
    PrevSixDevProductPlantComponent,
    PrevSixDevProductSalesComponent,
    PrevSixDevProductionBomComponent,
    PrevSixDevProductionRoutingComponent,
    PrevSixDevProductionRoutingS4Component,
    PrevSixDevProductionVersionComponent,
    PrevSixDevProductionAlternativesComponent,
    PrevSixDevProductionLeadtimeComponent,
    PrevSixDevProductionYieldComponent,
    PrevSixDevProductionLotsizeComponent,
    MastersOverviewComponent,
    PrevR4Mc2ProductProductionComponent,
    PrevR4Mc2ProductComponent,
    PrevR4Mc2ProductPlantComponent,
    PrevR4Mc2ProductSalesComponent,
    PrevR4Mc2ProductionBomComponent,
    PrevR4Mc2ProductionRoutingComponent,
    PrevR4Mc2ProductionRoutingS4Component,
    PrevR4Mc2ProductionVersionComponent,
    PrevR4Mc2ProductionAlternativesComponent,
    PrevR4Mc2ProductionLeadtimeComponent,
    PrevR4Mc2ProductionYieldComponent,
    PrevR4Mc2ProductionLotsizeComponent,
    PrevR4Mc2ProductionCycletimeComponent,
    FiestaMastersPrevR3DryrunComponent,
    FiestaMastersGoldenOpnComponent,
    FiestaMastersPrevR3Itc1Component,
    FiestaMastersPrevR3Itc2Component,
    UserBuyoffComponent,
    FiestaUserBuyoffComponent,
    ByoProductionComponent,
    ByoProductionHistoryComponent,
    ByoHistoryPopupComponent,
    ByoVersionCompareComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    DxDataGridModule,
    DxResizableModule,
    FiestaMastersRoutingModule,
    DxPopupModule
  ],
})
export class FiestaMastersModule { }
