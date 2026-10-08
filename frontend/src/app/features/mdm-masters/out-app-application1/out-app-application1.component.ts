import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-app-application1',
  templateUrl: './out-app-application1.component.html',
  styleUrl: './out-app-application1.component.scss'
})
export class OutAppApplication1Component {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
