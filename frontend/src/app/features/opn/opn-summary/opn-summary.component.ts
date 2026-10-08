import { Component, ViewChild } from '@angular/core'
import { CustomStore } from 'devextreme-aspnet-data-nojquery'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { environment } from 'src/environments/environment'
import { CriteriaRetrievedEvent, FilterExpression } from '../../../shared/components/filter-criteria/filter-criteria.component'
import { ActivatedRoute, Router } from '@angular/router'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { DxDataGridComponent } from 'devextreme-angular'

@Component({
  selector: 'app-opn-summary',
  templateUrl: './opn-summary.component.html',
  styleUrls: ['./opn-summary.component.scss']
})
export class OpnSummaryComponent {
  @ViewChild("dataGrid") dataGrid: DxDataGridComponent

  PageTitle: string = "OPN Summary"
  tableName: string = "V_OPN_LIST"
  endpoint: string = "OpnList"
  key: string[] | string = "opn"
  dataSource: CustomStore
  columnsConfig: Column[]
  opnStatuses = ["All", "Agile Blacklisted", "Fiesta Processing", "User Buyoff", "Fiesta Blacklisted", "Fiesta Blacklisted (Delivered older version)", "Fiesta Delivered"]
  opnStatusSelection: string
  dataGridFilterExp: FilterExpression = null
  criteriaFilterExp: FilterExpression = null
  opnStatusFilterExp: FilterExpression = null

  showCriteria: boolean = true
  showDataGrid: boolean = false
  criteriaFieldsDropdown = [
    { "dataField": "opn", "caption": "Orderable Part Number" }
  ]

  constructor(
    private send: SendRequestService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.columnsConfig = [
      {
        fixed: true,
        dataField: "opn",
        dataType: "string",
        caption: "OPN",
        alignment: "left",
        minWidth: 120,
        cellTemplate: "opnCellTemplate"
      },
      {
        fixed: true,
        dataField: "companyCode",
        dataType: "string",
        caption: "Company Code",
        width: 50,
        alignment: "left"
      },
      {
        fixed: true,
        dataField: "status",
        dataType: "string",
        caption: "Status",
        width: null,
        alignment: "left",
        cellTemplate: "statusCellTemplate"
      },
      {
        fixed: true,
        dataField: "legacyOrganization",
        dataType: "string",
        caption: "Legacy Org",
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "Legacy\nOrg"
      },
      {
        fixed: true,
        dataField: "plmStatus",
        dataType: "string",
        caption: "Lifecycle Phase",
        width: 70,
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "Lifecycle\nPhase"
      },
      {
        fixed: true,
        dataField: "TT",
        dataType: "string",
        caption: "OPN Group Stages",
        width: 300,
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "OPN\nGroup Stages"
      },
      {
        dataField: "agileSignoff",
        dataType: "string",
        caption: "Agile Sign-off",
        width: 70,
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "Agile\nSign-off"
      },
      {
        format: "yyyy-MM-dd HH:mm:ss",
        dataField: "agileSignoffDate",
        dataType: "datetime",
        caption: "Agile Sign-off Date",
        width: 111,
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "Agile\nSign-off Date"
      },
      {
        dataField: "fiestaSignoff",
        dataType: "string",
        caption: "Fiesta Sign-off",
        width: 70,
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "Delivered\nby FIESTA" //"Fiesta\nSign-off"
      },
      {
        format: "yyyy-MM-dd HH:mm:ss",
        dataField: "fiestaSignoffDate",
        dataType: "datetime",
        caption: "FIESTA Delivered Date",
        width: 111,
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "FIESTA\nDelivered Date"
      },
      {
        dataField: "userSignoff",
        dataType: "string",
        caption: "User Sign-off",
        width: 70,
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "User\nSign-off"
      },
      {
        format: "yyyy-MM-dd HH:mm:ss",
        dataField: "lastSignoffDate",
        dataType: "datetime",
        caption: "Last Sign-off Date",
        width: 111,
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "Last\nSign-off Date"
      },
      {
        dataField: "lastSignoffBy",
        dataType: "string",
        caption: "Last Sign-off By",
        width: 90,
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "Last\nSign-off By"
      },
      // {
      //   dataField: "fiestaSignoff",
      //   dataType: "string",
      //   caption: "Delivered by FIESTA",
      //   width: 65,
      //   alignment: "left",
      //   headerCellTemplate: (container) => container.innerText = "Delivered\nby FIESTA"
      // },
      {
        dataField: "existInProster",
        dataType: "string",
        caption: "Exist in PROSTER",
        width: 90,
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "Exist in\nPROSTER"
      },
      {
        dataField: "isTop95PercentRevenue",
        dataType: "string",
        caption: "Exist in Critical OPN",
        width: 90,
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "Exist in\nCritical OPN"
      },
      {
        dataField: "hasBilling",
        dataType: "string",
        caption: "Exist in GBI Revenue",
        width: 90,
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "Exist in\nGBI Revenue"
      },
      {
        dataField: "hasInventory",
        dataType: "string",
        caption: "Exist in GBI Inventory",
        width: 90,
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "Exist in\nGBI Inventory"
      },
      {
        dataField: "hasBacklog",
        dataType: "string",
        caption: "Exist in GBI Backlog",
        width: 90,
        alignment: "left",
        headerCellTemplate: (container) => container.innerText = "Exist in\nGBI Backlog"
      },
      {
        dataField: "failureReason",
        dataType: "string",
        caption: "Failure Reason",
        width: 200,
        alignment: "left"
      }
    ]
    this.getDataSource()
    this.prepareOpnStatusFilter()
  }

  getDataSource() {
    const url: string = `${environment.ServiceURL_Main}${this.endpoint}`
    this.dataSource = this.send.sendRequestVirtual(this.key, url)
  }

  prepareOpnStatusFilter() {
    this.opnStatusSelection = this.opnStatuses[0]
    this.route.queryParams.subscribe(params => {
      const status = decodeURIComponent(params['status'])
      if (this.opnStatuses.includes(status)) {
        this.opnStatusSelection = status
        switch (status) {
          case "All":
            this.opnStatusFilterExp = null
            break
          case "Agile Blacklisted":
            this.opnStatusFilterExp = [["status", "=", "Agile Blacklisted"]]
            break
          case "Fiesta Processing":
            this.opnStatusFilterExp = [["status", "=", "Fiesta Processing"]]
            break
          case "Fiesta Blacklisted":
            this.opnStatusFilterExp = [["status", "=", "Fiesta Blacklisted"]]
            break
          case "Fiesta Blacklisted (Delivered older version)":
            this.opnStatusFilterExp = [["status", "=", "Fiesta Blacklisted (Delivered older version)"]]
            break
          case "User Buyoff":
            this.opnStatusFilterExp = [["status", "=", "User Buyoff"]]
            break
          case "Fiesta Delivered":
            this.opnStatusFilterExp = [["status", "=", "Fiesta Delivered"]]
            break
          default:
            break
        }

        this.setDataGridFilterExp()
      }
    })
  }

  encodeFppLink(opn) {
    const params = {
      opn: opn
    }
    //return `${environment.postLogoutRedirectUri}masters/FiestaProductProduction?${new URLSearchParams(params).toString()}`
    return `${environment.postLogoutRedirectUri}masters/MastersOverview?${new URLSearchParams(params).toString()}`
  }

  encodeAgileBlacklistLink(opn) {
    const params = {
      ENTITY_ID: opn
    }
    return `${environment.postLogoutRedirectUri}plm/AgileBlacklist?${new URLSearchParams(params).toString()}`
  }

  encodePlmBlacklistLink(opn) {
    const params = {
      partNumber: opn
    }
    return `${environment.postLogoutRedirectUri}plm/PlmBlacklisted?${new URLSearchParams(params).toString()}`
  }

  encodeUserBuyoffLink(opn) {
    const params = {
      opn: opn
    }
    return `${environment.postLogoutRedirectUri}masters/UserBuyoff?${new URLSearchParams(params).toString()}`
  }

  onOpnStatusFilter(e: { value?: string }) {
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { status: e.value },
    })
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }

  onCriteriaRetrieved(e: CriteriaRetrievedEvent) {
    this.showCriteria = false
    this.showDataGrid = true
    this.criteriaFilterExp = e.filterExpression

    this.setDataGridFilterExp()
  }

  setDataGridFilterExp() {
    const finalFilterExp = []
    if (this.criteriaFilterExp && this.opnStatusFilterExp) {
      finalFilterExp.push(...this.criteriaFilterExp)
      finalFilterExp.push("and")
      finalFilterExp.push(...this.opnStatusFilterExp)
    } else if (this.criteriaFilterExp) {
      finalFilterExp.push(...this.criteriaFilterExp)
    } else if (this.opnStatusFilterExp) {
      finalFilterExp.push(...this.opnStatusFilterExp)
    }

    this.dataGridFilterExp = finalFilterExp
  }
}
