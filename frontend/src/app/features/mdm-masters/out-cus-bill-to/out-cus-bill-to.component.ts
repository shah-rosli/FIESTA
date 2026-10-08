import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'
@Component({
  selector: 'app-out-cus-bill-to',
  templateUrl: './out-cus-bill-to.component.html',
  styleUrl: './out-cus-bill-to.component.scss'
})
export class OutCusBillToComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}



