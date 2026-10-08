import { Component } from '@angular/core'
import { environment } from '../../../../../environments/environment'
import { BaseService } from '../../../../service/base/base.service'
import { Router } from '@angular/router'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { ToastrService } from 'ngx-toastr'
import { confirm } from 'devextreme/ui/dialog'
import { ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'


@Component({
  selector: 'app-user-deligation-history',
  templateUrl: './user-deligation-history.component.html',
  styleUrls: ['./user-deligation-history.component.scss']
})
export class UserDeligationHistoryComponent {

  PageTitle: string = this.base.getMessage("Delegation History");
  HistoryDelegationData: any[]

  constructor(public base: BaseService, private router: Router, private send: SendRequestService, private toastr: ToastrService) { }

  ngOnInit() {
    this.getGridData()
  }


  getGridData() {
    this.send.sendRequest(`${environment.ServiceURL_Main}CfgUserDelegation/GetDelegationHistoryFilterByUserId?user_id=` + this.base.getUserInfo("USER_ID"), "GET", "").subscribe(
      data => {
        console.log(data)
        this.HistoryDelegationData = data
      },
      error => {

        this.toastr.error(this.base.getMessage(error.message), this.base.getMessage('Error!'), errorToastOptions)
      }
    )
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}
