import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { OpnSummaryRoutingModule } from './opn-summary-routing.module'
import { OpnSummaryComponent } from './opn-summary.component'
import { SharedModule } from 'src/app/shared/shared.module'


@NgModule({
  declarations: [
    OpnSummaryComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    OpnSummaryRoutingModule
  ]
})
export class OpnSummaryModule { }
