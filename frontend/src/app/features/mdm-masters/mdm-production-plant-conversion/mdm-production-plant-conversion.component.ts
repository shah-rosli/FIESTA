import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-mdm-production-plant-conversion',
  templateUrl: './mdm-production-plant-conversion.component.html',
  styleUrl: './mdm-production-plant-conversion.component.scss'
})
export class MdmProductionPlantConversionComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
