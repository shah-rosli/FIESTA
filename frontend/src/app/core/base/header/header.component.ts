/**
 * Refer to node_modules\admin-lte\dist\js\adminlte.js for original js code.
 * Sidebar methods below are re-implemented in angular.
 */

import { Component, Renderer2 } from '@angular/core'
import { DateTime } from "luxon"
import { BaseService } from '../../../service/base/base.service'
import { environment } from '../../../../environments/environment'
import { timer } from 'rxjs'
import { MessageEventManager } from 'src/app/service/base/message.event.service'

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  providers: [BaseService]
})
export class HeaderComponent {

  currentDateTime: any = null
  siteModeDisplay: string = ""
  currentTimeZone: string = null

  CLASS_NAME_SIDEBAR_OPEN: string = "sidebar-open"
  CLASS_NAME_SIDEBAR_COLLAPSE: string = "sidebar-collapse"
  sidebarBreakpoint: number = 992

  constructor(public base: BaseService, private renderer: Renderer2, private messageEventManager: MessageEventManager) { }

  ngOnInit() {
    console.log("HeaderComponent: enter header")

    this.currentTimeZone = this.base.getSystemFormat('DefaultSystemTimezone')
    this.initDateTime(this.currentTimeZone)
    if (environment.environmentName) {
      this.siteModeDisplay = `[ ${environment.environmentName} Site ]`
    }
    if (environment.customSiteModeDisplay) {
      this.siteModeDisplay = environment.customSiteModeDisplay
    }

    this.initSidebar()
  }

  initDateTime(timezone: string) {
    const onesecondtimer = timer(0, 1000)
    onesecondtimer.subscribe(() => {
      this.currentDateTime = DateTime.now().toUTC().setZone(timezone).toFormat(this.base.getSystemFormat('DefaultHeaderDTMFormatLuxon'))
    })
  }

  initSidebar() {
    if (!(window.innerWidth <= this.sidebarBreakpoint)) {
      this.expand()
    }

    this.messageEventManager.subscribe("sidebarOverlayClicked", () => {
      this.toggle()
    })

    this.initSidebarAutoCollapse()
  }

  initSidebarAutoCollapse() {
    let previousWindowWidth = window.innerWidth

    const onWindowResize = () => {
      const currentWindowWidth = window.innerWidth
      const windowWidthChanged = previousWindowWidth !== currentWindowWidth

      if (windowWidthChanged) {
        const previouslySmallScreen = previousWindowWidth <= this.sidebarBreakpoint
        const currentlySmallScreen = window.innerWidth <= this.sidebarBreakpoint

        // auto collapse only happens when transition between big screen or small screen
        if (previouslySmallScreen && !currentlySmallScreen) {
          this.expand()
        } else if (!previouslySmallScreen && currentlySmallScreen) {
          this.collapse()
        }

        previousWindowWidth = currentWindowWidth
      }
    }

    window.addEventListener('resize', onWindowResize)
  }

  expand() {
    this.renderer.removeClass(document.body, this.CLASS_NAME_SIDEBAR_COLLAPSE)
    this.renderer.addClass(document.body, this.CLASS_NAME_SIDEBAR_OPEN)
  }

  collapse() {
    this.renderer.removeClass(document.body, this.CLASS_NAME_SIDEBAR_OPEN)
    this.renderer.addClass(document.body, this.CLASS_NAME_SIDEBAR_COLLAPSE)
  }

  toggle() {
    if (document.body.classList.contains(this.CLASS_NAME_SIDEBAR_COLLAPSE)) {
      this.expand()
    } else {
      this.collapse()
    }
  }
}