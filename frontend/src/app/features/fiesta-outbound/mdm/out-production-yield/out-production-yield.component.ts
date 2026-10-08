import { Component } from '@angular/core'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
@Component({
  selector: 'app-out-production-yield',
  templateUrl: './out-production-yield.component.html',
  styleUrls: ['./out-production-yield.component.scss']
})
export class OutProductionYieldComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}