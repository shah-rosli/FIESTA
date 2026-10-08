import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { UserDeligationHistoryComponent } from './user-deligation-history/user-deligation-history.component'

const routes: Routes = [{ path: '', component: UserDeligationHistoryComponent }]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserDeligationHistoryRoutingModule { }
