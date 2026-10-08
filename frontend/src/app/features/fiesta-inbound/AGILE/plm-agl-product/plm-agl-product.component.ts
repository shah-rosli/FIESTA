import { Component } from '@angular/core'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { environment } from '../../../../../environments/environment'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import DataSource from 'devextreme/data/data_source'

@Component({
  selector: 'app-plm-agl-product',
  templateUrl: './plm-agl-product.component.html',
  styleUrls: ['./plm-agl-product.component.scss']
})
export class PlmAglProductComponent {

  PageTitle: string = "Product"
  tableName: string = "PLM_AGL_PRODUCT"
  endpoint: string = "PlmAglProductUI"
  key: string[] | string = "referenceKey"

  dataSource: DataSource
  columnsConfig: Column[]
  showActiveRecords: boolean = true

  constructor(private send: SendRequestService) { }

  ngOnInit(): void {
    this.configureDatagrid()
  }

  getDataSource() {
    const url: string = `${environment.ServiceURL_Main}${this.endpoint}`
    this.dataSource = new DataSource({
      store: this.send.sendRequestVirtual(this.key, url)
    })
    if (this.showActiveRecords) {
      this.dataSource.filter(["deleteFlag", "=", "N"])
    }
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
            format: 'yyyy-MM-dd', //20260930 disable date filter
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
}
