import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-mdm-profit-center-hierarchy',
  templateUrl: './mdm-profit-center-hierarchy.component.html',
  styleUrl: './mdm-profit-center-hierarchy.component.scss'
})
export class MdmProfitCenterHierarchyComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
