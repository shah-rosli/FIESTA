import { Component } from '@angular/core'
import { PagePermission, PermissionService } from 'src/app/service/permission.service'

@Component({
  selector: 'app-production-costing-yield-config',
  templateUrl: './production-costing-yield-config.component.html',
  styleUrls: ['./production-costing-yield-config.component.scss']
})
export class ProductionCostingYieldConfigComponent {
  PageTitle: string = "Production Costing Yield Maintenance"
  pagePermission: PagePermission
  activeTab: number = 0

  constructor(private permission: PermissionService) { }

  ngOnInit(): void {
    this.pagePermission = this.permission.getUserPermissions()
  }

  onTabClick(tabNumber) {
    this.activeTab = tabNumber
  }

}