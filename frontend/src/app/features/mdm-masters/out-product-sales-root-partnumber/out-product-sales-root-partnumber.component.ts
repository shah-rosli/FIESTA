import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-product-sales-root-partnumber',
  templateUrl: './out-product-sales-root-partnumber.component.html',
  styleUrl: './out-product-sales-root-partnumber.component.scss'
})
export class OutProductSalesRootPartnumberComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
