import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { PageError500Component } from './page-error500/page-error500.component'

const routes: Routes = [{ path: '', component: PageError500Component }]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PageError500RoutingModule { }
