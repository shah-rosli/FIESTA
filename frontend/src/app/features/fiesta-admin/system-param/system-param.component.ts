import { Component } from '@angular/core'
import { environment } from '../../../../environments/environment'
import { BaseService } from '../../../service/base/base.service'
import { SendRequestService } from '../../../service/base/send-request.service'
import CustomStore from 'devextreme/data/custom_store'
import { ToastrService } from 'ngx-toastr'
import { PagePermission, PermissionService } from '../../../service/permission.service'
import DataSource from 'devextreme/data/data_source'
import { ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
@Component({
  selector: 'app-system-param',
  templateUrl: './system-param.component.html',
  styleUrls: ['./system-param.component.scss'],
  providers: [BaseService]
})
export class SystemParamComponent {
  PageTitle: string = 'System Parameter Configuration'
  dataSource: CustomStore
  pageIsLoading: boolean = false
  pagePermission: PagePermission

  HistoryData: any
  historyLoadingIndicator: boolean = false
  historyPopupVisible: boolean = false

  constructor(
    public base: BaseService,
    private send: SendRequestService,
    private toastr: ToastrService,
    private permission: PermissionService) {
    this.historyIconClick = this.historyIconClick.bind(this)
    this.loadDataSource()
  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }

  loadDataSource() {
    let URL: string = `${environment.ServiceURL_Main}systemparam`
    this.dataSource = new CustomStore({
      key: "CFG_SYSTEM_PARAM_ID",
      loadMode: "raw",
      load: () => this.send.sendRequestDevExtreme(URL),
      insert: (values) => this.send.sendRequestReturnLastInserted(URL, "POST", JSON.stringify(values)),
      update: (key, values) => this.send.sendRequestReturnLastInserted(URL, "PUT", JSON.stringify(values)),
      remove: (key) => this.send.sendRequestDevExtreme(URL + "/" + key, "DELETE", { key: key })
    })
  }

  postGridRow(e, action) {
    if (action == 'edit') { e.newData = { ...e.oldData, ...e.newData } }
  }

  postedGridRow(e, action) {
    if (action == 'create') {
      this.toastr.success('Record created successfully', 'Success!')
      this.setSessionParam()
    }
    if (action == 'edit') {
      this.toastr.success('Record modified successfully', 'Success!')
      this.setSessionParam()
    }
    if (action == 'delete') {
      this.toastr.success('Record deleted successfully', 'Success!')
      this.setSessionParam()
    }
  }

  setSessionParam() {
    let ParamList_Param: Object = {}
    this.send.sendRequest(`${environment.ServiceURL_Main}systemparam`, "GET", ParamList_Param).subscribe(
      data => {
        this.base.setParamData(data)
      }
    )
  }

  historyIconClick(e) {
    const ID = e.row.data.CFG_SYSTEM_PARAM_ID
    if (!ID) {
      this.toastr.error("Invalid/No ID", null, errorToastOptions)
      return
    }
    this.historyPopupVisible = true
    this.historyLoadingIndicator = true
    this.send.sendRequest(`${environment.ServiceURL_Main}CfgSysParam/GetHistory/${ID}`, "GET", "").subscribe(
      data => {
        this.HistoryData = data
        this.historyLoadingIndicator = false
      },
      () => {
        this.historyLoadingIndicator = false
      })
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}
