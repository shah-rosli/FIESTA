import { Component } from '@angular/core'
import { MessageEventManager } from 'src/app/service/base/message.event.service'

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {

  constructor(private messageEventManager: MessageEventManager) { }

  ngOnInit() {
  }

  collapse() {
    this.messageEventManager.broadcast({ name: 'sidebarOverlayClicked' })
  }

}
