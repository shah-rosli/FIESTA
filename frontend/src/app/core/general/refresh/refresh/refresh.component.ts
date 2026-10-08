import { Component } from '@angular/core'
import { Router } from '@angular/router'
import { CookieService } from 'ngx-cookie-service'
import { BaseService } from '../../../../service/base/base.service'


@Component({
  selector: 'app-refresh',
  templateUrl: './refresh.component.html',
  styleUrls: ['./refresh.component.scss'],
  providers: [BaseService]
})
export class RefreshComponent {
  constructor(public cookieService: CookieService, private router: Router,) {
  }



  ngOnInit() {

    console.log("entering refresh")
    console.log(this.router.url)
    let urlThatUserTryToRefresh = this.cookieService.get("urlThatUserTryToRefresh")

    if (urlThatUserTryToRefresh) {
      console.log("will navigate to urlThatUserTryToRefresh : " + urlThatUserTryToRefresh)
      this.cookieService.delete("urlThatUserTryToRefresh")
      location.href = urlThatUserTryToRefresh//navigate to "/" and make a full load page, means with app component loads- sign in
    }
    else {
      console.log("will navigate to /")
      location.href = '/'//navigate to "/" and make a full load page, means with app component loads- sign in
    }

  }

}
