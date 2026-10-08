import { Component, Input, ViewChild } from '@angular/core'
import { CustomStore } from 'devextreme-aspnet-data-nojquery'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { DxDataGridComponent } from 'devextreme-angular'
import { CriteriaRetrievedEvent } from '../../../../shared/components/filter-criteria/filter-criteria.component'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { environment } from 'src/environments/environment'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'

@Component({
  selector: 'app-fiesta-master',
  templateUrl: './fiesta-master.component.html',
  styleUrls: ['./fiesta-master.component.scss']
})
export class FiestaMasterComponent {

  @Input() PageTitle: string
  @Input() tableName: string
  @Input() endpoint: string
  @Input() criteriaFieldsDropdown = [
    { "dataField": "opn", "caption": "Orderable Part Number" },
    { "dataField": "partNumber", "caption": "Part Number" }
  ]

  dataSource: CustomStore
  columnsConfig: Column[]

  dataGridFilterExp: any[] = null
  showCriteria: boolean = true
  showDataGrid: boolean = false

  constructor(
    private send: SendRequestService,
  ) { }

  ngOnInit(): void {
    this.configureDatagrid()
  }

  configureDatagrid() {
    const upperUrl: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=${this.tableName}`
    this.send.sendRequest(upperUrl, "GET", "").subscribe(
      data => {
        this.columnsConfig = data
        this.getDataSource()
      }
    )
  }

  getDataSource() {
    const upperUrl: string = `${environment.ServiceURL_Main}${this.endpoint}`
    this.dataSource = this.send.sendRequestVirtual('recordKey', upperUrl)
  }

  onCriteriaRetrieved(e: CriteriaRetrievedEvent) {
    this.showDataGrid = true
    this.showCriteria = false
    this.dataGridFilterExp = e.filterExpression
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}

