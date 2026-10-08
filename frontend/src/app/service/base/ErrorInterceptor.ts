import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { confirm } from 'devextreme/ui/dialog'
import { ToastrService } from 'ngx-toastr'
import { Observable, throwError } from 'rxjs'
import { catchError } from 'rxjs/operators'
import { BaseService } from './base.service'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private base: BaseService, private toastr: ToastrService) { }

  ignoredURL = this.base.getIPAddressURL
  isConfirmDialogOpen: boolean = false;

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(err => {

      console.log("ErrorInterceptor:", err)

      console.log("ErrorInterceptor: se-error-handling " + request.headers.get("se-error-handling"))

      const isNotIgnoredURL = err.url != this.ignoredURL
      const matchStringHttpFailure = err.message.substring(0, 21) == "Http failure response"
      const matchStringUnknownError = err.statusText == "Unknown Error"
      if (isNotIgnoredURL && matchStringHttpFailure && matchStringUnknownError) {
        if (this.isConfirmDialogOpen) {
          return
        }
        this.isConfirmDialogOpen = true
        let result = confirm("System disconnected do you want to reload? <br> If the issue persists, click " +

          "<a href=\"https://renesasgroup.sharepoint.com/sites/collaborate/Penang/IT/_layouts/15/Doc.aspx?sourcedoc={88da69e5-7ab1-4eff-b70a-2307496e6c71}&action=edit&wd=target%28FAQs.one%7C12801391-e09d-4402-a50d-30097b78d293%2FVPN%20Disconnection%7C57336ce5-7bac-47b7-8d00-0e337efe1abb%2F%29&wdorigin=703\">here </a>"

          + "for help. ", "Reload confirmation")
        result.then((dialogResult) => {
          this.isConfirmDialogOpen = false
          if (dialogResult === true) {
            this.base.reload()
          }
        })
      }

      if (!request.headers.get("se-error-handling"))
        this.toastr.error(this.base.getMessage(err.message), this.base.getMessage('Error!'), errorToastOptions)

      return throwError(err)// what the API calling method will be received at error catch
    }))
  }
}