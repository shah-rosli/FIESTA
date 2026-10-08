import { Component } from '@angular/core'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { environment } from '../../../../../environments/environment'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import DataSource from 'devextreme/data/data_source'

@Component({
  selector: 'app-plm-agl-production',
  templateUrl: './plm-agl-production.component.html',
  styleUrls: ['./plm-agl-production.component.scss']
})
export class PlmAglProductionComponent {

  PageTitle: string = "Production"
  tableName: string = "PLM_AGL_PRODUCTION"
  endpoint: string = "PlmAglProductionUI"
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
