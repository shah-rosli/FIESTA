import { Component } from '@angular/core'
import { PagePermission, PermissionService } from '../../../../service/permission.service'

@Component({
  selector: 'app-out-production-lotsize',
  templateUrl: './out-production-lotsize.component.html',
  styleUrls: ['./out-production-lotsize.component.scss']
})
export class OutProductionLotsizeComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}