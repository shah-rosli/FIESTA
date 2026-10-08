import { Component } from '@angular/core'
import { CustomStore } from 'devextreme-aspnet-data-nojquery'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { environment } from 'src/environments/environment'

@Component({
  selector: 'app-plm-production-golden-opn',
  templateUrl: './plm-production-golden-opn.component.html',
  styleUrl: './plm-production-golden-opn.component.scss'
})
export class PlmProductionGoldenOpnComponent {

  PageTitle: string = "PLM Production"
  endpoint: string = "PlmProductionGoldenOpnUI"
  key: string[] | string = "recordKey"

  dataSource: CustomStore
  columnsConfig: Column[]
  blacklistedUrl = `${environment.postLogoutRedirectUri}PlmBlacklistedProduction?opn=`
  isViewFullView: boolean = false

  constructor(private send: SendRequestService) { }

  ngOnInit(): void {
    this.configureDatagrid()
  }

  configureDatagrid() {
    let tableName: "PLM_PRODUCTION" | "PLM_PRODUCTION_BASIC"
    if (this.isViewFullView) {
      tableName = "PLM_PRODUCTION"
    } else {
      tableName = "PLM_PRODUCTION_BASIC"
    }
    const url: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=${tableName}`
    this.send.sendRequest(url, "GET", "").subscribe(
      data => {
        this.columnsConfig = data
        this.columnsConfigOverride()
        this.getDataSource()
      }
    )
  }

  getDataSource() {
    const basic: number = this.isViewFullView ? 0 : 1
    const url: string = `${environment.ServiceURL_Main}${this.endpoint}?basic=${basic}`
    this.dataSource = this.send.sendRequestVirtual(this.key, url)
  }

  columnsConfigOverride() {
    for (const column of this.columnsConfig) {
      if (column.dataField === 'recordKey') {
        column.fixed = true
      }
      if (column.dataField === 'opn') {
        column.fixed = true
        column.minWidth = 120
        column.cellTemplate = "opnCellTemplate"
      }
    }
  }

  encodeOPN(opn) {
    return encodeURIComponent(opn)
  }

  onViewSwitched(e) {
    this.isViewFullView = e.value
    this.configureDatagrid()
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}

