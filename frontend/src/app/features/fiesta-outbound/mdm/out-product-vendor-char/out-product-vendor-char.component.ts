import { Component } from '@angular/core'
import { PagePermission, PermissionService } from '../../../../service/permission.service'

@Component({
  selector: 'app-out-product-vendor-char',
  templateUrl: './out-product-vendor-char.component.html',
  styleUrl: './out-product-vendor-char.component.scss'
})
export class OutProductVendorCharComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
