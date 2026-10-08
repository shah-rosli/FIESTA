import { Component, ElementRef, QueryList, ViewChild, ViewChildren } from '@angular/core'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { environment } from 'src/environments/environment'
import { DateTime } from "luxon"
import { ToastrService } from 'ngx-toastr'
import { DxChartComponent, DxPieChartComponent } from 'devextreme-angular'
import { Subject } from 'rxjs'
import { debounceTime, skip } from 'rxjs/operators'
import { calcRelativeTime } from 'src/app/shared/utils/calcRelativeTime'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { DatePipe } from '@angular/common'

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  providers: [DatePipe]
})
export class DashboardComponent {
  @ViewChild('dashboardContainer') dashboardContainer: ElementRef
  @ViewChild('blacklistChart') blacklistChart: DxChartComponent
  @ViewChildren(DxPieChartComponent) pieCharts: QueryList<DxPieChartComponent>

  PageTitle: string = "Dashboard"
  dataSource: any[] = []
  blacklist: any[] = []
  lastRefreshDate: string

  dataLoaded: boolean
  specialTexts: any = {}
  blacklistChartHeight = 400
  resizeObserver: ResizeObserver
  resizeSubject: Subject<void> = new Subject<void>()

  announcementData

  statDataSource
  activeTab01: number = 0
  tabLoaded01 = {
    0: true,
    1: false,
    2: false
  };

  activeTab02: number = 0
  tabLoaded02 = {
    0: true,
    1: false,
    2: false
  };

  activeTab03: number = 0
  tabLoaded03 = {
    0: true,
    1: false,
    2: false,
    3: false,
    4: false,
    5: false,
    6: false,
    7: false,
    8: false
  };

  constructor(private send: SendRequestService, private toastr: ToastrService, private datePipe: DatePipe) {
    this.customizeTooltip = this.customizeTooltip.bind(this)
    this.customizeHint = this.customizeHint.bind(this)
  }

  ngOnInit(): void {

    // this.send.sendRequest(`${environment.ServiceURL_Main}Dashboard/GetDashboardData_V2`, "GET").subscribe(
    //   response => {
    //     this.lastRefreshDate = response.statsLastRefreshDate
    //     try {
    //       this.statDataSource = response.stats
    //     } catch (error) {
    //       this.toastr.error("Fail to process stat data!", null, errorToastOptions)
    //     }
    //   }
    // )

    this.send.sendRequest(`${environment.ServiceURL_Main}Dashboard/GetDashboardData`, "GET").subscribe(
      response => {
        this.lastRefreshDate = response.statsLastRefreshDate
        try {
          this.processDashboardStats(response.stats)
        } catch (error) {
          this.toastr.error("Fail to process data!", null, errorToastOptions)
        }
        this.setupBlacklistChart(response.blacklist)
        setTimeout(() => this.initResizeObserver())
        this.dataLoaded = true
      }
    )
    this.getAnnouncement()
  }

  ngOnDestroy() {
    if (this.resizeObserver) {
      this.resizeObserver.disconnect()
    }
    if (this.resizeSubject) {
      this.resizeSubject.unsubscribe()
    }
  }

  processDashboardStats(records) {
    // associative array
    for (const record of records) {
      record.extendedLastUpdate = `${this.datePipe.transform(record.LASTUPDATE, 'yyyy-MM-dd HH:mm:ss')} (${calcRelativeTime(record.LASTUPDATE)})`
      record.readableCount = record.COUNT.toLocaleString("en-US")

      if (
        record.GROUPING === "PLM" ||
        record.GROUPING === "OPN" ||
        record.GROUPING === "OUT" ||
        record.GROUPING === "MDM" ||
        record.GROUPING === "BLK" ||
        record.GROUPING === "S4"

        || record.GROUPING === "OUT_PROD"
        || record.GROUPING === "OUT_PRODN"
        || record.GROUPING === "APP"
        || record.GROUPING === "CUSTOMER"
        || record.GROUPING === "FI"
        || record.GROUPING === "IP"
        || record.GROUPING === "LG"
        || record.GROUPING === "ORG"
        || record.GROUPING === "VENDOR"

      ) {
        // by GROUPING
        const grouping = record.GROUPING
        if (!this.dataSource[grouping]) {
          this.dataSource[grouping] = []
        }
        this.dataSource[grouping].push(record)
      } else {
        // by OBJECT
        this.dataSource[record.OBJECT] = record
      }
    }

    const opnTotal = this.dataSource['Delivered OPNs'].COUNT
    if (opnTotal > 0) {
      this.dataSource['REN CORE'].percent = (this.dataSource['REN CORE'].COUNT / opnTotal * 100).toFixed(1)
      this.dataSource['REN P&C'].percent = (this.dataSource['REN P&C'].COUNT / opnTotal * 100).toFixed(1)
      this.dataSource['REN PWR'].percent = (this.dataSource['REN PWR'].COUNT / opnTotal * 100).toFixed(1)
      this.dataSource['REN ANA'].percent = (this.dataSource['REN ANA'].COUNT / opnTotal * 100).toFixed(1)
    }

    this.dataSource['Top 95 Percent Sales Forecast'].pieChartDataSource = [{
      argument: "primary",
      opnValue: this.dataSource['Top 95 Percent Sales Forecast'].COUNT,
    }, {
      argument: "secondary",
      opnValue: 100 - this.dataSource['Top 95 Percent Sales Forecast'].COUNT,
    }]
    this.dataSource['Top 95 to 99 Percent Sales Forecast'].pieChartDataSource = [{
      argument: "primary",
      opnValue: this.dataSource['Top 95 to 99 Percent Sales Forecast'].COUNT,
    }, {
      argument: "secondary",
      opnValue: 100 - this.dataSource['Top 95 to 99 Percent Sales Forecast'].COUNT,
    }]
    this.dataSource['Last 1 Percent Sales Forecast'].pieChartDataSource = [{
      argument: "primary",
      opnValue: this.dataSource['Last 1 Percent Sales Forecast'].COUNT,
    }, {
      argument: "secondary",
      opnValue: 100 - this.dataSource['Last 1 Percent Sales Forecast'].COUNT,
    }]

    this.dataSource['Revenue'].pieChartDataSource = [{
      argument: "primary",
      opnValue: this.dataSource['Revenue'].COUNT,
      jpyValue: this.dataSource['Revenue JPY'].COUNT,
    }, {
      argument: "secondary",
      opnValue: 100 - this.dataSource['Revenue'].COUNT,
      jpyValue: 100 - this.dataSource['Revenue JPY'].COUNT,
    }]
    this.dataSource['Inventory'].pieChartDataSource = [{
      argument: "primary",
      opnValue: this.dataSource['Inventory'].COUNT,
      jpyValue: this.dataSource['Inventory JPY'].COUNT,
    }, {
      argument: "secondary",
      opnValue: 100 - this.dataSource['Inventory'].COUNT,
      jpyValue: 100 - this.dataSource['Inventory JPY'].COUNT,
    }]
    this.dataSource['Backlog'].pieChartDataSource = [{
      argument: "primary",
      opnValue: this.dataSource['Backlog'].COUNT,
      jpyValue: this.dataSource['Backlog JPY'].COUNT,
    }, {
      argument: "secondary",
      opnValue: 100 - this.dataSource['Backlog'].COUNT,
      jpyValue: 100 - this.dataSource['Backlog JPY'].COUNT,
    }]

    // special texts
    const doaMinDate = DateTime.fromISO(this.dataSource['MIN_DATE'].LASTUPDATE)
    const doaMaxDate = DateTime.fromISO(this.dataSource['MAX_DATE'].LASTUPDATE)
    this.specialTexts.doaRevenue = `(${doaMinDate.toFormat("MMM")} '${doaMinDate.toFormat("yy")} - ${doaMaxDate.toFormat("MMM")} '${doaMaxDate.toFormat("yy")})`
    const benchmarkDate = DateTime.fromISO(this.dataSource['BENCHMARK DATE'].LASTUPDATE).toFormat("yyyy-MM-dd")
    this.specialTexts.doaInventory = `(As per ${benchmarkDate})`
    this.specialTexts.doaBacklog = `(As per ${benchmarkDate})`

    const pendingSignOffTotal = this.dataSource['Pending Business Sign Off'].COUNT
    if (pendingSignOffTotal > 0) {
      const pendingSignOffCORE = this.dataSource['Pending Business Sign Off REN CORE']
      const pendingSignOffPNC = this.dataSource['Pending Business Sign Off REN P&C']
      const pendingSignOffPWR = this.dataSource['Pending Business Sign Off REN PWR']
      const pendingSignOffANA = this.dataSource['Pending Business Sign Off REN ANA']
      pendingSignOffCORE.percent = parseFloat((pendingSignOffCORE.COUNT / pendingSignOffTotal * 100).toFixed(0))
      pendingSignOffPNC.percent = parseFloat((pendingSignOffPNC.COUNT / pendingSignOffTotal * 100).toFixed(0))
      pendingSignOffPWR.percent = parseFloat((pendingSignOffPWR.COUNT / pendingSignOffTotal * 100).toFixed(0))
      pendingSignOffANA.percent = parseFloat((pendingSignOffANA.COUNT / pendingSignOffTotal * 100).toFixed(0))
    }
  }

  setupBlacklistChart(blacklist) {
    this.blacklist = blacklist.reverse()
      .map((record) => {
        record.percent = `${record.CNT}%`
        record.TITLE = record.DESCRIPTION.substring(0, 12)
        return record
      })

    const graphRowHeight = 16
    const graphHeight = this.blacklist.length * graphRowHeight
    if (graphHeight > this.blacklistChartHeight) {
      this.blacklistChartHeight = graphHeight
    }
  }

  pieChartCustomizePoint(pointInfo) {
    if (pointInfo.argument === "primary") {
      if (pointInfo.seriesName === "OPN") {
        return { color: "#6682bb" }
      } else {
        return { color: "#71a6d6" }
      }
    }
    if (pointInfo.argument === "secondary") {
      return { color: "#dbdbdb" }
    }
  }

  customizeSeriesLabelText(seriesInfo) {
    if (seriesInfo.argument === "primary") {
      return `${seriesInfo.value}%`
    }
  }

  initResizeObserver() {
    this.resizeSubject.pipe(
      debounceTime(100),
      skip(1),
    ).subscribe(() => {
      this.blacklistChart?.instance.render()
      for (const pieChart of this.pieCharts) {
        pieChart.instance.render({ force: true })
      }
    })

    this.resizeObserver = new ResizeObserver(() => {
      this.resizeSubject.next()
    })
    this.resizeObserver.observe(this.dashboardContainer.nativeElement)
  }

  customizeTooltip(pointInfo) {
    const record = this.blacklist.find(record => record.TITLE === pointInfo.argument)
    return {
      text: record.DESCRIPTION
    }
  }

  customizeHint(argumentLabel) {
    const record = this.blacklist.find(record => record.TITLE === argumentLabel.value)
    return record.DESCRIPTION
  }

  barChartCustomizePoint(pointInfo) {
    if (pointInfo.data.BLACKLIST_FLAG === "Y") {
      return { color: "#bb6666" }
    }
  }

  ////////////////////////////////////////////////////////////////////////////////

  getAnnouncement() {
    this.announcementData = []
    if (localStorage.getItem("paramDictionary")) {
      let temp = JSON.parse(localStorage.getItem("paramDictionary"))
      temp = temp.filter((filter) => filter.PARAM_CATEGORY == "DashboardAnnouncement")
      const tempAnnouncementData = []
      temp.forEach((element) => {
        tempAnnouncementData.push(JSON.parse(element.PARAM_VALUE.toString()))
      })
      if (tempAnnouncementData) {
        tempAnnouncementData.sort((a, b) => {
          return +new Date(b.date) - +new Date(a.date)
        })
      }
      tempAnnouncementData.forEach((element) => {
        const date1 = new Date(element.date).getTime()
        const date2 = new Date().getTime()
        const diffTime = Math.abs(date2 - date1)
        const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24))

        if (diffDays < 9000) {
          this.announcementData.push(element)
        }
      })
    }
  }

  goToLink(url: string) {
    window.open(url, "_blank")
  }

  onTabClick01(tabNumber) {
    this.activeTab01 = tabNumber
    this.tabLoaded01[tabNumber] = true;
  }

  onTabClick02(tabNumber) {
    this.activeTab02 = tabNumber
    this.tabLoaded02[tabNumber] = true;
  }

  onTabClick03(tabNumber) {
    this.activeTab03 = tabNumber
    this.tabLoaded03[tabNumber] = true;
  }
}
