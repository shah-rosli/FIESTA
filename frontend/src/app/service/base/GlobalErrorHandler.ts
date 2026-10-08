import { ErrorHandler, Injectable } from '@angular/core'

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {

  handleError(error: any): void {
    console.error("Caught by GlobalErrorHandler", error)

    if (error.message.includes('Failed to fetch dynamically imported module')) {
      // Could be:
      // 1. Legit network disconnect
      // 2. User has old version of the app and is trying to load a non-existent chuck
      // 3. User VPN disconnects just before navigating and chuck load is blocked by application proxy status 302
      // Ref: https://stackoverflow.com/questions/49198268/how-to-overcome-loading-chunk-failed-with-angular-lazy-loaded-modules
      window.location.reload()
    }
  }
}
