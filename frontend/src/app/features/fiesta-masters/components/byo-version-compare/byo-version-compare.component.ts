import { Component, EventEmitter, Input, Output, Renderer2, RendererStyleFlags2, ViewChild } from '@angular/core'
import { Column, ExportingEvent, Row } from 'devextreme/ui/data_grid'
import { finalize } from 'rxjs'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { environment } from 'src/environments/environment'
import { DxDataGridComponent } from 'devextreme-angular'
import { ToastrService } from 'ngx-toastr'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { TextDiffService } from 'src/app/service/text-diff/text-diff.service'

@Component({
  selector: 'app-byo-version-compare',
  templateUrl: './byo-version-compare.component.html',
  styleUrl: './byo-version-compare.component.scss'
})
export class ByoVersionCompareComponent {

  @ViewChild("upperDataGrid") upperDataGrid: DxDataGridComponent
  @ViewChild("lowerDataGrid") lowerDataGrid: DxDataGridComponent

  @Input() BYO: string

  TableName: string
  partNumber: string

  visible: boolean
  loading: boolean
  title: string

  dataSource_version: any[]
  dataSource_ddl_1: any[]
  dataSource_ddl_2: any[]
  upperDataSource: any[]
  lowerDataSource: any[]

  // upperDataSource_temp: any[]
  // lowerDataSource_temp: any[]

  selectedUpperVersion: string
  selectedLowerVersion: string

  revisionLabel_1: string
  revisionLabel_2: string
  revision_1: string
  revision_2: string

  contentReadyRunOnce: boolean = false
  columnsConfig: Column[]
  upperToolbarData = { opnVersion: null, date: null }
  lowerToolbarData = { opnVersion: null, date: null }

  uniqueKey_BYO_PRODUCT = ["partNumber"]
  cellDiffSkippedColumns_BYO_PRODUCT = ["recordKey", "createDateAndTime", "updateDateAndTime", "deleteDateAndTime"]

  // uniqueKey_BYO_PRODUCTION = ["opn", "partNumber", "parentPartNumber", "flowNumber", "operation"]
  uniqueKey_BYO_PRODUCTION = ["opn", "parentPartNumber", "partNumber", "flowNumber", "plant", "storageLocation", "operationNumber", "dieSet", "supplyPlant", "supplyStorageLocation"]
  //[PK] OPN, [PK] Parent Part Number, [PK] Part Number, [PK] Flow Number, Plant, Storage Location, Stage Number, Die Set, Supply Plant, 	Supply Storage Location
  cellDiffSkippedColumns_BYO_PRODUCTION = ["recordKey", "createDateAndTime", "updateDateAndTime", "deleteDateAndTime"]

  constructor(private send: SendRequestService, private toastr: ToastrService, private renderer: Renderer2, private textDiff: TextDiffService) { }
  onHidden() {
    this.visible = false
  }

  open(TableName: string, opn: string, columnsConfig: Column[]) {

    this.TableName = TableName
    this.partNumber = opn
    this.columnsConfig = columnsConfig

    this.visible = true
    this.loading = true

    if (this.TableName === "BYO_PRODUCT") {
      this.title = "Buyoff Product Version Compare"

      this.send.sendRequest(`${environment.ServiceURL_Main}BYO/GetDDLProductChangeOrder?partNumber=${opn}`, "GET", "")
        .pipe(finalize(() => this.loading = false))
        .subscribe({
          next: (value) => {
            this.dataSource_version = value
            this.dataSource_ddl_1 = value
            this.dataSource_ddl_2 = value

            if (value?.length) {
              this.selectedUpperVersion = value[0].prefixChangeOrder;
              this.refreshUpperGrid();

              if (value.length >= 2) {
                this.selectedLowerVersion = value[1]?.prefixChangeOrder;
                this.refreshLowerGrid();
              }
            }

            this.refreshUI()

            this.loading = false
          }
        })

    } else if (this.TableName === "BYO_PRODUCTION") {
      this.title = "Buyoff Production Version Compare"

      this.send.sendRequest(`${environment.ServiceURL_Main}BYO/GetDDLProductionChangeOrder?opn=${opn}`, "GET", "")
        .pipe(finalize(() => this.loading = false))
        .subscribe({
          next: (value) => {
            this.dataSource_version = value
            this.dataSource_ddl_1 = value
            this.dataSource_ddl_2 = value

            if (value?.length) {
              this.selectedUpperVersion = value[0].prefixChangeOrder;
              this.refreshUpperGrid();

              if (value.length >= 2) {
                this.selectedLowerVersion = value[1]?.prefixChangeOrder;
                this.refreshLowerGrid();
              }
            }

            this.refreshUI()

            this.loading = false
          }
        })
    }

  }

  onUpperDDLChanged(e: any) {
    // console.log("Selected value:", e.value);
    this.selectedUpperVersion = e.value;

    this.refreshUpperGrid();
  }

  onLowerDDLChanged(e: any) {
    // console.log("Selected value:", e.value);
    this.selectedLowerVersion = e.value;

    this.refreshLowerGrid();
  }

  refreshUI() {
    if (this.TableName === "BYO_PRODUCT") {
      this.revisionLabel_1 = "Product Revision: "
      this.revisionLabel_2 = "Product Revision: "
    } else if (this.TableName === "BYO_PRODUCTION") {
      this.revisionLabel_1 = "Production Revision: "
      this.revisionLabel_2 = "Production Revision: "
    }
    this.revision_1 = this.selectedUpperVersion
    this.revision_2 = this.selectedLowerVersion
  }

  refreshUpperGrid() {
    if (!this.selectedUpperVersion) return;

    const found = this.dataSource_version?.find(
      x => x.prefixChangeOrder === this.selectedUpperVersion
    );

    const source = found?.Source;

    let url = "";

    if (this.TableName === "BYO_PRODUCT") {
      if (source === 1) {
        url = `${environment.ServiceURL_Main}BYO/GetProductVersionCompare?partNumber=${this.partNumber}&prefixChangeOrder=${this.selectedUpperVersion}`;
      } else if (source === 2) {
        url = `${environment.ServiceURL_Main}BYO/GetProduct_His_VersionCompare?partNumber=${this.partNumber}&prefixChangeOrder=${this.selectedUpperVersion}`;
      }
    }

    if (this.TableName === "BYO_PRODUCTION") {
      if (source === 1) {
        url = `${environment.ServiceURL_Main}BYO/GetProductionVersionCompare?opn=${this.partNumber}&prefixChangeOrder=${this.selectedUpperVersion}`;
      } else if (source === 2) {
        url = `${environment.ServiceURL_Main}BYO/GetProduction_His_VersionCompare?opn=${this.partNumber}&prefixChangeOrder=${this.selectedUpperVersion}`;
      }
    }

    if (!url) {
      console.warn("No valid source found for version:", this.selectedUpperVersion);
      return;
    }

    this.send.sendRequest(url, "GET", "")
      .pipe(finalize(() => this.loading = false))
      .subscribe({
        next: (value) => {
          this.upperDataSource = value;
        }
      });
  }

  refreshLowerGrid() {
    if (!this.selectedLowerVersion) return;

    const found = this.dataSource_version?.find(
      x => String(x.prefixChangeOrder) === String(this.selectedLowerVersion)
    );

    const source = found?.Source;

    let url = "";

    if (this.TableName === "BYO_PRODUCT") {
      if (source === 1) {
        url = `${environment.ServiceURL_Main}BYO/GetProductVersionCompare?partNumber=${this.partNumber}&prefixChangeOrder=${this.selectedLowerVersion}`;
      } else if (source === 2) {
        url = `${environment.ServiceURL_Main}BYO/GetProduct_His_VersionCompare?partNumber=${this.partNumber}&prefixChangeOrder=${this.selectedLowerVersion}`;
      }
    }

    if (this.TableName === "BYO_PRODUCTION") {
      if (source === 1) {
        url = `${environment.ServiceURL_Main}BYO/GetProductionVersionCompare?opn=${this.partNumber}&prefixChangeOrder=${this.selectedLowerVersion}`;
      } else if (source === 2) {
        url = `${environment.ServiceURL_Main}BYO/GetProduction_His_VersionCompare?opn=${this.partNumber}&prefixChangeOrder=${this.selectedLowerVersion}`;
      }
    }

    if (!url) {
      console.warn("No valid source found for version:", this.selectedLowerVersion);
      return;
    }

    this.send.sendRequest(url, "GET", "")
      .pipe(finalize(() => this.loading = false))
      .subscribe({
        next: (value) => {
          this.lowerDataSource = value;
        }
      });
  }

  onContentReady() {
    if (!this.upperDataSource || this.upperDataSource.length < 1) {
      return
    }

    if (!this.lowerDataSource || this.lowerDataSource.length < 1) {
      return
    }

    const upperVisibleColumns: any[] = this.upperDataGrid.instance.getVisibleColumns()
    const lowervisibleColumns: any[] = this.lowerDataGrid.instance.getVisibleColumns()
    if (!(upperVisibleColumns[0].visibleWidth && lowervisibleColumns[0].visibleWidth)) {
      // skip when unable to read visible width
      return
    }
    if (!this.contentReadyRunOnce) {
      this.contentReadyRunOnce = true
      this.initScrollSync()
      this.syncColumnWidth()
      this.populateToolbarData()
      //this.initSignOffFunction()
      return
    } else {
      this.initScrollSync()
    }

    if (this.TableName === "BYO_PRODUCT") {
      this.renderDifferences_BYO_PRODUCT();

    } else if (this.TableName === "BYO_PRODUCTION") {
      this.renderDifferences_BYO_PRODUCTION();
    }

  }

  initScrollSync() {
    const scrollableDg1 = this.upperDataGrid.instance.getScrollable()
    const scrollableDg2 = this.lowerDataGrid.instance.getScrollable()
    scrollableDg1.on("scroll", (e) => scrollableDg2.scrollTo(e.scrollOffset))
    scrollableDg2.on("scroll", (e) => scrollableDg1.scrollTo(e.scrollOffset))
  }

  syncColumnWidth() {
    const upperVisibleColumns: any[] = this.upperDataGrid.instance.getVisibleColumns()
    const lowervisibleColumns: any[] = this.lowerDataGrid.instance.getVisibleColumns()
    this.columnsConfig = this.columnsConfig.map((column) => {
      const upperColumnWidth = upperVisibleColumns.find(item => item.dataField === column.dataField).visibleWidth
      const lowerColumnWidth = lowervisibleColumns.find(item => item.dataField === column.dataField).visibleWidth
      if (upperColumnWidth > lowerColumnWidth) {
        column.width = upperColumnWidth
      } else {
        column.width = lowerColumnWidth
      }
      return column
    })
  }

  populateToolbarData() {
    // opn version
    const previousOpnVersion = this.lowerDataSource[0]?.opnVersion
    this.upperToolbarData.opnVersion = Number.isInteger(previousOpnVersion) ? previousOpnVersion + 1 :
      this.upperDataSource.length ? 1 : null
    this.lowerToolbarData.opnVersion = Number.isInteger(previousOpnVersion) ? previousOpnVersion : null

    // use Array.reduce to get max date
    try {
      this.upperToolbarData.date = this.upperDataSource.reduce((previous, current) => {
        return new Date(current.updateDateAndTime) > new Date(previous.updateDateAndTime) ? current : previous
      }, this.upperDataSource[0]).updateDateAndTime
      this.lowerToolbarData.date = this.lowerDataSource.reduce((previous, current) => {
        return new Date(current.PLM_PRODUCTION_BUYOFF_HIS_DATE) > new Date(previous.PLM_PRODUCTION_BUYOFF_HIS_DATE) ? current : previous
      }, this.lowerDataSource[0]).PLM_PRODUCTION_BUYOFF_HIS_DATE
    } catch (error) {
      console.error(error)
    }
  }



  renderDifferences_BYO_PRODUCT() {

    if (this.upperDataGrid.instance.getVisibleRows().length < 1) {
      return
    }
    if (this.lowerDataGrid.instance.getVisibleRows().length < 1) {
      return
    }

    this.onPurgeBackGroundColor();

    // calculate row-level difference
    const rowDifferenceMap = new Map<string, { dataGrid: "upper" | "lower", row: Row }>()
    const getMapKey = (row: Row) => this.uniqueKey_BYO_PRODUCT.map(key => row.data[key]).join("_")

    const rowDeletedMap = new Map<string, { dataGrid: "upper" | "lower", row: Row }>()

    for (const row of this.upperDataGrid.instance.getVisibleRows()) {
      rowDifferenceMap.set(getMapKey(row), { dataGrid: "upper", row: row })
    }
    for (const row of this.lowerDataGrid.instance.getVisibleRows()) {
      if (rowDifferenceMap.get(getMapKey(row))) {
        rowDifferenceMap.delete(getMapKey(row))

        rowDeletedMap.set(getMapKey(row), { dataGrid: "upper", row: row }) //add deleted upper row to rowDeletedMap

      } else if (rowDeletedMap.get(getMapKey(row))) {
        continue //if lower grid row in rowDeletedMap, do nothing
      } else {
        rowDifferenceMap.set(getMapKey(row), { dataGrid: "lower", row: row })
      }
    }

    const cellDiffUpperRows = this.upperDataGrid.instance.getVisibleRows().filter(row => !rowDifferenceMap.has(getMapKey(row)))
    const cellDiffLowerRows = this.lowerDataGrid.instance.getVisibleRows().filter(row => !rowDifferenceMap.has(getMapKey(row)))
    // if (cellDiffUpperRows.length !== cellDiffLowerRows.length) {
    //   const errorMapUpper = new Map()
    //   for (const row of this.upperDataGrid.instance.getVisibleRows()) {
    //     if (errorMapUpper.has(getMapKey(row))) {
    //       this.toastr.error("Difference calculation stopped, unique constraint violated on upper datagrid!", "Error!", errorToastOptions)
    //       return
    //     }
    //     errorMapUpper.set(getMapKey(row), "")
    //   }
    //   const errorMapLower = new Map()
    //   for (const row of this.lowerDataGrid.instance.getVisibleRows()) {
    //     if (errorMapLower.has(getMapKey(row))) {
    //       this.toastr.error("Difference calculation stopped, unique constraint violated on lower datagrid!", "Error!", errorToastOptions)
    //       return
    //     }
    //     errorMapLower.set(getMapKey(row), "")
    //   }
    //   this.toastr.error("Difference calculation stopped, upper and lower datagrid does not have same row count, cause unknown.", "Error!", errorToastOptions)
    //   return
    // }
    rowDifferenceMap.forEach(item => {
      if (item.dataGrid === "upper") {
        const rowElement = this.upperDataGrid.instance.getRowElement(item.row.rowIndex)
        // this.renderer.addClass(rowElement[0], "diff-addition-row")
        this.renderer.setStyle(
          rowElement[0],
          'background-color',
          '#bdefbc',
          RendererStyleFlags2.Important
        );
      }
      if (item.dataGrid === "lower") {
        const rowElement = this.lowerDataGrid.instance.getRowElement(item.row.rowIndex)
        // this.renderer.addClass(rowElement[0], "diff-deletion-row")
        this.renderer.setStyle(
          rowElement[0],
          'background-color',
          '#ffabab',
          RendererStyleFlags2.Important
        );
      }
    })

    // calculate cell-level difference
    for (const i in cellDiffUpperRows) {
      const row = cellDiffUpperRows[i]
      for (const column of this.upperDataGrid.instance.getVisibleColumns()) {
        if (this.cellDiffSkippedColumns_BYO_PRODUCT.includes(column.dataField)) {
          continue
        }
        const upperCellValue = String(cellDiffUpperRows[i].data[column.dataField] ?? "")
        const lowerCellValue = String(cellDiffLowerRows[i].data[column.dataField] ?? "")
        if (upperCellValue === lowerCellValue) {
          continue
        }
        const differences = this.textDiff.diff(lowerCellValue, upperCellValue)
        const cellElement = this.upperDataGrid.instance.getCellElement(row.rowIndex, column.visibleIndex)
        this.renderer.setProperty(cellElement, 'innerHTML', '')
        for (const difference of differences) {
          if (difference[0] === 1) {
            const span = this.renderer.createElement("span")
            //this.renderer.addClass(span, "diff-addition-cell")
            this.renderer.setStyle(
              span,
              'background-color',
              '#bdefbc',
              RendererStyleFlags2.Important
            );
            this.renderer.appendChild(span, this.renderer.createText(difference[1]))
            this.renderer.appendChild(cellElement, span)
          } else if (difference[0] === 0) {
            this.renderer.appendChild(cellElement, this.renderer.createText(difference[1]))
          }
        }
      }
    }

    for (const i in cellDiffLowerRows) {
      const row = cellDiffLowerRows[i]
      for (const column of this.lowerDataGrid.instance.getVisibleColumns()) {
        if (this.cellDiffSkippedColumns_BYO_PRODUCT.includes(column.dataField)) {
          continue
        }
        const upperCellValue = String(cellDiffUpperRows[i].data[column.dataField] ?? "")
        const lowerCellValue = String(cellDiffLowerRows[i].data[column.dataField] ?? "")
        if (upperCellValue === lowerCellValue) {
          continue
        }
        const differences = this.textDiff.diff(lowerCellValue, upperCellValue)
        const cellElement = this.lowerDataGrid.instance.getCellElement(row.rowIndex, column.visibleIndex)
        this.renderer.setProperty(cellElement, 'innerHTML', '')
        for (const difference of differences) {
          if (difference[0] === -1) {
            const span = this.renderer.createElement("span")
            //this.renderer.addClass(cellElement, "diff-deletion-cell")
            this.renderer.setStyle(
              span,
              'background-color',
              '#ffabab',
              RendererStyleFlags2.Important
            );
            this.renderer.appendChild(span, this.renderer.createText(difference[1]))
            this.renderer.appendChild(cellElement, span)
          } else if (difference[0] === 0) {
            this.renderer.appendChild(cellElement, this.renderer.createText(difference[1]))
          }
        }
      }
    }
  }

  renderDifferences_BYO_PRODUCTION() {

    if (this.upperDataGrid.instance.getVisibleRows().length < 1) {
      return
    }
    if (this.lowerDataGrid.instance.getVisibleRows().length < 1) {
      return
    }

    this.onPurgeBackGroundColor();

    // calculate row-level difference
    const rowDifferenceMap = new Map<string, { dataGrid: "upper" | "lower", row: Row }>()
    const getMapKey = (row: Row) => this.uniqueKey_BYO_PRODUCTION.map(key => row.data[key]).join("_")

    const rowDeletedMap = new Map<string, { dataGrid: "upper" | "lower", row: Row }>()

    for (const row of this.upperDataGrid.instance.getVisibleRows()) {
      rowDifferenceMap.set(getMapKey(row), { dataGrid: "upper", row: row })
    }
    for (const row of this.lowerDataGrid.instance.getVisibleRows()) {
      if (rowDifferenceMap.get(getMapKey(row))) {
        rowDifferenceMap.delete(getMapKey(row))

        rowDeletedMap.set(getMapKey(row), { dataGrid: "upper", row: row }) //add deleted upper row to rowDeletedMap

      } else if (rowDeletedMap.get(getMapKey(row))) {
        continue //if lower grid row in rowDeletedMap, do nothing
      }
      else {
        rowDifferenceMap.set(getMapKey(row), { dataGrid: "lower", row: row })
      }
    }

    const cellDiffUpperRows = this.upperDataGrid.instance.getVisibleRows().filter(row => !rowDifferenceMap.has(getMapKey(row)))
    const cellDiffLowerRows = this.lowerDataGrid.instance.getVisibleRows().filter(row => !rowDifferenceMap.has(getMapKey(row)))
    // if (cellDiffUpperRows.length !== cellDiffLowerRows.length) {
    //   const errorMapUpper = new Map()
    //   for (const row of this.upperDataGrid.instance.getVisibleRows()) {
    //     if (errorMapUpper.has(getMapKey(row))) {
    //       this.toastr.error("Difference calculation stopped, unique constraint violated on upper datagrid!", "Error!", errorToastOptions)
    //       return
    //     }
    //     errorMapUpper.set(getMapKey(row), "")
    //   }
    //   const errorMapLower = new Map()
    //   for (const row of this.lowerDataGrid.instance.getVisibleRows()) {
    //     if (errorMapLower.has(getMapKey(row))) {
    //       this.toastr.error("Difference calculation stopped, unique constraint violated on lower datagrid!", "Error!", errorToastOptions)
    //       return
    //     }
    //     errorMapLower.set(getMapKey(row), "")
    //   }
    //   this.toastr.error("Difference calculation stopped, upper and lower datagrid does not have same row count, cause unknown.", "Error!", errorToastOptions)
    //   return
    // }
    rowDifferenceMap.forEach(item => {
      if (item.dataGrid === "upper") {
        const rowElement = this.upperDataGrid.instance.getRowElement(item.row.rowIndex)
        // this.renderer.addClass(rowElement[0], "diff-addition-row")
        this.renderer.setStyle(
          rowElement[0],
          'background-color',
          '#bdefbc',
          RendererStyleFlags2.Important
        );
      }
      if (item.dataGrid === "lower") {
        const rowElement = this.lowerDataGrid.instance.getRowElement(item.row.rowIndex)
        // this.renderer.addClass(rowElement[0], "diff-deletion-row")
        this.renderer.setStyle(
          rowElement[0],
          'background-color',
          '#ffabab',
          RendererStyleFlags2.Important
        );
      }
    })

    // calculate cell-level difference
    for (const i in cellDiffUpperRows) {
      const row = cellDiffUpperRows[i]
      for (const column of this.upperDataGrid.instance.getVisibleColumns()) {
        if (this.cellDiffSkippedColumns_BYO_PRODUCTION.includes(column.dataField)) {
          continue
        }
        const upperCellValue = String(cellDiffUpperRows[i].data[column.dataField] ?? "")
        const lowerCellValue = String(cellDiffLowerRows[i].data[column.dataField] ?? "")
        if (upperCellValue === lowerCellValue) {
          continue
        }
        const differences = this.textDiff.diff(lowerCellValue, upperCellValue)
        const cellElement = this.upperDataGrid.instance.getCellElement(row.rowIndex, column.visibleIndex)
        this.renderer.setProperty(cellElement, 'innerHTML', '')
        for (const difference of differences) {
          if (difference[0] === 1) {
            const span = this.renderer.createElement("span")
            //this.renderer.addClass(span, "diff-addition-cell")
            this.renderer.setStyle(
              span,
              'background-color',
              '#bdefbc',
              RendererStyleFlags2.Important
            );
            this.renderer.appendChild(span, this.renderer.createText(difference[1]))
            this.renderer.appendChild(cellElement, span)
          } else if (difference[0] === 0) {
            this.renderer.appendChild(cellElement, this.renderer.createText(difference[1]))
          }
        }
      }
    }

    for (const i in cellDiffLowerRows) {
      const row = cellDiffLowerRows[i]
      for (const column of this.lowerDataGrid.instance.getVisibleColumns()) {
        if (this.cellDiffSkippedColumns_BYO_PRODUCTION.includes(column.dataField)) {
          continue
        }
        const upperCellValue = String(cellDiffUpperRows[i].data[column.dataField] ?? "")
        const lowerCellValue = String(cellDiffLowerRows[i].data[column.dataField] ?? "")
        if (upperCellValue === lowerCellValue) {
          continue
        }
        const differences = this.textDiff.diff(lowerCellValue, upperCellValue)
        const cellElement = this.lowerDataGrid.instance.getCellElement(row.rowIndex, column.visibleIndex)
        this.renderer.setProperty(cellElement, 'innerHTML', '')
        for (const difference of differences) {
          if (difference[0] === -1) {
            const span = this.renderer.createElement("span")
            //this.renderer.addClass(cellElement, "diff-deletion-cell")
            this.renderer.setStyle(
              span,
              'background-color',
              '#ffabab',
              RendererStyleFlags2.Important
            );
            this.renderer.appendChild(span, this.renderer.createText(difference[1]))
            this.renderer.appendChild(cellElement, span)
          } else if (difference[0] === 0) {
            this.renderer.appendChild(cellElement, this.renderer.createText(difference[1]))
          }
        }
      }
    }
  }

  onPurgeBackGroundColor(): void {
    const cleanCell = (cellElement: any) => {
      if (!cellElement) return;

      // Remove all spans (diff highlights)
      const spans = cellElement.querySelectorAll('span');
      spans.forEach((span: HTMLElement) => {
        this.renderer.removeStyle(span, 'background-color');
      });

      // Optional: restore original text
      // safest way:
      const text = cellElement.innerText;
      this.renderer.setProperty(cellElement, 'innerHTML', text);
    };

    for (const row of this.upperDataGrid.instance.getVisibleRows()) {
      const rowElement = this.upperDataGrid.instance.getRowElement(row.rowIndex);
      this.renderer.removeStyle(rowElement[0], 'background-color');
    }
    for (const row of this.lowerDataGrid.instance.getVisibleRows()) {
      const rowElement = this.lowerDataGrid.instance.getRowElement(row.rowIndex);
      this.renderer.removeStyle(rowElement[0], 'background-color');
    }
    for (const row of this.upperDataGrid.instance.getVisibleRows()) {
      for (const column of this.upperDataGrid.instance.getVisibleColumns()) {
        const cellElement = this.upperDataGrid.instance.getCellElement(row.rowIndex, column.visibleIndex);
        cleanCell(cellElement);
      }
    }
    for (const row of this.lowerDataGrid.instance.getVisibleRows()) {
      for (const column of this.lowerDataGrid.instance.getVisibleColumns()) {
        const cellElement = this.lowerDataGrid.instance.getCellElement(row.rowIndex, column.visibleIndex);
        cleanCell(cellElement);
      }
    }
  }
}
