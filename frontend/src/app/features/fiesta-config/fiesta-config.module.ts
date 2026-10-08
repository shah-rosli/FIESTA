import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { FiestaConfigRoutingModule } from './fiesta-config-routing.module'
import { DxPopupModule, DxLoadPanelModule, DxFileUploaderModule } from 'devextreme-angular'
import { SharedModule } from 'src/app/shared/shared.module'
import { ConfigHistoryPopupComponent } from './components/config-history-popup/config-history-popup.component'
import { DeltaUploadComponent } from './components/delta-upload/delta-upload.component'
import { PatternDisplayComponent } from './components/pattern-display/pattern-display.component'
import { ProductionAltFullComponent } from './components/production-alt-full/production-alt-full.component'
import { ProductionAltPriorityComponent } from './components/production-alt-priority/production-alt-priority.component'
import { ProductionCostingYieldByGlmComponent } from './components/production-costing-yield-by-glm/production-costing-yield-by-glm.component'
import { ProductionCostingYieldByGsComponent } from './components/production-costing-yield-by-gs/production-costing-yield-by-gs.component'
import { ProductionLeadtimeByGlmComponent } from './components/production-leadtime-by-glm/production-leadtime-by-glm.component'
import { ProductionLeadtimeByGsComponent } from './components/production-leadtime-by-gs/production-leadtime-by-gs.component'
import { ProductionPlanningYieldByGlmComponent } from './components/production-planning-yield-by-glm/production-planning-yield-by-glm.component'
import { ProductionPlanningYieldByGsComponent } from './components/production-planning-yield-by-gs/production-planning-yield-by-gs.component'
import { CdbConfigComponent } from './pages/cdb-config/cdb-config.component'
import { CompanyCodeMappingComponent } from './pages/company-code-mapping/company-code-mapping.component'
import { ComponentsConfigComponent } from './pages/components-config/components-config.component'
import { LeadtimePatternBackendComponent } from './pages/leadtime-pattern-backend/leadtime-pattern-backend.component'
import { LeadtimePatternFrontendComponent } from './pages/leadtime-pattern-frontend/leadtime-pattern-frontend.component'
import { PkgConvertMasterComponent } from './pages/pkg-convert-master/pkg-convert-master.component'
import { ProcessConvertMasterComponent } from './pages/process-convert-master/process-convert-master.component'
import { ProductConfigComponent } from './pages/product-config/product-config.component'
import { ProductR4MpnPartdescConfigComponent } from './pages/product-r4-mpn-partdesc-config/product-r4-mpn-partdesc-config.component'
import { ProductR4OpnPartdescConfigComponent } from './pages/product-r4-opn-partdesc-config/product-r4-opn-partdesc-config.component'
import { ProductionAltConfigComponent } from './pages/production-alt-config/production-alt-config.component'
import { ProductionCostingYieldConfigComponent } from './pages/production-costing-yield-config/production-costing-yield-config.component'
import { ProductionCycletimeConfigComponent } from './pages/production-cycletime-config/production-cycletime-config.component'
import { ProductionLeadtimeConfigComponent } from './pages/production-leadtime-config/production-leadtime-config.component'
import { ProductionLotsizeConfigComponent } from './pages/production-lotsize-config/production-lotsize-config.component'
import { ProductionPlanningYieldConfigComponent } from './pages/production-planning-yield-config/production-planning-yield-config.component'
import { ProductionVersionConfigComponent } from './pages/production-version-config/production-version-config.component'
import { ProductionVersionPatternComponent } from './pages/production-version-pattern/production-version-pattern.component'
import { ShipPointConfigComponent } from './pages/ship-point-config/ship-point-config.component'
import { YieldPatternBackendComponent } from './pages/yield-pattern-backend/yield-pattern-backend.component'
import { YieldPatternFrontendComponent } from './pages/yield-pattern-frontend/yield-pattern-frontend.component';
import { DcPriorityMaxtrixConfigComponent } from './pages/dc-priority-maxtrix-config/dc-priority-maxtrix-config.component';
import { DcFinalFactoryPlantConfigComponent } from './pages/dc-final-factory-plant-config/dc-final-factory-plant-config.component';
import { BusinessPlannerCodeComponent } from './pages/business-planner-code/business-planner-code.component'


@NgModule({
  declarations: [
    DeltaUploadComponent,
    PkgConvertMasterComponent,
    ProcessConvertMasterComponent,
    ProductionAltConfigComponent,
    ProductionAltFullComponent,
    ProductionAltPriorityComponent,
    ProductionLotsizeConfigComponent,
    ProductionLeadtimeConfigComponent,
    ShipPointConfigComponent,
    ProductionVersionConfigComponent,
    ProductionPlanningYieldConfigComponent,
    ProductionPlanningYieldByGlmComponent,
    ProductionPlanningYieldByGsComponent,
    ProductionCostingYieldConfigComponent,
    ProductionCostingYieldByGlmComponent,
    ProductionCostingYieldByGsComponent,
    ProductionLeadtimeByGlmComponent,
    ProductionLeadtimeByGsComponent,
    ProductionCycletimeConfigComponent,
    ProductR4OpnPartdescConfigComponent,
    ProductR4MpnPartdescConfigComponent,
    ProductConfigComponent,
    ConfigHistoryPopupComponent,
    CdbConfigComponent,
    ComponentsConfigComponent,
    LeadtimePatternFrontendComponent,
    LeadtimePatternBackendComponent,
    YieldPatternFrontendComponent,
    YieldPatternBackendComponent,
    ProductionVersionPatternComponent,
    PatternDisplayComponent,
    CompanyCodeMappingComponent,
    DcPriorityMaxtrixConfigComponent,
    DcFinalFactoryPlantConfigComponent,
    BusinessPlannerCodeComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    DxPopupModule,
    DxLoadPanelModule,
    DxFileUploaderModule,
    FiestaConfigRoutingModule
  ]
})
export class FiestaConfigModule { }
