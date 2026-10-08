import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core'
import { ColumnConfigItem } from '../grid-config/grid-config.component'
import { ExportingEvent, RowDraggingReorderEvent } from 'devextreme/ui/data_grid'
import { ToastrService } from 'ngx-toastr'
import { DxDataGridComponent } from 'devextreme-angular'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'

@Component({
  selector: 'app-column-config-reorder',
  templateUrl: './column-config-reorder.component.html',
  styleUrls: ['./column-config-reorder.component.scss'],
})
export class ColumnConfigReorderComponent {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @Input() tableConfigID: number
  @Input() dataSource: ColumnConfigItem[]
  @Output() onSave: EventEmitter<void> = new EventEmitter()

  orderingChanged: boolean = false
  originalDataSource: ColumnConfigItem[] = null

  constructor(
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.onReorder = this.onReorder.bind(this)
  }

  onReorder(e: RowDraggingReorderEvent) {
    try {
      if (this.orderingChanged === false) {
        this.originalDataSource = structuredClone(this.dataSource)
      }
      this.orderingChanged = true

      this.dataSource.splice(e.fromIndex, 1)
      this.dataSource.splice(e.toIndex, 0, e.itemData)
    } catch (error) {
      this.toastr.error(error, null, errorToastOptions)
      console.error(error)
    }
  }

  onSaveChanges() {
    const visibleRows = this.dataGrid.instance.getVisibleRows()
    if (!visibleRows) {
      return
    }
    for (const index in visibleRows) {
      const row = visibleRows[index]
      row.data.visibleIndex = index
    }
    this.onSave.emit()
    this.resetToolbar()
  }

  onDiscardChanges() {
    this.dataSource = this.originalDataSource
    this.resetToolbar()
  }

  resetToolbar() {
    this.originalDataSource = null
    this.orderingChanged = false
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}
