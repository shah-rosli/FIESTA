import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-ven-vendor-purchase-info-rec',
  templateUrl: './out-ven-vendor-purchase-info-rec.component.html',
  styleUrl: './out-ven-vendor-purchase-info-rec.component.scss'
})
export class OutVenVendorPurchaseInfoRecComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
