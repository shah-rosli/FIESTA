import { Component, QueryList, ViewChild, ViewChildren } from '@angular/core'
import { CustomStore } from 'devextreme-aspnet-data-nojquery'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { DxDataGridComponent } from 'devextreme-angular'
import { CriteriaRetrievedEvent, FilterCriteriaComponent, FilterExpression } from '../../../../shared/components/filter-criteria/filter-criteria.component'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { environment } from 'src/environments/environment'
import { Workbook } from 'exceljs'
import { exportDataGrid } from 'devextreme/excel_exporter'
import saveAs from 'file-saver'
import { ToastrService } from 'ngx-toastr'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { forkJoin, map } from 'rxjs'
import { ActivatedRoute, Router } from '@angular/router'
import DataSource from 'devextreme/data/data_source'

interface Master {
  title: string,
  tablename: string,
  endpoint: string,
  dataSource?: DataSource,
  columnsConfig?: Column[],
}

@Component({
  selector: 'app-user-buyoff',
  templateUrl: './user-buyoff.component.html',
  styleUrls: ['./user-buyoff.component.scss']
})
export class UserBuyoffComponent {
  @ViewChildren(DxDataGridComponent) dataGrids!: QueryList<DxDataGridComponent>

  PageTitle: string = "Business Sign-off"
  tab: "summary" | "buyoff" = "summary"
  summaryColumnsConfig: any[]
  summaryDataSource: DataSource
  enableExportAll: boolean = false
  masters: Master[] = [
    { title: "Production", tablename: "V_PRODUCTION_BASIC", endpoint: "OutProductionUI" },
    { title: "Product", tablename: "V_PRODUCT", endpoint: "VProductUI" },
    { title: "Product Plant", tablename: "V_PRODUCT_PLANT", endpoint: "VProductPlantUI" },
    { title: "Product Sales", tablename: "V_PRODUCT_SALES", endpoint: "VProductSalesUI" },
    { title: "Product Components", tablename: "V_PRODUCT_COMPONENTS", endpoint: "VProductComponentsUI" },
    { title: "Product Vendor Characteristics", tablename: "V_PRODUCT_VENDOR_CHAR", endpoint: "VProductVendorCharUI" },
    { title: "Product Matrix", tablename: "V_PRODUCT_MATRIX", endpoint: "VProductMatrixUI" },
    { title: "Production BOM", tablename: "V_PRODUCTION_BOM", endpoint: "VProductionBomUI" },
    { title: "Production Routing", tablename: "V_PRODUCTION_ROUTING", endpoint: "VProductionRoutingUI" },
    { title: "Production Routing S4", tablename: "V_PRODUCTION_ROUTING_S4", endpoint: "VProductionRoutingS4UI" },
    { title: "Production Version", tablename: "V_PRODUCTION_VERSION", endpoint: "VProductionVersionUI" },
    { title: "Production Priority Mix Ratios", tablename: "V_PRODUCTION_ALTERNATIVES_MIX_RATIOS", endpoint: "VProductionAlternativesMixRatioUI" },
    { title: "Production Leadtime", tablename: "V_PRODUCTION_LEADTIME", endpoint: "VProductionLeadtimeUI" },
    { title: "Production Planning Yield", tablename: "V_PRODUCTION_YIELD", endpoint: "VProductionPlanningYieldUI" },
    { title: "Production Costing Yield", tablename: "V_PRODUCTION_YIELD", endpoint: "VProductionCostingYieldUI" },
    { title: "Production Lotsize", tablename: "V_PRODUCTION_LOTSIZE", endpoint: "VProductionLotsizeUI" },
    { title: "Production Cycletime", tablename: "V_PRODUCTION_CYCLETIME", endpoint: "VProductionCycletimeUI" },
  ]
  filter: FilterExpression
  buyoffOpn: string

  constructor(
    private send: SendRequestService,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.configureSummary()
    this.configureBuyoff()
  }

  configureSummary() {
    const createMainColumns = (columns: Column[]): Column[] => {
      const mainColumns = [...columns]
      mainColumns.forEach((column) => {
        if (column.dataField === "status") {
          column.cellTemplate = "statusCellTemplate"
        }
      })
      return mainColumns
    }
    const url = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=V_OPN_LIST_BUYOFF`
    this.send.sendRequest(url, "GET", "").subscribe(data => {
      this.summaryColumnsConfig = createMainColumns(data)
      this.summaryDataSource = new DataSource({
        store: this.send.sendRequestVirtual("opn", `${environment.ServiceURL_Main}OpnList`),
        filter: [["status", "=", "User Buyoff"]]
      })
    })
  }

  configureBuyoff() {
    const payload = {
      tableName: this.masters.map(item => item.tablename)
    }
    const url = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableNames`
    this.send.sendRequest(url, 'GET', payload)
      .subscribe({
        next: response => {
          for (const master of this.masters) {
            const config = response.find(item => item.tableName === master.tablename)
            master.columnsConfig = config.columns
          }
          this.watchOpnParam()
        },
        error: error => {
          const message = error?.error?.message || "Something went wrong"
          this.toastr.error(message, "Error!", errorToastOptions)
        }
      })
  }

  watchOpnParam() {
    this.route.queryParams.subscribe(params => {
      const opn = params.opn
      if (opn) {
        this.tab = "buyoff"
        this.buyoffOpn = opn
        this.enableExportAll = true
        this.getMastersDataSource()
      } else {
        this.tab = "summary"
      }
    })
  }

  getMastersDataSource() {
    for (const master of this.masters) {
      const url: string = `${environment.ServiceURL_Main}${master.endpoint}`
      master.dataSource = new DataSource({
        store: this.send.sendRequestVirtual("recordKey", url),
        filter: [["opn", "=", this.buyoffOpn], "and", ["deleteFlag", "=", "N"]]
      })
    }
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

  onBuyoff() {
    this.send.sendRequest(`${environment.ServiceURL_Main}UserBuyoff`, "GET", { opn: this.buyoffOpn })
      .subscribe({
        next: response => {
          this.toastr.success(response.message)
          setTimeout(() => {
            this.tab = "summary";
          }, 5000);
        },
        error: error => {
          const message = error?.error?.message || "Something went wrong"
          this.toastr.error(message, "Error!", errorToastOptions)
        }
      })
  }
}
