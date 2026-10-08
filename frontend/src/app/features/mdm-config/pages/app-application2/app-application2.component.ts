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


type JsonRecord = Record<string, unknown>;

interface LogPushGrid {
  columns: {
    caption: string;
    calculateCellValue: (row: JsonRecord) => string | number | boolean;
  }[];
  records: JsonRecord[];
}

export class LogPushComponent {
  logPushGrids: LogPushGrid[] = [];

  async getLogPush(): Promise<void> {
    // Your getLogPush code goes here
  }
}


@Component({
  selector: 'app-app-application2',
  templateUrl: './app-application2.component.html',
  styleUrl: './app-application2.component.scss'
})

export class AppApplication2Component {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @ViewChild(DeltaUploadComponent) deltaUpload: DeltaUploadComponent
  @ViewChild(ConfigHistoryPopupComponent) historyPopup: ConfigHistoryPopupComponent

  PageTitle: string = "Application 2 Maintenance"
  endpoint: string = "CfgAppApplication2"
  tableName: string = "CFG_APP_APPLICATION2"
  dataSource: DataSource
  pagePermission: PagePermission
  dataGridKey: string = "recordKey"
  fieldsAllowEditing: string[] = [
    "applicationLevel2Name",
    "applicationLevel1Code",
    "deleteFlag"
  ]
  fieldsRequired: string[] = [
    "applicationLevel2Code",
    "deleteFlag"
  ]
  fieldsCreateOnly: string[] = [
    "applicationLevel2Code"
  ]
  yesNoDataSource = ["Y", "N"]

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

  applicationLevel1CodeDataSource: any[]
  applicationLevel1CodeDropDown: string[]



  logPushGrids: LogPushGrid[] = [];


  constructor(
    private send: SendRequestService,
    private toastr: ToastrService,
    private permission: PermissionService) {
  }

  async ngOnInit() {
    this.historyIconClick = this.historyIconClick.bind(this)

    await this.populateApplicationLevel1Code()
    this.setApplicationLevel1CodeValue = this.setApplicationLevel1CodeValue.bind(this)

    await this.getLogPush();

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
        if (column.dataField === "applicationLevel1Code") {
          column.editCellTemplate = "applicationLevel1CodeEditor"
          column.setCellValue = this.setApplicationLevel1CodeValue
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
    e.data.deleteFlag = "N"
  }
  saveButtonDisabled(): boolean {
    return !this.dataGrid?.instance.hasEditData()
  }
  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }

  async populateApplicationLevel1Code() {
    const url: string = `${environment.ServiceURL_Main}CfgAppApplication2/GetapplicationLevel1Code`
    try {
      const data = await firstValueFrom(this.send.sendRequest(url, "GET"))
      this.applicationLevel1CodeDataSource = data
      this.applicationLevel1CodeDropDown = Array.from(new Set(this.applicationLevel1CodeDataSource.map(item => item.applicationLevel1Code)))
    } catch (error) {
      this.resetApplicationLevel1CodesData()
      if (error?.status === 404) {
        this.toastr.error(`applicationLevel1Code DropDown Error`, null, errorToastOptions)
      }
    }
  }

  resetApplicationLevel1CodesData() {
    this.applicationLevel1CodeDataSource = null
    this.applicationLevel1CodeDropDown = null
  }

  setApplicationLevel1CodeValue(newData, value) {
    const filtered = this.applicationLevel1CodeDataSource.filter(item =>
      item.applicationLevel1Code === value
    )
    newData.applicationLevel1Code = filtered[0].applicationLevel1Code
    newData.applicationLevel1Code = value
  }


  async getLogPush(): Promise<void> {
    // const url = `${environment.ServiceURL_Main}CfgAppApplication2/getLogPush`;
    const url = `${environment.ServiceURL_Main}CfgAppApplication2/GetApplicationLevel1Code2`;

    try {
      const logs = await firstValueFrom(
        this.send.sendRequest(url, 'GET')
      ) as Record<string, unknown>[];

      this.logPushGrids = logs.map(log => {
        // Handles JSON_DATA, jsonData, or jsoN_DATA from different API settings.
        const jsonData = Object.entries(log)
          .find(([key]) => key.toLowerCase().replace(/_/g, '') === 'jsondata')?.[1];

        const parsed: unknown = JSON.parse(
          typeof jsonData === 'string' ? jsonData : '[]'
        );

        if (
          !Array.isArray(parsed) ||
          !parsed.every(item => item !== null && typeof item === 'object' && !Array.isArray(item))
        ) {
          throw new Error('JSON_DATA must contain an array of objects');
        }

        const records = parsed as JsonRecord[];
        const fieldNames = [...new Set(records.flatMap(record => Object.keys(record)))];

        return {
          records,
          columns: fieldNames.map(field => ({
            caption: field,
            calculateCellValue: (row: JsonRecord) => {
              const value = row[field];

              if (value == null) return '';
              if (typeof value === 'object') return JSON.stringify(value);

              return value as string | number | boolean;
            }
          }))
        };
      });
    } catch (error) {
      this.logPushGrids = [];
      console.error('Failed to load or parse LOG_PUSH data', error);
      this.toastr.error('LogPush Error', undefined, errorToastOptions);
    }
  }
}
