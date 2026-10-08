import { Component, Input, ViewChild } from '@angular/core'
import { CustomStore } from 'devextreme-aspnet-data-nojquery'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { environment } from '../../../../../environments/environment'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { CriteriaRetrievedEvent, FilterExpression } from 'src/app/shared/components/filter-criteria/filter-criteria.component'
import { DxDataGridComponent } from 'devextreme-angular/ui/data-grid'


@Component({
  selector: 'app-plm-product',
  templateUrl: './plm-product.component.html',
  styleUrl: './plm-product.component.scss'
})
export class PlmProductComponent {
  PageTitle: string = "PLM Product"
  tableName: string = "PLM_PRODUCT"
  endpoint: string = "PlmProductUI"
  key: string[] | string = "recordKey"

  dataSource: CustomStore
  columnsConfig: Column[]

  dataGridFilterExp: FilterExpression = null
  showCriteria: boolean = true
  showDataGrid: boolean = false
  criteriaFieldsDropdown = [
    { "dataField": "partNumber", "caption": "Part Number" }
  ]

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

  onCriteriaRetrieved(e: CriteriaRetrievedEvent) {
    this.showDataGrid = true
    this.showCriteria = false
    this.dataGridFilterExp = e.filterExpression
  }

  handleRowPrepared(e: any): void {
    if (e.rowType !== 'data') return;

    const deleteFlag = e.data?.deleteFlag;

    if (deleteFlag === 'Y') {
      e.rowElement.style.color = 'red';
    }
  }
}
