import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { NoAddingMenuComponent } from './no-adding-menu/no-adding-menu.component'

const routes: Routes = [{ path: '', component: NoAddingMenuComponent }]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NoAddingMenuRoutingModule { }
