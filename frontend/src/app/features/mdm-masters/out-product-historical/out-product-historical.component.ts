import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'
@Component({
  selector: 'app-out-product-historical',
  templateUrl: './out-product-historical.component.html',
  styleUrl: './out-product-historical.component.scss'
})
export class OutProductHistoricalComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
