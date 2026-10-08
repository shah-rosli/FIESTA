import { Component } from '@angular/core'
import { ToastrService } from 'ngx-toastr'
import { SendRequestService } from '../../../service/base/send-request.service'
import { PagePermission, PermissionService } from '../../../service/permission.service'
import { environment } from '../../../../environments/environment'
import { ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'

@Component({
  selector: 'app-sp-validate-dynamic',
  templateUrl: './sp-validate-dynamic.component.html',
  styleUrls: ['./sp-validate-dynamic.component.scss']
})
export class SpValidateDynamicComponent {

  PageTitle: string = "SP Validate Dynamic"
  pagePermission: PagePermission
  dataSource: any
  validateList: string[] = []

  formData = {
    validateSelection: "",
  }

  buttonOptions: any = {
    text: "Execute",
    useSubmitBehavior: true,
    type: "success",
    width: "100%",
  }

  constructor(
    private permission: PermissionService,
    private send: SendRequestService,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.pagePermission = this.permission.getUserPermissions()
    this.getTableName()
  }

  getTableName() {
    const url: string = `${environment.ServiceURL_Main}systemparam/GetDistinctCategory?category=Validate`
    this.send.sendRequest(url, "GET").subscribe(
      response => {
        this.validateList = response.map(response => response.PARAM_CATEGORY)
      }
    )
  }

  onFormSubmit(e) {
    this.dataSource = [] // reset
    const url: string = `${environment.ServiceURL_Main}SPVldDynamicUI?filterParamCategory=${this.formData.validateSelection}`
    this.send.sendRequest(url, "POST", this.formData).subscribe(
      response => {
        this.dataSource = response.status
        console.log(this.dataSource)
      }
    )

    e.preventDefault()
  }

  onRowPrepared(e) {
    if (e.rowType === "data") {
      if (e.data.PARAM_VALUE > 0) {
        e.rowElement.classList.add("invalid-row")
      }
    }
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}
