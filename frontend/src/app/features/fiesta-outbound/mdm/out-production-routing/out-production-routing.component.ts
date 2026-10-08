import { Component } from '@angular/core'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
@Component({
  selector: 'app-out-production-routing',
  templateUrl: './out-production-routing.component.html',
  styleUrls: ['./out-production-routing.component.scss']
})
export class OutProductionRoutingComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}

