import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-cus-sold-to',
  templateUrl: './out-cus-sold-to.component.html',
  styleUrl: './out-cus-sold-to.component.scss'
})
export class OutCusSoldToComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
