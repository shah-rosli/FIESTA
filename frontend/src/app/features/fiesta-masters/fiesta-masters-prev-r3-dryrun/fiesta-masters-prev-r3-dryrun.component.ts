import { Component, QueryList, ViewChild, ViewChildren } from '@angular/core'
import { CustomStore } from 'devextreme-aspnet-data-nojquery'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { DxDataGridComponent } from 'devextreme-angular'
import { CriteriaRetrievedEvent, FilterCriteriaComponent } from '../../../shared/components/filter-criteria/filter-criteria.component'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { environment } from 'src/environments/environment'
import { Workbook } from 'exceljs'
import { exportDataGrid } from 'devextreme/excel_exporter'
import saveAs from 'file-saver'
import { ToastrService } from 'ngx-toastr'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { forkJoin, map } from 'rxjs'

interface Master {
  title: string,
  tablename: string,
  endpoint: string,
  dataSource?: CustomStore,
  columnsConfig?: Column[],
}

@Component({
  selector: 'app-fiesta-masters-prev-r3-dryrun',
  templateUrl: './fiesta-masters-prev-r3-dryrun.component.html',
  styleUrl: './fiesta-masters-prev-r3-dryrun.component.scss'
})
export class FiestaMastersPrevR3DryrunComponent {
  @ViewChild(FilterCriteriaComponent) filterCriteria: FilterCriteriaComponent
  @ViewChildren(DxDataGridComponent) dataGrids!: QueryList<DxDataGridComponent>

  PageTitle: string = "Fiesta Masters"
  showCriteria: boolean = true
  showDataGrid: boolean = false
  enableExportAll: boolean = false
  criteriaColumns: any
  criteriaFieldsDropdown = [
    { "dataField": "opn", "caption": "Orderable Part Number" },
    { "dataField": "partNumber", "caption": "Part Number" }
  ]
  masters: Master[] = [
    { title: "Production", tablename: "V_PRODUCTION_BASIC", endpoint: "OutProductionPrevCycleR3DryrunUI" },
    { title: "Product", tablename: "V_PRODUCT", endpoint: "VProductPrevCycleR3DryrunUI" },
    { title: "Product Plant", tablename: "V_PRODUCT_PLANT", endpoint: "VProductPlantPrevCycleR3DryrunUI" },
    { title: "Product Sales", tablename: "V_PRODUCT_SALES", endpoint: "VProductSalesPrevCycleR3DryrunUI" },
    { title: "Production BOM", tablename: "V_PRODUCTION_BOM", endpoint: "VProductionBomPrevCycleR3DryrunUI" },
    { title: "Production Routing", tablename: "V_PRODUCTION_ROUTING", endpoint: "VProductionRoutingPrevCycleR3DryrunUI" },
    { title: "Production Routing S4", tablename: "V_PRODUCTION_ROUTING_S4", endpoint: "VProductionRoutingS4PrevCycleR3DryrunUI" },
    { title: "Production Version", tablename: "V_PRODUCTION_VERSION", endpoint: "VProductionVersionPrevCycleR3DryrunUI" },
    { title: "Production Priority Mix Ratios", tablename: "V_PRODUCTION_ALTERNATIVES_MIX_RATIOS", endpoint: "VProductionAlternativesMixRatioPrevCycleR3DryrunUI" },
    { title: "Production Leadtime", tablename: "V_PRODUCTION_LEADTIME", endpoint: "VProductionLeadtimePrevCycleR3DryrunUI" },
    { title: "Production Planning Yield", tablename: "V_PRODUCTION_YIELD", endpoint: "VProductionPlanningYieldPrevCycleR3DryrunUI" },
    { title: "Production Costing Yield", tablename: "V_PRODUCTION_YIELD", endpoint: "VProductionCostingYieldPrevCycleR3DryrunUI" },
    { title: "Production Lotsize", tablename: "V_PRODUCTION_LOTSIZE", endpoint: "VProductionLotsizePrevCycleR3DryrunUI" },
    { title: "Production Cycletime", tablename: "V_PRODUCTION_CYCLETIME", endpoint: "VProductionCycletimePrevCycleR3DryrunUI" },
  ]

  constructor(
    private send: SendRequestService,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.configureDatagrid()
  }

  configureDatagrid() {
    const requests = this.masters.map(master => {
      const upperUrl = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=${master.tablename}`
      return this.send.sendRequest(upperUrl, 'GET', '').pipe(
        map(response => {
          master.columnsConfig = response
          return master
        })
      )
    })

    forkJoin(requests).subscribe(() => {
      // Enable the Retrieve button
      this.criteriaColumns = [
        { "dataField": "opn" },
        { "dataField": "partNumber" },
        { "dataField": "deleteFlag" }
      ]

      this.getDataSource()
    })
  }

  getDataSource() {
    for (const master of this.masters) {
      const upperUrl: string = `${environment.ServiceURL_Main}${master.endpoint}`
      master.dataSource = this.send.sendRequestVirtual('recordKey', upperUrl)
    }
  }

  onCriteriaRetrieved(e: CriteriaRetrievedEvent) {
    this.enableExportAll = this.filterCriteria.fieldCriteria.value ? true : false

    this.showDataGrid = true
    this.showCriteria = false

    // next tick
    setTimeout(() => this.dataGrids.forEach((each, index) => {
      if (index === 0 && e.filterExpression[0][0] === "partNumber") {
        const filterExpression: any = structuredClone(e.filterExpression)
        filterExpression[0][0] = "childPartNumber"
        each.instance.option("filterValue", filterExpression)
        return
      }
      each.instance.option("filterValue", e.filterExpression)
    }))
  }

  async datagridExportAll() {
    this.enableExportAll = false

    try {
      for (const datagrid of this.dataGrids) {
        while (datagrid.instance.getDataSource().isLoading()) {
          await new Promise(resolve => setTimeout(resolve, 1000))
        }
      }

      const workbook = new Workbook()
      const promises = []

      for (let i = 0; i < this.dataGrids.length; i++) {
        const master = this.masters[i]
        const datagrid = Array.from(this.dataGrids)[i]

        const worksheet = workbook.addWorksheet(master.title)
        await exportDataGrid({
          component: datagrid.instance,
          worksheet,
          autoFilterEnabled: true,
        })
        promises.push(workbook.xlsx.writeBuffer())
      }

      await Promise.all(promises)
      const finalBuffer = await workbook.xlsx.writeBuffer()
      saveAs(new Blob([finalBuffer], { type: 'application/octet-stream' }), `${this.PageTitle}.xlsx`)
    } catch (error) {
      this.toastr.error("Export All failed!", null, errorToastOptions)
    }
    this.enableExportAll = true
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}
