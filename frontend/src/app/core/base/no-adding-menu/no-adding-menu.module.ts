import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { SharedModule } from '../../../shared/shared.module'
import { NoAddingMenuRoutingModule } from './no-adding-menu-routing.module'
import { NoAddingMenuComponent } from './no-adding-menu/no-adding-menu.component'

@NgModule({
  declarations: [
    NoAddingMenuComponent
  ],
  imports: [
    CommonModule, SharedModule,
    NoAddingMenuRoutingModule
  ]
})
export class NoAddingMenuModule { }
