import { Component } from '@angular/core'
import { PagePermission, PermissionService } from '../../../../service/permission.service'

@Component({
  selector: 'app-out-production-cycletime',
  templateUrl: './out-production-cycletime.component.html',
  styleUrls: ['./out-production-cycletime.component.scss']
})
export class OutProductionCycletimeComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
