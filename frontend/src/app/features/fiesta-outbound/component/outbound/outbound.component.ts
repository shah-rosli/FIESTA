import { Component, Input } from '@angular/core'
import { environment } from '../../../../../environments/environment'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { CustomStore } from 'devextreme-aspnet-data-nojquery'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'

import { ToastrService } from 'ngx-toastr'
import { DxDataGridComponent } from 'devextreme-angular';
import { ViewChild } from '@angular/core';
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { confirm } from 'devextreme/ui/dialog';
import { firstValueFrom } from 'rxjs'

@Component({
  selector: 'app-outbound',
  templateUrl: './outbound.component.html',
  styleUrls: ['./outbound.component.scss']
})

export class OutboundComponent {
  @Input() PageTitle: string
  @Input() tableName: string
  @Input() endpoint: string
  @Input('download') downloadMode: "api" | "devextreme" | "both"
  @Input() key: string | string[] = "recordKey";

  dataSource: CustomStore
  columnsConfig: Column[]
  exportBtn = {
    visible: false,
    message: ''
  }

  //FilterPanel parameter (optional)
  @Input() showFilterPanel = false;
  //repush parameter (optional)
  @Input() allowRepush = false;
  selectedRows: any[] = [];
  skipUncheck = false;
  //for repush
  processStatus2: string = '2';
  repushStatus3: string = '3';
  processStatus2_count: number = 0;
  confirmMsg: string;
  processStatus3_url
  repush_url
  processStatus3Limit = 1000;
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;


  urlFileName: string;
  urlExport: string;

  isLoading = false;

  constructor(private toastr: ToastrService,
    private send: SendRequestService,
  ) { }

  ngOnInit(): void {

    if (
      this.tableName == "OUT_PRODUCT_ECCN_CONVERSION"
      || this.tableName == "OUT_PRODUCT_HS_CONVERSION"
      || this.tableName == "OUT_PRODUCT_STANDARD_COST"
      || this.tableName == "OUT_PRODUCT_SALES_ROOT_PARTNUMBER"
      || this.tableName == "OUT_PRODUCT_WIP_SELL_PRICE"
      || this.tableName == "OUT_PRODUCT_TYPE"
      || this.tableName == "OUT_PRODUCT_LINE"
      || this.tableName == "OUT_PRODUCT_HISTORICAL"

      || this.tableName == "OUT_APP_APPLICATION1"
      || this.tableName == "OUT_APP_APPLICATION2"
      || this.tableName == "OUT_APP_APPLICATION3"
      || this.tableName == "OUT_CUS_BILL_TO"
      || this.tableName == "OUT_CUS_SHIP_TO"
      || this.tableName == "OUT_CUS_SOLD_TO"
      || this.tableName == "OUT_CUS_END_CUSTOMER"
      || this.tableName == "MDM_PROFIT_CENTER_HIERARCHY_V2"
      || this.tableName == "OUT_FIN_IP_CUSTOMER"
      || this.tableName == "OUT_FIN_IP_OPN"
      || this.tableName == "V_MDM_PLANTS"
      || this.tableName == "V_MDM_STORAGE_LOCATION"
      || this.tableName == "V_MDM_COMPANY_CODE"
      || this.tableName == "OUT_VEN_VENDOR"
      || this.tableName == "OUT_VEN_VENDOR_COMPANY"
      || this.tableName == "OUT_VEN_VENDOR_PURCHASE_INFO_REC"
      || this.tableName == "V_MDM_PRODUCTION_GROUP_STAGE"
      || this.tableName == "V_MDM_PRODUCTION_GROUP_STAGE_CONVERSION"
      || this.tableName == "V_MDM_PRODUCTION_PLANT_CONVERSION"
    ) {
      this.processStatus2 = '1';
      this.repushStatus3 = '0';
    } else {
      this.processStatus2 = '2';
      this.repushStatus3 = '3';
    }

    this.configureDatagrid()
    this.initExportBtn()
  }

  getDataSource() {
    const url: string = `${environment.ServiceURL_Main}${this.endpoint}`
    this.dataSource = this.send.sendRequestVirtual(this.key, url)
  }

  // configureDatagrid() {
  //   const url: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=${this.tableName}`
  //   this.send.sendRequest(url, "GET", "").subscribe(
  //     data => {
  //       this.columnsConfig = data
  //       this.getDataSource()
  //       this.enableFilterToSeconds(this.columnsConfig)
  //     }
  //   )
  // }


  configureDatagrid() {
    const url =
      `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=${this.tableName}`;

    this.send.sendRequest(url, 'GET', '').subscribe(data => {
      this.columnsConfig = data.map((column: Column) => {
        //if (column.dataField === 'P3ExpirationDate') {
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

      this.enableFilterToSeconds(this.columnsConfig);
      this.getDataSource();
    });
  }

  enableFilterToSeconds(columnConfig) {
    columnConfig.forEach((config) => {
      const condition = config.dataField === "createDateAndTime" ||
        config.dataField === "updateDateAndTime" ||
        config.dataField === "deleteDateAndTime"
      if (condition) {
        config.calculateFilterExpression = function (filterValue, selectedFilterOperation) {
          console.log("Type:", typeof filterValue, { filterValue, selectedFilterOperation })

          // when user using filter header, skip
          if (typeof filterValue === 'string' || typeof filterValue === 'number') {
            return this.defaultCalculateFilterExpression.apply(this, arguments)
          }

          let dateStart = filterValue
          let dateEnd = new Date(dateStart)
          dateEnd.setSeconds(dateEnd.getSeconds() + 1)

          if (selectedFilterOperation === "=") {
            let filterExpression = [
              [this.dataField, ">=", dateStart],
              "and",
              [this.dataField, "<", dateEnd]
            ]
            return filterExpression
          }

          if (selectedFilterOperation === "<>") {
            let filterExpression = [
              [this.dataField, "<", dateStart],
              "or",
              [this.dataField, ">=", dateEnd]
            ]
            return filterExpression
          }

          if (selectedFilterOperation === "<") {
            let filterExpression = [
              [this.dataField, "<", dateStart]
            ]
            return filterExpression
          }

          if (selectedFilterOperation === ">") {
            let filterExpression = [
              [this.dataField, ">=", dateEnd]
            ]
            return filterExpression
          }

          if (selectedFilterOperation === "<=") {
            let filterExpression = [
              [this.dataField, "<=", dateEnd]
            ]
            return filterExpression
          }

          if (selectedFilterOperation === ">=") {
            let filterExpression = [
              [this.dataField, ">=", dateStart]
            ]
            return filterExpression
          }

          return this.defaultCalculateFilterExpression.apply(this, arguments)
        }
      }
    })
  }

  initExportBtn() {
    this.updateExportBtn()
  }

  updateExportBtn(callback?) {
    // const url: string = `${environment.ServiceURL_Main}CfgSysTableConfig?tableName=${this.tableName}`

    // if (this.tableName == "OUT_PRODUCT_CONSOLIDATE") {
    //   this.urlFileName = `${environment.ServiceURL_Main}CfgSysTableConfig?tableName=PRODUCT_PRODUCT`
    // } else if (this.tableName == "OUT_PRODUCT_PLANT_CONSOLIDATE") {
    //   this.urlFileName = `${environment.ServiceURL_Main}CfgSysTableConfig?tableName=OUT_PRODUCT_PLANT`
    // } else if (this.tableName == "OUT_PRODUCT_SALES_CONSOLIDATE") {
    //   this.urlFileName = `${environment.ServiceURL_Main}CfgSysTableConfig?tableName=OUT_PRODUCT_SALES`
    // } else {
    //   this.urlFileName = `${environment.ServiceURL_Main}CfgSysTableConfig?tableName=${this.tableName}`
    // }
    this.urlFileName = `${environment.ServiceURL_Main}CfgSysTableConfig?tableName=${this.tableName}`


    this.send.sendRequest(this.urlFileName, "GET", "").subscribe(
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

      //const url: string = `${environment.ServiceURL_Main}DownloadFile?tableName=${this.tableName}`

      // if (this.tableName == "OUT_PRODUCT_CONSOLIDATE") {
      //   this.urlExport = `${environment.ServiceURL_Main}DownloadFile?tableName=PRODUCT_PRODUCT`
      // } else if (this.tableName == "OUT_PRODUCT_PLANT_CONSOLIDATE") {
      //   this.urlExport = `${environment.ServiceURL_Main}DownloadFile?tableName=OUT_PRODUCT_PLANT`
      // } else if (this.tableName == "OUT_PRODUCT_SALES_CONSOLIDATE") {
      //   this.urlExport = `${environment.ServiceURL_Main}DownloadFile?tableName=OUT_PRODUCT_SALES`
      // } else {
      //   this.urlExport = `${environment.ServiceURL_Main}DownloadFile?tableName=${this.tableName}`
      // }
      this.urlExport = `${environment.ServiceURL_Main}DownloadFile?tableName=${this.tableName}`


      this.send.sendRequestDownloadFile(this.urlExport, 'application/zip').subscribe(data => {
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

  handleRowPrepared(e: any): void {
    if (e.rowType !== 'data') return;

    const deleteFlag = e.data?.deleteFlag;

    if (deleteFlag === 'Y') {
      e.rowElement.style.color = 'red';
    }
  }

  //for repush checkbox
  onCellPrepared(e: any) {
    if (e.rowType === 'data' && e.column.command === 'select') {
      if (e.data.processStatus !== this.processStatus2
        // || e.data.partNumber === '#00003A00-AN00WP'
      ) {
        //e.cellElement.classList.add('disabled-selection');
        e.cellElement.closest('.dx-command-select')?.classList.add('disabled-selection');
      }
    }
  }
  // onCellPrepared(e: any) {
  //   if (e.rowType === 'data' && e.column.command === 'select') {

  //     if (e.data.processStatus !== this.processStatus2) {

  //       const checkbox = e.cellElement.querySelector('.dx-checkbox');

  //       if (checkbox) {
  //         //checkbox.classList.add('disabled-selection');
  //       }
  //     }
  //   }
  // }

  async onCellClick(e: any) {
    if (e.rowType === "header" && e.column.command === "select") {

      // setTimeout(() => {

      e.component.option('loadPanel.enabled', false);
      e.component.option('loadPanel.enabled', true);


      //const totalRows = e.component.getVisibleRows().length;

      //const totalRows = e.component.getDataSource().totalCount();
      const ds = e.component.getDataSource();
      console.log('totalRows: ' + ds.totalCount());

      const processStatusRows = ds.items().filter(x => x.processStatus === this.processStatus2);

      if (processStatusRows.length == 0) {
        e.component.clearSelection();
        this.selectedRows = [];
        this.toastr.error("No available records for Repush.", null, errorToastOptions)
      }
      else if (ds.totalCount() >= 1000) {
        e.component.clearSelection();
        this.selectedRows = [];
        this.toastr.error("Select all is not allowed when the grid contains more than 1000 records, please filter the grid less than 1000 records to perform Repush selection.", null, errorToastOptions)
      } else {
        this.selectedRows = await e.component.getSelectedRowsData();
        console.log('selectedRows: ' + this.selectedRows);

        if (this.selectedRows.length === ds.totalCount()) {
          console.log("Selected all rows");
          // e.component.clearSelection();
          /////////////////const rows = e.component.getSelectedRowsData();
          const invalidRows = this.selectedRows.filter(
            row => row.processStatus !== this.processStatus2
            // || row.partNumber === '#00003A00-AN00WP'
          );
          if (invalidRows.length) {
            e.component.deselectRows(
              invalidRows.map(r => r.recordKey)
            );
          }
        } else if (this.selectedRows.length === 0) {
          console.log("Selected 0 rows");
        } else if (this.selectedRows.length < ds.totalCount()) {
          console.log("Selected some rows");
          e.component.clearSelection();
          this.selectedRows = [];
        } else {
          console.log("Unknown");
        }
      }

      // });

    } else if (e.rowType === "data" && e.column.command === "select") {

      const ds = e.component.getDataSource();
      const processStatusRows = ds.items().filter(x => x.processStatus === this.processStatus2);

      if (processStatusRows.length == 0) {
        e.component.clearSelection();
        this.selectedRows = [];
      } else {
        this.selectedRows = await e.component.getSelectedRowsData();

        const invalidRows = this.selectedRows.filter(
          row => row.processStatus !== this.processStatus2
          //|| row.partNumber === '#00003A00-AN00WP'
        );

        if (invalidRows.length) {

          if (this.tableName === 'MDM_PRODUCTION_STAGE') {
            e.component.deselectRows(
              invalidRows.map(r => r.stage)
            );
          } else if (this.tableName === 'MDM_PRODUCTION_STAGE_CONVERSION') {
            e.component.deselectRows(
              invalidRows.map(r => ({
                stage: r.stage,
                legacyType: r.legacyType,
                legacyStage: r.legacyStage
              }))
            );
          } else {
            e.component.deselectRows(
              invalidRows.map(r => r.recordKey)
            );
          }

        }
      }

      //this.selectedRows = e.component.getSelectedRowsData();
    }
  }

  repushButtonOptions = {
    text: 'Repush',
    type: 'success',
    onClick: () => this.onRepush()
  };

  async onRepush() {
    if (this.selectedRows.length == 0) {
      this.toastr.error("No row is selected to proceed Repush.", "Error!", errorToastOptions)
      return;
    }

    this.isLoading = true;

    try {
      this.processStatus3_url = '';
      this.repush_url = '';

      if (this.tableName === 'OUT_PRODUCT_CONSOLIDATE') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCT_CONSOLIDATE_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCT?`;
      } else if (this.tableName === 'OUT_PRODUCT_PLANT_CONSOLIDATE') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCT_PLANT_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCT_PLANT?`;
      } else if (this.tableName === 'OUT_PRODUCT_SALES_CONSOLIDATE') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCT_SALES_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCT_SALES?`;
      } else if (this.tableName === 'OUT_COMPONENTS') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_COMPONENTS_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_COMPONENTS?`;
      } else if (this.tableName === 'OUT_PRODUCT_VENDOR_CHAR') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCT_VENDOR_CHAR_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCT_VENDOR_CHAR?`;
      } else if (this.tableName === 'OUT_PRODUCT_MATRIX') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCT_MATRIX_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCT_MATRIX?`;
      } else if (this.tableName === 'OUT_PRODUCT_CAN_FLAGS4') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCT_CAN_FLAGS4_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCT_CAN_FLAGS4?`;
      } else if (this.tableName === 'OUT_PRODUCT_ECCN_CONVERSION') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCT_ECCN_CONVERSION_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCT_ECCN_CONVERSION?`;
      } else if (this.tableName === 'OUT_PRODUCT_HS_CONVERSION') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCT_HS_CONVERSION_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCT_HS_CONVERSION?`;
      } else if (this.tableName === 'OUT_PRODUCT_STANDARD_COST') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCT_STANDARD_COST_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCT_STANDARD_COST?`;
      } else if (this.tableName === 'OUT_PRODUCT_SALES_ROOT_PARTNUMBER') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCT_SALES_ROOT_PARTNUMBER_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCT_SALES_ROOT_PARTNUMBER?`;
      } else if (this.tableName === 'OUT_PRODUCT_WIP_SELL_PRICE') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCT_WIP_SELL_PRICE_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCT_WIP_SELL_PRICE?`;
      } else if (this.tableName === 'MDM_PRODUCT_HIERARCHY_V2') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_MDM_PRODUCT_HIERARCHY_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_MDM_PRODUCT_HIERARCHY?`;
      } else if (this.tableName === 'MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION_V2') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION?`;
      } else if (this.tableName === 'OUT_PRODUCT_TYPE') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCT_TYPE_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCT_TYPE?`;
      } else if (this.tableName === 'OUT_PRODUCT_LINE') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCT_LINE_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCT_LINE?`;
      } else if (this.tableName === 'OUT_PRODUCT_HISTORICAL') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCT_HISTORICAL_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCT_HISTORICAL?`;
      } else if (this.tableName === 'OUT_PRODUCTION_BOM') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCTION_BOM_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCTION_BOM?`;
      } else if (this.tableName === 'OUT_PRODUCTION_ROUTING') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCTION_ROUTING_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCTION_ROUTING?`;
      } else if (this.tableName === 'OUT_PRODUCTION_ROUTING_S4') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCTION_ROUTING_S4_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCTION_ROUTING_S4?`;
      } else if (this.tableName === 'OUT_PRODUCTION_VERSION') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCTION_VERSION_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCTION_VERSION?`;
      } else if (this.tableName === 'OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOS') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOS_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOS?`;
      } else if (this.tableName === 'OUT_PRODUCTION_LOTSIZE') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCTION_LOTSIZE_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCTION_LOTSIZE?`;
      } else if (this.tableName === 'OUT_PRODUCTION_YIELD') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCTION_YIELD_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCTION_YIELD?`;
      } else if (this.tableName === 'OUT_PRODUCTION_LEADTIME') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCTION_LEADTIME_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCTION_LEADTIME?`;
      } else if (this.tableName === 'OUT_PRODUCTION_CYCLETIME') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_PRODUCTION_CYCLETIME_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_PRODUCTION_CYCLETIME?`;
      } else if (this.tableName === 'MDM_PRODUCTION_STAGE') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_MDM_PRODUCTION_STAGE_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_MDM_PRODUCTION_STAGE?`;
      } else if (this.tableName === 'MDM_PRODUCTION_STAGE_CONVERSION') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_MDM_PRODUCTION_STAGE_CONVERSION_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_MDM_PRODUCTION_STAGE_CONVERSION?`;
      } else if (this.tableName === 'V_MDM_PRODUCTION_GROUP_STAGE') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_MDM_PRODUCTION_GROUP_STAGE_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_MDM_PRODUCTION_GROUP_STAGE?`;
      } else if (this.tableName === 'V_MDM_PRODUCTION_GROUP_STAGE_CONVERSION') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_MDM_PRODUCTION_GROUP_STAGE_CONVERSION_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_MDM_PRODUCTION_GROUP_STAGE_CONVERSION?`;
      } else if (this.tableName === 'V_MDM_PRODUCTION_PLANT_CONVERSION') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_MDM_PRODUCTION_PLANT_CONVERSION_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}get_MDM_PRODUCTION_PLANT_CONVERSION_processStatus?`;
      } else if (this.tableName === 'OUT_APP_APPLICATION1') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_APP_APPLICATION1_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_APP_APPLICATION1?`;
      } else if (this.tableName === 'OUT_APP_APPLICATION2') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_APP_APPLICATION2_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_APP_APPLICATION2?`;
      } else if (this.tableName === 'OUT_APP_APPLICATION3') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_APP_APPLICATION3_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_APP_APPLICATION3?`;
      } else if (this.tableName === 'OUT_CUS_BILL_TO') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_CUS_BILL_TO_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_CUS_BILL_TO?`;
      } else if (this.tableName === 'OUT_CUS_SHIP_TO') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_CUS_SHIP_TO_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_CUS_SHIP_TO?`;
      } else if (this.tableName === 'OUT_CUS_SOLD_TO') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_CUS_SOLD_TO_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_CUS_SOLD_TO?`;
      } else if (this.tableName === 'OUT_CUS_END_CUSTOMER') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_CUS_END_CUSTOMER_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_CUS_END_CUSTOMER?`;
      } else if (this.tableName === 'MDM_PROFIT_CENTER_HIERARCHY_V2') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_MDM_PROFIT_CENTER_HIERARCHY_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_MDM_PROFIT_CENTER_HIERARCHY?`;
      } else if (this.tableName === 'OUT_FIN_IP_CUSTOMER') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_FIN_IP_CUSTOMER_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_FIN_IP_CUSTOMER?`;
      } else if (this.tableName === 'OUT_FIN_IP_OPN') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_FIN_IP_OPN_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_FIN_IP_OPN?`;
      } else if (this.tableName === 'V_MDM_PLANTS') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_MDM_PLANTS_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_MDM_PLANTS?`;
      } else if (this.tableName === 'V_MDM_STORAGE_LOCATION') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_MDM_STORAGE_LOCATION_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_MDM_STORAGE_LOCATION?`;
      } else if (this.tableName === 'V_MDM_COMPANY_CODE') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_MDM_COMPANY_CODE_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_MDM_COMPANY_CODE?`;
      } else if (this.tableName === 'OUT_VEN_VENDOR') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_VEN_VENDOR_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_VEN_VENDOR?`;
      } else if (this.tableName === 'OUT_VEN_VENDOR_COMPANY') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_VEN_VENDOR_COMPANY_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_VEN_VENDOR_COMPANY?`;
      } else if (this.tableName === 'OUT_VEN_VENDOR_PURCHASE_INFO_REC') {
        this.processStatus3_url = `${environment.ServiceURL_Main}get_OUT_VEN_VENDOR_PURCHASE_INFO_REC_processStatus?processStatus=` + this.repushStatus3
        this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_OUT_VEN_VENDOR_PURCHASE_INFO_REC?`;
      }

      const PSdata = await firstValueFrom(
        this.send.sendRequest(this.processStatus3_url, 'POST', null)
      );

      if (PSdata.length + this.selectedRows.length > this.processStatus3Limit) {
        this.toastr.error(
          this.selectedRows.length + " selected record(s) and " + PSdata.length + " existing Process Status '3' records exceed the limit of " + this.processStatus3Limit + ".",
          "Error!",
          errorToastOptions
        );
        return;
      }

      this.confirmMsg = this.selectedRows.length + " row(s) has been selected. Are you sure you want to proceed Repush for the selected records?";
      const dialogResult = await confirm(this.confirmMsg, "Confirmation");

      if (!dialogResult) {
        return;
      }

      let pns = '';
      if (this.tableName === 'MDM_PRODUCT_HIERARCHY_V2') {
        for (const row of this.selectedRows) {
          pns += pns === ''
            ? 'phCodes=' + encodeURIComponent(row.phCode)
            : '&phCodes=' + encodeURIComponent(row.phCode);
        }
      } else if (this.tableName === 'MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION_V2') {
        for (const row of this.selectedRows) {
          pns += pns === ''
            ? 'productHierarchyCodes=' + encodeURIComponent(row.productHierarchyCode)
            : '&productHierarchyCodes=' + encodeURIComponent(row.productHierarchyCode);
        }
      } else if (this.tableName === 'MDM_PRODUCTION_STAGE') {
        for (const row of this.selectedRows) {
          pns += pns === ''
            ? 'stages=' + encodeURIComponent(row.stage)
            : '&stages=' + encodeURIComponent(row.stage);
        }
      } else if (this.tableName === 'MDM_PRODUCTION_STAGE_CONVERSION') {
        for (const row of this.selectedRows) {
          pns += pns === ''
            ? 'p_sll_s=' + encodeURIComponent(row.stage + '_' + row.legacyType + '_' + row.legacyStage)
            : '&p_sll_s=' + encodeURIComponent(row.stage + '_' + row.legacyType + '_' + row.legacyStage);
        }
      } else {
        for (const row of this.selectedRows) {
          pns += pns === ''
            ? 'recordKeys=' + encodeURIComponent(row.recordKey)
            : '&recordKeys=' + encodeURIComponent(row.recordKey);
        }
      }

      const res: any = await firstValueFrom(
        this.send.sendRequest(this.repush_url + pns, 'POST', null)
      );

      this.toastr.success(res.Result);
      this.selectedRows = [];
      this.dataGrid.instance.clearSelection();
      await this.dataGrid.instance.refresh();
      this.dataGrid.instance.clearSelection();

    } catch (error: any) {
      this.toastr.error(error?.message || "Unexpected error occurred.", "Error!", errorToastOptions);
    } finally {
      this.isLoading = false;
    }
  }
}
