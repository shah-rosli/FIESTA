import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { SharedModule } from '../../../shared/shared.module'
import { PageError401RoutingModule } from './page-error401-routing.module'
import { PageError401Component } from './page-error401/page-error401.component'

@NgModule({
  declarations: [
    PageError401Component
  ],
  imports: [
    CommonModule, SharedModule,
    PageError401RoutingModule
  ]
})
export class PageError401Module { }
