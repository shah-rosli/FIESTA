import { Component } from '@angular/core'
import { PagePermission, PermissionService } from '../../../../service/permission.service'

@Component({
  selector: 'app-production-stage',
  templateUrl: './production-stage.component.html',
  styleUrls: ['./production-stage.component.scss']
})
export class ProductionStageComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}