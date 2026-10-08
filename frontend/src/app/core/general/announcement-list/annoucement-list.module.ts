import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { SharedModule } from '../../../shared/shared.module'
import { AnnouncementListRoutingModule } from './annoucement-list-routing.module'
import { AnnouncementListComponent } from './annoucement-list/announcement-list.component'

@NgModule({
  declarations: [
    AnnouncementListComponent
  ],
  imports: [
    CommonModule, SharedModule,
    AnnouncementListRoutingModule
  ]
})
export class AnnouncementListModule { }
