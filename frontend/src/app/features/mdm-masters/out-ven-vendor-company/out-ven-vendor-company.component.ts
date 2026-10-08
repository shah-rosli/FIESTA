import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-ven-vendor-company',
  templateUrl: './out-ven-vendor-company.component.html',
  styleUrl: './out-ven-vendor-company.component.scss'
})
export class OutVenVendorCompanyComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
