import { Component } from '@angular/core';
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-out-product-wip-sell-price',
  templateUrl: './out-product-wip-sell-price.component.html',
  styleUrl: './out-product-wip-sell-price.component.scss'
})
export class OutProductWipSellPriceComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
