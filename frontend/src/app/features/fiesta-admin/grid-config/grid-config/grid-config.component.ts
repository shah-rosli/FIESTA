import { Component, ViewChild } from '@angular/core'
import { ToastrService } from 'ngx-toastr'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
import { environment } from '../../../../../environments/environment'
import { TableConfigComponent } from '../table-config/table-config.component'
import { ColumnConfigReorderComponent } from '../column-config-reorder/column-config-reorder.component'
import { ColumnConfigComponent } from '../column-config/column-config.component'
import { ValueChangedEvent } from 'devextreme/ui/switch'
import { debounceTime, Subject } from 'rxjs'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
export interface ColumnConfigItem {
  CFG_SYS_COLUMN_CONFIG_ID: number
  CFG_SYS_TABLE_CONFIG_ID: number
  ACTIVE: string
  _fixed: string
  fixedPosition: null | string
  dataField: string
  dataType: string
  caption: string
  visible: string
  visibleIndex: number
  format: null | string
  sortIndex: null | number
  sortOrder: null | string
  CFG_SYS_TABLE_CONFIG: any
}

@Component({
  selector: 'app-grid-config',
  templateUrl: './grid-config.component.html',
  styleUrls: ['./grid-config.component.scss']
})
export class GridConfigComponent {

  @ViewChild(TableConfigComponent) tableConfig: TableConfigComponent
  @ViewChild(ColumnConfigComponent, { static: false }) columnConfig: ColumnConfigComponent
  @ViewChild(ColumnConfigReorderComponent, { static: false }) columnConfigReorder: ColumnConfigReorderComponent

  PageTitle: string = "Grid Configuration"
  pageIsLoading: boolean = false
  pagePermission: PagePermission

  columnConfigDataSource: ColumnConfigItem[]
  columnConfigReorderDataSource: ColumnConfigItem[]

  selectedTableConfigID: number
  rowReorderingMode: boolean = false

  resizeSubject: Subject<void> = new Subject<void>();

  constructor(
    private send: SendRequestService,
    private toastr: ToastrService,
    private permission: PermissionService) {
  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()

    this.resizeSubject
      .pipe(debounceTime(50))
      .subscribe(() => this.updateAllDimentions())
  }

  onResize() {
    this.resizeSubject.next()
  }

  onTableCfgSelectedRowChange(tableConfigID: number) {
    this.selectedTableConfigID = tableConfigID
    this.loadColumnCfgDataSource()
  }

  loadColumnCfgDataSource() {
    const URL = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableID?id=${this.selectedTableConfigID}`
    this.send.sendRequest(URL, "GET").subscribe(
      data => {
        this.columnConfigDataSource = data
        this.columnConfigReorderDataSource = data
      },
      _ => {
        this.columnConfigDataSource = null
        this.columnConfigReorderDataSource = null
      }
    )
  }

  toggleRowReorder(e: ValueChangedEvent) {
    if (e.value === true) {
      if (this.columnConfig.dataGrid.instance.hasEditData()) {
        e.component.instance().option("value", e.previousValue)
        this.toastr.info("Please save or discard unsaved changes!")
        return
      }
    } else {
      if (this.columnConfigReorder.orderingChanged) {
        e.component.instance().option("value", e.previousValue)
        this.toastr.info("Please save or discard unsaved changes!")
        return
      }
    }
    this.rowReorderingMode = e.value
  }

  saveDataSource(dataSourceToSave) {
    const findDuplicateObjects = (arr, property) => {
      const seen = new Set()
      const duplicates = []
      for (const item of arr) {
        const value = item[property]
        if (seen.has(value)) {
          duplicates.push(item)
        } else {
          seen.add(value)
        }
      }
      return duplicates
    }
    const displayResponseMessage = (response) => {
      if (response.InfoMsg) {
        this.toastr.info(response.InfoMsg, "Info")
      } else if (response.SuccessMsg) {
        this.toastr.success(response.SuccessMsg, 'Success')
      } else if (response.WarningMsg) {
        this.toastr.warning(response.WarningMsg, "Warning")
      } else if (response.ErrorMsg) {
        this.toastr.warning(response.ErrorMsg, "Error")
      }
    }
    const duplicates = findDuplicateObjects(dataSourceToSave, 'dataField')
    if (duplicates.length > 0) {
      this.toastr.error("Found duplicate in column 'dataField', abort update, duplicate values are: " + JSON.stringify(duplicates), "Error!", errorToastOptions)
    }

    const URL = `${environment.ServiceURL_Main}CfgSysTableConfig/UpdateTableColumns?id=${this.selectedTableConfigID}`
    this.send.sendRequest(URL, "POST", dataSourceToSave)
      .subscribe(response => {
        displayResponseMessage(response)
        this.loadColumnCfgDataSource()
      })
  }

  onColumnConfigSave() {
    this.saveDataSource(this.columnConfigDataSource)
  }

  onReorderSave() {
    this.saveDataSource(this.columnConfigReorderDataSource)
  }

  updateAllDimentions() {
    this.tableConfig?.dataGrid.instance.updateDimensions()
    this.columnConfig?.dataGrid.instance.updateDimensions()
    this.columnConfigReorder?.dataGrid.instance.updateDimensions()
  }

  onColumnConfigReloadClick() {
    if (this.columnConfig.dataGrid.instance.hasEditData()) {
      this.toastr.info("Please save or discard unsaved changes!")
      return
    }
    this.loadColumnCfgDataSource()
  }
}
