import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { SharedModule } from '../../../shared/shared.module'
import { PageOfflineRoutingModule } from './page-offline-routing.module'
import { PageOfflineComponent } from './page-offline/page-offline.component'

@NgModule({
  declarations: [
    PageOfflineComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    PageOfflineRoutingModule
  ]
})
export class PageOfflineModule { }
