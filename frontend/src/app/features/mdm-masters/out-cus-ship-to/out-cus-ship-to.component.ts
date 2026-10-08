import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-cus-ship-to',
  templateUrl: './out-cus-ship-to.component.html',
  styleUrl: './out-cus-ship-to.component.scss'
})
export class OutCusShipToComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
