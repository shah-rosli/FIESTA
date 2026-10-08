import { Component } from '@angular/core'
import { NavigationEnd, Router } from '@angular/router'
import { filter } from 'rxjs/operators'
import { BaseService } from '../../../service/base/base.service'
import { MessageEventManager } from 'src/app/service/base/message.event.service'

interface AccessRight {
  company: string
  access_right: string
}

interface MenuItem {
  Id: number
  Icon: string
  Link: string | null
  Desc: string
  External: boolean
  Sub: string
  AccessRight: AccessRight[]
  SideMenu?: MenuItem[]
  extend?: boolean
  active?: boolean
}

@Component({
  selector: 'app-sidebar-menu',
  templateUrl: './sidebar-menu.component.html',
  styleUrls: ['./sidebar-menu.component.scss'],
  providers: [BaseService]
})
export class SidebarMenuComponent {

  SideMenuData: MenuItem[]
  SideMenuDataOri: MenuItem[]

  constructor(
    public base: BaseService,
    private router: Router,
    private messageEventManager: MessageEventManager,
  ) { }

  ngOnInit(): void {
    this.initSidebar()
    // listen sidebar menu data reload from base service, reflect changes in UI
    this.messageEventManager.subscribe('sidemenuDone', () => {
      this.initSidebar()
    })
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        this.calculateMenuState(event.url)
      })
  }

  initSidebar() {
    if (localStorage.getItem("UserMenu") && localStorage.getItem("UserMenu").length > 0) {
      console.log("get menu from localStorage")
      this.SideMenuData = JSON.parse(localStorage.getItem("UserMenu"))
      this.SideMenuDataOri = this.SideMenuData
    }
    this.calculateMenuState(this.router.url)
  }

  calculateMenuState(currentUrlPath) {
    currentUrlPath = currentUrlPath.split("?")[0] // remove query param
    const resetMenuItemState = (menuItem: MenuItem) => {
      menuItem.active = false
      menuItem.extend = false
    }

    for (const menuLevel1 of this.SideMenuData) {
      resetMenuItemState(menuLevel1)

      if (menuLevel1.Link === currentUrlPath) {
        menuLevel1.active = true
        currentUrlPath = ""
      } else if (menuLevel1.SideMenu) {
        for (const menuLevel2 of menuLevel1.SideMenu) {
          resetMenuItemState(menuLevel2)

          if (menuLevel2.Link === currentUrlPath) {
            menuLevel2.active = true
            menuLevel1.extend = true
            menuLevel1.active = true
            currentUrlPath = ""
          } else if (menuLevel2.SideMenu) {
            for (const menuLevel3 of menuLevel2.SideMenu) {
              resetMenuItemState(menuLevel3)

              if (menuLevel3.Link === currentUrlPath) {
                menuLevel3.active = true
                menuLevel2.extend = true
                menuLevel2.active = true
                menuLevel1.extend = true
                menuLevel1.active = true
                currentUrlPath = ""
              }
            }
          }
        }
      }
    }
  }

  toggleMenuExtend(menuItem: MenuItem) {
    if (menuItem.SideMenu) {
      menuItem.extend = !menuItem.extend
      return
    }
  }

  getLink(val) {
    if (val == null)
      return "dummy"
    else return val
  }

  MenuFitler(e) {
    // reset menu to null, start filtering
    this.SideMenuData = []
    this.GetFilteredMenu(this.SideMenuDataOri, e.value)
  }

  GetFilteredMenu(menu, inputvalue) {
    //loop through nested object for filter, if found,stop looping proceed next.
    for (let key in menu) {
      let menuitem = menu[key]
      if (this.base.getMessage(menuitem.Desc).toLowerCase().indexOf(inputvalue.toLowerCase()) >= 0) {
        if (this.SideMenuData) {
          this.SideMenuData.push(menuitem)
        } else {
          this.SideMenuData = [menuitem]
        }
      } else {
        if (menuitem.SideMenu) {
          this.GetFilteredMenu(menuitem.SideMenu, inputvalue)
        }
      }
    }
  }
}