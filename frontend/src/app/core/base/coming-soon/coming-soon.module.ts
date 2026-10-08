import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { SharedModule } from '../../../shared/shared.module'
import { ComingSoonRoutingModule } from './coming-soon-routing.module'
import { ComingSoonComponent } from './coming-soon/coming-soon.component'

@NgModule({
  declarations: [
    ComingSoonComponent
  ],
  imports: [
    CommonModule, SharedModule,
    ComingSoonRoutingModule
  ]
})
export class ComingSoonModule { }
