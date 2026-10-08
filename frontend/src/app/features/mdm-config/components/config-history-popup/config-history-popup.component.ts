import { Component, EventEmitter, Input, Output } from '@angular/core'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { finalize } from 'rxjs'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { environment } from 'src/environments/environment'

@Component({
  selector: 'app-config-history-popup',
  templateUrl: './config-history-popup.component.html',
  styleUrl: './config-history-popup.component.scss'
})
export class ConfigHistoryPopupComponent {
  @Input() columns: Column[]
  @Input() endpoint: string

  visible: boolean
  loading: boolean
  dataSource: any[]

  constructor(private send: SendRequestService) { }

  onHidden() {
    this.visible = false
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }

  open(historyId: string) {
    this.visible = true
    this.loading = true
    this.send.sendRequest(`${environment.ServiceURL_Main}${this.endpoint}/GetHistory/${historyId}`, "GET", "")
      .pipe(finalize(() => this.loading = false))
      .subscribe({
        next: (value) => {
          this.dataSource = value
        }
      })
  }
}