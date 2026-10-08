import { Component, Input } from '@angular/core'
import { CustomStore } from 'devextreme-aspnet-data-nojquery'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { SendRequestService } from '../../../service/base/send-request.service'
import { environment } from '../../../../environments/environment'
import { exportGridToExcel } from '../../utils/exportGridToExcel'

import { ToastrService } from 'ngx-toastr'
import { DxDataGridComponent } from 'devextreme-angular';
import { ViewChild } from '@angular/core';
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { confirm } from 'devextreme/ui/dialog';
import { firstValueFrom } from 'rxjs'
// import DataGrid from 'devextreme/ui/data_grid';
// import CheckBox from 'devextreme/ui/check_box';


@Component({
  selector: 'app-basic-datagrid',
  templateUrl: './basic-datagrid.component.html',
  styleUrls: ['./basic-datagrid.component.scss']
})
export class BasicDatagridComponent {

  @Input() PageTitle: string
  @Input() tableName: string
  @Input() endpoint: string
  @Input() key: string[] | string

  dataSource: CustomStore
  columnsConfig: Column[]

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

  constructor(private toastr: ToastrService, private send: SendRequestService) { }

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
  //     }
  //   )
  // }
  configureDatagrid() {
    const url: string =
      `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=${this.tableName}`;

    this.send.sendRequest(url, 'GET', '').subscribe(data => {
      this.columnsConfig = data.map((column: Column) => {
        if (column.dataType === 'date') {
          return {
            ...column,
            dataType: 'date',
            format: 'yyyy-MM-dd',
            allowHeaderFiltering: false
          };
        }

        return column;
      });

      this.getDataSource();
    });
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
    }

    else if (this.tableName === 'V_MDM_PRODUCTION_GROUP_STAGE') {
      this.processStatus3_url = `${environment.ServiceURL_Main}get_MDM_PRODUCTION_GROUP_STAGE_processStatus?processStatus=` + this.repushStatus3
      this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_MDM_PRODUCTION_GROUP_STAGE?`;
    } else if (this.tableName === 'V_MDM_PRODUCTION_GROUP_STAGE_CONVERSION') {
      this.processStatus3_url = `${environment.ServiceURL_Main}get_MDM_PRODUCTION_GROUP_STAGE_CONVERSION_processStatus?processStatus=` + this.repushStatus3
      this.repush_url = `${environment.ServiceURL_Main}STATUS_CHANGE_3_MDM_PRODUCTION_GROUP_STAGE_CONVERSION?`;
    } else if (this.tableName === 'V_MDM_PRODUCTION_PLANT_CONVERSION') {
      this.processStatus3_url = `${environment.ServiceURL_Main}get_MDM_PRODUCTION_PLANT_CONVERSION_processStatus?processStatus=` + this.repushStatus3
      this.repush_url = `${environment.ServiceURL_Main}get_MDM_PRODUCTION_PLANT_CONVERSION_processStatus?`;
    }

    else if (this.tableName === 'OUT_APP_APPLICATION1') {
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


    try {
      const PSdata = await firstValueFrom(this.send.sendRequest(this.processStatus3_url, 'POST', null))
      console.log(PSdata);
      if (PSdata.length + this.selectedRows.length > this.processStatus3Limit) {
        this.toastr.error(this.selectedRows.length + " selceted record(s) and " + PSdata.length + " existing Process Status '3' records exceed the limit of " + this.processStatus3Limit + ".", "Error!", errorToastOptions)
        return;
      }
    } catch (error) {
      this.toastr.error(error.message, "Error!", errorToastOptions);
    }

    this.confirmMsg = this.selectedRows.length + " row(s) has been selected. Are you sure you want to proceed Repush for the selected records?";

    const result = confirm(
      this.confirmMsg,
      "Confirmation"
    );

    result.then((dialogResult) => {
      if (!dialogResult) {
        return;
      }

      let pns = '';
      if (this.tableName === 'MDM_PRODUCT_HIERARCHY_V2') {
        for (const row of this.selectedRows) {
          console.log(row.applicationLevel1Code);
          if (pns === '') {
            pns = 'phCodes=' + encodeURIComponent(row.phCode);
          } else {
            pns = pns + '&phCodes=' + encodeURIComponent(row.phCode);
          }
        }
      } else if (this.tableName === 'MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION_V2') {
        for (const row of this.selectedRows) {
          console.log(row.applicationLevel1Code);
          if (pns === '') {
            pns = 'productHierarchyCodes=' + encodeURIComponent(row.productHierarchyCode);
          } else {
            pns = pns + '&productHierarchyCodes=' + encodeURIComponent(row.productHierarchyCode);
          }
        }
      } else if (this.tableName === 'MDM_PRODUCTION_STAGE') {
        for (const row of this.selectedRows) {
          console.log(row.applicationLevel1Code);
          if (pns === '') {
            pns = 'stages=' + encodeURIComponent(row.stage);
          } else {
            pns = pns + '&stages=' + encodeURIComponent(row.stage);
          }
        }
      } else if (this.tableName === 'MDM_PRODUCTION_STAGE_CONVERSION') {
        for (const row of this.selectedRows) {
          console.log(row.applicationLevel1Code);
          if (pns === '') {
            pns = 'p_sll_s=' + encodeURIComponent(row.stage + '_' + row.legacyType + '_' + row.legacyStage);
          } else {
            pns = pns + '&p_sll_s=' + encodeURIComponent(row.stage + '_' + row.legacyType + '_' + row.legacyStage);
          }
        }
      } else {
        for (const row of this.selectedRows) {
          console.log(row.applicationLevel1Code);
          if (pns === '') {
            pns = 'recordKeys=' + encodeURIComponent(row.recordKey);
          } else {
            pns = pns + '&recordKeys=' + encodeURIComponent(row.recordKey);
          }
        }
      }

      this.send.sendRequest(this.repush_url + pns, 'POST', null)
        .subscribe({
          next: async (res: any) => {
            this.toastr.success(res.Result);
            this.selectedRows = [];
            this.dataGrid.instance.clearSelection();
            await this.dataGrid.instance.refresh();
            this.dataGrid.instance.clearSelection();
          },
          error: (error: any) => {
            this.toastr.error(error.message, "Error!", errorToastOptions);
          }
        });
    });
  }
}
