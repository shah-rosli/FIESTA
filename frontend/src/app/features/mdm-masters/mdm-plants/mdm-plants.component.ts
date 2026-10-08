import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-mdm-plants',
  templateUrl: './mdm-plants.component.html',
  styleUrl: './mdm-plants.component.scss'
})
export class MdmPlantsComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
