import { Component, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import { ActivatedRoute } from '@angular/router'
import { CustomStore } from 'devextreme-aspnet-data-nojquery'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { forkJoin } from 'rxjs'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { environment } from 'src/environments/environment'

@Component({
  selector: 'app-plm-blacklisted',
  templateUrl: './plm-blacklisted.component.html',
  styleUrls: ['./plm-blacklisted.component.scss']
})
export class PlmBlacklistedComponent {

  // @ViewChild('grid', { static: false })
  // grid!: DxDataGridComponent;

  @ViewChild('upperGrid', { static: false }) upperGrid!: DxDataGridComponent;
  @ViewChild('lowerGrid', { static: false }) lowerGrid!: DxDataGridComponent;

  PageTitle: string = "PLM Blacklist"

  upperEndpoint: string = "PlmBlacklistSummaryUI"
  lowerEndpoint: string = "PlmBlacklistedOpnProductUI"
  viewByOPNEndpoint: string = "PlmBlacklistedByOPNUI"
  viewByPartEndpoint: string = "PlmBlacklistedByPartUI"

  upperKey: string[] | string = "Blacklist_Number"
  lowerKey: string[] | string = "partNumber"
  viewByOPNKey: string[] | string = "opn"
  viewByPartKey: string[] | string = "opn"

  upperDataSource: CustomStore
  lowerDataSource: CustomStore
  viewByOPNDataSource: CustomStore
  viewByPartDataSource: CustomStore

  upperColumnsConfig: Column[]
  lowerColumnsConfig: Column[]
  viewByOPNColumnsConfig: Column[]
  viewByPartColumnsConfig: Column[]

  //lowerFilterValue: any = null
  lowerFilterValue = ['deleteFlag', '=', 'N'];

  showBottomOnly: boolean = false
  activeTab: number = 0

  tabLoaded = {
    0: true,
    1: false,
    2: false
  };



  constructor(
    private send: SendRequestService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.configureDatagrid()
  }

  configureDatagrid() {

    const createLinkColumns = (columns: Column[]): Column[] => {
      const mainColumns = [...columns]
      mainColumns.forEach((column) => {
        if (column.dataField === "blacklistDetails") {
          column.cellTemplate = "opnBlackListTemplate"
        }
      })
      return mainColumns
    }

    const upperUrl: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=V_PLM_BLACKLIST_SUMMARY`
    const lowerUrl: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=PLM_BLACKLISTED_PRODUCT`
    const viewByOPNUrl: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=PLM_BLACKLISTED_BY_OPN`
    const viewByPartUrl: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=PLM_BLACKLISTED_BY_PART`
    forkJoin([
      this.send.sendRequest(upperUrl, "GET", ""),
      this.send.sendRequest(lowerUrl, "GET", ""),
      this.send.sendRequest(viewByOPNUrl, "GET", ""),
      this.send.sendRequest(viewByPartUrl, "GET", "")
    ])
      .subscribe(([upperResult, lowerResult, viewByOPNResult, viewByPartResult]) => {
        this.upperColumnsConfig = upperResult
        this.lowerColumnsConfig = lowerResult
        this.viewByOPNColumnsConfig = createLinkColumns(viewByOPNResult)
        this.viewByPartColumnsConfig = createLinkColumns(viewByPartResult)
        this.getDataSource()
      })
  }

  getDataSource() {
    this.route.queryParams.subscribe(params => {
      const partNumber = params['partNumber']
      if (partNumber) {
        this.lowerFilterValue = ['partNumber', '=', partNumber]
        this.showBottomOnly = true
      }
      const upperUrl: string = `${environment.ServiceURL_Main}${this.upperEndpoint}`
      setTimeout(() => this.upperDataSource = this.send.sendRequestVirtual(this.upperKey, upperUrl))
      const lowerUrl: string = `${environment.ServiceURL_Main}${this.lowerEndpoint}`
      setTimeout(() => this.lowerDataSource = this.send.sendRequestVirtual(this.lowerKey, lowerUrl))

      const viewByOPNUrl: string = `${environment.ServiceURL_Main}${this.viewByOPNEndpoint}`
      setTimeout(() => this.viewByOPNDataSource = this.send.sendRequestVirtual(this.viewByOPNKey, viewByOPNUrl))
      const viewByPartUrl: string = `${environment.ServiceURL_Main}${this.viewByPartEndpoint}`
      setTimeout(() => this.viewByPartDataSource = this.send.sendRequestVirtual(this.viewByPartKey, viewByPartUrl))
    })
  }

  refreshUpperGrid = () => {
    this.upperGrid.instance.getDataSource().reload();
  };

  refreshLowerGrid = () => {
    this.lowerGrid.instance.getDataSource().reload();
  };

  // refreshViewByOPN = () => {
  //   const url = `${environment.ServiceURL_Main}${this.viewByOPNEndpoint}`;
  //   this.viewByOPNDataSource = this.send.sendRequestVirtual(this.viewByOPNKey, url);
  // };

  // refreshViewByPart = () => {
  //   const url = `${environment.ServiceURL_Main}${this.viewByPartEndpoint}`;
  //   this.viewByPartDataSource = this.send.sendRequestVirtual(this.viewByPartKey, url);
  // };

  onTabClick(tabNumber) {
    this.activeTab = tabNumber
    this.tabLoaded[tabNumber] = true;
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }

  refreshGrid = () => {
    this.getDataSource()
  };

  onClickBlacklistDetail(partNumber) {
    this.activeTab = 0
    this.lowerFilterValue = ['partNumber', '=', partNumber]
  }


}
