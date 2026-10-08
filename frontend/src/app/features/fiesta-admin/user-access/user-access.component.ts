import { Component, ViewChild } from '@angular/core'
import { environment } from '../../../../environments/environment'
import { BaseService } from '../../../service/base/base.service'
import { SendRequestService } from '../../../service/base/send-request.service'
import { ToastrService } from 'ngx-toastr'
import { DxDropDownBoxComponent } from 'devextreme-angular'
import { PagePermission, PermissionService } from '../../../service/permission.service'

@Component({
  selector: 'app-user-access',
  templateUrl: './user-access.component.html',
  styleUrls: ['./user-access.component.scss'],
  providers: [BaseService]
})

export class UserAccessComponent {

  @ViewChild(DxDropDownBoxComponent, { static: false }) userGroupDropdown

  PageTitle: string = "User Access Configuration"
  userGroupDetails: any[]
  menuListDataSource: any[]
  selectedUserGroup: any
  selectedUserGroupId: any
  pagePermission: PagePermission

  constructor(public base: BaseService,
    private send: SendRequestService,
    private toastr: ToastrService,
    private permission: PermissionService
  ) { }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
    this.getUserGroup()
  }

  onRequestorChange(e) {
    const selected = e.selectedRowsData[0]
    this.selectedUserGroup = selected
    this.selectedUserGroupId = selected.CFG_USER_GROUP_ID
    this.loadMenuList()
    this.userGroupDropdown.instance.close()
  }

  FillCheckBox(item) {
    item.saMenu.forEach((items) => {
      this.menuListDataSource.forEach((MenuItem) => {
        if ((MenuItem.ID === items.MENU_ID) && (MenuItem.Head_ID != "-1")) {
          if (MenuItem.saOperation) {
            MenuItem.saOperation.forEach((MenuSaOperations) => {
              if (MenuSaOperations.Key === items.ACCESS_OPERATION) {
                MenuSaOperations.Value = true
              }
            })
          }
        }
      })
    })
  }

  loadMenuList() {
    this.send.sendRequest(`${environment.ServiceURL_Main}CfgSystemMenu/GetAllSystemMenuDetailList`, "GET", "").subscribe(
      data => {
        this.menuListDataSource = data
          .filter(item => item.ACTIVE === "Yes")
          .map(item => {
            return {
              MenuName: item.MENU_NAME,
              MenuId: item.CFG_SYSTEM_MENU_ID,
              ID: item.CFG_SYSTEM_MENU_ID,
              Head_ID: item.MENU_PARENT_ID,
              saOperation: item.saOperationMap?.map(saOperation => {
                return { Key: saOperation, Value: false }
              }) || null
            }
          })
        this.FillCheckBox(this.selectedUserGroup)
      }
    )
  }

  SaveUserGroupRights() {
    const saMenu = []
    this.menuListDataSource.forEach((MenuItem) => {
      if (MenuItem.Head_ID === "-1") {
        return
      }
      if (!MenuItem.saOperation) {
        return
      }
      MenuItem.saOperation.forEach((MenuSaOperations) => {
        if (MenuSaOperations.Value === true) {
          saMenu.push({
            MENU_ID: MenuItem.ID,
            ACCESS_OPERATION: MenuSaOperations.Key,
          })
        }
      })
    })

    this.selectedUserGroup["saMenu"] = saMenu
    this.send.sendRequest(`${environment.ServiceURL_Main}CfgUserGroup`, "PUT", this.selectedUserGroup).subscribe(
      data => {
        this.loadMenuList()
        this.base.getSideMenu()
        this.toastr.success(this.base.getMessage("Record modified successfully"), this.base.getMessage('Success!'))
      }
    )
  }

  getUserGroup() {
    this.send.sendRequest(`${environment.ServiceURL_Main}CfgUserGroup/GetCfgUserGroupDetail`, "GET", "").subscribe(
      data => {
        this.userGroupDetails = data.filter(item => item.ACTIVE === "Yes")
      }
    )
  }
}
