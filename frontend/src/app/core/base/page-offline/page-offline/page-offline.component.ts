import { Component } from '@angular/core'
import { BaseService } from '../../../../service/base/base.service'

@Component({
  selector: 'app-page-offline',
  templateUrl: './page-offline.component.html',
  styleUrls: ['./page-offline.component.scss'],
  providers: [BaseService]
})
export class PageOfflineComponent {

  PageTitle: string = this.base.getMessage("Site Offline");
  DisplayMsg: String = "";

  constructor(public base: BaseService) { }

  ngOnInit() {



    if (localStorage.getItem("paramDictionary")) {
      //get timeout from param
      let temp = JSON.parse(localStorage.getItem("paramDictionary"))
      temp.forEach((element) => {
        if (element.PARAM_CATEGORY == 'System_Offline' && element.PARAM_KEY == 'Yes') {
          this.DisplayMsg = element.PARAM_VALUE;;
        }
      })

    }

  }

}
