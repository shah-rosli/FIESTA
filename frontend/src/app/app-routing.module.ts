import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { MsalGuard } from '@azure/msal-angular'
import { environment } from 'src/environments/environment'
import { ComingSoonComponent } from './core/base/coming-soon/coming-soon/coming-soon.component'
import { NoAccessUserComponent } from './core/base/no-access-user/no-access-user/no-access-user.component'
import { NoAddingMenuComponent } from './core/base/no-adding-menu/no-adding-menu/no-adding-menu.component'
import { PageError401Component } from './core/base/page-error401/page-error401/page-error401.component'
import { PageError404Component } from './core/base/page-error404/page-error404/page-error404.component'
import { PageError500Component } from './core/base/page-error500/page-error500/page-error500.component'
import { PageOfflineComponent } from './core/base/page-offline/page-offline/page-offline.component'
import { AnnouncementListComponent } from './core/general/announcement-list/annoucement-list/announcement-list.component'
import { DashboardComponent } from './core/general/dashboard/dashboard/dashboard.component'
import { RefreshComponent } from './core/general/refresh/refresh/refresh.component'
import { UserDeligationHistoryComponent } from './core/general/user-deligation-history/user-deligation-history/user-deligation-history.component'
import { UserDeligationComponent } from './core/general/user-deligation/user-deligation/user-deligation.component'
import { OpnSummaryComponent } from './features/opn/opn-summary/opn-summary.component'
import { UserBuyoffComponent } from './features/fiesta-masters/fiesta-masters/user-buyoff/user-buyoff.component'


const guards: any[] = environment.enableMsal ? [MsalGuard] : []

const routes: Routes = [

  { path: '', redirectTo: 'Dashboard', pathMatch: 'full' },

  // general features
  {
    path: 'Dashboard',
    component: DashboardComponent,
    canActivate: guards,
    loadChildren: () => import('./core/general/dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path: 'AnnouncementList',
    component: AnnouncementListComponent,
    canActivate: guards,
    loadChildren: () => import('./core/general/announcement-list/annoucement-list.module').then(m => m.AnnouncementListModule)
  },
  {
    path: 'UserDelegation',
    component: UserDeligationComponent,
    canActivate: guards,
    loadChildren: () => import('./core/general/user-deligation/user-deligation.module').then(m => m.UserDeligationModule)
  },
  {
    path: 'UserDelegation-report',
    component: UserDeligationHistoryComponent,
    canActivate: guards,
    loadChildren: () => import('./core/general/user-deligation-history/user-deligation-history.module').then(m => m.UserDeligationHistoryModule)
  },

  // general
  {
    path: 'refresh',
    component: RefreshComponent,
    loadChildren: () => import('./core/general/refresh/refresh.module').then(m => m.RefreshModule)
  },
  {
    path: 'ComingSoon',
    component: ComingSoonComponent,
    canActivate: guards,
    loadChildren: () => import('./core/base/coming-soon/coming-soon.module').then(m => m.ComingSoonModule)
  },
  {
    path: 'NoSideMenu',
    component: NoAddingMenuComponent,
    canActivate: guards,
    loadChildren: () => import('./core/base/no-adding-menu/no-adding-menu.module').then(m => m.NoAddingMenuModule)
  },
  {
    path: 'PageError401',
    component: PageError401Component,
    canActivate: guards,
    loadChildren: () => import('./core/base/page-error401/page-error401.module').then(m => m.PageError401Module)
  },
  {
    path: 'PageError404',
    component: PageError404Component,
    canActivate: guards,
    loadChildren: () => import('./core/base/page-error404/page-error404.module').then(m => m.PageError404Module)
  },
  {
    path: 'PageError500',
    component: PageError500Component,
    canActivate: guards,
    loadChildren: () => import('./core/base/page-error500/page-error500.module').then(m => m.PageError500Module)
  },
  {
    path: 'Offline',
    component: PageOfflineComponent,
    canActivate: guards,
    loadChildren: () => import('./core/base/page-offline/page-offline.module').then(m => m.PageOfflineModule)
  },
  {
    path: 'NoAccessUser',
    component: NoAccessUserComponent,
    canActivate: guards,
    loadChildren: () => import('./core/base/no-access-user/no-access-user.module').then(m => m.NoAccessUserModule)
  },

  // everything else
  {
    path: 'OpnSummary',
    component: OpnSummaryComponent,
    canActivate: guards,
    loadChildren: () => import('./features/opn/opn-summary/opn-summary.module').then(m => m.OpnSummaryModule)
  },

  // feature module
  {
    path: 'inbound',
    canActivate: guards,
    loadChildren: () => import('./features/fiesta-inbound/fiesta-inbound.module').then(m => m.FiestaInboundModule)
  },
  {
    path: 'outbound',
    canActivate: guards,
    loadChildren: () => import('./features/fiesta-outbound/fiesta-outbound.module').then(m => m.FiestaOutboundModule)
  },
  {
    path: 'masters',
    canActivate: guards,
    loadChildren: () => import('./features/fiesta-masters/fiesta-masters.module').then(m => m.FiestaMastersModule)
  },
  {
    path: 'config',
    canActivate: guards,
    loadChildren: () => import('./features/fiesta-config/fiesta-config.module').then(m => m.FiestaConfigModule)
  },
  {
    path: 'admin',
    canActivate: guards,
    loadChildren: () => import('./features/fiesta-admin/fiesta-admin.module').then(m => m.FiestaAdminModule)
  },
  {
    path: 'plm',
    canActivate: guards,
    loadChildren: () => import('./features/plm-masters/plm-masters.module').then(m => m.PlmMastersModule)
  },
  {
    path: 'trn',
    canActivate: guards,
    loadChildren: () => import('./features/trn-masters/trn-masters.module').then(m => m.TrnMastersModule)
  },
  {
    path: 'mdm',
    canActivate: guards,
    loadChildren: () => import('./features/mdm-masters/mdm-masters.module').then(m => m.MdmMastersModule)
  },
  {
    path: 'mdmconfig',
    canActivate: guards,
    loadChildren: () => import('./features/mdm-config/mdm-config.module').then(m => m.MdmConfigModule)
  },

  { path: '**', redirectTo: 'PageError404' }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
