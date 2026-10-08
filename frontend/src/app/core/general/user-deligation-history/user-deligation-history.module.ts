import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { SharedModule } from '../../../shared/shared.module'
import { UserDeligationHistoryRoutingModule } from './user-deligation-history-routing.module'
import { UserDeligationHistoryComponent } from './user-deligation-history/user-deligation-history.component'

@NgModule({
  declarations: [
    UserDeligationHistoryComponent
  ],
  imports: [
    CommonModule, SharedModule,
    UserDeligationHistoryRoutingModule
  ]
})
export class UserDeligationHistoryModule { }
