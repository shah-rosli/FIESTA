import { Component } from '@angular/core'
import { BaseService } from 'src/app/service/base/base.service'

@Component({
  selector: 'app-no-view-permission',
  templateUrl: './no-view-permission.component.html',
  styleUrl: './no-view-permission.component.scss'
})
export class NoViewPermissionComponent {
  constructor(public base: BaseService) { }
}
