import { Component, Input, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment'
import { ByoHistoryPopupComponent } from '../byo-history-popup/byo-history-popup.component';
import { Column } from 'devextreme/ui/data_grid'
import { ByoVersionCompareComponent } from '../byo-version-compare/byo-version-compare.component';

@Component({
  selector: 'app-byo-production',
  templateUrl: './byo-production.component.html',
  styleUrl: './byo-production.component.scss'
})
export class ByoProductionComponent {
  @Input() dataSource_BYO_PRODUCT: any[] = [];
  @Input() dataSource_BYO_PRODUCTION: any[] = []; //for BYO_Production
  @Input() opn: string;
  @Input() buyOffReason: string;
  @Input() changeOrderType: string;
  @Input() prefixChangeOrder: string;
  @Input() updateDateAndTime: string;

  //@Input() historyColumn_BYO_PRODUCT_HIS_data: any; //for BYO_PRODUCT
  @Input() historyColumn_BYO_PRODUCT_HIS: Column[]; //for BYO_PRODUCT

  @Input() historyColumnBYO: Column[]; //for BYO_PRODUCTION_HISTORY

  @Input() columnConfig_BYO_PRODUCT: Column[];
  @Input() columnConfig_BYO_PRODUCTION: Column[];

  @Input() BYO_PRODUCT_SOURCE: string;
  @Input() BYO_PRODUCTION_SOURCE: string;

  isAccepted: boolean = true;
  environment = environment;

  @Input() showHistory_BYO_PRODUCT: boolean = true;
  @Input() showHistory_BYO_PRODUCTION: boolean = true; //hide BYO_PRODUCTION history when SCENARIO-3

  @ViewChild('historyPopup_BP') historyPopup_BP!: ByoHistoryPopupComponent;
  @ViewChild('historyPopup') historyPopup!: ByoHistoryPopupComponent;

  @ViewChild('versionComparePopup') versionComparePopup!: ByoVersionCompareComponent;


  ngOnInit() {

  }

  openHistory_BP(opn: string) {
    this.historyPopup_BP.open("BYO_PRODUCT_HIS", opn);
  }

  openHistory(opn: string) {
    this.historyPopup.open("BYO_PRODUCTION_HIS", opn);
  }

  openVersionCompare(opn: string, tableName: string) {
    if (tableName === "BYO_PRODUCT") {
      this.versionComparePopup.open(tableName, opn, this.columnConfig_BYO_PRODUCT);
    } else if (tableName === "BYO_PRODUCTION") {
      this.versionComparePopup.open(tableName, opn, this.columnConfig_BYO_PRODUCTION);
    }

  }



  handleRowPrepared_BYO_PRODUCT(e: any): void {
    if (e.rowType === 'data' && this.BYO_PRODUCT_SOURCE === 'BYO_PRODUCT') {
      e.rowElement.style.backgroundColor = '#faf19dff';

      // const partNumberCell = e.rowElement.querySelector('[aria-colindex="1"]');
      // if (partNumberCell) {
      //   partNumberCell.style.fontWeight = 'bold';
      //   partNumberCell.style.color = 'darkgreen';
      // }
    }
  }

  handleRowPrepared_BYO_PRODUCTION(e: any): void {
    if (e.rowType === 'data' && this.BYO_PRODUCTION_SOURCE === 'BYO_PRODUCTION') {
      e.rowElement.style.backgroundColor = '#faf19dff';

      // const partNumberCell_1 = e.rowElement.querySelector('[aria-colindex="1"]');
      // if (partNumberCell_1) {
      //   partNumberCell_1.style.fontWeight = 'bold';
      //   partNumberCell_1.style.color = 'darkgreen';
      // }

      // if (e.data.opn === e.data.partNumber || e.data.BYOProductPartNumber === e.data.partNumber) {
      //   //const partNumberCell = e.rowElement.querySelector('[aria-colindex="' + e.component.columnOption("partNumber").index + '"]');
      //   const partNumberCell = e.rowElement.querySelector('[aria-colindex="6"]');
      //   if (partNumberCell) {
      //     partNumberCell.style.fontWeight = 'bold';
      //     partNumberCell.style.color = 'darkgreen';
      //   }
      // }
    }

    if (e.rowType === 'data') {
      const partNumberCell = e.rowElement.querySelector('[aria-colindex="6"]');
      if (partNumberCell) {
        partNumberCell.style.fontWeight = 'bold';
      }
    }
  }

}
