import { Component } from '@angular/core'
import { ToastrService } from 'ngx-toastr'
import { SendRequestService } from '../../../service/base/send-request.service'
import { PagePermission, PermissionService } from '../../../service/permission.service'
import { environment } from '../../../../environments/environment'

@Component({
  selector: 'app-sp-update',
  templateUrl: './sp-update.component.html',
  styleUrls: ['./sp-update.component.scss']
})
export class SPUpdateComponent {

  PageTitle: string = "SP Update PN UpdateTime"
  pagePermission: PagePermission
  formData = {
    partNumber: "",
    partType: "",
    tableName: "",
  }
  apiResponse: any

  buttonOptions: any = {
    text: "Execute",
    useSubmitBehavior: true,
    type: "success",
    width: "100%",
  }

  partTypeEditorOptions = { items: ["OPN", "PN"], searchEnabled: true, value: '' };
  tableNameEditorOptions = {
    items: [
      "ALL",
      "PRODUCT",
      "PRODUCT_PLANT",
      "PRODUCT_SALES",
      "PRODUCT_PIR",
      "PRODUCTION_BOM",
      "PRODUCTION_ROUTING",
      "PRODUCTION_ROUTING_S4",
      "PRODUCTION_VERSION",
      "PRODUCTION_ALTERNATIVES_MIX_RATIOS",
    ],
    searchEnabled: true,
    value: ''
  };

  constructor(
    private permission: PermissionService,
    private send: SendRequestService,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.pagePermission = this.permission.getUserPermissions()
  }

  onFormSubmit(e) {
    this.apiResponse = null
    const params = new URLSearchParams()
    for (const key in this.formData) {
      if (this.formData.hasOwnProperty(key)) {
        params.append(key, this.formData[key])
      }
    }
    const url: string = `${environment.ServiceURL_Main}SPUpdateTime?${params.toString()}`
    this.send.sendRequest(url, "POST", this.formData).subscribe(
      response => {
        this.apiResponse = response
      }
    )

    e.preventDefault()
  }

}
