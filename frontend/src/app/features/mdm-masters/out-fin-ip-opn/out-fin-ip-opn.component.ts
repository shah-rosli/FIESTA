import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-fin-ip-opn',
  templateUrl: './out-fin-ip-opn.component.html',
  styleUrl: './out-fin-ip-opn.component.scss'
})
export class OutFinIpOpnComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
