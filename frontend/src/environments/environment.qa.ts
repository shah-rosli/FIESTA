import { Environment } from "./environment.interface"

export const environment: Environment = {

  environmentName: 'QA',
  customSiteModeDisplay: '[ MDM2.0 PCP Testing ]',
  //customSiteModeDisplay: '[ Non Core RR Mix Ratio Testing ]',
  production: true,
  ServiceURL_Main: "https://fiesta-qas.eapp.renesas.com/FIESTA_BACKEND/api/",
  LocaleID: "en_US",
  //SSO
  clientId: "a60535a7-f24b-4d71-9214-474982ff10d5",
  authority: "https://login.microsoftonline.com/53d82571-da19-47e4-9cb4-625a166a4a2a",
  redirectUri: "https://fiesta-qas.eapp.renesas.com/Login",
  postLogoutRedirectUri: "https://fiesta-qas.eapp.renesas.com/",
  withCedential: true,
  enableMsal: true

}
