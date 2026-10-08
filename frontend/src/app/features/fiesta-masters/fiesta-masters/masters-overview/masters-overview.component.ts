import { Component, QueryList, ViewChild, ViewChildren } from '@angular/core'
import { CustomStore } from 'devextreme-aspnet-data-nojquery'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { DxDataGridComponent } from 'devextreme-angular'
import { CriteriaRetrievedEvent, FilterCriteriaComponent } from '../../../../shared/components/filter-criteria/filter-criteria.component'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { environment } from 'src/environments/environment'
import { Workbook } from 'exceljs'
import { exportDataGrid } from 'devextreme/excel_exporter'
import saveAs from 'file-saver'
import { ToastrService } from 'ngx-toastr'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { forkJoin, map } from 'rxjs'
import { ActivatedRoute } from '@angular/router'

interface Master {
  title: string,
  tablename: string,
  endpoint: string,
  dataSource?: CustomStore,
  columnsConfig?: Column[],
}

@Component({
  selector: 'app-masters-overview',
  templateUrl: './masters-overview.component.html',
  styleUrls: ['./masters-overview.component.scss']
})
export class MastersOverviewComponent {
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

  constructor(
    private send: SendRequestService,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.configureDatagrid()

    // this.route.queryParams.subscribe(params => {
    //   const opn = params['opn']
    //   if (opn) {
    //     this.applyOpnFilter(opn)
    //   }
    // })
  }

  // configureDatagrid() {
  //   const payload = {
  //     tableName: this.masters.map(item => item.tablename)
  //   }
  //   const url = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableNames`
  //   this.send.sendRequest(url, 'GET', payload)
  //     .subscribe({
  //       next: response => {
  //         for (const master of this.masters) {
  //           const config = response.find(item => item.tableName === master.tablename)
  //           master.columnsConfig = config.columns
  //         }

  //         // Enable the Retrieve button
  //         this.criteriaColumns = [
  //           { "dataField": "opn" },
  //           { "dataField": "partNumber" },
  //           { "dataField": "deleteFlag" }
  //         ]

  //         this.getDataSource()

  //         this.route.queryParams.subscribe(params => {
  //           const opn = params['opn']
  //           if (opn) {
  //             this.applyOpnFilter(opn)
  //           }
  //         })
  //       },
  //       error: error => {
  //         const message = error?.error?.message || "Something went wrong"
  //         this.toastr.error(message, "Error!", errorToastOptions)
  //       }
  //     })
  // }
  configureDatagrid() {
    const payload = {
      tableName: this.masters.map(item => item.tablename)
    };

    const url =
      `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableNames`;

    this.send.sendRequest(url, 'GET', payload)
      .subscribe({
        next: response => {
          for (const master of this.masters) {
            const config = response.find(
              item => item.tableName === master.tablename
            );

            master.columnsConfig = (config?.columns ?? []).map((column: Column) => {
              if (column.dataType === 'date') {
                return {
                  ...column,
                  dataType: 'date',
                  format: 'yyyy-MM-dd',
                  allowHeaderFiltering: false //20260930 disable date filter
                };
              }

              return column;
            });
          }

          this.criteriaColumns = [
            { dataField: 'opn' },
            { dataField: 'partNumber' },
            { dataField: 'deleteFlag' }
          ];

          this.getDataSource();

          this.route.queryParams.subscribe(params => {
            const opn = params['opn'];

            if (opn) {
              this.applyOpnFilter(opn);
            }
          });
        },
        error: error => {
          const message = error?.error?.message || 'Something went wrong';
          this.toastr.error(message, 'Error!', errorToastOptions);
        }
      });
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

  applyOpnFilter(opn: string) {
    this.enableExportAll = true
    this.showDataGrid = true
    this.showCriteria = false

    const filterExpression: any = [
      ['opn', 'anyof', [opn]],
      'and',
      ['deleteFlag', '=', 'N']
    ]

    setTimeout(() => this.dataGrids.forEach(each => {
      each.instance.option("filterValue", filterExpression)
    }))
  }

  handleRowPrepared(e: any): void {
    if (e.rowType !== 'data') return;

    const deleteFlag = e.data?.deleteFlag;

    if (deleteFlag === 'Y') {
      e.rowElement.style.color = 'red';
    }
  }
}
