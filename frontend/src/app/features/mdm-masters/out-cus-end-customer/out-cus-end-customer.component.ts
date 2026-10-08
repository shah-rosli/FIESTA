import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-cus-end-customer',
  templateUrl: './out-cus-end-customer.component.html',
  styleUrl: './out-cus-end-customer.component.scss'
})
export class OutCusEndCustomerComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}

