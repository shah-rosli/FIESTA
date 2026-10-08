import { Component } from '@angular/core'
import { BaseService } from '../../../service/base/base.service'


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  PageTitle: string = this.base.getMessage("Login")

  constructor(public base: BaseService) { }

}
