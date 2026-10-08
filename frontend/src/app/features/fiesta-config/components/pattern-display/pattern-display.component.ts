import { Component, Input } from '@angular/core'
import { CustomStore } from 'devextreme-aspnet-data-nojquery'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { environment } from 'src/environments/environment'

@Component({
  selector: 'app-pattern-display',
  templateUrl: './pattern-display.component.html',
  styleUrl: './pattern-display.component.scss'
})
export class PatternDisplayComponent {

  @Input() PageTitle: string
  @Input() tableName: string
  @Input() endpoint: string
  @Input() key: string[] | string
  @Input() image: string

  dataSource: CustomStore
  columnsConfig: Column[]

  constructor(private send: SendRequestService) { }

  ngOnInit(): void {
    this.configureDatagrid()
  }

  getDataSource() {
    const url: string = `${environment.ServiceURL_Main}${this.endpoint}`
    this.dataSource = this.send.sendRequestVirtual(this.key, url)
  }

  configureDatagrid() {
    const url: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=${this.tableName}`
    this.send.sendRequest(url, "GET", "").subscribe(
      data => {
        this.columnsConfig = data
        this.getDataSource()
      }
    )
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }

  handleRowPrepared(e: any): void {
    if (e.rowType !== 'data') return;

    const deleteFlag = e.data?.deleteFlag;

    if (deleteFlag === 'Y') {
      e.rowElement.style.color = 'red';
    }
  }
}
