import { Component, ViewChild } from '@angular/core'
import { DxDataGridComponent } from 'devextreme-angular'
import DataSource from 'devextreme/data/data_source'
import { ToastrService } from 'ngx-toastr'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
import { environment } from '../../../../../environments/environment'
import { DeltaUploadComponent } from '../../../mdm-config/components/delta-upload/delta-upload.component'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { ConfigHistoryPopupComponent } from '../../../mdm-config/components/config-history-popup/config-history-popup.component'
import { firstValueFrom } from 'rxjs'
import CustomStore from "devextreme/data/custom_store"

@Component({
  selector: 'app-product-v2',
  templateUrl: './product-v2.component.html',
  styleUrl: './product-v2.component.scss'
})
export class ProductV2Component {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @ViewChild(DeltaUploadComponent) deltaUpload: DeltaUploadComponent
  @ViewChild(ConfigHistoryPopupComponent) historyPopup: ConfigHistoryPopupComponent

  PageTitle: string = "Product Sales Root PartNumber Maintenance"
  endpoint: string = "CfgProductV2"
  tableName: string = "CFG_PRODUCT_V2"
  dataSource: DataSource
  pagePermission: PagePermission
  dataGridKey: string = "recordKey"
  fieldsAllowEditing: string[] = [
    // "partDescription",
    // "plmStatus",
    // "minimumOrderQuantity",
    // "standardPackingQuantity",
    // "businessPlannerCode",
    // "deleteFlag",
    // "proposePartDesc",
    // "partDescApprovedBy",
    // "partDescApprovedDateTime",
    "salesRootPartNumber",
    "deleteFlag"
  ]
  fieldsRequired: string[] = [
    "partNumber",
    "deleteFlag"
  ]
  fieldsCreateOnly: string[] = [
    "partNumber"
  ]
  yesNoDataSource = ["Y", "N"]
  //OneZeroDataSource = ["1", "0"]

  columnConfig: Column[]
  deltaUploadColumnConfig: Column[]
  historyColumnConfig: Column[]

  saveButtonOptions = {
    text: 'Save',
    onClick: () => this.dataGrid.instance.saveEditData()
  }

  cancelButtonOptions = {
    text: 'Cancel',
    onClick: () => this.dataGrid.instance.cancelEditData()
  }

  salesRootPartNumberDataSource: any[]
  salesRootPartNumberDropDown

  constructor(
    private send: SendRequestService,
    private toastr: ToastrService,
    private permission: PermissionService) {
  }

  async ngOnInit() {
    this.historyIconClick = this.historyIconClick.bind(this)

    await this.populateSalesRootPartNumber()
    this.setSalesRootPartNumberValue = this.setSalesRootPartNumberValue.bind(this)

    this.pagePermission = this.permission.getUserPermissions()
    this.configureColumns()
  }

  configureColumns() {
    const createMainColumns = (columns: Column[]): Column[] => {
      const mainColumns = [...columns]
      mainColumns.forEach((column) => {
        if (
          !this.fieldsAllowEditing.includes(column.dataField) &&
          !this.fieldsCreateOnly.includes(column.dataField)
        ) {
          column.allowEditing = false
        } else {
          column.allowEditing = true
        }
        if (this.fieldsRequired.includes(column.dataField)) {
          column.validationRules = [{ type: 'required' }]
        }
        if (column.dataField === "salesRootPartNumber") {
          column.editCellTemplate = "salesRootPartNumberEditor"
          column.setCellValue = this.setSalesRootPartNumberValue
        }
        if (column.dataField === "deleteFlag") {
          column.lookup = { dataSource: this.yesNoDataSource }
        }
      })
      mainColumns.push({
        type: "buttons",
        fixed: true,
        fixedPosition: "right",
        buttons: ["edit", {
          hint: "Show History",
          text: "History",
          onClick: this.historyIconClick
        }]
      })
      return mainColumns
    }
    const createHistoryColumns = (columns: Column[]): Column[] => {
      const historyColumns: Column[] = [
        { dataField: `${this.tableName}_HIS_ID`, caption: "History ID" },
        ...columns.map(column => ({
          dataField: column.dataField,
          caption: column.caption,
          dataType: column.dataType,
          format: column.format,
          visible: column.visible
        }))
      ]

      const updateDateColumn = historyColumns.find(col => col.dataField === "updateDateAndTime")
      if (updateDateColumn) {
        updateDateColumn.sortOrder = "desc"
      }

      return historyColumns
    }
    const url: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=${this.tableName}`
    this.send.sendRequest(url, "GET", "").subscribe(
      data => {
        this.columnConfig = createMainColumns(data)
        this.deltaUploadColumnConfig = data
        this.historyColumnConfig = createHistoryColumns(data)

        this.setDataSource()
      }
    )
  }

  setDataSource() {
    let url: string = `${environment.ServiceURL_Main}${this.endpoint}`
    this.dataSource = new DataSource({
      store: this.send.sendRequestVirtualConfigurable({
        key: this.dataGridKey,
        loadUrl: url + "/GetAll",
        insertUrl: url,
        updateUrl: url,
      })
    })
  }

  postGridRow(e, action) {
    if (action == 'edit') { e.newData = { ...e.oldData, ...e.newData } }
  }

  async postedGridRow(e, action) {
    if (action == 'create') { this.toastr.success('Record created successfully', 'Success!') }
    if (action == 'edit') { this.toastr.success('Record modified successfully', 'Success!') }
    if (action == 'delete') { this.toastr.success('Record deleted successfully', 'Success!') }
  }

  historyIconClick(e) {
    const ID = e.row.data[this.dataGridKey]
    if (!ID) {
      this.toastr.error("Invalid/No ID", null, errorToastOptions)
      return
    }
    this.historyPopup.open(ID)
  }

  onEditorPreparing(e) {
    for (const dataField of this.fieldsCreateOnly) {
      if (e.parentType === "dataRow" && e.dataField === dataField) {
        if (e.row.isNewRow) {
          e.editorOptions.readOnly = false //enabled when new row
        } else {
          e.editorOptions.readOnly = true //disabled when existing row
        }
      }
    }
    for (const dataField of this.fieldsAllowEditing) {
      if (e.parentType === "dataRow" && e.dataField === dataField) {
        e.editorOptions.readOnly = false
      }
    }
    // editCellTemplate does not get triggered by onEditorPreparing
    // borrow the event from recordKey to set lineName and supplyLegacyLine readOnly
    if (e.parentType === "dataRow" && e.dataField === "recordKey") {
      // this.setLinesDropdownReadOnly(e)
    }
  }

  openDeltaUpload() {
    if (this.dataSource.isLoaded()) {
      this.deltaUpload.openUploadPopup()
    }
  }

  onInitNewRow(e) {
    e.data.activeFlag = "1"
  }

  saveButtonDisabled(): boolean {
    return !this.dataGrid?.instance.hasEditData()
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }

  async populateSalesRootPartNumber() {
    // const url: string = `${environment.ServiceURL_Main}CfgProductV2/GetSalesRootPartNumber`
    // try {
    //   const data = await firstValueFrom(this.send.sendRequest(url, "GET"))
    // } catch (error) {
    //   this.resetSalesRootPartNumberData()
    //   if (error?.status === 404) {
    //     this.toastr.error(`Sales Root Part Number DropDown Error`, null, errorToastOptions)
    //   }
    // }


    this.salesRootPartNumberDropDown = new DataSource({
      store: new CustomStore({
        key: "partNumber",

        load: async (loadOptions) => {
          const search = loadOptions.searchValue || "";

          const data: any[] = await firstValueFrom(
            this.send.sendRequest(
              `${environment.ServiceURL_Main}CfgProductV2/SearchSalesRootPartNumber?search=${encodeURIComponent(search)}`,
              "GET"
            )
          );

          if (!data || data.length === 0) {
            // if (search) {

            // }
            this.toastr.warning(
              "Sales Root Part Number Not Found",
              "",
              { timeOut: 3000 }
            );
          }
          return data;
        }

        ,

        byKey: async (key) => {
          const data: any[] = await firstValueFrom(
            this.send.sendRequest(
              `${environment.ServiceURL_Main}CfgProductV2/SearchSalesRootPartNumber?search=${encodeURIComponent(key)}`,
              "GET"
            )
          );

          return data.find(x => x.partNumber === key);
        }
      })
    });


  }

  onSalesRootPartNumberChanged(e, cellInfo) {
    if (e.value !== cellInfo.value) {
      cellInfo.setValue(e.value);
    }

    // force grid to detect edit
    this.dataGrid.instance.repaint();
  }

  // onSalesRootPartNumberOpened(e: any) {
  //   e.component.getDataSource().load();
  // }


  resetSalesRootPartNumberData() {
    this.salesRootPartNumberDataSource = null
    this.salesRootPartNumberDropDown = null
  }

  setSalesRootPartNumberValue(newData, value) {
    // const filtered = this.salesRootPartNumberDataSource.filter(item =>
    //   item.salesRootPartNumber === value
    // )
    // newData.salesRootPartNumber = filtered[0].salesRootPartNumber
    // newData.salesRootPartNumber = value
    newData.salesRootPartNumber = value;
  }

}


