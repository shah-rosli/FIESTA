import { Component, ViewChild } from '@angular/core'
import { environment } from '../../../../environments/environment'
import { BaseService } from '../../../service/base/base.service'
import { SendRequestService } from '../../../service/base/send-request.service'
import CustomStore from 'devextreme/data/custom_store'
import { ToastrService } from 'ngx-toastr'
import { PagePermission, PermissionService } from '../../../service/permission.service'
import DataSource from 'devextreme/data/data_source'
import { ExportingEvent, InitNewRowEvent } from 'devextreme/ui/data_grid'
import { DxDataGridComponent } from 'devextreme-angular/ui/data-grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'

@Component({
  selector: 'app-system-menu',
  templateUrl: './system-menu.component.html',
  styleUrls: ['./system-menu.component.scss'],
  providers: [BaseService]
})
export class SystemMenuComponent {
  @ViewChild("dataGrid") dataGrid: DxDataGridComponent

  PageTitle: string = "Menu Configuration"
  dataSource: CustomStore
  booleanDataSource: any[]
  defaultSaOpertions: any[]
  ParentIdDataSource: any
  pagePermission: PagePermission
  pageIsLoading: boolean = false
  editModeSwitch: boolean
  editModeStorageKey: string = "SYSTEM_MENU_EDIT_MODE"

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
    this.booleanDataSource = this.base.getBooleanData()
  }

  ngOnInit() {
    this.SaOpertions()
    this.getParentId()
    this.pagePermission = this.permission.getUserPermissions()
    this.editModeSwitch = localStorage.getItem(this.editModeStorageKey) ? true : false
  }

  loadDataSource() {
    let URL: string = `${environment.ServiceURL_Main}CfgSystemMenu`
    this.dataSource = new CustomStore({
      key: "CFG_SYSTEM_MENU_ID",
      loadMode: "raw",
      load: () => this.send.sendRequestDevExtreme(URL + "/GetAllSystemMenuDetailList"),
      insert: (values) => this.send.sendRequestReturnLastInserted(URL, "POST", JSON.stringify(values)),
      update: (key, values) => this.send.sendRequestReturnLastInserted(URL, "PUT", JSON.stringify(values)),
      remove: (key) => this.send.sendRequestDevExtreme(URL + "/" + key, "DELETE", { key: key })
    })
  }

  getParentId() {
    let parent = [
      {
        "Value": "No Parent",
        "Key": 0
      }
    ]
    this.send.sendRequest(`${environment.ServiceURL_Main}CfgSystemMenu/GetAllSystemMenuDetailList`, "GET", "").subscribe(
      data => {
        data.forEach((item) => {
          parent.push({
            "Value": item.MENU_NAME,
            "Key": item.CFG_SYSTEM_MENU_ID
          })
        })
        this.ParentIdDataSource = parent
      }
    )
  }

  SaOpertions() {
    this.defaultSaOpertions = [{
      OperaionValue: 1,
      OperationsName: 'View'
    }, {
      OperaionValue: 2,
      OperationsName: 'Create'
    },
    {
      OperaionValue: 3,
      OperationsName: 'Update'
    },
    {
      OperaionValue: 4,
      OperationsName: 'Delete'
    }]
  }

  onTagBoxValueChanged(e: any, cell: any): void {
    console.log(JSON.stringify(e.value))
    cell.setValue(e.value)
  }

  postGridRow(e, action) {
    if (action == 'edit') { e.newData = { ...e.oldData, ...e.newData } }
  }

  async postedGridRow(e, action) {
    this.pageIsLoading = true
    await this.base.getSideMenu()//get updated menu list
    this.pageIsLoading = false

    this.getParentId()

    if (action == 'create') { this.toastr.success('Record created successfully', 'Success!') }
    if (action == 'edit') { this.toastr.success('Record modified successfully', 'Success!') }
    if (action == 'delete') { this.toastr.success('Record deleted successfully', 'Success!') }
  }

  historyIconClick(e) {
    const ID = e.row.data.CFG_SYSTEM_MENU_ID
    if (!ID) {
      this.toastr.error("Invalid/No ID", null, errorToastOptions)
      return
    }
    this.historyPopupVisible = true
    this.historyLoadingIndicator = true
    this.send.sendRequest(`${environment.ServiceURL_Main}CfgSystemMenu/GetHistory/${ID}`, "GET", "").subscribe(
      data => {
        this.HistoryData = data
        this.historyLoadingIndicator = false
      },
      () => {
        this.historyLoadingIndicator = false
      })
  }

  menuParentDisplayExpr(item) {
    if (!item) {
      return
    }
    return `${item.Key} - ${item.Value}`
  }

  onInitNewRow(e: InitNewRowEvent) {
    e.data.ACTIVE = "Yes"
    e.data.saOperationMap = ["View"]
  }

  onStateResetClick() {
    this.dataGrid.instance.state(null)
    this.editModeSwitch = false
    this.onEditingModeChanged()
  }

  onEditingModeChanged() {
    if (this.editModeSwitch) {
      localStorage.setItem(this.editModeStorageKey, JSON.stringify(this.editModeSwitch))
    } else {
      localStorage.removeItem(this.editModeStorageKey)
    }
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}
