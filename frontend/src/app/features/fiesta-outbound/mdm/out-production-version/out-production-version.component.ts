import { Component } from '@angular/core'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
@Component({
  selector: 'app-out-production-version',
  templateUrl: './out-production-version.component.html',
  styleUrls: ['./out-production-version.component.scss']
})
export class OutProductionVersionComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
