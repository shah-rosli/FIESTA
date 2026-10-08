import { Component } from '@angular/core'
import { BaseService } from '../../../../service/base/base.service'



@Component({
  selector: 'app-no-adding-menu',
  templateUrl: './no-adding-menu.component.html',
  styleUrls: ['./no-adding-menu.component.scss'],
  providers: [BaseService]
})
export class NoAddingMenuComponent {
  PageTitle: string = this.base.getMessage("Not Create Any Menu");
  constructor(public base: BaseService) { }

}
