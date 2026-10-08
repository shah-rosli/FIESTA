import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-ven-vendor',
  templateUrl: './out-ven-vendor.component.html',
  styleUrl: './out-ven-vendor.component.scss'
})
export class OutVenVendorComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
