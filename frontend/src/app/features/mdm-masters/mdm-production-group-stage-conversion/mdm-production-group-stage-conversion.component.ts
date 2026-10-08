import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-mdm-production-group-stage-conversion',
  templateUrl: './mdm-production-group-stage-conversion.component.html',
  styleUrl: './mdm-production-group-stage-conversion.component.scss'
})
export class MdmProductionGroupStageConversionComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
