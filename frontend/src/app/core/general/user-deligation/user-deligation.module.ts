import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { SharedModule } from '../../../shared/shared.module'
import { UserDeligationRoutingModule } from './user-deligation-routing.module'
import { UserDeligationComponent } from './user-deligation/user-deligation.component'

@NgModule({
  declarations: [
    UserDeligationComponent
  ],
  imports: [
    CommonModule, SharedModule,
    UserDeligationRoutingModule
  ]
})
export class UserDeligationModule { }
