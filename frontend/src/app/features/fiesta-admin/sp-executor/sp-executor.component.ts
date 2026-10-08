import { Component, ViewChild } from '@angular/core'
import { SendRequestService } from '../../../service/base/send-request.service'
import { ToastrService } from 'ngx-toastr'
import { environment } from '../../../../environments/environment'
import { DxDataGridComponent } from 'devextreme-angular'
import { BaseService } from '../../../service/base/base.service'
import { Router } from '@angular/router'

@Component({
  selector: 'app-sp-executor',
  templateUrl: './sp-executor.component.html',
  styleUrls: ['./sp-executor.component.scss']
})
export class SpExecutorComponent {

  @ViewChild("outDataDataGrid") outDataDataGrid: DxDataGridComponent

  PageTitle: string = "SP Executor"
  PermissionForView: boolean
  pageIsLoading: boolean
  parametersFormData: SpParameters
  spNameDataSource: object[]
  spTableNameDataSource: object[]
  apiResponse: SPExecutorResponse
  autoResizeEnabled: boolean = false
  textAreaHeight: number = 300

  executeButtonOptions: any = {
    text: "Execute",
    useSubmitBehavior: true,
    type: "success",
    width: "100%",
  }

  constructor(
    private base: BaseService,
    private router: Router,
    private send: SendRequestService,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.initUserPermission()
    this.initDataSources()
    this.parametersFormData = {
      "SPNAME": null,
      "PAGE_NO": null,
      "PAGE_SIZE": null,
      "DATEUPDATE": this.left(new Date().toISOString(), 19),
      "TABLEPATH": null,
      "TABLENAME": null,
    }
    this.apiResponse = {
      TOTAL_PAGE: null,
      MAXDATEUPDATE: null,
      OUT_DATA_RAW: null,
      OUT_DATA_GRID: null,
    }
  }

  initUserPermission() {
    this.PermissionForView = false
    let UserPermissions = this.base.getUserAccessPermission(this.router.url)
    UserPermissions.forEach((permission) => {
      if (permission.access_right === 'View') {
        this.PermissionForView = true
      }
    })
  }

  initDataSources() {
    this.spNameDataSource = [
      { name: "SP_TEST_DATA" },
      { name: "SP_GET_FIESTA_DELTA_DATA" },
    ]
    const url: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetSPTableName`
    this.send.sendRequest(url, "GET", "").subscribe(
      response => {
        this.spTableNameDataSource = response
      }
    )
  }

  left(str: string, length: number): string {
    return str.substring(0, length)
  }

  onFormSubmit(e) {
    this.pageIsLoading = true
    const url: string = `${environment.ServiceURL_Main}SPExecutor`
    this.send.sendRequest(url, "GET", this.parametersFormData).subscribe(
      response => {
        this.apiResponse = response
        this.pageIsLoading = false
        this.toastr.success('Search Success', 'Success!')
      },
      error => {
        this.pageIsLoading = false
      }
    )

    e.preventDefault()
  }

  onAutoResizeChanged(e) {
    this.textAreaHeight = e.value ? undefined : 300
  }
}

interface SpParameters {
  SPNAME: string
  PAGE_NO: string
  PAGE_SIZE: string
  DATEUPDATE: string
  TABLEPATH: string
  TABLENAME: string
}

interface SPExecutorResponse {
  TOTAL_PAGE: number,
  MAXDATEUPDATE: string,
  OUT_DATA_RAW: string,
  OUT_DATA_GRID: Object[],
}
