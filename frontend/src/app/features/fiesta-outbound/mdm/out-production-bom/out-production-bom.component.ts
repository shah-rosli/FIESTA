import { Component } from '@angular/core'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
@Component({
  selector: 'app-out-production-bom',
  templateUrl: './out-production-bom.component.html',
  styleUrls: ['./out-production-bom.component.scss']
})
export class OutProductionBomComponent {

  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }

}

