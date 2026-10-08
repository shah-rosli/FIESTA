import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Router } from '@angular/router'
import { CookieService } from 'ngx-cookie-service'
import { ToastrService } from 'ngx-toastr'
import { catchError, timeout } from 'rxjs/operators'
import { environment } from 'src/environments/environment'
import * as AspNetData from 'devextreme-aspnet-data-nojquery-frombody'
import * as AspNetData2 from 'devextreme-aspnet-data-nojquery'
import { Observable } from 'rxjs'

type SendRequestMethods = "GET" | "PUT" | "POST" | "DELETE"

@Injectable({
  providedIn: 'root'
})
export class SendRequestService {

  constructor(
    private http: HttpClient,
    private router: Router,
    private toastr: ToastrService,
    private cookieService: CookieService
  ) { }

  sendRequest(URL: string, method: SendRequestMethods, data = null): Observable<any> {
    this.checkTimeOut()
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': '*/*',
      // 'Cache-Control': 'no-cache',
      // 'Access-Control-Allow-Origin': '*',
      // 'Access-Control-Allow-Credentials': 'true',
      // 'Access-Control-Allow-Headers': '*',
      // 'Access-Control-Allow-Methods': '*'
    })

    if (this.getUserToken()) {
      headers = headers.append('Authorization', 'Bearer ' + this.getUserToken())
    }

    const httpOptions = { withCredentials: environment.withCedential, headers: headers }
    switch (method) {
      case "GET":
        const httpParams = new HttpParams({ fromObject: data })
        const httpOptionsGet = { withCredentials: environment.withCedential, params: httpParams, headers: headers }
        return this.http.get(URL, httpOptionsGet)
      case "PUT":
        return this.http.put(URL, JSON.stringify(data), httpOptions)
      case "POST":
        return this.http.post(URL, JSON.stringify(data), httpOptions)
      case "DELETE":
        return this.http.delete(URL, httpOptionsGet)
    }
  }

  sendRequestDownloadFile(URL: string, contentType: string) {
    this.checkTimeOut()
    if (!this.getUserToken()) {
      throw new Error('this.getUserToken() is false')
    }
    let headers = new HttpHeaders({
      'Content-Type': contentType,
      'Accept': '*/*',
      // 'Cache-Control': 'no-cache',
      // 'Access-Control-Allow-Origin': '*',
      // 'Access-Control-Allow-Credentials': 'true',
      // 'Access-Control-Allow-Headers': '*',
      // 'Access-Control-Allow-Methods': '*',
      'Authorization': 'Bearer ' + this.getUserToken()
    })
    let httpOptionsGet = {
      withCredentials: environment.withCedential,
      headers: headers,
      responseType: 'arraybuffer'
    } as const
    return this.http.get(URL, httpOptionsGet)
  }

  /**
   * Use this to send objects with FormData interface.
   * It should generate correct Content-Type header
   */
  sendRequestFormData(URL: string, formData: FormData) {
    this.checkTimeOut()
    if (!this.getUserToken()) {
      return
    }
    let headers = new HttpHeaders({
      // 'Cache-Control': 'no-cache',
      'Accept': '*/*',
      // 'Access-Control-Allow-Origin': '*',
      // 'Access-Control-Allow-Credentials': 'true',
      // 'Access-Control-Allow-Headers': '*',
      // 'Access-Control-Allow-Methods': '*',
      'Authorization': 'Bearer ' + this.getUserToken()
    })
    let httpOptions = { withCredentials: environment.withCedential, headers: headers }
    return this.http.post(URL, formData, httpOptions)
  }

  //devextreme JSON posting with error handler
  sendRequestReturnLastInserted(url: string, method: string = "GET", data: any = {}): any {
    this.checkTimeOut()
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      // 'Access-Control-Allow-Origin': '*',
      // 'Access-Control-Allow-Credentials': 'true',
    })
    if (this.getUserToken()) {
      headers = headers.append('Authorization', 'Bearer ' + this.getUserToken())
    }

    let httpParams = new HttpParams({ fromObject: data })
    let httpOptions = { withCredentials: environment.withCedential, body: httpParams, headers: headers }
    let httpOptionsPost = { withCredentials: environment.withCedential, headers: headers }
    let result

    switch (method) {
      case "GET":
        result = this.http.get(url, httpOptions)
        break
      case "PUT":
        result = this.http.put(url, data, httpOptionsPost)
        break
      case "POST":
        result = this.http.post(url, data, httpOptionsPost)
        break
      case "DELETE":
        result = this.http.delete(url, httpOptions)
        break
    }

    return result
      .toPromise()
      .then((data: any) => {
        console.log("dtata", method === "GET" ? data : data)
        return method === "GET" ? data : data.Data[0]
      })
      .catch(e => {
        throw e && e.error && e.error.Message
      })
  }

  //devextreme JSON posting with error handler
  sendRequestDevExtreme(url: string, method: string = "GET", data: any = {}): any {
    this.checkTimeOut()
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      // 'Access-Control-Allow-Origin': '*',
      // 'Access-Control-Allow-Credentials': 'true',
    })
    if (this.getUserToken()) {
      headers = headers.append('Authorization', 'Bearer ' + this.getUserToken())
    }
    let httpParams = new HttpParams({ fromObject: data })
    let httpOptions = { withCredentials: environment.withCedential, body: httpParams, headers: headers }
    let httpOptionsPost = { withCredentials: environment.withCedential, headers: headers }
    let result

    switch (method) {
      case "GET":
        result = this.http.get(url, httpOptions)
        break
      case "PUT":
        result = this.http.put(url, data, httpOptionsPost)
        break
      case "POST":
        result = this.http.post(url, data, httpOptionsPost)
        break
      case "DELETE":
        result = this.http.delete(url, httpOptions)
        break
    }

    return result
      .toPromise()
      .then((data: any) => {
        return method === "GET" ? data : data
      })
      .catch(e => {
        throw e && e.error && e.error.Message
      })
  }

  sendRequestVirtual(key, url, params = {}) {
    return AspNetData.createStore({
      key: key,
      loadUrl: url,
      loadParams: params,
      onBeforeSend: (e, f) => {
        this.checkTimeOut()
        f.headers = {
          'Content-Type': 'application/json',
          'Accept': '*/*',
          // 'Cache-Control': 'no-cache',
          // 'Access-Control-Allow-Origin': '*',
          // 'Access-Control-Allow-Credentials': 'true',
          // 'Access-Control-Allow-Headers': '*',
          // 'Access-Control-Allow-Methods': '*',
          'Authorization': 'Bearer ' + this.getUserToken()
        }
      }
    })
  }

  sendRequestVirtualConfigurable(options: AspNetData.Options) {
    let mergedOptions = {
      ...{
        onBeforeSend: (e, f) => {
          this.checkTimeOut()
          f.headers = {
            'Authorization': 'Bearer ' + this.getUserToken(),
            'Content-Type': 'application/json'
          }
        }
      },
      ...options
    }
    return AspNetData.createStore(mergedOptions)
  }

  checkTimeOut() {
    let defaultTimeoutMins = 30

    if (localStorage.getItem('paramDictionary')) {
      //get timeout from param
      let temp = JSON.parse(localStorage.getItem('paramDictionary'))
      temp.forEach((element) => {
        if (element.PARAM_CATEGORY == 'System_Timeout' && element.PARAM_KEY == 'System_Timeout(Minute)') {
          defaultTimeoutMins = element.PARAM_VALUE
        }
        if (element.PARAM_CATEGORY == 'System_Offline' && element.PARAM_KEY == 'Yes') {
          this.router.navigate(['/Offline'])
        }
      })
    }

    if (localStorage.getItem("lastActiveTimestamp")) {
      //compare last active time
      let lastActiveTimestampVal = new Date(localStorage.getItem("lastActiveTimestamp")).getTime()
      let current = new Date().getTime()
      let diffMinute = Math.floor((current - lastActiveTimestampVal) / 60000)

      if (diffMinute > defaultTimeoutMins) {
        this.toastr.error("System time out! - relogin in progress " + "Inactive duration - " + diffMinute + " mins", "Time Out!")
        console.log("timeout")
        localStorage.setItem("activeUserId", "")

        setTimeout(() => {
          // relogin after timeout.
          window.location.reload() //this code cause toast error not shown , must put timeout
        }, 1000)
      }
    }

    //set new Active Timestamp
    let lastActiveTimestampVal = JSON.stringify(new Date())
    lastActiveTimestampVal = lastActiveTimestampVal.replace("\"", "")//remove first ""
    lastActiveTimestampVal = lastActiveTimestampVal.replace("\"", "")//remove second ""
    localStorage.setItem("lastActiveTimestamp", lastActiveTimestampVal)
  }

  getRequest(url) {
    return this.http.get(url).pipe(
      timeout(2000),
      catchError(e => {
        // do something on a timeout
        return null
      })
    ).toPromise().catch(err => {
      console.log(JSON.stringify(err))
    })
  }

  getUserToken() {
    return this.cookieService.get('userToken')
  }
}
