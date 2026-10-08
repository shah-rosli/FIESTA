import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { SharedModule } from '../../../shared/shared.module'
import { PageError404Component } from './page-error404/page-error404.component'
import { PageError404RoutingModule } from './page-error404-routing.module'

@NgModule({
  declarations: [
    PageError404Component
  ],
  imports: [
    CommonModule, SharedModule,
    PageError404RoutingModule
  ]
})
export class PageError404Module { }
