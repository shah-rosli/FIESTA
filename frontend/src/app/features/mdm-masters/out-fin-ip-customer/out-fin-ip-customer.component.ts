import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-fin-ip-customer',
  templateUrl: './out-fin-ip-customer.component.html',
  styleUrl: './out-fin-ip-customer.component.scss'
})
export class OutFinIpCustomerComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
