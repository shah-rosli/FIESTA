import { Component } from '@angular/core'
import { BaseService } from '../../../../service/base/base.service'

@Component({
  selector: 'app-announcement-list',
  templateUrl: './announcement-list.component.html',
  styleUrls: ['./announcement-list.component.scss']
})
export class AnnouncementListComponent {

  PageTitle: string = this.base.getMessage("Announcement");
  announcementData: any

  constructor(public base: BaseService) { }

  ngOnInit() {
    this.getAnnouncement()
  }

  getAnnouncement() {

    this.announcementData = []
    if (localStorage.getItem("paramDictionary")) {
      let temp = JSON.parse(localStorage.getItem("paramDictionary"))
      temp = temp.filter(filter => filter.PARAM_CATEGORY == "DashboardAnnouncement")
      //temp = temp.sort((a,b) =>  (a.CFG_SYSTEM_PARAM_ID < b.CFG_SYSTEM_PARAM_ID ? 1 : -1));
      let tempAnnouncementData = []
      temp.forEach((element) => {
        tempAnnouncementData.push(JSON.parse(element.PARAM_VALUE.toString()))
      })

      if (tempAnnouncementData) {
        tempAnnouncementData.sort((a, b) => {
          return +new Date(b.date) - +new Date(a.date)
        })
      }
      tempAnnouncementData.forEach((element) => {
        this.announcementData.push(element)
      })

    }

  }

  goToLink(url: string) {
    window.open(url, "_blank")
  }


}
