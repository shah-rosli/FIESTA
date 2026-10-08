import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { PkgConvertMasterComponent } from './pages/pkg-convert-master/pkg-convert-master.component'
import { ProcessConvertMasterComponent } from './pages/process-convert-master/process-convert-master.component'
import { ProductionAltConfigComponent } from './pages/production-alt-config/production-alt-config.component'
import { ProductionLeadtimeConfigComponent } from './pages/production-leadtime-config/production-leadtime-config.component'
import { ProductionLotsizeConfigComponent } from './pages/production-lotsize-config/production-lotsize-config.component'
import { ProductionVersionConfigComponent } from './pages/production-version-config/production-version-config.component'
import { ShipPointConfigComponent } from './pages/ship-point-config/ship-point-config.component'
import { ProductionPlanningYieldConfigComponent } from './pages/production-planning-yield-config/production-planning-yield-config.component'
import { ProductionCostingYieldConfigComponent } from './pages/production-costing-yield-config/production-costing-yield-config.component'
import { ProductionCycletimeConfigComponent } from './pages/production-cycletime-config/production-cycletime-config.component'
import { ProductR4OpnPartdescConfigComponent } from './pages/product-r4-opn-partdesc-config/product-r4-opn-partdesc-config.component'
import { ProductR4MpnPartdescConfigComponent } from './pages/product-r4-mpn-partdesc-config/product-r4-mpn-partdesc-config.component'
import { ProductConfigComponent } from './pages/product-config/product-config.component'
import { CdbConfigComponent } from './pages/cdb-config/cdb-config.component'
import { ComponentsConfigComponent } from './pages/components-config/components-config.component'
import { LeadtimePatternBackendComponent } from './pages/leadtime-pattern-backend/leadtime-pattern-backend.component'
import { LeadtimePatternFrontendComponent } from './pages/leadtime-pattern-frontend/leadtime-pattern-frontend.component'
import { ProductionVersionPatternComponent } from './pages/production-version-pattern/production-version-pattern.component'
import { YieldPatternBackendComponent } from './pages/yield-pattern-backend/yield-pattern-backend.component'
import { YieldPatternFrontendComponent } from './pages/yield-pattern-frontend/yield-pattern-frontend.component'
import { CompanyCodeMappingComponent } from './pages/company-code-mapping/company-code-mapping.component'
import { DcFinalFactoryPlantConfigComponent } from './pages/dc-final-factory-plant-config/dc-final-factory-plant-config.component'
import { DcPriorityMaxtrixConfigComponent } from './pages/dc-priority-maxtrix-config/dc-priority-maxtrix-config.component'
import { BusinessPlannerCodeComponent } from './pages/business-planner-code/business-planner-code.component'

const routes: Routes = [
  {
    path: 'PkgConvertMaster',
    component: PkgConvertMasterComponent,
  },
  {
    path: 'ProcessConvertMaster',
    component: ProcessConvertMasterComponent,
  },
  {
    path: 'ProductionAltConfig',
    component: ProductionAltConfigComponent,
  },
  {
    path: 'ProductionLotsizeConfig',
    component: ProductionLotsizeConfigComponent,
  },
  {
    path: 'ProductionLeadtimeConfig',
    component: ProductionLeadtimeConfigComponent,
  },
  {
    path: 'ShipPointConfig',
    component: ShipPointConfigComponent,
  },
  {
    path: 'ProductionVersionConfig',
    component: ProductionVersionConfigComponent,
  },
  {
    path: 'ProductionPlanningYieldConfig',
    component: ProductionPlanningYieldConfigComponent,
  },
  {
    path: 'ProductionCostingYieldConfig',
    component: ProductionCostingYieldConfigComponent,
  },
  {
    path: 'ProductionCycletimeConfig',
    component: ProductionCycletimeConfigComponent,
  },
  {
    path: 'ProductR4OpnPartdescConfig',
    component: ProductR4OpnPartdescConfigComponent,
  },
  {
    path: 'ProductR4MpnPartdescConfig',
    component: ProductR4MpnPartdescConfigComponent,
  },
  {
    path: 'ProductConfig',
    component: ProductConfigComponent,
  },
  {
    path: 'CdbConfig',
    component: CdbConfigComponent,
  },
  {
    path: 'ComponentsConfig',
    component: ComponentsConfigComponent,
  },
  {
    path: 'LeadtimePatternFrontend',
    component: LeadtimePatternFrontendComponent,
  },
  {
    path: 'LeadtimePatternBackend',
    component: LeadtimePatternBackendComponent,
  },
  {
    path: 'YieldPatternFrontend',
    component: YieldPatternFrontendComponent,
  },
  {
    path: 'YieldPatternBackend',
    component: YieldPatternBackendComponent,
  },
  {
    path: 'ProductionVersionPattern',
    component: ProductionVersionPatternComponent,
  },
  {
    path: 'CompanyCodeMapping',
    component: CompanyCodeMappingComponent,
  },
  {
    path: 'DcPriorityMaxtrixConfig',
    component: DcPriorityMaxtrixConfigComponent,
  },
  {
    path: 'DcFinalFactoryPlantConfig',
    component: DcFinalFactoryPlantConfigComponent,
  },
  {
    path: 'BusinessPlannerCodeConfig',
    component: BusinessPlannerCodeComponent,
  },

  { path: '**', redirectTo: '/PageError404' }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FiestaConfigRoutingModule { }
