import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { SharedModule } from '../../../shared/shared.module'
import { PageError500RoutingModule } from './page-error500-routing.module'
import { PageError500Component } from './page-error500/page-error500.component'

@NgModule({
  declarations: [
    PageError500Component
  ],
  imports: [
    CommonModule, SharedModule,
    PageError500RoutingModule
  ]
})
export class PageError500Module { }
