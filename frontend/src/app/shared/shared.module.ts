//Core import
import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { FormsModule } from '@angular/forms'
import { DxButtonModule, DxDataGridModule, DxDateBoxModule, DxDropDownBoxModule, DxFormModule, DxGalleryModule, DxLoadIndicatorModule, DxSelectBoxModule, DxTagBoxModule, DxTextBoxModule, DxLookupModule, DxTextAreaModule, DxSwitchModule, DxPopoverModule, DxValidationGroupModule, DxValidatorModule } from 'devextreme-angular'

// shared component
import { PageLoaderComponent } from './components/page-loader/page-loader.component'
import { PageTitleComponent } from "./components/page-title/page-title.component"
import { FilterCriteriaComponent } from './components/filter-criteria/filter-criteria.component'
import { NgbDropdownModule, NgbNavModule } from '@ng-bootstrap/ng-bootstrap'
import { NoViewPermissionComponent } from './components/no-view-permission/no-view-permission.component'
import { BasicDatagridComponent } from './components/basic-datagrid/basic-datagrid.component'

@NgModule({
  declarations: [
    PageTitleComponent,
    PageLoaderComponent,
    FilterCriteriaComponent,
    NoViewPermissionComponent,
    BasicDatagridComponent
  ],
  imports: [
    DxLoadIndicatorModule,
    DxButtonModule,
    DxTagBoxModule,
    DxLookupModule,
    DxSwitchModule,
    DxSelectBoxModule,
    DxTextAreaModule,
    DxDataGridModule,
    DxValidatorModule,
    CommonModule,
  ],
  exports: [
    // DevExtreme Modules
    DxDataGridModule,
    DxDateBoxModule,
    DxLoadIndicatorModule,
    DxSelectBoxModule,
    DxGalleryModule,
    DxTextBoxModule,
    DxFormModule,
    DxDropDownBoxModule,
    DxButtonModule,
    DxSwitchModule,
    DxPopoverModule,
    // Ng Bootstrap
    NgbDropdownModule,
    NgbNavModule,
    // Components
    PageTitleComponent,
    PageLoaderComponent,
    FilterCriteriaComponent,
    NoViewPermissionComponent,
    BasicDatagridComponent,
    // Angular Modules
    FormsModule,
  ]
})
export class SharedModule { }
