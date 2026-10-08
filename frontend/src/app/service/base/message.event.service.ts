import { Injectable } from "@angular/core"
import { Observable, Subscription, Subject } from "rxjs"
import { filter } from "rxjs/operators"

type EventName =
  'sidemenuDone' |
  'sidebarOverlayClicked' |
  'dummy'

interface Event {
  name: EventName,
  data?: any // optional data passing
}

@Injectable({
  providedIn: 'root'
})
export class MessageEventManager {
  private subject: Subject<Event> = new Subject<Event>();
  private observable$: Observable<Event> = this.subject.asObservable();

  subscribe(eventName: EventName, callback: (event: Event) => void): Subscription {
    return this.observable$
      .pipe(
        filter((event) => {
          return event.name === eventName
        })
      )
      .subscribe(event => callback(event))
  }

  broadcast(event: Event): void {
    this.subject.next(event)
  }

  destroy(subscriber: Subscription) {
    subscriber.unsubscribe()
  }
}
