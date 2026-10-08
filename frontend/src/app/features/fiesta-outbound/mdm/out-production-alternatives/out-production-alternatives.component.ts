import { Component } from '@angular/core'
import { PagePermission, PermissionService } from '../../../../service/permission.service'

@Component({
  selector: 'app-out-production-alternatives',
  templateUrl: './out-production-alternatives.component.html',
  styleUrls: ['./out-production-alternatives.component.scss']
})
export class OutProductionAlternativesComponent {
  pagePermission: PagePermission

  constructor(private permission: PermissionService) {

  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
  }
}
