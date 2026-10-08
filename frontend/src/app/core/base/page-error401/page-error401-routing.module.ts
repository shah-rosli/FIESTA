import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { PageError401Component } from './page-error401/page-error401.component'

const routes: Routes = [{ path: '', component: PageError401Component }]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PageError401RoutingModule { }
