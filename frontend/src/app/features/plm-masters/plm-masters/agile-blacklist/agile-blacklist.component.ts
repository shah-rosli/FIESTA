import { Component } from '@angular/core'
import { ActivatedRoute } from '@angular/router'
import { CustomStore } from 'devextreme-aspnet-data-nojquery'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { environment } from 'src/environments/environment'

@Component({
  selector: 'app-agile-blacklist',
  templateUrl: './agile-blacklist.component.html',
  styleUrl: './agile-blacklist.component.scss'
})
export class AgileBlacklistComponent {

  PageTitle: string = "Agile Blacklist"
  tableName: string = "AGILE_OPN_SUMMARY"
  endpoint: string = "AgileOpnSummaryUI"
  key: string[] | string = "ID"

  dataSource: CustomStore
  columnsConfig: Column[]
  filterValue: any = null

  constructor(
    private send: SendRequestService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.configureDatagrid()
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

  getDataSource() {
    this.route.queryParams.subscribe(params => {
      const entityId = params['ENTITY_ID']
      if (entityId) {
        this.filterValue = ['ENTITY_ID', '=', entityId]
      }
      const url: string = `${environment.ServiceURL_Main}${this.endpoint}`
      setTimeout(() => this.dataSource = this.send.sendRequestVirtual(this.key, url))
    })
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}
