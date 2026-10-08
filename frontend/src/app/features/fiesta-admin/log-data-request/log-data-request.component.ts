import { Component } from '@angular/core'
import { environment } from '../../../../environments/environment'
import { SendRequestService } from '../../../service/base/send-request.service'
import { CustomStore } from 'devextreme-aspnet-data-nojquery'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { ActivatedRoute } from '@angular/router'
import { KeyValue } from '@angular/common'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'

@Component({
  selector: 'app-log-data-request',
  templateUrl: './log-data-request.component.html',
  styleUrls: ['./log-data-request.component.scss']
})
export class LogDataRequestComponent {
  PageTitle: string = "Log"
  dataSource: CustomStore
  columnsConfig: Column[]
  popupVisible: boolean
  popupData: KeyValue<string, string>[]

  constructor(
    private send: SendRequestService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.configureDatagrid()
    this.getDataSource()
  }

  getDataSource() {
    const url: string = `${environment.ServiceURL_Main}LogDataRequest/GetAll`
    this.dataSource = this.send.sendRequestVirtual('ID', url)
  }

  configureDatagrid() {
    const url: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=LOG_DATA_REQUEST`
    this.send.sendRequest(url, "GET", "").subscribe(
      data => {
        data.forEach((column) => {
          if (column.dataField === 'PAYLOAD') column.width = '350px'
          if (column.dataField === 'MESSAGE') column.width = '350px'
          if (column.dataField === 'START_TIME') column.width = '130px'
          if (column.dataField === 'END_TIME') column.width = '130px'
        })
        data.push({
          cellTemplate: 'cellTemplate',
          fixed: true,
          width: '40px'
        })
        this.columnsConfig = data.sort((a, b) => a.visibleIndex - b.visibleIndex)
      }
    )
  }

  onRowClickView(row) {
    if (!row) {
      return
    }
    const popupData = []
    for (const column of this.columnsConfig) {
      popupData.push({
        key: column.dataField,
        value: row[column.dataField]
      })
    }
    this.popupData = popupData
    this.popupVisible = true
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}
