import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'
@Component({
  selector: 'app-out-product-sales-consolidate',
  templateUrl: './out-product-sales-consolidate.component.html',
  styleUrl: './out-product-sales-consolidate.component.scss'
})
export class OutProductSalesConsolidateComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
