import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-app-application3',
  templateUrl: './out-app-application3.component.html',
  styleUrl: './out-app-application3.component.scss'
})
export class OutAppApplication3Component {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
