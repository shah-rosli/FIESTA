import { ExportingEvent } from "devextreme/ui/data_grid"
import { Workbook } from 'exceljs'
import { saveAs } from 'file-saver'
import { exportDataGrid } from 'devextreme/excel_exporter'

export function exportGridToExcel(e: any, fileName: string) {
  const workbook = new Workbook()
  const worksheet = workbook.addWorksheet('Sheet')

  exportDataGrid({
    component: e.component,
    worksheet,
  }).then(() => {
    workbook.xlsx.writeBuffer().then((buffer) => {
      saveAs(new Blob([buffer], { type: 'application/octet-stream' }), `${fileName}.xlsx`)
    })
  })
}