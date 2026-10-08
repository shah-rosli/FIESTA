import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-mdm-storage-location',
  templateUrl: './mdm-storage-location.component.html',
  styleUrl: './mdm-storage-location.component.scss'
})
export class MdmStorageLocationComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
