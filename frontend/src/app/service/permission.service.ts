import { Injectable } from '@angular/core'
import { BaseService } from './base/base.service'
import { Router } from '@angular/router'

export interface PagePermission {
  create: boolean
  edit: boolean
  view: boolean
  delete: boolean
}

@Injectable({
  providedIn: 'root'
})
export class PermissionService {

  constructor(
    private base: BaseService,
    private router: Router
  ) { }

  getUserPermissions() {
    const UrlwithoutUrlParams = this.router.url.split("?")[0]
    const userPermission = this.base.getUserAccessPermission(UrlwithoutUrlParams)
    const permissions: PagePermission = {
      create: false,
      edit: false,
      view: false,
      delete: false,
    }
    if (userPermission !== null) {
      userPermission.forEach(function (item) {
        switch (item.access_right) {
          case 'Create':
            permissions.create = true
            break
          case 'Update':
            permissions.edit = true
            break
          case 'View':
            permissions.view = true
            break
          case 'Delete':
            permissions.delete = true
            break
        }
      })
    }
    return permissions
  }
}
