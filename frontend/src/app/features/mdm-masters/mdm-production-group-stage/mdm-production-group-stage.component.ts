import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-mdm-production-group-stage',
  templateUrl: './mdm-production-group-stage.component.html',
  styleUrl: './mdm-production-group-stage.component.scss'
})
export class MdmProductionGroupStageComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
