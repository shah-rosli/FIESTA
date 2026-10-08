import { Component } from '@angular/core'
import { PagePermission, PermissionService } from '../../../../service/permission.service'

@Component({
  selector: 'app-out-product-matrix',
  templateUrl: './out-product-matrix.component.html',
  styleUrl: './out-product-matrix.component.scss'
})
export class OutProductMatrixComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
