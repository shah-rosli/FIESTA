import { Component } from '@angular/core'
import { BaseService } from '../../../service/base/base.service'

@Component({
  selector: 'app-company-master',
  templateUrl: './company-master.component.html',
  styleUrls: ['./company-master.component.scss'],
  providers: [BaseService],
})

export class CompanyMasterComponent {

  constructor() { }

}


