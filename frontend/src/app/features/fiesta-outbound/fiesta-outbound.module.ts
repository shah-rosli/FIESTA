import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { FiestaOutboundRoutingModule } from './fiesta-outbound-routing.module'
import { PrevOutProductPlantComponent } from './mdm-prev/prev-out-product-plant/prev-out-product-plant.component'
import { PrevOutProductSalesComponent } from './mdm-prev/prev-out-product-sales/prev-out-product-sales.component'
import { PrevOutProductComponent } from './mdm-prev/prev-out-product/prev-out-product.component'
import { PrevOutProductionAlternativesComponent } from './mdm-prev/prev-out-production-alternatives/prev-out-production-alternatives.component'
import { PrevOutProductionBomComponent } from './mdm-prev/prev-out-production-bom/prev-out-production-bom.component'
import { PrevOutProductionRoutingS4Component } from './mdm-prev/prev-out-production-routing-s4/prev-out-production-routing-s4.component'
import { PrevOutProductionRoutingComponent } from './mdm-prev/prev-out-production-routing/prev-out-production-routing.component'
import { PrevOutProductionVersionComponent } from './mdm-prev/prev-out-production-version/prev-out-production-version.component'
import { PrevFiveOutProductPlantComponent } from './mdm-prev-5/prev-five-out-product-plant/prev-five-out-product-plant.component'
import { PrevFiveOutProductSalesComponent } from './mdm-prev-5/prev-five-out-product-sales/prev-five-out-product-sales.component'
import { PrevFiveOutProductComponent } from './mdm-prev-5/prev-five-out-product/prev-five-out-product.component'
import { PrevFiveOutProductionAlternativesComponent } from './mdm-prev-5/prev-five-out-production-alternatives/prev-five-out-production-alternatives.component'
import { PrevFiveOutProductionBomComponent } from './mdm-prev-5/prev-five-out-production-bom/prev-five-out-production-bom.component'
import { PrevFiveOutProductionRoutingS4Component } from './mdm-prev-5/prev-five-out-production-routing-s4/prev-five-out-production-routing-s4.component'
import { PrevFiveOutProductionRoutingComponent } from './mdm-prev-5/prev-five-out-production-routing/prev-five-out-production-routing.component'
import { PrevFiveOutProductionVersionComponent } from './mdm-prev-5/prev-five-out-production-version/prev-five-out-production-version.component'
import { OutProductPlantComponent } from './mdm/out-product-plant/out-product-plant.component'
import { OutProductSalesComponent } from './mdm/out-product-sales/out-product-sales.component'
import { OutProductComponent } from './mdm/out-product/out-product.component'
import { OutProductionAlternativesComponent } from './mdm/out-production-alternatives/out-production-alternatives.component'
import { OutProductionBomComponent } from './mdm/out-production-bom/out-production-bom.component'
import { OutProductionRoutingS4Component } from './mdm/out-production-routing-s4/out-production-routing-s4.component'
import { OutProductionRoutingComponent } from './mdm/out-production-routing/out-production-routing.component'
import { OutProductionVersionComponent } from './mdm/out-production-version/out-production-version.component'
import { OutProductionComponent } from './mdm/out-production/out-production.component'
import { OutProductionLeadtimeComponent } from './mdm/out-production-leadtime/out-production-leadtime.component'
import { OutProductionLotsizeComponent } from './mdm/out-production-lotsize/out-production-lotsize.component'
import { OutProductionYieldComponent } from './mdm/out-production-yield/out-production-yield.component'
import { S4ViewSummaryComponent } from './s4-view-summary/s4-view-summary.component'
import { OutboundComponent } from './component/outbound/outbound.component'
import { SharedModule } from 'src/app/shared/shared.module'
import { OutProductionCycletimeComponent } from './mdm/out-production-cycletime/out-production-cycletime.component'
import { PrevSixOutProductComponent } from './mdm-prev-6/prev-six-out-product/prev-six-out-product.component'
import { PrevSixOutProductPlantComponent } from './mdm-prev-6/prev-six-out-product-plant/prev-six-out-product-plant.component'
import { PrevSixOutProductSalesComponent } from './mdm-prev-6/prev-six-out-product-sales/prev-six-out-product-sales.component'
import { PrevSixOutProductionBomComponent } from './mdm-prev-6/prev-six-out-production-bom/prev-six-out-production-bom.component'
import { PrevSixOutProductionRoutingComponent } from './mdm-prev-6/prev-six-out-production-routing/prev-six-out-production-routing.component'
import { PrevSixOutProductionRoutingS4Component } from './mdm-prev-6/prev-six-out-production-routing-s4/prev-six-out-production-routing-s4.component'
import { PrevSixOutProductionVersionComponent } from './mdm-prev-6/prev-six-out-production-version/prev-six-out-production-version.component'
import { PrevSixOutProductionAlternativesComponent } from './mdm-prev-6/prev-six-out-production-alternatives/prev-six-out-production-alternatives.component'
import { PrevSixOutProductionLeadtimeComponent } from './mdm-prev-6/prev-six-out-production-leadtime/prev-six-out-production-leadtime.component'
import { PrevSixOutProductionYieldComponent } from './mdm-prev-6/prev-six-out-production-yield/prev-six-out-production-yield.component'
import { PrevSixOutProductionLotsizeComponent } from './mdm-prev-6/prev-six-out-production-lotsize/prev-six-out-production-lotsize.component'
import { PrevSixOutProductPirComponent } from './mdm-prev-6/prev-six-out-product-pir/prev-six-out-product-pir.component'
import { PrevSixOutProductVendorCharComponent } from './mdm-prev-6/prev-six-out-product-vendor-char/prev-six-out-product-vendor-char.component'
import { PrevSixDevOutProductComponent } from './mdm-prev-6-dev/prev-six-dev-out-product/prev-six-dev-out-product.component'
import { PrevSixDevOutProductPlantComponent } from './mdm-prev-6-dev/prev-six-dev-out-product-plant/prev-six-dev-out-product-plant.component'
import { PrevSixDevOutProductSalesComponent } from './mdm-prev-6-dev/prev-six-dev-out-product-sales/prev-six-dev-out-product-sales.component'
import { PrevSixDevOutProductionBomComponent } from './mdm-prev-6-dev/prev-six-dev-out-production-bom/prev-six-dev-out-production-bom.component'
import { PrevSixDevOutProductionRoutingComponent } from './mdm-prev-6-dev/prev-six-dev-out-production-routing/prev-six-dev-out-production-routing.component'
import { PrevSixDevOutProductionRoutingS4Component } from './mdm-prev-6-dev/prev-six-dev-out-production-routing-s4/prev-six-dev-out-production-routing-s4.component'
import { PrevSixDevOutProductionVersionComponent } from './mdm-prev-6-dev/prev-six-dev-out-production-version/prev-six-dev-out-production-version.component'
import { PrevSixDevOutProductionAlternativesComponent } from './mdm-prev-6-dev/prev-six-dev-out-production-alternatives/prev-six-dev-out-production-alternatives.component'
import { PrevSixDevOutProductionLeadtimeComponent } from './mdm-prev-6-dev/prev-six-dev-out-production-leadtime/prev-six-dev-out-production-leadtime.component'
import { PrevSixDevOutProductionYieldComponent } from './mdm-prev-6-dev/prev-six-dev-out-production-yield/prev-six-dev-out-production-yield.component'
import { PrevSixDevOutProductionLotsizeComponent } from './mdm-prev-6-dev/prev-six-dev-out-production-lotsize/prev-six-dev-out-production-lotsize.component'
import { PrevSixDevOutProductPirComponent } from './mdm-prev-6-dev/prev-six-dev-out-product-pir/prev-six-dev-out-product-pir.component'
import { PrevSixDevOutProductVendorCharComponent } from './mdm-prev-6-dev/prev-six-dev-out-product-vendor-char/prev-six-dev-out-product-vendor-char.component'
import { ProductionStageConversionComponent } from './mdm/production-stage-conversion/production-stage-conversion.component'
import { ProductionStageComponent } from './mdm/production-stage/production-stage.component'
import { PrevR4Mc2OutProductComponent } from './mdm-prev-r4-mc2/prev-r4-mc2-out-product/prev-r4-mc2-out-product.component'
import { PrevR4Mc2OutProductPlantComponent } from './mdm-prev-r4-mc2/prev-r4-mc2-out-product-plant/prev-r4-mc2-out-product-plant.component'
import { PrevR4Mc2OutProductSalesComponent } from './mdm-prev-r4-mc2/prev-r4-mc2-out-product-sales/prev-r4-mc2-out-product-sales.component'
import { PrevR4Mc2OutProductionBomComponent } from './mdm-prev-r4-mc2/prev-r4-mc2-out-production-bom/prev-r4-mc2-out-production-bom.component'
import { PrevR4Mc2OutProductionRoutingComponent } from './mdm-prev-r4-mc2/prev-r4-mc2-out-production-routing/prev-r4-mc2-out-production-routing.component'
import { PrevR4Mc2OutProductionRoutingS4Component } from './mdm-prev-r4-mc2/prev-r4-mc2-out-production-routing-s4/prev-r4-mc2-out-production-routing-s4.component'
import { PrevR4Mc2OutProductionVersionComponent } from './mdm-prev-r4-mc2/prev-r4-mc2-out-production-version/prev-r4-mc2-out-production-version.component'
import { PrevR4Mc2OutProductionAlternativesComponent } from './mdm-prev-r4-mc2/prev-r4-mc2-out-production-alternatives/prev-r4-mc2-out-production-alternatives.component'
import { PrevR4Mc2OutProductionLeadtimeComponent } from './mdm-prev-r4-mc2/prev-r4-mc2-out-production-leadtime/prev-r4-mc2-out-production-leadtime.component'
import { PrevR4Mc2OutProductionYieldComponent } from './mdm-prev-r4-mc2/prev-r4-mc2-out-production-yield/prev-r4-mc2-out-production-yield.component'
import { PrevR4Mc2OutProductionLotsizeComponent } from './mdm-prev-r4-mc2/prev-r4-mc2-out-production-lotsize/prev-r4-mc2-out-production-lotsize.component'
import { PrevR4Mc2OutProductionCycletimeComponent } from './mdm-prev-r4-mc2/prev-r4-mc2-out-production-cycletime/prev-r4-mc2-out-production-cycletime.component'
import { PrevR4Mc2OutProductPirComponent } from './mdm-prev-r4-mc2/prev-r4-mc2-out-product-pir/prev-r4-mc2-out-product-pir.component'
import { PrevR4Mc2OutProductVendorCharComponent } from './mdm-prev-r4-mc2/prev-r4-mc2-out-product-vendor-char/prev-r4-mc2-out-product-vendor-char.component'
import { OutProductVendorCharComponent } from './mdm/out-product-vendor-char/out-product-vendor-char.component'
import { OutProductMatrixComponent } from './mdm/out-product-matrix/out-product-matrix.component'
import { MdmViewSummaryComponent } from './mdm-view-summary/mdm-view-summary.component'
import { ScmViewComponent } from './scm-view/scm-view.component';
import { PrevR3DryrunOutProductComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-out-product/prev-r3-dryrun-out-product.component';
import { PrevR3DryrunOutProductPlantComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-out-product-plant/prev-r3-dryrun-out-product-plant.component';
import { PrevR3DryrunOutProductSalesComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-out-product-sales/prev-r3-dryrun-out-product-sales.component';
import { PrevR3DryrunOutProductMatrixComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-out-product-matrix/prev-r3-dryrun-out-product-matrix.component';
import { PrevR3DryrunOutProductVendorCharComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-out-product-vendor-char/prev-r3-dryrun-out-product-vendor-char.component';
import { PrevR3DryrunOutProductionBomComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-out-production-bom/prev-r3-dryrun-out-production-bom.component';
import { PrevR3DryrunOutProductionRoutingComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-out-production-routing/prev-r3-dryrun-out-production-routing.component';
import { PrevR3DryrunOutProductionRoutingS4Component } from './mdm-prev-r3-dryrun/prev-r3-dryrun-out-production-routing-s4/prev-r3-dryrun-out-production-routing-s4.component';
import { PrevR3DryrunOutProductionVersionComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-out-production-version/prev-r3-dryrun-out-production-version.component';
import { PrevR3DryrunOutProductionAlternativesComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-out-production-alternatives/prev-r3-dryrun-out-production-alternatives.component';
import { PrevR3DryrunOutProductionLeadtimeComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-out-production-leadtime/prev-r3-dryrun-out-production-leadtime.component';
import { PrevR3DryrunOutProductionYieldComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-out-production-yield/prev-r3-dryrun-out-production-yield.component';
import { PrevR3DryrunOutProductionLotsizeComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-out-production-lotsize/prev-r3-dryrun-out-production-lotsize.component';
import { PrevR3DryrunOutProductionCycletimeComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-out-production-cycletime/prev-r3-dryrun-out-production-cycletime.component';
import { PrevR3DryrunProductionStageComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-production-stage/prev-r3-dryrun-production-stage.component';
import { PrevR3DryrunProductionStageConvComponent } from './mdm-prev-r3-dryrun/prev-r3-dryrun-production-stage-conv/prev-r3-dryrun-production-stage-conv.component';
import { OutProductGoldenOpnComponent } from './mdm-golden-opn/out-product-golden-opn/out-product-golden-opn.component';
import { OutProductPlantGoldenOpnComponent } from './mdm-golden-opn/out-product-plant-golden-opn/out-product-plant-golden-opn.component';
import { OutProductSalesGoldenOpnComponent } from './mdm-golden-opn/out-product-sales-golden-opn/out-product-sales-golden-opn.component';
import { OutProductMatrixGoldenOpnComponent } from './mdm-golden-opn/out-product-matrix-golden-opn/out-product-matrix-golden-opn.component';
import { OutProductVendorCharGoldenOpnComponent } from './mdm-golden-opn/out-product-vendor-char-golden-opn/out-product-vendor-char-golden-opn.component';
import { OutProductionBomGoldenOpnComponent } from './mdm-golden-opn/out-production-bom-golden-opn/out-production-bom-golden-opn.component';
import { OutProductionRoutingGoldenOpnComponent } from './mdm-golden-opn/out-production-routing-golden-opn/out-production-routing-golden-opn.component';
import { OutProductionRoutingS4GoldenOpnComponent } from './mdm-golden-opn/out-production-routing-s4-golden-opn/out-production-routing-s4-golden-opn.component';
import { OutProductionVersionGoldenOpnComponent } from './mdm-golden-opn/out-production-version-golden-opn/out-production-version-golden-opn.component';
import { OutProductionAlternativesGoldenOpnComponent } from './mdm-golden-opn/out-production-alternatives-golden-opn/out-production-alternatives-golden-opn.component';
import { OutProductionLeadtimeGoldenOpnComponent } from './mdm-golden-opn/out-production-leadtime-golden-opn/out-production-leadtime-golden-opn.component';
import { OutProductionYieldGoldenOpnComponent } from './mdm-golden-opn/out-production-yield-golden-opn/out-production-yield-golden-opn.component';
import { OutProductionLotsizeGoldenOpnComponent } from './mdm-golden-opn/out-production-lotsize-golden-opn/out-production-lotsize-golden-opn.component';
import { OutProductionCycletimeGoldenOpnComponent } from './mdm-golden-opn/out-production-cycletime-golden-opn/out-production-cycletime-golden-opn.component';
import { OutComponentsComponent } from './mdm/out-components/out-components.component';
import { PrevR3Itc1OutProductComponent } from './mdm-prev-r3-itc1/prev-r3-itc1-out-product/prev-r3-itc1-out-product.component';
import { PrevR3Itc1OutProductPlantComponent } from './mdm-prev-r3-itc1/prev-r3-itc1-out-product-plant/prev-r3-itc1-out-product-plant.component';
import { PrevR3Itc1OutProductSalesComponent } from './mdm-prev-r3-itc1/prev-r3-itc1-out-product-sales/prev-r3-itc1-out-product-sales.component';
import { PrevR3Itc1OutProductMatrixComponent } from './mdm-prev-r3-itc1/prev-r3-itc1-out-product-matrix/prev-r3-itc1-out-product-matrix.component';
import { PrevR3Itc1OutProductVendorCharComponent } from './mdm-prev-r3-itc1/prev-r3-itc1-out-product-vendor-char/prev-r3-itc1-out-product-vendor-char.component';
import { PrevR3Itc1OutComponentsComponent } from './mdm-prev-r3-itc1/prev-r3-itc1-out-components/prev-r3-itc1-out-components.component';
import { PrevR3Itc1OutProductionBomComponent } from './mdm-prev-r3-itc1/prev-r3-itc1-out-production-bom/prev-r3-itc1-out-production-bom.component';
import { PrevR3Itc1OutProductionRoutingComponent } from './mdm-prev-r3-itc1/prev-r3-itc1-out-production-routing/prev-r3-itc1-out-production-routing.component';
import { PrevR3Itc1OutProductionRoutingS4Component } from './mdm-prev-r3-itc1/prev-r3-itc1-out-production-routing-s4/prev-r3-itc1-out-production-routing-s4.component';
import { PrevR3Itc1OutProductionVersionComponent } from './mdm-prev-r3-itc1/prev-r3-itc1-out-production-version/prev-r3-itc1-out-production-version.component';
import { PrevR3Itc1OutProductionAlternativesComponent } from './mdm-prev-r3-itc1/prev-r3-itc1-out-production-alternatives/prev-r3-itc1-out-production-alternatives.component';
import { PrevR3Itc1OutProductionLeadtimeComponent } from './mdm-prev-r3-itc1/prev-r3-itc1-out-production-leadtime/prev-r3-itc1-out-production-leadtime.component';
import { PrevR3Itc1OutProductionYieldComponent } from './mdm-prev-r3-itc1/prev-r3-itc1-out-production-yield/prev-r3-itc1-out-production-yield.component';
import { PrevR3Itc1OutProductionLotsizeComponent } from './mdm-prev-r3-itc1/prev-r3-itc1-out-production-lotsize/prev-r3-itc1-out-production-lotsize.component';
import { PrevR3Itc1OutProductionCycletimeComponent } from './mdm-prev-r3-itc1/prev-r3-itc1-out-production-cycletime/prev-r3-itc1-out-production-cycletime.component';
import { PrevR3Itc2OutComponentsComponent } from './mdm-prev-r3-itc2/prev-r3-itc2-out-components/prev-r3-itc2-out-components.component';
import { PrevR3Itc2OutProductComponent } from './mdm-prev-r3-itc2/prev-r3-itc2-out-product/prev-r3-itc2-out-product.component';
import { PrevR3Itc2OutProductionAlternativesComponent } from './mdm-prev-r3-itc2/prev-r3-itc2-out-production-alternatives/prev-r3-itc2-out-production-alternatives.component';
import { PrevR3Itc2OutProductionBomComponent } from './mdm-prev-r3-itc2/prev-r3-itc2-out-production-bom/prev-r3-itc2-out-production-bom.component';
import { PrevR3Itc2OutProductionCycletimeComponent } from './mdm-prev-r3-itc2/prev-r3-itc2-out-production-cycletime/prev-r3-itc2-out-production-cycletime.component';
import { PrevR3Itc2OutProductionLeadtimeComponent } from './mdm-prev-r3-itc2/prev-r3-itc2-out-production-leadtime/prev-r3-itc2-out-production-leadtime.component';
import { PrevR3Itc2OutProductionLotsizeComponent } from './mdm-prev-r3-itc2/prev-r3-itc2-out-production-lotsize/prev-r3-itc2-out-production-lotsize.component';
import { PrevR3Itc2OutProductionRoutingComponent } from './mdm-prev-r3-itc2/prev-r3-itc2-out-production-routing/prev-r3-itc2-out-production-routing.component';
import { PrevR3Itc2OutProductionRoutingS4Component } from './mdm-prev-r3-itc2/prev-r3-itc2-out-production-routing-s4/prev-r3-itc2-out-production-routing-s4.component';
import { PrevR3Itc2OutProductionVersionComponent } from './mdm-prev-r3-itc2/prev-r3-itc2-out-production-version/prev-r3-itc2-out-production-version.component';
import { PrevR3Itc2OutProductionYieldComponent } from './mdm-prev-r3-itc2/prev-r3-itc2-out-production-yield/prev-r3-itc2-out-production-yield.component';
import { PrevR3Itc2OutProductMatrixComponent } from './mdm-prev-r3-itc2/prev-r3-itc2-out-product-matrix/prev-r3-itc2-out-product-matrix.component';
import { PrevR3Itc2OutProductPlantComponent } from './mdm-prev-r3-itc2/prev-r3-itc2-out-product-plant/prev-r3-itc2-out-product-plant.component';
import { PrevR3Itc2OutProductSalesComponent } from './mdm-prev-r3-itc2/prev-r3-itc2-out-product-sales/prev-r3-itc2-out-product-sales.component';
import { PrevR3Itc2OutProductVendorCharComponent } from './mdm-prev-r3-itc2/prev-r3-itc2-out-product-vendor-char/prev-r3-itc2-out-product-vendor-char.component'
import { DxLoadPanelModule } from 'devextreme-angular';

@NgModule({
  declarations: [
    OutboundComponent,
    OutProductComponent,
    OutProductPlantComponent,
    OutProductSalesComponent,
    OutProductionComponent,
    OutProductionBomComponent,
    OutProductionRoutingComponent,
    OutProductionRoutingS4Component,
    OutProductionVersionComponent,
    OutProductionAlternativesComponent,
    S4ViewSummaryComponent,
    OutProductionLeadtimeComponent,
    OutProductionYieldComponent,
    OutProductionLotsizeComponent,
    PrevOutProductComponent,
    PrevOutProductPlantComponent,
    PrevOutProductSalesComponent,
    PrevOutProductionBomComponent,
    PrevOutProductionRoutingComponent,
    PrevOutProductionRoutingS4Component,
    PrevOutProductionVersionComponent,
    PrevOutProductionAlternativesComponent,
    PrevFiveOutProductComponent,
    PrevFiveOutProductionAlternativesComponent,
    PrevFiveOutProductionBomComponent,
    PrevFiveOutProductionRoutingComponent,
    PrevFiveOutProductionRoutingS4Component,
    PrevFiveOutProductionVersionComponent,
    PrevFiveOutProductPlantComponent,
    PrevFiveOutProductSalesComponent,
    OutProductionCycletimeComponent,
    PrevSixOutProductComponent,
    PrevSixOutProductPlantComponent,
    PrevSixOutProductSalesComponent,
    PrevSixOutProductionBomComponent,
    PrevSixOutProductionRoutingComponent,
    PrevSixOutProductionRoutingS4Component,
    PrevSixOutProductionVersionComponent,
    PrevSixOutProductionAlternativesComponent,
    PrevSixOutProductionLeadtimeComponent,
    PrevSixOutProductionYieldComponent,
    PrevSixOutProductionLotsizeComponent,
    PrevSixOutProductPirComponent,
    PrevSixOutProductVendorCharComponent,
    PrevSixDevOutProductComponent,
    PrevSixDevOutProductPlantComponent,
    PrevSixDevOutProductSalesComponent,
    PrevSixDevOutProductionBomComponent,
    PrevSixDevOutProductionRoutingComponent,
    PrevSixDevOutProductionRoutingS4Component,
    PrevSixDevOutProductionVersionComponent,
    PrevSixDevOutProductionAlternativesComponent,
    PrevSixDevOutProductionLeadtimeComponent,
    PrevSixDevOutProductionYieldComponent,
    PrevSixDevOutProductionLotsizeComponent,
    PrevSixDevOutProductPirComponent,
    PrevSixDevOutProductVendorCharComponent,
    ProductionStageConversionComponent,
    ProductionStageComponent,
    PrevR4Mc2OutProductComponent,
    PrevR4Mc2OutProductPlantComponent,
    PrevR4Mc2OutProductSalesComponent,
    PrevR4Mc2OutProductionBomComponent,
    PrevR4Mc2OutProductionRoutingComponent,
    PrevR4Mc2OutProductionRoutingS4Component,
    PrevR4Mc2OutProductionVersionComponent,
    PrevR4Mc2OutProductionAlternativesComponent,
    PrevR4Mc2OutProductionLeadtimeComponent,
    PrevR4Mc2OutProductionYieldComponent,
    PrevR4Mc2OutProductionLotsizeComponent,
    PrevR4Mc2OutProductionCycletimeComponent,
    PrevR4Mc2OutProductPirComponent,
    PrevR4Mc2OutProductVendorCharComponent,
    OutProductVendorCharComponent,
    OutProductMatrixComponent,
    MdmViewSummaryComponent,
    ScmViewComponent,
    PrevR3DryrunOutProductComponent,
    PrevR3DryrunOutProductPlantComponent,
    PrevR3DryrunOutProductSalesComponent,
    PrevR3DryrunOutProductMatrixComponent,
    PrevR3DryrunOutProductVendorCharComponent,
    PrevR3DryrunOutProductionBomComponent,
    PrevR3DryrunOutProductionRoutingComponent,
    PrevR3DryrunOutProductionRoutingS4Component,
    PrevR3DryrunOutProductionVersionComponent,
    PrevR3DryrunOutProductionAlternativesComponent,
    PrevR3DryrunOutProductionLeadtimeComponent,
    PrevR3DryrunOutProductionYieldComponent,
    PrevR3DryrunOutProductionLotsizeComponent,
    PrevR3DryrunOutProductionCycletimeComponent,
    PrevR3DryrunProductionStageComponent,
    PrevR3DryrunProductionStageConvComponent,
    OutProductGoldenOpnComponent,
    OutProductPlantGoldenOpnComponent,
    OutProductSalesGoldenOpnComponent,
    OutProductMatrixGoldenOpnComponent,
    OutProductVendorCharGoldenOpnComponent,
    OutProductionBomGoldenOpnComponent,
    OutProductionRoutingGoldenOpnComponent,
    OutProductionRoutingS4GoldenOpnComponent,
    OutProductionVersionGoldenOpnComponent,
    OutProductionAlternativesGoldenOpnComponent,
    OutProductionLeadtimeGoldenOpnComponent,
    OutProductionYieldGoldenOpnComponent,
    OutProductionLotsizeGoldenOpnComponent,
    OutProductionCycletimeGoldenOpnComponent,
    OutComponentsComponent,
    PrevR3Itc1OutProductComponent,
    PrevR3Itc1OutProductPlantComponent,
    PrevR3Itc1OutProductSalesComponent,
    PrevR3Itc1OutProductMatrixComponent,
    PrevR3Itc1OutProductVendorCharComponent,
    PrevR3Itc1OutComponentsComponent,
    PrevR3Itc1OutProductionBomComponent,
    PrevR3Itc1OutProductionRoutingComponent,
    PrevR3Itc1OutProductionRoutingS4Component,
    PrevR3Itc1OutProductionVersionComponent,
    PrevR3Itc1OutProductionAlternativesComponent,
    PrevR3Itc1OutProductionLeadtimeComponent,
    PrevR3Itc1OutProductionYieldComponent,
    PrevR3Itc1OutProductionLotsizeComponent,
    PrevR3Itc1OutProductionCycletimeComponent,
    PrevR3Itc2OutComponentsComponent,
    PrevR3Itc2OutProductComponent,
    PrevR3Itc2OutProductionAlternativesComponent,
    PrevR3Itc2OutProductionBomComponent,
    PrevR3Itc2OutProductionCycletimeComponent,
    PrevR3Itc2OutProductionLeadtimeComponent,
    PrevR3Itc2OutProductionLotsizeComponent,
    PrevR3Itc2OutProductionRoutingComponent,
    PrevR3Itc2OutProductionRoutingS4Component,
    PrevR3Itc2OutProductionVersionComponent,
    PrevR3Itc2OutProductionYieldComponent,
    PrevR3Itc2OutProductMatrixComponent,
    PrevR3Itc2OutProductPlantComponent,
    PrevR3Itc2OutProductSalesComponent,
    PrevR3Itc2OutProductVendorCharComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    FiestaOutboundRoutingModule,
    DxLoadPanelModule
  ],
  exports: [
    OutboundComponent
  ]
})
export class FiestaOutboundModule { }
