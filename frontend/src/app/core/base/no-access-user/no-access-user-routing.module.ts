import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { NoAccessUserComponent } from './no-access-user/no-access-user.component'

const routes: Routes = [{ path: '', component: NoAccessUserComponent }]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NoAccessUserRoutingModule { }
