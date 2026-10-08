import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { CompanyMasterComponent } from './company-master/company-master.component'
import { ConfigUserDeligationComponent } from './config-user-deligation/config-user-deligation.component'
import { GridConfigComponent } from './grid-config/grid-config/grid-config.component'
import { JobSummaryComponent } from './job-summary/job-summary.component'
import { LogDataRequestComponent } from './log-data-request/log-data-request.component'
import { SpExecutorComponent } from './sp-executor/sp-executor.component'
import { SPUpdateComponent } from './sp-update/sp-update.component'
import { SpValidateDynamicComponent } from './sp-validate-dynamic/sp-validate-dynamic.component'
import { SystemLanguageComponent } from './system-language/system-language.component'
import { SystemMenuComponent } from './system-menu/system-menu.component'
import { SystemParamComponent } from './system-param/system-param.component'
import { UserAccessComponent } from './user-access/user-access.component'
import { UserGroupComponent } from './user-group/user-group.component'
import { UserComponent } from './user/user.component'
import { TranToOutStatusComponent } from './tran-to-out-status/tran-to-out-status.component'

const routes: Routes = [
  {
    path: 'Log',
    component: LogDataRequestComponent,
  },
  {
    path: 'SpExecutor',
    component: SpExecutorComponent,
  },
  {
    path: 'JobSummary',
    component: JobSummaryComponent,
  },
  {
    path: 'GridConfig',
    component: GridConfigComponent,
  },
  {
    path: 'SPUpdate',
    component: SPUpdateComponent,
  },
  {
    path: 'SpValidateDynamic',
    component: SpValidateDynamicComponent,
  },
  {
    path: 'Config-SystemParam',
    component: SystemParamComponent,
  },
  {
    path: 'Config-SystemLanguage',
    component: SystemLanguageComponent,
  },
  {
    path: 'Config-Menu',
    component: SystemMenuComponent,
  },
  {
    path: 'Config-User',
    component: UserComponent,
  },
  {
    path: 'Config-UserGroup',
    component: UserGroupComponent,
  },
  {
    path: 'Company-Master',
    component: CompanyMasterComponent,
  },
  {
    path: 'User-Access',
    component: UserAccessComponent,
  },
  {
    path: 'config-user-deligation',
    component: ConfigUserDeligationComponent,
  },
  {
    path: 'tran-to-out_status',
    component: TranToOutStatusComponent,
  },
  { path: '**', redirectTo: '/PageError404' }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FiestaAdminRoutingModule { }
