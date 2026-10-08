import { Component, Inject } from '@angular/core'
import { Event, NavigationEnd, RouteConfigLoadStart, Router } from '@angular/router'
import { MsalBroadcastService, MsalGuardConfiguration, MsalService, MSAL_GUARD_CONFIG } from '@azure/msal-angular'
import { AuthenticationResult, EventMessage, EventType, InteractionStatus, RedirectRequest } from '@azure/msal-browser'
import { loadMessages, locale } from 'devextreme/localization'
import { CookieService } from 'ngx-cookie-service'
import { ToastrService } from 'ngx-toastr'
import { Subject } from 'rxjs'
import { filter, takeUntil } from 'rxjs/operators'
import { BaseService } from 'src/app/service/base/base.service'
import { SendRequestService } from 'src/app/service/base/send-request.service'
import { environment } from 'src/environments/environment'
import { MessageEventManager } from './service/base/message.event.service'
import { TokenProperties } from './app.module'
import { errorToastOptions } from './shared/utils/errorToastOption'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  title = 'FIESTA';
  msalInstance: any
  private readonly _destroying$ = new Subject<void>();
  previousUrl = ""
  locales: any = null;
  locale: string = null;
  ssoInProgress: boolean = false
  isIframe = false;
  loginDisplay = false;
  readyToPopulateRouterURL = false;
  routerPageLoader = { willShowLoading: false, loading: false }

  constructor(
    public base: BaseService,
    private send: SendRequestService,
    private router: Router,
    @Inject(MSAL_GUARD_CONFIG) private msalGuardConfig: MsalGuardConfiguration,
    private toastr: ToastrService,
    private authService: MsalService,
    private msalBroadcastService: MsalBroadcastService,
    private messageEventManager: MessageEventManager,
    private cookieService: CookieService
  ) {
    if (environment.production) {
      if (location.protocol === 'http:') {
        if (environment.enableMsal)
          window.location.href = location.href.replace('http', 'https')
      }
    }

    router.events.subscribe((event: Event) => {
      this.navigationIntercept(event)
    })
  }

  ngOnInit() {
    console.log("enter AppComponent")
    if (!environment.enableMsal)
      this.userSSOLogin()//TEMP

    this.isIframe = window !== window.parent && !window.opener // Remove this line to use Angular Universal

    //below will cater for relogin
    this.messageEventManager.subscribe('sidemenuDone', () => {
      this.loginDisplay = true
      this.ssoInProgress = false
    })

    this.authService.instance.enableAccountStorageEvents() // Optional - This will enable ACCOUNT_ADDED and ACCOUNT_REMOVED events emitted when a user logs in or out of another tab or window
    this.msalBroadcastService.msalSubject$
      .pipe(
        filter((msg: EventMessage) => msg.eventType === EventType.ACCOUNT_ADDED || msg.eventType === EventType.ACCOUNT_REMOVED),
      )
      .subscribe((result: EventMessage) => {
        console.log("msalSubject EventMessage: ", result)

        if (result.eventType === EventType.ACCOUNT_ADDED) {
          //this.toastr.show("ACC ADDDED")
        }
        // else
        //this.toastr.show(result.eventType)
      })

    this.msalBroadcastService.msalSubject$
      .pipe(
        filter((msg: EventMessage) => msg.eventType === EventType.LOGIN_SUCCESS),
      )
      .subscribe((result: EventMessage) => {
        console.log(result)
        const payload = result.payload as AuthenticationResult
        this.authService.instance.setActiveAccount(payload.account)
        let accountObj = payload.account.username
        const id_token = payload.idToken
        const access_token = payload.accessToken
        console.log(payload)
        console.log("accountObj :  " + accountObj)
        console.log("id_token :  " + id_token)
        console.log("access_token :  " + access_token)
        localStorage.setItem("activeUserId", accountObj)
      })

    this.msalBroadcastService.inProgress$
      .pipe(
        filter((status: InteractionStatus) => status === InteractionStatus.None),
        takeUntil(this._destroying$)
      )
      .subscribe((x) => {
        console.log("inProgress ", x)
        this.checkAndSetActiveAccount()
      })
  }

  checkAndSetActiveAccount() {
    /**
     * If no active account set but there are accounts signed in, sets first account to active account
     * To use active account set here, subscribe to inProgress$ first in your component
     * Note: Basic usage demonstrated. Your app may require more complicated account selection logic
     */

    console.log("checkAndSetActiveAccount")
    let activeAccount = this.authService.instance.getActiveAccount()

    if (!activeAccount && this.authService.instance.getAllAccounts().length > 0) {
      let accounts = this.authService.instance.getAllAccounts()
      this.authService.instance.setActiveAccount(accounts[0])
      localStorage.setItem("activeUserId", accounts[0].username)
      console.log(accounts[0])
      //this.toastr.show("set active acc")
      console.log("set active account")
      this.userSSOLogin()
    }

    else if (!activeAccount) {
      console.log("msalactiveguard will decide to login or not")
      //this.toastr.show("msalguard")
      //this.loginRedirect() - use msalactiveguard
    }
    else if (!localStorage.getItem("activeUserId"))//reconnect vpn test case & lastActiveTimestamp (token expired/timeout)
    //. has account
    {
      console.log("RECONNECT")
      this.authService.instance.setActiveAccount(null)
      window.location.reload()
    }
    else {
      //this.toastr.show("4")
      this.loginDisplay = true // user has active account alrdy
      console.log("has account ", this.authService.instance.getAllAccounts().length > 0)
      this.userSSOLogin()
    }
  }

  loginRedirect() {
    if (!this.base.isGeneralPage()) {
      console.log("LETS LOGIN")
      if (this.msalGuardConfig.authRequest) {
        console.log("1")
        this.authService.loginRedirect({ ...this.msalGuardConfig.authRequest } as RedirectRequest)
      } else {
        console.log("2")
        this.authService.loginRedirect()
      }
    }
  }

  navigationIntercept(event) {
    if (event instanceof RouteConfigLoadStart) {
      // will show loading when lazy load takes longer then a specified time.
      this.routerPageLoader.willShowLoading = true
      const waitDuration = 600
      setTimeout(() => {
        if (this.routerPageLoader.willShowLoading) {
          this.routerPageLoader.loading = true
        }
      }, waitDuration)
      return
    }
    if (event instanceof NavigationEnd) {
      console.log('prev:', event.url)
      this.previousUrl = event.url

      // cors error, refresh , after login it will go to /Login
      if (event.url == "/Login") {
        // vpn not connected then page reloaded, insert microsoft username n pwd then text msg number verification then here code hitted
        console.log("Try to go to /Login, go to / instead")
        this.router.navigate(['/'])
      }
      // general page , always show content without any sign in
      else if (this.base.isGeneralPage()) {
        this.loginDisplay = true
        console.log("Display general page")
      }
      else if (!this.base.isGeneralPage() && !event.url.includes("/Login")) {
        this.cookieService.set("urlThatUserTryToOpen", event.url)
        console.log('urlThatUserTryToOpen:', event.url)
      }

      this.readyToPopulateRouterURL = true
    }
    this.routerPageLoader = { willShowLoading: false, loading: false }
  }

  isTemplate(): boolean {
    //this.router.url is = "/" at very first load, so use readyToPopulateRouterURL when this.router.url is appoint to correct url
    if (this.base.isGeneralPage()) {
      return false
    }
    else if (
      this.router.url.includes("PurchaseRequest-View") ||
      this.router.url.includes("InvestmentProposal-View") ||
      this.router.url.includes("CapitalInvestment-View")
    ) {
      return false
    } else if (this.cookieService.get("UserInfo") === null) {
      return false
    } else {
      return true
    }
  }

  ngOnDestroy(): void {
    console.log("destroy")
    this._destroying$.next(undefined)
    this._destroying$.complete()
  }

  userSSOLogin() {
    this.deploymentValidation()
    if (localStorage.getItem("DeligationActiveFlag") === "true") {
      console.log("DeligationActiveFlag is true")

      this.ssoInProgress = true
      this.getJwtToken()
    }
    else {
      let emailToken = localStorage.getItem("activeUserId")
      if (!environment.enableMsal) {
        // using this email when disable Msal
        emailToken = "poh-leng.tan.kf@renesas.com"
      }
      if (!emailToken) {
        // should go to RECONNECT. already handle earlier at RECONNECT
        console.error("Can't do userSSOLogin, token is null")
      }
      const isUserAttributeNotSet = !this.cookieService.get("UserInfo")
      const updateUserInfoFlag = localStorage.getItem("updateUserInfo")
      const encryptedEmailInCookieNotSet = !this.cookieService.get("EncryptData") // TODO: this makes no sense, it was never set, will always return true
      if (isUserAttributeNotSet || updateUserInfoFlag || encryptedEmailInCookieNotSet) {
        console.log("userSSOLogin is required")
        // localStorage.getItem("DeligationActiveFlag") === "false" also need to run, in case of change back to original logged in user
        localStorage.removeItem("updateUserInfo")

        this.ssoInProgress = true
        this.getJwtToken(emailToken)
      }
      else {
        console.log("userSSOLogin is not required")
      }
    }
  }

  getJwtToken(emailToken?) {
    let payload = {
      key: null,
      delegateid: null
    }

    if (emailToken) {
      this.cookieService.set("msToken", emailToken)
      let EncryptData = this.base.encrypt(emailToken) // encrypt email id from Msal
      localStorage.setItem("EncryptData", EncryptData)
      payload.key = EncryptData
      payload.delegateid = "0"
    } else {
      payload.key = localStorage.getItem("EncryptData")
      payload.delegateid = localStorage.getItem("DeligateeId")
    }

    console.log("jwt/key payload", payload)

    this.send.sendRequest(`${environment.ServiceURL_Main}jwt/key`, "POST", payload).subscribe(
      response => {
        console.log("jwt/key complete")
        localStorage.removeItem("localStorageUserList") //TODO: why is this here? should centralize logic in user service
        this.cookieService.set('userToken', response.data)

        this.getTokenProperties()
        this.setSystemParam()
      }
    )
  }

  getTokenProperties() {
    this.send.sendRequest(`${environment.ServiceURL_Main}jwt/tokenproperties`, "GET", "").subscribe(
      (tokenProperties: TokenProperties) => {
        console.log({ tokenProperties })

        if (!tokenProperties.USER_FULL_NAME) {
          this.ssoInProgress = false
          this.cookieService.delete("UserInfo")
          this.router.navigate(['NoAccessUser'])
          return
        }
        if (tokenProperties.ACTIVE !== 'Yes') {
          this.ssoInProgress = false
          console.log("navigate to pageerror401")
          this.router.navigate(['/PageError401'])
          this.toastr.error("User is inactive", 'Error!', errorToastOptions)
        } else {
          // active user
          this.cookieService.set("UserInfo", JSON.stringify(tokenProperties))

          // to hide "no view permission template", will need to wait getSideMenu() finish, then show template.
          // getSideMenu() will send a message here.
          this.base.getSideMenu(tokenProperties.USER_ID)
        }
      },
      _ => {
        this.ssoInProgress = false
      }
    )
  }

  setSystemParam() {
    let ParamList_Param: Object = {}
    this.send.sendRequest(`${environment.ServiceURL_Main}systemparam`, "GET", ParamList_Param).subscribe(
      data => {
        this.base.setParamData(data)
        // this.setLanguage()
      }
    )
  }

  setLanguage() {
    let varLangDic: any = null
    let ParamList_Param: Object = {}

    this.send.sendRequest(`${environment.ServiceURL_Main}systemlanguage`, "GET", ParamList_Param).subscribe(
      data => {
        varLangDic = data
        loadMessages(this.base.getDictionaryData(varLangDic))
        this.locales = this.base.getLanguageCodeData()
        this.locale = this.base.getLanguageData()
        locale(this.locale)
      }
    )
  }

  deploymentValidation() {
    const urlInBundle = new URL(environment.ServiceURL_Main)
    const urlInBrowser = new URL(window.location.href)
    if (!urlInBrowser.hostname.endsWith("renesas.com")) {
      // skip validation when in localhost
      return
    }
    if (urlInBrowser.hostname !== urlInBundle.hostname) {
      this.toastr.error(`This bundle is intended for ${urlInBundle.hostname}, but opened in ${urlInBrowser.hostname}, please contact support to resolve this error.`, "Environment mismatch!", errorToastOptions)
    }
  }

  sidebarOverlayClicked() {
    this.messageEventManager.broadcast({ name: 'sidebarOverlayClicked' })
  }
}