import { Component } from '@angular/core'
import { PagePermission, PermissionService } from '../../../../service/permission.service'

@Component({
  selector: 'app-production-stage-conversion',
  templateUrl: './production-stage-conversion.component.html',
  styleUrls: ['./production-stage-conversion.component.scss']
})
export class ProductionStageConversionComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}