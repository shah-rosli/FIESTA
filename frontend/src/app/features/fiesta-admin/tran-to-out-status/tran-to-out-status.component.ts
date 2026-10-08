import { Component } from '@angular/core'
import { environment } from '../../../../environments/environment'
import { SendRequestService } from '../../../service/base/send-request.service'
import { Column } from 'devextreme/ui/data_grid'
import CustomStore from 'devextreme/data/custom_store'
import { timer } from 'rxjs'
import { map, switchMap, tap } from 'rxjs/operators'
import { DateTime } from "luxon"

@Component({
  selector: 'app-tran-to-out-status',
  templateUrl: './tran-to-out-status.component.html',
  styleUrl: './tran-to-out-status.component.scss'
})
export class TranToOutStatusComponent {
  PageTitle: string = "Chain Job Status"
  dataSource: CustomStore
  columnsConfig: Column[]

  constructor(
    private send: SendRequestService,
  ) { }

  ngOnInit(): void {
    this.initDataSource()
  }

  initDataSource() {
    const MILLISECONDS = 60000;

    timer(0, MILLISECONDS)
      .pipe(
        switchMap(() => this.getDataSource()),
        tap((res: any) => {
          this.dataSource = res.data;
        })
      )
      .subscribe();
  }

  getDataSource() {
    const url = `${environment.ServiceURL_Main}CfgSysTableConfig/GetTrantoOutStatusUI`;
    return this.send.sendRequest(url, 'GET');
  }

  onCellPrepared(e: any) {
    // data rows only
    if (e.rowType === 'data') {
      if (e.column?.dataField?.includes('SP_TRN_TO_OUT')
        || e.column?.dataField?.includes('SP_TRN')
        || e.column?.dataField?.includes('SP_TRAN')
        || e.column?.dataField?.includes('SP_PLM')
      ) {
        if (e.value === 'S') {
          e.cellElement.style.backgroundColor = '#ff0000';
          e.cellElement.style.color = '#ffffff';
        } else if (e.value === 'F' || e.value === 'R') {
          e.cellElement.style.backgroundColor = '#ffff00';
        } else if (e.value === 'I') {
          e.cellElement.style.backgroundColor = '#42a845';
          //e.cellElement.style.backgroundColor = '#0080ff';
        }
      } else if (e.column?.dataField?.includes('STATUS')) {
        if (e.value === 'RUNNING') {
          e.cellElement.style.color = '#0080ff';
        } else if (e.value === 'SUCCEEDED') {
          e.cellElement.style.color = '#42a845';
        } else {
          e.cellElement.style.color = '#ff0000';
        }
      } else if (e.column?.dataField?.includes('DURATION_HOURS') && e.value >= 150) {
        e.cellElement.style.backgroundColor = '#ffff00';
      }
    }
  }
}
