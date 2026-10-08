import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'
@Component({
  selector: 'app-out-product-plant-consolidate',
  templateUrl: './out-product-plant-consolidate.component.html',
  styleUrl: './out-product-plant-consolidate.component.scss'
})
export class OutProductPlantConsolidateComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
