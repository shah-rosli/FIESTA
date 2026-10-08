import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core'
import { ColumnConfigItem } from '../grid-config/grid-config.component'
import { EditorPreparingEvent, ExportingEvent, InitNewRowEvent } from 'devextreme/ui/data_grid'
import { DxDataGridComponent } from 'devextreme-angular'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
import { BaseService } from '../../../../service/base/base.service'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'

@Component({
  selector: 'app-column-config',
  templateUrl: './column-config.component.html',
  styleUrls: ['./column-config.component.scss']
})
export class ColumnConfigComponent {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @Input() tableConfigID: number
  @Input() dataSource: ColumnConfigItem[]
  @Output() onSave: EventEmitter<void> = new EventEmitter()
  @Output() onReloadClick: EventEmitter<void> = new EventEmitter()

  columnCfgChanges: any = []
  pagePermission: PagePermission
  booleanDataSource: any

  constructor(
    private base: BaseService,
    private permission: PermissionService
  ) { }

  ngOnInit(): void {
    this.validateFieldIsUnique = this.validateFieldIsUnique.bind(this)
    this.pagePermission = this.permission.getUserPermissions()
    this.booleanDataSource = this.base.getBooleanData()
  }

  updateColumnCfg() {
    this.onSave.emit()
  }

  onColumnCfgInitNewRow(e: InitNewRowEvent) {
    // get a new visible index
    let largestVisibleIndex = 0
    for (const item of this.dataSource) {
      if (item.visibleIndex > largestVisibleIndex) {
        largestVisibleIndex = item.visibleIndex
      }
    }
    if (this.columnCfgChanges) {
      for (const item of this.columnCfgChanges) {
        if (item.data.visibleIndex > largestVisibleIndex) {
          largestVisibleIndex = item.data.visibleIndex
        }
      }
    }
    // update the cell
    e.data.visibleIndex = largestVisibleIndex + 1
    e.data.CFG_SYS_TABLE_CONFIG_ID = this.tableConfigID

    e.data.visible = "true"
    e.data.ACTIVE = "Yes"
  }

  validateFieldIsUnique(options) {
    if (!options.value) {
      console.log("Validating unique field, field is falsy")
      return false
    }
    const fieldName = options.column.name
    const inputtedValue = options.value
    let validationDataSource = structuredClone(this.dataSource)

    // handle changes (type update and type remove)
    // Iterate through the changes array
    for (const change of this.columnCfgChanges) {
      if (change.type === "update") {
        // Find the index of the object to update in validatingDataSource
        const indexToUpdate = validationDataSource.findIndex((item) =>
          item.CFG_SYS_COLUMN_CONFIG_ID === change.key.CFG_SYS_COLUMN_CONFIG_ID
        )

        if (indexToUpdate !== -1) {
          // Update the object with the new data
          validationDataSource[indexToUpdate].dataField = change.data.dataField
        }
      } else if (change.type === "remove") {
        // Find the index of the object to remove in validatingDataSource
        const indexToRemove = validationDataSource.findIndex((item) =>
          item.CFG_SYS_COLUMN_CONFIG_ID === change.key.CFG_SYS_COLUMN_CONFIG_ID
        )

        if (indexToRemove !== -1) {
          // Remove the object from validatingDataSource
          validationDataSource.splice(indexToRemove, 1)
        }
      }
    }

    // row that has CFG_SYS_COLUMN_CONFIG_ID
    const foundItem = validationDataSource.find(item => item[fieldName] === inputtedValue)
    if (foundItem) {
      if (foundItem.CFG_SYS_COLUMN_CONFIG_ID === options.data.CFG_SYS_COLUMN_CONFIG_ID) {
        //
        return true
      }
      else {
        return false
      }
    }
    // new row that has CFG_SYS_COLUMN_CONFIG_ID null
    else {
      for (const item of this.columnCfgChanges) {
        if (item.data[fieldName] === inputtedValue) {
          if (item.data.__KEY__ === options.data.__KEY__) {
            return true
          }
          else {
            return false
          }
        }
      }
    }
    // no match anything at all, assume no duplicate
    return true
  }

  onMarkAllDeleteClick() {
    this.dataGrid.instance.getDataSource().items().forEach((column: ColumnConfigItem, index: number) => {
      this.dataGrid.instance.deleteRow(index)
    })
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}