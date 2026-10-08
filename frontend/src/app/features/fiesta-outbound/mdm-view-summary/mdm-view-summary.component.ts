import { Component } from '@angular/core'
import { environment } from '../../../../environments/environment'
import { SendRequestService } from '../../../service/base/send-request.service'
import { Column } from 'devextreme/ui/data_grid'
import CustomStore from 'devextreme/data/custom_store'
import { timer } from 'rxjs'
import { map, switchMap, tap } from 'rxjs/operators'
import { calcRelativeTime } from 'src/app/shared/utils/calcRelativeTime'

@Component({
  selector: 'app-mdm-view-summary',
  templateUrl: './mdm-view-summary.component.html',
  styleUrl: './mdm-view-summary.component.scss'
})
export class MdmViewSummaryComponent {
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
    //const url: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetBySysTableGroupName?tableGroupName=Product Master`
    const url: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetMultipleCfgSysTableConfig?`
      + `tableNames=OUT_PRODUCTION`
      + `&tableNames=OUT_PRODUCT_CONSOLIDATE`
      + `&tableNames=OUT_PRODUCT_SALES_CONSOLIDATE`
      + `&tableNames=OUT_PRODUCT_PLANT_CONSOLIDATE`
      + `&tableNames=OUT_COMPONENTS`
      + `&tableNames=OUT_PRODUCT_VENDOR_CHAR`
      + `&tableNames=OUT_PRODUCT_MATRIX`
      + `&tableNames=OUT_PRODUCT_CAN_FLAGS4`
      + `&tableNames=OUT_PRODUCT_ECCN_CONVERSION`
      + `&tableNames=OUT_PRODUCT_HS_CONVERSION`
      + `&tableNames=OUT_PRODUCT_STANDARD_COST`
      + `&tableNames=OUT_PRODUCT_SALES_ROOT_PARTNUMBER`
      + `&tableNames=OUT_PRODUCT_WIP_SELL_PRICE`
      + `&tableNames=MDM_PRODUCT_HIERARCHY_V2`
      + `&tableNames=MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION_V2`
      + `&tableNames=OUT_PRODUCT_TYPE`
      + `&tableNames=OUT_PRODUCT_LINE`
      + `&tableNames=OUT_PRODUCT_HISTORICAL`
      + `&tableNames=OUT_PRODUCTION_BOM`
      + `&tableNames=OUT_PRODUCTION_ROUTING`
      + `&tableNames=OUT_PRODUCTION_ROUTING_S4`
      + `&tableNames=OUT_PRODUCTION_VERSION`
      + `&tableNames=OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOS`
      + `&tableNames=OUT_PRODUCTION_LOTSIZE`
      + `&tableNames=OUT_PRODUCTION_YIELD`
      + `&tableNames=OUT_PRODUCTION_LEADTIME`
      + `&tableNames=OUT_PRODUCTION_CYCLETIME`
      + `&tableNames=MDM_PRODUCTION_STAGE`
      + `&tableNames=MDM_PRODUCTION_STAGE_CONVERSION`
      + `&tableNames=V_MDM_PRODUCTION_GROUP_STAGE`
      + `&tableNames=V_MDM_PRODUCTION_GROUP_STAGE_CONVERSION`
      + `&tableNames=V_MDM_PRODUCTION_PLANT_CONVERSION`
      + `&tableNames=PLM_PRODUCTION`
      + `&tableNames=PLM_PRODUCT`


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
