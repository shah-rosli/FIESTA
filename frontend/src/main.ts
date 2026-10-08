import { enableProdMode } from '@angular/core'
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic'
import { AppModule } from './app/app.module'
import { environment } from './environments/environment'

import config from 'devextreme/core/config'
config({ licenseKey: 'ewogICJmb3JtYXQiOiAxLAogICJjdXN0b21lcklkIjogIjExNThlZWVjLTY1YmEtNDJmZS1iN2EwLTk0MDJlYWZlMmVjZSIsCiAgIm1heFZlcnNpb25BbGxvd2VkIjogMjQxCn0=.crO1L7Ese7eiyDmIp8Mti8fsswhE8GUiRtyh5FIfxBp9gzs+2Guywg857eLge7MiQTK8Cscz45b+QY4LghsH41lLew7PwIl7CaX8r/0JPAOX3knKjN8+XVhMrMhr7qDXWSYkOw==' })

if (environment.production) {
  enableProdMode()
}

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));

