import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-mdm-product-hierarchy-profitcenter-conversion',
  templateUrl: './mdm-product-hierarchy-profitcenter-conversion.component.html',
  styleUrl: './mdm-product-hierarchy-profitcenter-conversion.component.scss'
})
export class MdmProductHierarchyProfitcenterConversionComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
