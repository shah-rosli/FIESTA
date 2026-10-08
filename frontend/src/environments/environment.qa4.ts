import { Environment } from "./environment.interface"

export const environment: Environment = {

  environmentName: 'QA4',
  production: false,
  customSiteModeDisplay: '[ MDM2.0 QAS4 ]',
  // ServiceURL_Main: "https://fiesta-dev.eapp.renesas.com/FIESTA_BACKEND/api/",
  ServiceURL_Main: "https://fiesta-qas4.eapp.renesas.com/FIESTA_BACKEND/api/",
  LocaleID: "en_US",
  // SSO
  clientId: "b4a508a9-991c-4fca-92c5-e1399677c9cd",
  authority: "https://login.microsoftonline.com/53d82571-da19-47e4-9cb4-625a166a4a2a",
  redirectUri: "https://fiesta-qas4.eapp.renesas.com/Login",
  postLogoutRedirectUri: "https://fiesta-qas4.eapp.renesas.com/",
  withCedential: false,
  enableMsal: true

}