import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-product-hs-conversion',
  templateUrl: './out-product-hs-conversion.component.html',
  styleUrl: './out-product-hs-conversion.component.scss'
})
export class OutProductHsConversionComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
