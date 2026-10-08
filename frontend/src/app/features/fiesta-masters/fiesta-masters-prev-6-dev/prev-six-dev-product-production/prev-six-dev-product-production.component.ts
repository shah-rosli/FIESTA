import { Component, ViewChild } from '@angular/core'
import { environment } from '../../../../../environments/environment'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { CustomStore } from 'devextreme-aspnet-data-nojquery'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { ToastrService } from 'ngx-toastr'
import { DxDataGridComponent } from 'devextreme-angular'
import { CriteriaRetrievedEvent, FilterExpression } from '../../../../shared/components/filter-criteria/filter-criteria.component'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'

@Component({
  selector: 'app-prev-six-dev-product-production',
  templateUrl: './prev-six-dev-product-production.component.html',
  styleUrls: ['./prev-six-dev-product-production.component.scss']
})
export class PrevSixDevProductProductionComponent {
  @ViewChild("upperDataGrid") upperDataGrid: DxDataGridComponent
  @ViewChild("lowerDataGrid") lowerDataGrid: DxDataGridComponent

  PageTitle: string = "Fiesta Product & Production"
  upperDataSource: CustomStore
  lowerDataSource: CustomStore
  upperColumnsConfig: Column[]
  lowerColumnsConfig: Column[]

  upperDataGridFilterExp: FilterExpression = null
  lowerDataGridFilterExp: FilterExpression = null

  showCriteria: boolean = true
  showUpperDataGrid: boolean = false
  showLowerDataGrid: boolean = false
  criteriaFieldsDropdown = [
    { "dataField": "opn", "caption": "Orderable Part Number" }
  ]

  exportBtn = {
    visible: false,
    message: ''
  }
  upperDataGridheight

  constructor(
    private send: SendRequestService,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.configureDatagrid()
    this.getDataSource()
    this.initExportBtn()
    this.upperDataGridheight = 500
  }

  getDataSource() {
    const upperUrl: string = `${environment.ServiceURL_Main}OutProductionPrevCycle6DevUI`
    this.upperDataSource = this.send.sendRequestVirtual('recordKey', upperUrl)
  }

  configureDatagrid() {
    const upperUrl: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=V_PRODUCTION_PREVCYCLE`
    this.send.sendRequest(upperUrl, "GET", "").subscribe(
      data => {
        this.upperColumnsConfig = data
      }
    )
    const lowerUrl: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=V_PRODUCT`
    this.send.sendRequest(lowerUrl, "GET", "").subscribe(
      data => {
        this.lowerColumnsConfig = data
      }
    )
  }

  onUpperDatagridRowClick(e) {
    let clickData: string = e.data.opn
    this.setLowerDataGrid(clickData)
  }

  selectFirstRow(e) {
    const selectingIndex = 0
    e.component.selectRowsByIndexes(selectingIndex)
    const selectedRowsData: any = this.upperDataGrid.instance.getSelectedRowsData()[0]
    this.setLowerDataGrid(selectedRowsData.opn)
  }

  setLowerDataGrid(fieldData) {
    if (!fieldData) {
      this.toastr.error("Failed to get selected data, unable to populate lower datagrid", null, errorToastOptions)
    }
    const lowerUrl: string = `${environment.ServiceURL_Main}OutProductPrevCycle6DevByOpnUI`
    this.lowerDataSource = this.send.sendRequestVirtual('recordKey', lowerUrl, { opn: fieldData })
    this.showLowerDataGrid = true
  }

  onCriteriaRetrieved(e: CriteriaRetrievedEvent) {
    this.showUpperDataGrid = true
    this.showCriteria = false
    this.upperDataGridFilterExp = e.filterExpression

    // filter deleted record for lower datagrid when available
    for (const filterItem of e.filterExpression) {
      if (filterItem[0] === "deleteFlag") {
        this.lowerDataGridFilterExp = filterItem as FilterExpression
      }
    }
  }

  initExportBtn() {
    this.updateExportBtn()
  }

  updateExportBtn(callback?) {
    const url: string = `${environment.ServiceURL_Main}CfgSysTableConfig?tableName=OUT_PRODUCTION`
    this.send.sendRequest(url, "GET", "").subscribe(
      data => {
        this.exportBtn.message = data.CFG_SYS_TABLE_EXTRACT_FILENAME
        this.exportBtn.visible = true
        callback()
      }
    )
  }

  exportBtnClick() {
    const download = () => {
      // https://stackoverflow.com/questions/44112470/download-zip-file-using-angular
      const url: string = `${environment.ServiceURL_Main}DownloadFile?tableName=OUT_PRODUCTION`
      this.send.sendRequestDownloadFile(url, 'application/zip').subscribe(data => {
        const blob = new Blob([data], {
          type: 'application/zip'
        })
        const anchor = document.createElement('a')
        anchor.href = window.URL.createObjectURL(blob)
        anchor.download = this.exportBtn.message
        anchor.click()
        window.URL.revokeObjectURL(anchor.href)
      })
    }
    this.updateExportBtn(download)
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}
