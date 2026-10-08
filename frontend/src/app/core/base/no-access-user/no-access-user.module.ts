import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { SharedModule } from '../../../shared/shared.module'
import { NoAccessUserRoutingModule } from './no-access-user-routing.module'
import { NoAccessUserComponent } from './no-access-user/no-access-user.component'

@NgModule({
  declarations: [
    NoAccessUserComponent
  ],
  imports: [
    CommonModule, SharedModule,
    NoAccessUserRoutingModule
  ]
})
export class NoAccessUserModule { }
