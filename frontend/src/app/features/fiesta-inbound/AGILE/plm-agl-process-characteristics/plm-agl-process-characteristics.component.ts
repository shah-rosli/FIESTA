import { Component } from '@angular/core'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { environment } from '../../../../../environments/environment'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import DataSource from 'devextreme/data/data_source'

@Component({
  selector: 'app-plm-agl-process-characteristics',
  templateUrl: './plm-agl-process-characteristics.component.html',
  styleUrl: './plm-agl-process-characteristics.component.scss'
})
export class PlmAglProcessCharacteristicsComponent {

  PageTitle: string = "Process Characteristics"
  tableName: string = "PLM_AGL_PROCESS_CHARACTERISTICS"
  endpoint: string = "PlmAglProcessCharacteristicsUI"
  key: string[] | string = "referenceKey"

  dataSource: DataSource
  columnsConfig: Column[]
  showActiveRecords: boolean = true

  constructor(private send: SendRequestService) { }

  ngOnInit(): void {
    this.configureDatagrid()
  }

  getDataSource() {
    const url: string = `${environment.ServiceURL_Main}${this.endpoint}`
    this.dataSource = new DataSource({
      store: this.send.sendRequestVirtual(this.key, url)
    })
    if (this.showActiveRecords) {
      this.dataSource.filter(["deleteFlag", "=", "N"])
    }
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
}
