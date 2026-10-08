import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { OpnSummaryComponent } from './opn-summary.component'

const routes: Routes = [{ path: '', component: OpnSummaryComponent }]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OpnSummaryRoutingModule { }
