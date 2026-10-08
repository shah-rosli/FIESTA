import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { FiestaAdminRoutingModule } from './fiesta-admin-routing.module'
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
import { TableConfigComponent } from './grid-config/table-config/table-config.component'
import { ColumnConfigComponent } from './grid-config/column-config/column-config.component'
import { ColumnConfigReorderComponent } from './grid-config/column-config-reorder/column-config-reorder.component'
import { SharedModule } from 'src/app/shared/shared.module'
import { DxCheckBoxModule, DxPopupModule, DxScrollViewModule, DxSplitterModule, DxTagBoxModule, DxTextAreaModule, DxTreeListModule } from 'devextreme-angular';
import { TranToOutStatusComponent } from './tran-to-out-status/tran-to-out-status.component'


@NgModule({
  declarations: [
    LogDataRequestComponent,
    SpExecutorComponent,
    JobSummaryComponent,
    GridConfigComponent,
    TableConfigComponent,
    ColumnConfigComponent,
    ColumnConfigReorderComponent,
    SPUpdateComponent,
    SpValidateDynamicComponent,
    SystemParamComponent,
    SystemLanguageComponent,
    SystemMenuComponent,
    UserComponent,
    UserGroupComponent,
    CompanyMasterComponent,
    UserAccessComponent,
    ConfigUserDeligationComponent,
    TranToOutStatusComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    DxTagBoxModule,
    DxPopupModule,
    DxTreeListModule,
    DxCheckBoxModule,
    DxTextAreaModule,
    DxScrollViewModule,
    DxSplitterModule,
    FiestaAdminRoutingModule
  ]
})
export class FiestaAdminModule { }
