import { Component } from '@angular/core'
import { PagePermission, PermissionService } from 'src/app/service/permission.service'

@Component({
  selector: 'app-production-alt-config',
  templateUrl: './production-alt-config.component.html',
  styleUrls: ['./production-alt-config.component.scss']
})
export class ProductionAltConfigComponent {
  PageTitle: string = "Production Priority Mix Ratios Maintenance"
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
