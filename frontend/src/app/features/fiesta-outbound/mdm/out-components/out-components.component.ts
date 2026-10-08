import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../../service/permission.service'

@Component({
  selector: 'app-out-components',
  templateUrl: './out-components.component.html',
  styleUrl: './out-components.component.scss'
})
export class OutComponentsComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
