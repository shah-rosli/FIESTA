import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-mdm-company-code',
  templateUrl: './mdm-company-code.component.html',
  styleUrl: './mdm-company-code.component.scss'
})
export class MdmCompanyCodeComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
