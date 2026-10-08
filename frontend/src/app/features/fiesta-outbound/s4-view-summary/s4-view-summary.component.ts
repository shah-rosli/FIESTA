import { Component } from '@angular/core'
import { environment } from '../../../../environments/environment'
import { SendRequestService } from '../../../service/base/send-request.service'
import { Column } from 'devextreme/ui/data_grid'
import CustomStore from 'devextreme/data/custom_store'
import { timer } from 'rxjs'
import { map, switchMap, tap } from 'rxjs/operators'
import { calcRelativeTime } from 'src/app/shared/utils/calcRelativeTime'

@Component({
  selector: 'app-s4-view-summary',
  templateUrl: './s4-view-summary.component.html',
  styleUrls: ['./s4-view-summary.component.scss']
})
export class S4ViewSummaryComponent {
  PageTitle: string = "View Summary"
  dataSource: CustomStore
  columnsConfig: Column[]

  constructor(
    private send: SendRequestService,
  ) { }

  ngOnInit(): void {
    this.initDataSource()
  }

  initDataSource() {
    const MILISECONDS = 1000 * 60
    timer(0, MILISECONDS)
      .pipe(
        switchMap(() => this.getDataSource()),
      )
      .subscribe()
  }

  getDataSource(callback?: () => void) {
    const url: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetBySysTableGroupName?tableGroupName=S4 Initial Load`
    return this.send.sendRequest(url, "GET", "").pipe(
      map((table: any) => {
        table.map((row) => {
          row.CFG_SYS_TABLE_EXTRACT_DATETIME = this.customColumnFormatting(row)
        })
        return table
      }),
      tap((table: any) => {
        this.dataSource = new CustomStore({
          key: "CFG_SYS_TABLE_CONFIG_ID",
          loadMode: "raw",
          load: () => table,
        })
        callback ? callback() : ''
      })
    )
  }

  exportBtnClick(templateData) {
    let download = async () => {
      let column = await this.dataSource.byKey(templateData.data.CFG_SYS_TABLE_CONFIG_ID)
      const url: string = `${environment.ServiceURL_Main}DownloadFile?tableName=${templateData.data.CFG_SYS_TABLE_NAME}`
      this.send.sendRequestDownloadFile(url, 'application/zip').subscribe(data => {
        const blob = new Blob([data], {
          type: 'application/zip'
        })
        const anchor = document.createElement('a')
        anchor.href = window.URL.createObjectURL(blob)
        anchor.download = column.CFG_SYS_TABLE_EXTRACT_FILENAME
        anchor.click()
        window.URL.revokeObjectURL(anchor.href)
      })
    }
    this.getDataSource(download).subscribe()
  }

  customColumnFormatting(row): string {
    if (!row.CFG_SYS_TABLE_EXTRACT_DATETIME) {
      return ''
    }
    return this.readableISODatestring(row.CFG_SYS_TABLE_EXTRACT_DATETIME)
      + " "
      + "("
      + calcRelativeTime(row.CFG_SYS_TABLE_EXTRACT_DATETIME)
      + ")"
  }

  readableISODatestring(ISODatestring): string {
    const now = new Date(ISODatestring)
    const month = now.getMonth() + 1
    const day = now.getDate()
    const year = now.getFullYear()
    const hours = now.getHours()
    const minutes = now.getMinutes()
    const ampm = hours >= 12 ? 'PM' : 'AM'
    const formattedHours = hours % 12 === 0 ? 12 : hours % 12
    const formattedMinutes = minutes.toString().padStart(2, '0')
    return `${month}/${day}/${year}, ${formattedHours}:${formattedMinutes} ${ampm}`
  }
}
