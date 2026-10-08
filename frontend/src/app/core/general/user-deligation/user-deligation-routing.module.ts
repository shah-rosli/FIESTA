import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { UserDeligationComponent } from './user-deligation/user-deligation.component'

const routes: Routes = [{ path: '', component: UserDeligationComponent }]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserDeligationRoutingModule { }
