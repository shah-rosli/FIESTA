import { Component, Input, ViewChild } from '@angular/core'
import { DxDataGridComponent, DxFileUploaderComponent } from 'devextreme-angular'
import { Workbook } from 'exceljs'
import saveAs from 'file-saver'
import { ToastrService } from 'ngx-toastr'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { Column } from 'devextreme/ui/data_grid'
import { environment } from '../../../../../environments/environment'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { confirm } from 'devextreme/ui/dialog'

interface payloadStructure {
  id: number
  insertOrUpdate: "Insert" | "Update"
  bulkImportObj: Record<string, number | string | boolean>
  haveError: boolean
  errorMessage: string
  haveDifference: boolean
  selected: boolean
}

@Component({
  selector: 'app-delta-upload',
  templateUrl: './delta-upload.component.html',
  styleUrls: ['./delta-upload.component.scss']
})
export class DeltaUploadComponent {
  @Input("PageTitle") PageTitle: string
  @Input("columnConfig") columnConfig: Column[]
  @Input("dataGrid") parentMainDataGrid: DxDataGridComponent
  @Input("endpoint") endpoint: string

  @ViewChild("review") reviewDataGrid: DxDataGridComponent
  @ViewChild(DxFileUploaderComponent) fileUploader: DxFileUploaderComponent

  pageIsLoading: boolean = false
  uploadPopup: boolean = false
  selectedFile: File[] = []
  fileIsValid: boolean = false
  isDropZoneActive: boolean = false
  reviewPopup: boolean = false
  reviewColumnConfig: Column[] = []
  reviewDataSource: payloadStructure[] = []
  reviewSummary = {
    insertCount: 0,
    updateCount: 0,
    errorCount: 0,
    noChangeCount: 0
  }

  nextButtonOptions = {
    text: "Next",
    stylingMode: "outlined",
    type: "normal",
    onClick: () => this.validateSelectedFile()
  }

  downloadErrorButtonOptions = {
    text: "Download Error Log",
    stylingMode: "outlined",
    type: "normal",
    onClick: () => this.downloadErrorLog()
  }

  closeButtonOptions = {
    text: "Cancel",
    stylingMode: "outlined",
    type: "normal",
    onClick: () => this.closeReviewPopup()
  }

  saveChangesButtonOptions = {
    text: "Save Changes",
    stylingMode: "outlined",
    type: "normal",
    onClick: () => this.saveChanges()
  }

  constructor(
    private send: SendRequestService,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.setReviewColumn(this.columnConfig)
  }

  setReviewColumn(columnConfig) {
    const staticPart: Column[] = [
      {
        dataField: "insertOrUpdate",
        caption: "Mode"
      },
      {
        dataField: "errorMessage",
        caption: "Error",
        sortOrder: "desc"
      }
    ]
    const dynamicPart = columnConfig.map(config => ({
      dataField: `bulkImportObj.${config.dataField}`,
      caption: config.caption,
      dataType: config.dataType,
      format: config.format,
    }))
    this.reviewColumnConfig = staticPart.concat(dynamicPart)
  }

  openUploadPopup() {
    this.uploadPopup = true
  }

  closeUploadPopup() {
    this.uploadPopup = false
  }

  openReviewPopup() {
    this.setReviewColumn(this.columnConfig)
    this.reviewPopup = true
  }

  closeReviewPopup() {
    this.reviewPopup = false
  }

  removeSelectedFile() {
    this.fileUploader.instance.removeFile(this.fileUploader.value[0])
    this.fileIsValid = false
  }

  onUploaderDropZoneEnter() {
    this.isDropZoneActive = true
  }

  onUploaderDropZoneLeave() {
    this.isDropZoneActive = false
  }

  onSelectedFileChanged(e) {
    this.onUploaderDropZoneLeave()
    // validation
    const files = e.value
    const fileExtension = files[0].name.slice(-5)
    if (fileExtension === ".xlsx") {
      this.fileIsValid = true
    } else {
      this.fileIsValid = false
    }
  }

  onExportSampleFile() {
    const workbook = new Workbook()
    const worksheet = workbook.addWorksheet("Sheet")

    // set column width
    const MAX_DIGIT_WIDTH_IN_PIXELS = 7
    const MAX_EXCEL_COLUMN_WIDTH = 255
    this.parentMainDataGrid.instance.getVisibleColumns().forEach((column: any, index) => {
      const columnWidth = column.visibleWidth
      const excelIndex = index + 1
      if ("number" === typeof columnWidth && isFinite(columnWidth)) {
        worksheet.getColumn(excelIndex).width = Math.min(MAX_EXCEL_COLUMN_WIDTH, Math.floor(columnWidth / MAX_DIGIT_WIDTH_IN_PIXELS * 100) / 100)
      }
    })

    // fill the header cells
    const excelHeader = worksheet.getRow(1)
    this.columnConfig.forEach((column, index) => {
      const excelIndex = index + 1
      const excelCell = excelHeader.getCell(excelIndex)
      excelCell.value = column.caption
      excelCell.style = {
        "font": {
          "bold": true
        },
        "alignment": {
          "wrapText": false,
          "horizontal": "center",
          "vertical": "top"
        }
      }
    })
    worksheet.views = [
      { state: "frozen", ySplit: 1 }
    ]

    // write and save file
    workbook.xlsx.writeBuffer()
      .then((buffer: BlobPart) => {
        saveAs(new Blob([buffer], { type: "application/octet-stream" }), `Example ${this.PageTitle}.xlsx`)
      })
  }

  validateSelectedFile() {
    const errorReadFile = (message) => {
      this.toastr.error(message, null, errorToastOptions)
      this.pageIsLoading = false
      this.removeSelectedFile()
    }

    const startTime = Date.now()
    const tenSeconds = 10 * 1000

    this.pageIsLoading = true
    const userSelectedFile: File = this.selectedFile[0]

    const reader = new FileReader()
    reader.readAsArrayBuffer(userSelectedFile)
    reader.onerror = () => errorReadFile("Fail to read file. File was modified after selected.")
    reader.onload = async () => {
      const formData = new FormData()

      try {
        const buffer = reader.result
        if (!(buffer instanceof ArrayBuffer)) {
          throw new Error("Buffer not type ArrayBuffer")
        }

        let workbook = new Workbook()
        workbook = await workbook.xlsx.load(buffer)
        const firstSheet = workbook.worksheets[0]
        const headerRow = firstSheet.getRow(1)
        headerRow.eachCell((cell) => {
          // rename header from caption to dataField
          const column = this.columnConfig.find((column) => column.caption === cell.value)
          if (column) {
            cell.value = column.dataField
          }
        })

        const writtenBuffer = await workbook.xlsx.writeBuffer()
        // saveAs(new Blob([writtenBuffer], { type: "application/octet-stream" }), `Debug ${this.PageTitle}.xlsx`) // keep this for debugging
        const file = new File([writtenBuffer], userSelectedFile.name, { type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" })
        formData.append("upload", file, file.name)
      } catch (error) {
        console.error(error)
        errorReadFile("Fail to process file. Please check the file and try again.")
        return
      }

      const duration = Date.now() - startTime
      if (duration > tenSeconds) {
        this.toastr.info("Processing complete, sending to server")
      }

      const url = `${environment.ServiceURL_Main}${this.endpoint}/ValidateUpload`
      this.send.sendRequestFormData(url, formData).subscribe(
        (response: { Data: payloadStructure[] }) => {
          this.reviewDataSource = response.Data.filter(item => item.haveDifference === true)
          this.calcReviewSummary(response.Data)
          this.closeUploadPopup()
          this.openReviewPopup()
          this.pageIsLoading = false
        },
        response => {
          this.pageIsLoading = false
          this.removeSelectedFile()
          this.toastr.error(response.error.ErrorMsg, null, errorToastOptions)
        }
      )
    }
  }

  async saveChanges() {
    this.pageIsLoading = true

    if (this.reviewDataSource.length < 1) {
      this.toastr.info("There are no changes to be saved.")
      this.pageIsLoading = false
      return
    }

    if (this.reviewDataSource.some(item => item.haveError === true)) {
      if (this.reviewDataSource.length === this.reviewDataSource.filter(item => item.haveError === true).length) {
        this.toastr.info("There are no changes to be saved. All lines have error.")
        this.pageIsLoading = false
        return
      }

      this.pageIsLoading = false
      let confirmed = await confirm(
        "Continue save changes on validated records?<br>Note: Please download the error log for your reference before proceed.",
        "Confirm"
      )

      if (!confirmed) {
        return
      }

      this.pageIsLoading = true
    }

    for (const item of this.reviewDataSource) {
      item.selected = true
    }

    const url = `${environment.ServiceURL_Main}${this.endpoint}/PerformUpload`
    this.send.sendRequest(url, "POST", []).subscribe(
      data => {
        this.displayResponseMessage(data)
        this.pageIsLoading = false
        this.closeReviewPopup()
        this.parentMainDataGrid.instance.refresh()
      },
      error => {
        this.pageIsLoading = false
      }
    )
  }

  onRowPrepared(e) {
    if (e.rowType === "data") {
      if (e.data.haveError === true) {
        e.rowElement.classList.add("invalid-row")
      }
    }
  }

  displayResponseMessage(response) {
    if (response.InfoMsg) {
      this.toastr.info(response.InfoMsg, "Info")
    } else if (response.SuccessMsg) {
      this.toastr.success(response.SuccessMsg, "Success")
    } else if (response.WarningMsg) {
      this.toastr.warning(response.WarningMsg, "Warning")
    } else if (response.ErrorMsg) {
      this.toastr.warning(response.ErrorMsg, "Error")
    }
  }

  calcReviewSummary(data: payloadStructure[]) {
    let insertCount = 0, updateCount = 0, noChangeCount = 0, errorCount = 0
    for (const row of this.reviewDataSource) {
      if (row.insertOrUpdate === "Insert") {
        insertCount++
      } else if (row.insertOrUpdate === "Update") {
        updateCount++
      }

      if (row.haveError) {
        errorCount++
      }
    }

    noChangeCount = data.filter(x => x.haveDifference === false && x.haveError === false).length

    this.reviewSummary = {
      insertCount: insertCount,
      updateCount: updateCount,
      errorCount: errorCount,
      noChangeCount: noChangeCount
    }
  }

  downloadErrorLog() {
    exportGridToExcel({ component: this.reviewDataGrid.instance }, "Error Log")
  }
}
