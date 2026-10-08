import { Component, ViewChild, ViewContainerRef } from '@angular/core'
import { environment } from 'src/environments/environment'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { Column } from 'devextreme/ui/data_grid'
import CustomStore from 'devextreme/data/custom_store'
import { timer } from 'rxjs'
import { map, switchMap, tap } from 'rxjs/operators'
import { DateTime } from "luxon"
import { ActivatedRoute, Router } from '@angular/router'
import { HttpClient, HttpParams } from '@angular/common/http';
import { ByoProductionComponent } from '../../components/byo-production/byo-production.component';
import { PagePermission, PermissionService } from '../../../../service/permission.service'
import { ToastrService } from 'ngx-toastr'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { DatePipe } from '@angular/common';
import { ByoHistoryPopupComponent } from '../../components/byo-history-popup/byo-history-popup.component';
import { confirm } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-fiesta-user-buyoff',
  templateUrl: './fiesta-user-buyoff.component.html',
  styleUrl: './fiesta-user-buyoff.component.scss'
})
export class FiestaUserBuyoffComponent {

  pagePermission: PagePermission

  PageTitle: string = "Fiesta User Buyoff";
  dataSource: any;
  dataSource_ProductionBuyoff: any;

  dataSource_BYO_Product: any;
  dataSource_BYO_Production: any;

  selectedPartNumbers: string[] = [];
  selectedPartNumbers_BYO_Product: string[] = [];

  selectedOPNs: string[] = [];
  selectedOPNs_BYO_Production: string[] = [];

  showMain: boolean = false;
  showBuyoffProduct: boolean = false;
  showBuyoffProduction: boolean = false;

  columnConfig_BYO_PRODUCT: Column[];
  columnConfig_BYO_PRODUCTION: Column[];

  activeTab: number = 1;
  tabLoaded = {
    0: false,
    1: true
  };

  confirmMsg: string;

  @ViewChild('productionContainer', { read: ViewContainerRef })
  container!: ViewContainerRef;
  componentRefs: any[]

  historyColumn_BYO_PRODUCT_HIS: Column[]
  //historyColumn_BYO_PRODUCT_HIS_data: Column[]

  historyColumn_BYO_PRODUCTION_HIS: Column[]

  //for BYO_Product_History
  dataGridKey: string = "partNumber";
  @ViewChild('historyPopup') historyPopup!: ByoHistoryPopupComponent;
  //historyColumnBYO: Column[];

  //BYO SUMMARY///////////////////////////////////////////////

  showBYOSummary: boolean = true;

  dataSource_BYO_SUMMARY: any;

  showBuyoffProductButton: boolean = false;
  showBuyoffProductionButton: boolean = false;

  selectedRows_BYO_SUMMARY: any[] = [];

  constructor(private send: SendRequestService, private router: Router, private toastr: ToastrService, private permission: PermissionService) {
    // this.dataSource = this.createDataSource_ProductBuyoff();
    // this.dataSource_ProductionBuyoff = this.createDataSource_ProductionBuyoff();
    this.dataSource_BYO_SUMMARY = this.createDataSource_BuyoffSummary();
  }

  ngOnInit(): void {
    this.pagePermission = this.permission.getUserPermissions()

    this.showMain = false;

    this.showBYOSummary = true;
    this.showBuyoffProduct = false;
    this.showBuyoffProduction = false;

    this.configureColumns();
  }

  onTabClick(tabNumber) {
    this.activeTab = tabNumber
    this.tabLoaded[tabNumber] = true;
  }

  createDataSource_ProductBuyoff() {
    const url = `${environment.ServiceURL_Main}ProductBuyoff`;
    return new CustomStore({
      //key: 'partNumber',
      load: () => {
        return this.send.sendRequest(url, 'GET').toPromise();
      }
    });
  }

  createDataSource_ProductionBuyoff() {
    const url = `${environment.ServiceURL_Main}ProductionBuyoff`;
    return new CustomStore({
      //key: 'partNumber',
      load: () => {
        return this.send.sendRequest(url, 'GET').toPromise();
      }
    });
  }

  onSelectionChanged_PRODUCT(e: any): void {
    this.selectedPartNumbers = e.selectedRowsData.map(
      (row: any) => row.partNumber
    );
  }

  onSelectionChanged_PRODUCTION(e: any): void {
    this.selectedOPNs = e.selectedRowsData.map(
      (row: any) => row.opn
    );
  }
  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

  onProductBuyoff(): void {

    if (this.selectedPartNumbers.length <= 0) {
      this.toastr.error("No Part Number is selected.", "Error!", errorToastOptions)
      return;
    }

    this.showMain = false;
    this.showBuyoffProduct = true;
    this.showBuyoffProduction = false;

    let pns = '';
    let params = new HttpParams();
    this.selectedPartNumbers.forEach(p => {
      params = params.append('partNumbers', p);

      if (pns === '') {
        pns = 'partNumbers=' + p;
      } else {
        pns = pns + '&partNumbers=' + p;
      }
    });

    const url = `${environment.ServiceURL_Main}BYO_PRODUCT?` + pns;

    this.send.sendRequest(url, 'GET', null).subscribe((res: any) => {
      this.dataSource_BYO_Product = res;
      this.selectedPartNumbers_BYO_Product = res.map((item: any) => item.partNumber);
    });

  }

  onProductionBuyoff(): void {

    if (this.selectedOPNs.length <= 0) {
      this.toastr.error("No OPN is selected.", "Error!", errorToastOptions)
      return;
    }

    this.showMain = false;
    this.showBuyoffProduct = false;
    this.showBuyoffProduction = true;

    setTimeout(() => {
      this.container.clear();

      let os = '';
      this.selectedOPNs.forEach(p => {
        if (os === '') {
          os = 'OPNs=' + p;
        } else {
          os = os + '&OPNs=' + p;
        }
      });
      const url = `${environment.ServiceURL_Main}BYO_PRODUCTION?` + os;
      this.send.sendRequest(url, 'GET', null).subscribe((res: any) => {

        this.componentRefs = [];

        this.selectedOPNs.forEach(pp => {
          const filteredResults = res.filter(item => item.opn === pp);

          //const OPNRecord = this.dataSource_ProductionBuyoff.find(x => x.opn === pp);


          const componentRef = this.container.createComponent(ByoProductionComponent);

          componentRef.instance.columnConfig_BYO_PRODUCTION = this.columnConfig_BYO_PRODUCTION;
          componentRef.instance.dataSource_BYO_PRODUCTION = filteredResults; //for grid (raw BYO_PRODUCTION)
          componentRef.instance.opn = pp; //for display OPN

          this.dataSource_ProductionBuyoff.load().then((buyoffData: any[]) => {
            const buyoffRecord = buyoffData.find(x => x.opn === pp);

            componentRef.instance.prefixChangeOrder = buyoffRecord.productionChangeOrder;
            //componentRef.instance.productionChangeOrder = 'N' + String(buyoffRecord.productionChangeOrder).padStart(8, '0');

            const date = new Date(buyoffRecord.updateDateAndTime);
            const formatted =
              date.getFullYear() + '-' +
              String(date.getMonth() + 1).padStart(2, '0') + '-' +
              String(date.getDate()).padStart(2, '0') + ' ' +
              String(date.getHours()).padStart(2, '0') + ':' +
              String(date.getMinutes()).padStart(2, '0') + ':' +
              String(date.getSeconds()).padStart(2, '0');
            componentRef.instance.updateDateAndTime = formatted + ' (UTC)';

          });
          // componentRef.instance.productionChangeOrder = "testing";
          // componentRef.instance.updateDateAndTime = "testing";
          componentRef.instance.historyColumnBYO = this.historyColumn_BYO_PRODUCTION_HIS; //for BYO Production History
          this.componentRefs.push(componentRef);

          componentRef.changeDetectorRef.detectChanges();
        });
      });
    });
  }

  onBack_BYO_PRODUCT(): void {
    this.showMain = true;
    this.showBuyoffProduct = false;
    this.showBuyoffProduction = false;

    this.selectedPartNumbers = [];
  }

  onBack_BYO_PRODUCTION(): void {
    //this.showMain = true;
    this.showBYOSummary = true;
    this.showBuyoffProduct = false;
    this.showBuyoffProduction = false;

    this.selectedOPNs = [];
  }

  onSelectionChanged_BYO_Product(e: any): void {
    this.selectedPartNumbers_BYO_Product = e.selectedRowsData.map(
      (row: any) => row.partNumber
    );
  }

  // onSelectionChanged_BYO_Production(e: any): void {
  //   this.selectedOPNs_BYO_Production = e.selectedRowsData.map(
  //     (row: any) => row.opn
  //   );
  // }

  onBuyoff_BYO_Product(): void {

    ////multiple part numbers
    // if (this.selectedPartNumbers_BYO_Product.length <= 0) {
    //   this.toastr.error("No Part Number is selected to proceed buyoff.", "Error!", errorToastOptions)
    //   return;
    // }

    // if (this.selectedPartNumbers_BYO_Product.length == 1) {
    //   this.confirmMsg = this.selectedPartNumbers_BYO_Product.length + " Part Number has been selected. Are you sure you want to proceed with the buyoff?";
    // } else if (this.selectedPartNumbers_BYO_Product.length > 1) {
    //   this.confirmMsg = this.selectedPartNumbers_BYO_Product.length + " Part Numbers have been selected. Are you sure you want to proceed with the buyoff?";
    // }

    ////single OPN
    if (this.selectedRows_BYO_SUMMARY[0].materialType == "ZFER") {
      this.confirmMsg = "OPN " + this.selectedRows_BYO_SUMMARY[0].partNumber + " has been selected. Are you sure you want to proceed with the product buyoff?";
    } else if (this.selectedRows_BYO_SUMMARY[0].materialType == "ZHAL") {
      this.confirmMsg = "MPN " + this.selectedRows_BYO_SUMMARY[0].partNumber + " has been selected. Are you sure you want to proceed with the product buyoff?";
    }

    const result = confirm(
      this.confirmMsg,
      "Confirmation"
    );

    result.then((dialogResult) => {
      if (!dialogResult) {
        return;
      }

      // let pns = '';
      // let params = new HttpParams();
      // this.selectedPartNumbers_BYO_Product.forEach(p => {
      //   params = params.append('partNumbers', p);
      //   if (pns === '') {
      //     pns = 'partNumbers=' + p;
      //   } else {
      //     pns = pns + '&partNumbers=' + p;
      //   }
      // });

      // const url = `${environment.ServiceURL_Main}Buyoff_BYO_Product?` + pns;
      const url = `${environment.ServiceURL_Main}Buyoff_BYO_Product?partNumbers=` + this.selectedRows_BYO_SUMMARY[0].partNumber;
      this.send.sendRequest(url, 'POST', null).subscribe((res: any) => {
        this.toastr.success(res.Result)
        setTimeout(() => {
          this.selectedRows_BYO_SUMMARY = [];

          this.showBYOSummary = true;
          this.showBuyoffProduct = false;
          this.showBuyoffProduction = false;
          // this.selectedPartNumbers = [];
          // this.selectedPartNumbers_BYO_Product = [];

          // this.selectedOPNs = [];
          // this.selectedOPNs_BYO_Production = [];

          // this.showMain = true;
          // this.showBuyoffProduct = false;
          // this.showBuyoffProduction = false;
        }, 3000);
      });
    });


  }

  onBuyoff_BYO_Production(): void {

    ////multiple selected OPNs
    // this.selectedOPNs_BYO_Production = [];

    // this.componentRefs.forEach(ref => {
    //   if (ref.instance.isAccepted) {
    //     this.selectedOPNs_BYO_Production.push(ref.instance.opn);
    //   }
    // });
    // console.log('Selected OPNs:', this.selectedOPNs_BYO_Production);

    // if (this.selectedOPNs_BYO_Production.length <= 0) {
    //   this.toastr.error("No OPN is selected to proceed buyoff.", "Error!", errorToastOptions)
    //   return;
    // }

    // if (this.selectedOPNs_BYO_Production.length == 1) {
    //   this.confirmMsg = this.selectedOPNs_BYO_Production.length + " OPN has been selected. Are you sure you want to proceed with the buyoff?";
    // } else if (this.selectedOPNs_BYO_Production.length > 1) {
    //   this.confirmMsg = this.selectedOPNs_BYO_Production.length + " OPNs have been selected. Are you sure you want to proceed with the buyoff?";
    // }

    ////single OPN
    if (this.selectedRows_BYO_SUMMARY[0].materialType == "ZFER") {
      this.confirmMsg = "OPN " + this.selectedRows_BYO_SUMMARY[0].partNumber + " has been selected. Are you sure you want to proceed with the production buyoff?";
    } else if (this.selectedRows_BYO_SUMMARY[0].materialType == "ZHAL") {
      this.confirmMsg = "MPN " + this.selectedRows_BYO_SUMMARY[0].partNumber + " has been selected. Are you sure you want to proceed with the production buyoff?";
    }

    const result = confirm(
      this.confirmMsg,
      "Confirmation"
    );

    result.then((dialogResult) => {
      if (!dialogResult) {
        return;
      }

      // let os = '';
      // this.selectedOPNs_BYO_Production.forEach(p => {
      //   if (os === '') {
      //     os = 'OPNs=' + p;
      //   } else {
      //     os = os + '&OPNs=' + p;
      //   }
      // });

      //const url = `${environment.ServiceURL_Main}Buyoff_BYO_Production?` + os;
      const url = `${environment.ServiceURL_Main}Buyoff_BYO_Production?OPNs=` + this.selectedRows_BYO_SUMMARY[0].partNumber
      this.send.sendRequest(url, 'POST', null).subscribe((res: any) => {
        this.toastr.success(res.Result)
        setTimeout(() => {

          this.selectedRows_BYO_SUMMARY = [];

          this.showBYOSummary = true;
          this.showBuyoffProduct = false;
          this.showBuyoffProduction = false;

          // this.selectedPartNumbers = [];
          // this.selectedPartNumbers_BYO_Product = [];

          // this.selectedOPNs = [];
          // this.selectedOPNs_BYO_Production = [];

          // this.showMain = true;
          // this.showBuyoffProduct = false;
          // this.showBuyoffProduction = false;
        }, 3000);
      });

    });


  }

  configureColumns() {
    const createColumns_BYO_PRODUCT = (columns: Column[]): Column[] => {
      const mainColumns = [...columns]
      // mainColumns.push({
      //   type: "buttons",
      //   fixed: true,
      //   fixedPosition: "right",
      //   buttons: [{
      //     hint: "Show History",
      //     text: "History",
      //     onClick: this.historyIconClick
      //   }]
      // })
      return mainColumns
    }

    const createColumns_BYO_PRODUCTION = (columns: Column[]): Column[] => {
      const mainColumns = [...columns]
      return mainColumns
    }

    const createBYOHistoryColumns = (columns: Column[]): Column[] => {
      const historyColumns: Column[] = [
        { dataField: `recordKey`, caption: "History ID" },
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

    const url_BYO_Product: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=BYO_PRODUCT`
    this.send.sendRequest(url_BYO_Product, "GET", "").subscribe(
      data => {
        this.columnConfig_BYO_PRODUCT = createColumns_BYO_PRODUCT(data)
      }
    )
    const url_BYO_Production: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=BYO_PRODUCTION`
    this.send.sendRequest(url_BYO_Production, "GET", "").subscribe(
      data => {
        this.columnConfig_BYO_PRODUCTION = createColumns_BYO_PRODUCTION(data)
      }
    )
    const url_BYO_Product_History: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=BYO_PRODUCT_HIS`
    this.send.sendRequest(url_BYO_Product_History, "GET", "").subscribe(
      data => {
        this.historyColumn_BYO_PRODUCT_HIS = createBYOHistoryColumns(data)
      }
    )
    const url_BYO_ProductION_History: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=BYO_PRODUCTION_HIS`
    this.send.sendRequest(url_BYO_ProductION_History, "GET", "").subscribe(
      data => {
        this.historyColumn_BYO_PRODUCTION_HIS = createBYOHistoryColumns(data)
      }
    )
  }

  historyIconClick = (e: any) => {
    e.event?.preventDefault();
    const rowData = e.row.data;
    console.log("History clicked for row:", rowData);
    this.historyPopup.open("BYO_PRODUCT_HIS", rowData.partNumber);

    //return false;
  }


  createDataSource_BuyoffSummary() {
    const url = `${environment.ServiceURL_Main}BuyoffSummary`;
    return new CustomStore({
      //key: 'partNumber',
      load: () => {
        return this.send.sendRequest(url, 'GET').toPromise();
      }
    });
  }



  //BYO_SUMMARY////////////////////////////////////////////////////////////////////////////////////////////


  onBYOSummary(rowData: any) {
    console.log(rowData);

    this.showBYOSummary = false;
    this.showBuyoffProduct = false;
    this.showBuyoffProduction = true;

    this.selectedRows_BYO_SUMMARY = [];
    this.selectedRows_BYO_SUMMARY.push(rowData); //push page 1 selected row to the array
    setTimeout(() => {

      this.container.clear();
      this.componentRefs = [];
      const componentRef = this.container.createComponent(ByoProductionComponent);


      componentRef.instance.columnConfig_BYO_PRODUCT = this.columnConfig_BYO_PRODUCT;
      componentRef.instance.columnConfig_BYO_PRODUCTION = this.columnConfig_BYO_PRODUCTION;

      const url_BYO_Product = `${environment.ServiceURL_Main}BYO_PRODUCT?` + 'partNumbers=' + rowData.partNumber + '&type=' + rowData.type + '&remarks=' + rowData.remarks;

      this.send.sendRequest(url_BYO_Product, 'GET', null).subscribe((res: any) => {
        componentRef.instance.BYO_PRODUCT_SOURCE = res.source;
        componentRef.instance.dataSource_BYO_PRODUCT = res.data;
      });

      const url_BYO_Production = `${environment.ServiceURL_Main}BYO_PRODUCTION?` + 'partNumbers=' + rowData.partNumber + '&type=' + rowData.type + '&remarks=' + rowData.remarks + '&materialType=' + rowData.materialType;
      this.send.sendRequest(url_BYO_Production, 'GET', null).subscribe((res: any) => {
        componentRef.instance.BYO_PRODUCTION_SOURCE = res.source;
        componentRef.instance.dataSource_BYO_PRODUCTION = res.data;
      });

      componentRef.instance.historyColumn_BYO_PRODUCT_HIS = this.historyColumn_BYO_PRODUCT_HIS; //for BYO Product History
      componentRef.instance.historyColumnBYO = this.historyColumn_BYO_PRODUCTION_HIS; //for BYO Production History

      componentRef.instance.opn = rowData.partNumber; //for display OPN or MPN
      componentRef.instance.buyOffReason = rowData.buyOffReason;
      componentRef.instance.prefixChangeOrder = rowData.prefixChangeOrder;
      //componentRef.instance.productionChangeOrder = 'N' + String(buyoffRecord.productionChangeOrder).padStart(8, '0');

      if (rowData.type == "BYO_PRODUCT") {
        componentRef.instance.changeOrderType = "Product";
        this.showBuyoffProductButton = true && this.pagePermission.edit;
        this.showBuyoffProductionButton = false;
      } else if (rowData.type == "BYO_PRODUCTION") {
        componentRef.instance.changeOrderType = "Production";
        this.showBuyoffProductButton = false;
        this.showBuyoffProductionButton = true && this.pagePermission.edit;
      }

      const date = new Date(rowData.updateDateAndTime);
      const formatted =
        date.getFullYear() + '-' +
        String(date.getMonth() + 1).padStart(2, '0') + '-' +
        String(date.getDate()).padStart(2, '0') + ' ' +
        String(date.getHours()).padStart(2, '0') + ':' +
        String(date.getMinutes()).padStart(2, '0') + ':' +
        String(date.getSeconds()).padStart(2, '0');
      componentRef.instance.updateDateAndTime = formatted + ' (UTC)';

      if (rowData.remarks == "SCENARIO-2") {
        componentRef.instance.showHistory_BYO_PRODUCT = false; //hide BYO_PRODUCT history when SCENARIO-2
      } else {
        componentRef.instance.showHistory_BYO_PRODUCT = true;
      }

      if (rowData.remarks == "SCENARIO-3") {
        componentRef.instance.showHistory_BYO_PRODUCTION = false; //hide BYO_PRODUCTION history when SCENARIO-3
      } else {
        componentRef.instance.showHistory_BYO_PRODUCTION = true;
      }


      componentRef.changeDetectorRef.detectChanges();

      this.componentRefs.push(componentRef);
    });



  }
}
