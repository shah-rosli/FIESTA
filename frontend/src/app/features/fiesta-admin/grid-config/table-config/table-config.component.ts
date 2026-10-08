import { Component, EventEmitter, Output, ViewChild } from '@angular/core'
import { DxDataGridComponent } from 'devextreme-angular'
import CustomStore from 'devextreme/data/custom_store'
import DataSource from 'devextreme/data/data_source'
import { ToastrService } from 'ngx-toastr'
import { BaseService } from '../../../../service/base/base.service'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
import { environment } from '../../../../../environments/environment'
import { ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'

@Component({
  selector: 'app-table-config',
  templateUrl: './table-config.component.html',
  styleUrls: ['./table-config.component.scss']
})
export class TableConfigComponent {
  @Output() onTableCfgSelectedRowChange: EventEmitter<number> = new EventEmitter()
  @ViewChild("tableCfgDataGrid") dataGrid: DxDataGridComponent

  tableCfgDataSource: DataSource
  booleanDataSource: any
  pagePermission: PagePermission

  constructor(private base: BaseService,
    private send: SendRequestService,
    private toastr: ToastrService,
    private permission: PermissionService
  ) { }

  ngOnInit(): void {
    this.setTableConfigDataSource()
    this.booleanDataSource = this.base.getBooleanData()
    this.pagePermission = this.permission.getUserPermissions()
  }

  setTableConfigDataSource() {
    let URL: string = `${environment.ServiceURL_Main}CfgSysTableConfig`
    this.tableCfgDataSource = new DataSource({
      store: new CustomStore({
        key: "CFG_SYS_TABLE_CONFIG_ID",
        loadMode: "raw",
        load: () => this.send.sendRequestDevExtreme(URL + "/GetAll").then(responsebody => responsebody.data),
        insert: (values) => this.send.sendRequestReturnLastInserted(URL, "POST", JSON.stringify(values)),
        update: (key, values) => this.send.sendRequestReturnLastInserted(URL, "PUT", JSON.stringify(values)),
      }),
    })
  }

  selectFirstRow(e) {
    const selectingIndex = 0
    e.component.selectRowsByIndexes(selectingIndex)
  }

  onSelectionChanged(e: any) {
    const tableConfigID = e.selectedRowsData[0].CFG_SYS_TABLE_CONFIG_ID
    if (!tableConfigID) {
      this.toastr.error("Selected row has Invalid ID", "Error!", errorToastOptions)
      return
    }
    this.onTableCfgSelectedRowChange.emit(tableConfigID)
  }

  postGridRow(e, action) {
    if (action == 'edit') { e.newData = { ...e.oldData, ...e.newData } }
  }

  async postedGridRow(e, action) {
    if (action == 'create') { this.toastr.success('Record created successfully', 'Success!') }
    if (action == 'edit') { this.toastr.success('Record modified successfully', 'Success!') }
    if (action == 'delete') { this.toastr.success('Record deleted successfully', 'Success!') }
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}
