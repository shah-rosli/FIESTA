import { Component } from '@angular/core'
import { BaseService } from '../../../../service/base/base.service'

@Component({
  selector: 'app-coming-soon',
  templateUrl: './coming-soon.component.html',
  styleUrls: ['./coming-soon.component.scss'],
  providers: [BaseService]
})
export class ComingSoonComponent {

  PageTitle: string = this.base.getMessage("Coming Soon");

  constructor(public base: BaseService) { }

}
