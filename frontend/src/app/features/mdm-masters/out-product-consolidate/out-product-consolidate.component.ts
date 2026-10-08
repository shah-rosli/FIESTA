import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'
@Component({
  selector: 'app-out-product-consolidate',
  templateUrl: './out-product-consolidate.component.html',
  styleUrl: './out-product-consolidate.component.scss'
})
export class OutProductConsolidateComponent {

  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }


}
