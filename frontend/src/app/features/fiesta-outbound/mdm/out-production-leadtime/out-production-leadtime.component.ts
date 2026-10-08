import { Component } from '@angular/core'
import { PagePermission, PermissionService } from '../../../../service/permission.service'

@Component({
  selector: 'app-out-production-leadtime',
  templateUrl: './out-production-leadtime.component.html',
  styleUrls: ['./out-production-leadtime.component.scss']
})
export class OutProductionLeadtimeComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}