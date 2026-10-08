import { Component } from '@angular/core'
import { PagePermission, PermissionService } from 'src/app/service/permission.service'

@Component({
  selector: 'app-production-planning-yield-config',
  templateUrl: './production-planning-yield-config.component.html',
  styleUrls: ['./production-planning-yield-config.component.scss']
})
export class ProductionPlanningYieldConfigComponent {
  PageTitle: string = "Production Planning Yield Maintenance"
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