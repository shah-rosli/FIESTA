import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-product-eccn-conversion',
  templateUrl: './out-product-eccn-conversion.component.html',
  styleUrl: './out-product-eccn-conversion.component.scss'
})
export class OutProductEccnConversionComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
