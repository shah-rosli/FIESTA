import { Component } from '@angular/core'
import { BaseService } from '../../../../service/base/base.service'

@Component({
  selector: 'app-page-error500',
  templateUrl: './page-error500.component.html',
  styleUrls: ['./page-error500.component.scss'],
  providers: [BaseService]
})
export class PageError500Component {

  PageTitle: string = this.base.getMessage("Page Error 500");

  constructor(public base: BaseService) { }

}
