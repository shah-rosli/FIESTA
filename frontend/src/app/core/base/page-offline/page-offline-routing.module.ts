import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { PageOfflineComponent } from './page-offline/page-offline.component'

const routes: Routes = [{ path: '', component: PageOfflineComponent }]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PageOfflineRoutingModule { }
