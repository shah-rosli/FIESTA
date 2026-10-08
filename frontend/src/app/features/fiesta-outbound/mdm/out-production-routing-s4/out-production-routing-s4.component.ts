import { Component } from '@angular/core'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
@Component({
  selector: 'app-out-production-routing-s4',
  templateUrl: './out-production-routing-s4.component.html',
  styleUrls: ['./out-production-routing-s4.component.scss']
})
export class OutProductionRoutingS4Component {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
