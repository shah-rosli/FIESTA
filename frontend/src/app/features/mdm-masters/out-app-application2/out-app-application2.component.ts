import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-app-application2',
  templateUrl: './out-app-application2.component.html',
  styleUrl: './out-app-application2.component.scss'
})
export class OutAppApplication2Component {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
