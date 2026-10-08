import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-product-standard-cost',
  templateUrl: './out-product-standard-cost.component.html',
  styleUrl: './out-product-standard-cost.component.scss'
})
export class OutProductStandardCostComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
