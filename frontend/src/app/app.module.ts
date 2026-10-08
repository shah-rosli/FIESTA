//Core import
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http'
import { ApplicationRef, ErrorHandler, NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { MsalBroadcastService, MsalGuard, MsalGuardConfiguration, MsalInterceptor, MsalInterceptorConfiguration, MsalModule, MsalRedirectComponent, MsalService, MSAL_GUARD_CONFIG, MSAL_INSTANCE, MSAL_INTERCEPTOR_CONFIG } from '@azure/msal-angular'
import { BrowserCacheLocation, InteractionType, IPublicClientApplication, LogLevel, PublicClientApplication } from '@azure/msal-browser'
//dev extreme multilingual import
import { loadMessages } from 'devextreme/localization'
import { ToastrModule } from 'ngx-toastr'
import jaMessages from 'src/app/core/localization/devExtreme_jaMesseges.json'
import zhMessages from 'src/app/core/localization/devExtreme_zhMesseges.json'
import { environment } from 'src/environments/environment'
import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { FooterComponent } from './core/base/footer/footer.component'
import { HeaderUserComponent } from './core/base/header-user/header-user.component'
import { HeaderComponent } from './core/base/header/header.component'
import { LoginComponent } from './core/base/login/login.component'
import { SidebarMenuComponent } from './core/base/sidebar-menu/sidebar-menu.component'
import { SidebarComponent } from './core/base/sidebar/sidebar.component'
import { SharedModule } from './shared/shared.module'
import { ErrorInterceptor } from './service/base/ErrorInterceptor'
import { GlobalErrorHandler } from './service/base/GlobalErrorHandler'
import { MsalComponent } from './core/base/msal/MsalComponent'
import { JwtInterceptor } from './service/base/JwtInterceptor'
import { OverlayscrollbarsModule } from 'overlayscrollbars-ngx';

export interface TokenProperties {
  CFG_USER_ID: number
  USER_ID: string
  USER_DS_NUMBER?: string | null
  USER_EMAIL: string
  USER_FULL_NAME: string
  USER_FIRST_NAME: string
  USER_LAST_NAME: string
  DEFAULT_COST_CENTER?: any
  USER_COMPANY_CODE: string
  USER_LOCAL_GRADE?: any
  USER_LOCAL_TITLE: string
  USER_GLOBAL_GRADE?: any
  USER_GLOBAL_TITLE: string
  USER_GLOBAL_UNIT?: any
  USER_GLOBAL_UNIT_CODE?: any
  USER_GLOBAL_UNIT_NAME?: any
  USER_GLOBAL_DIV: string
  USER_GLOBAL_DIV_CODE?: any
  USER_GLOBAL_DIV_NAME?: any
  USER_MANAGER_USER_ID?: any
  ACTIVE: string
  DEFAULT_TIMEZONE: string
  DEFAULT_DISP_DATE_FORMAT: string
  DEFAULT_DISP_TIME_FORMAT: string
  DEFAULT_DISP_DATETIME_FORMAT: string
  DEFAULT_LANGUAGE: string
  DELEGATE_ID: string
  USER_GROUPS: string | string[]
}

loadMessages(jaMessages)
loadMessages(zhMessages)

function loggerCallback(logLevel: LogLevel, message: string) {
  console.log(message)
}

function MSALInstanceFactory(): IPublicClientApplication {
  const redirectUriVal = environment.redirectUri
  return new PublicClientApplication({
    auth: {
      clientId: environment.clientId,
      authority: environment.authority,
      redirectUri: redirectUriVal,
      postLogoutRedirectUri: environment.postLogoutRedirectUri
    },
    cache: {
      cacheLocation: BrowserCacheLocation.LocalStorage,
    },
    system: {
      loggerOptions: {
        loggerCallback,
        logLevel: LogLevel.Info,
        piiLoggingEnabled: false
      }
    }
  })
}

function MSALGuardConfigFactory(): MsalGuardConfiguration {
  return {
    interactionType: InteractionType.Redirect,
    authRequest: {
      scopes: ['openid']
    },
    loginFailedRoute: '/PageError401'
  }
}

function MSALInterceptorConfigFactory(): MsalInterceptorConfiguration {
  const protectedResourceMap = new Map<string, Array<string>>()
  // protectedResourceMap.set('https://graph.microsoft.com/v1.0/me', ['user.read']); // Prod environment. Uncomment to use.

  return {
    interactionType: InteractionType.Redirect,
    protectedResourceMap
  }
}

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    SidebarMenuComponent,
    HeaderUserComponent,
    SidebarMenuComponent,
    LoginComponent,
    MsalComponent,
  ],
  bootstrap: [AppComponent, MsalRedirectComponent],
  imports: [
    BrowserModule,
    SharedModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 3000,
    }),
    MsalModule,
    OverlayscrollbarsModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true
    },
    {
      provide: MSAL_INSTANCE,
      useFactory: MSALInstanceFactory
    },
    {
      provide: MSAL_GUARD_CONFIG,
      useFactory: MSALGuardConfigFactory
    },
    {
      provide: MSAL_INTERCEPTOR_CONFIG,
      useFactory: MSALInterceptorConfigFactory
    },
    MsalService,
    MsalGuard,
    MsalBroadcastService,
    { provide: ErrorHandler, useClass: GlobalErrorHandler },
    provideHttpClient(withInterceptorsFromDi())
  ]
})

export class AppModule {
  constructor() {
    console.log('APP Module Constructor!')
  }
  ngDoBootstrap(ref: ApplicationRef) {
    if (window !== window.parent && !window.opener) {
      console.log("Bootstrap: MSAL")
      ref.bootstrap(MsalComponent)
    }
    else {
      console.log("Bootstrap: App")
      ref.bootstrap(AppComponent)
    }
  }
}

