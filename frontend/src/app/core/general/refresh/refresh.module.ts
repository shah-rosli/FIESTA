import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { SharedModule } from '../../../shared/shared.module'
import { RefreshRoutingModule } from './refresh-routing.module'
import { RefreshComponent } from './refresh/refresh.component'

@NgModule({
  declarations: [
    RefreshComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RefreshRoutingModule
  ]
})
export class RefreshModule { }
