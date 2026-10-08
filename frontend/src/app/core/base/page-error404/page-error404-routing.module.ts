import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { PageError404Component } from './page-error404/page-error404.component'

const routes: Routes = [{ path: '', component: PageError404Component }]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PageError404RoutingModule { }
