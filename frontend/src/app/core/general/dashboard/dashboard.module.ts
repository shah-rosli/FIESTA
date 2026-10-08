import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { SharedModule } from '../../../shared/shared.module'
import { DashboardRoutingModule } from './dashboard-routing.module'
import { DashboardComponent } from './dashboard/dashboard.component'
import { DxChartModule, DxPieChartModule } from 'devextreme-angular'

@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    DxPieChartModule,
    DxChartModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }
