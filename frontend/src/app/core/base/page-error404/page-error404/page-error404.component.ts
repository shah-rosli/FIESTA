import { Component } from '@angular/core'
import { BaseService } from '../../../../service/base/base.service'

@Component({
  selector: 'app-page-error404',
  templateUrl: './page-error404.component.html',
  styleUrls: ['./page-error404.component.scss'],
  providers: [BaseService]
})
export class PageError404Component {

  PageTitle: string = this.base.getMessage("Page Error 404");

  constructor(public base: BaseService) { }

}
