import { Component } from '@angular/core'
import { BaseService } from '../../../../service/base/base.service'
import { CookieService } from 'ngx-cookie-service'
import { Router } from '@angular/router'



@Component({
  selector: 'app-no-access-user',
  templateUrl: './no-access-user.component.html',
  styleUrls: ['./no-access-user.component.scss'],
  providers: [BaseService]
})

export class NoAccessUserComponent {
  PageTitle: string = this.base.getMessage("User has no access");

  constructor(
    private base: BaseService,
    private cookieService: CookieService,
    private router: Router
  ) { }

  ngOnInit() {
    if (this.cookieService.check("UserInfo")) {
      this.router.navigate(['/'])
    }
  }
}
