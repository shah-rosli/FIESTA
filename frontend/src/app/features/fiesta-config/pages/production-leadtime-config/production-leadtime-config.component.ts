import { Component } from '@angular/core'
import { PagePermission, PermissionService } from 'src/app/service/permission.service'

@Component({
  selector: 'app-production-leadtime-config',
  templateUrl: './production-leadtime-config.component.html',
  styleUrls: ['./production-leadtime-config.component.scss']
})
export class ProductionLeadtimeConfigComponent {
  PageTitle: string = "Production Lead Time Maintenance"
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
