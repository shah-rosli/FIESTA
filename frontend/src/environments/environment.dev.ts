import { Environment } from "./environment.interface"

export const environment: Environment = {

  // environmentName: 'DEV',
  // customSiteModeDisplay: '[ MDM2.0 DEV1 ]',
  // production: true,
  // ServiceURL_Main: "https://fiesta-dev.eapp.renesas.com/FIESTA_BACKEND/api/",
  // LocaleID: "en_US",
  // //SSO
  // clientId: "480aa2b7-3281-4103-8b15-13a6b03bd564",
  // authority: "https://login.microsoftonline.com/53d82571-da19-47e4-9cb4-625a166a4a2a",
  // redirectUri: "https://fiesta-dev.eapp.renesas.com/Login",
  // postLogoutRedirectUri: "https://fiesta-dev.eapp.renesas.com/",
  // withCedential: true,
  // enableMsal: true

  environmentName: 'DEV',
  customSiteModeDisplay: '[ MDM2.0 DEV1 ]',
  production: true,
  ServiceURL_Main: "https://mdm-dev.eapp.renesas.com/FIESTA_BACKEND/api/",
  LocaleID: "en_US",
  //SSO
  clientId: "480aa2b7-3281-4103-8b15-13a6b03bd564",
  authority: "https://login.microsoftonline.com/53d82571-da19-47e4-9cb4-625a166a4a2a",
  redirectUri: "https://mdm-dev.eapp.renesas.com/Login",
  postLogoutRedirectUri: "https://mdm-dev.eapp.renesas.com/",
  withCedential: true,
  enableMsal: true
}
