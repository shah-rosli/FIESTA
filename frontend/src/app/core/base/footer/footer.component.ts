import { Component } from '@angular/core'
import { BaseService } from '../../../service/base/base.service'

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss'],
  providers: [BaseService]
})
export class FooterComponent {

  DisplayVersion: string

  constructor(public base: BaseService) { }

  ngOnInit() {
    if (localStorage.getItem("paramDictionary")) {
      this.DisplayVersion = this.base.getParamData('System_Version')[0].PARAM_VALUE
    }
  }

}
