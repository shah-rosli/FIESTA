import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { FiestaInboundRoutingModule } from './fiesta-inbound-routing.module'
import { PlmAglComponentsComponent } from './AGILE/plm-agl-components/plm-agl-components.component'
import { PlmAglMaterialsComponent } from './AGILE/plm-agl-materials/plm-agl-materials.component'
import { PlmAglProductComponent } from './AGILE/plm-agl-product/plm-agl-product.component'
import { PlmAglProductionComponent } from './AGILE/plm-agl-production/plm-agl-production.component'
import { PlmEolStatusComponent } from './EOL/plm-eol-status/plm-eol-status.component'
import { CompanyCodeComponent } from './MDM/company-code/company-code.component'
import { PlantsComponent } from './MDM/plants/plants.component'
import { ProductHierarchyProfitcenterConversionComponent } from './MDM/product-hierarchy-profitcenter-conversion/product-hierarchy-profitcenter-conversion.component'
import { ProductHierarchyComponent } from './MDM/product-hierarchy/product-hierarchy.component'
import { ProductionGroupStageConversionComponent } from './MDM/production-group-stage-conversion/production-group-stage-conversion.component'
import { ProductionGroupStageComponent } from './MDM/production-group-stage/production-group-stage.component'
import { ProductionPlantConversionComponent } from './MDM/production-plant-conversion/production-plant-conversion.component'
import { ProfitCenterHierarchyComponent } from './MDM/profit-center-hierarchy/profit-center-hierarchy.component'
import { ProfitCenterMapComponent } from './MDM/profit-center-map/profit-center-map.component'
import { ProfitCenterComponent } from './MDM/profit-center/profit-center.component'
import { StorageLocationComponent } from './MDM/storage-location/storage-location.component'
import { PlmPriOpnComponent } from './PRIDES/plm-pri-opn/plm-pri-opn.component'
import { PlmProAltMixRatiosComponent } from './PROSTER/plm-pro-alt-mix-ratios/plm-pro-alt-mix-ratios.component'
import { PlmProBomComponent } from './PROSTER/plm-pro-bom/plm-pro-bom.component'
import { PlmProLeadtimeMinitsComponent } from './PROSTER/plm-pro-leadtime-minits/plm-pro-leadtime-minits.component'
import { PlmProLeadtimeProsterComponent } from './PROSTER/plm-pro-leadtime-proster/plm-pro-leadtime-proster.component'
import { PlmProMpnS4Component } from './PROSTER/plm-pro-mpn-s4/plm-pro-mpn-s4.component'
import { PlmProRoutingComponent } from './PROSTER/plm-pro-routing/plm-pro-routing.component'
import { PlmProVersionComponent } from './PROSTER/plm-pro-version/plm-pro-version.component'
import { PlmProYieldMinitsComponent } from './PROSTER/plm-pro-yield-minits/plm-pro-yield-minits.component'
import { PlmProYieldProsterComponent } from './PROSTER/plm-pro-yield-proster/plm-pro-yield-proster.component'
import { PlmRetMaterialComponent } from './RETIS/plm-ret-material/plm-ret-material.component'
import { PlmRetPnstatusComponent } from './RETIS/plm-ret-pnstatus/plm-ret-pnstatus.component'
import { PlmAglCharacteristicsComponent } from './AGILE/plm-agl-characteristics/plm-agl-characteristics.component'
import { PlmProCycleTimeComponent } from './PROSTER/plm-pro-cycle-time/plm-pro-cycle-time.component'
import { SharedModule } from 'src/app/shared/shared.module'
import { RawAglComponentsComponent } from './AGILE/raw-agl-components/raw-agl-components.component'
import { RawAglMatrixComponent } from './AGILE/raw-agl-matrix/raw-agl-matrix.component'
import { PlmAglMatrixComponent } from './AGILE/plm-agl-matrix/plm-agl-matrix.component'
import { RawAglProcessCharacteristicsComponent } from './AGILE/raw-agl-process-characteristics/raw-agl-process-characteristics.component'
import { PlmAglProcessCharacteristicsComponent } from './AGILE/plm-agl-process-characteristics/plm-agl-process-characteristics.component'
import { RawAglProductComponent } from './AGILE/raw-agl-product/raw-agl-product.component'
import { RawAglProductionComponent } from './AGILE/raw-agl-production/raw-agl-production.component'
import { MesStageExpansionComponent } from './MES/mes-stage-expansion/mes-stage-expansion.component'


@NgModule({
  declarations: [
    PlmAglProductionComponent,
    PlmAglProductComponent,
    PlmAglMaterialsComponent,
    PlmAglComponentsComponent,
    ProductHierarchyComponent,
    ProfitCenterComponent,
    ProfitCenterHierarchyComponent,
    ProductionGroupStageComponent,
    ProductHierarchyProfitcenterConversionComponent,
    ProductionGroupStageConversionComponent,
    ProductionPlantConversionComponent,
    CompanyCodeComponent,
    StorageLocationComponent,
    PlantsComponent,
    ProfitCenterMapComponent,
    PlmEolStatusComponent,
    PlmPriOpnComponent,
    PlmProAltMixRatiosComponent,
    PlmProBomComponent,
    PlmProLeadtimeMinitsComponent,
    PlmProLeadtimeProsterComponent,
    PlmProMpnS4Component,
    PlmProRoutingComponent,
    PlmProVersionComponent,
    PlmProYieldMinitsComponent,
    PlmProYieldProsterComponent,
    PlmRetMaterialComponent,
    PlmRetPnstatusComponent,
    PlmAglCharacteristicsComponent,
    PlmProCycleTimeComponent,
    RawAglComponentsComponent,
    RawAglMatrixComponent,
    PlmAglMatrixComponent,
    RawAglProcessCharacteristicsComponent,
    PlmAglProcessCharacteristicsComponent,
    RawAglProductComponent,
    RawAglProductionComponent,
    MesStageExpansionComponent,
  ],
  imports: [
    CommonModule, SharedModule,
    FiestaInboundRoutingModule
  ]
})
export class FiestaInboundModule { }
