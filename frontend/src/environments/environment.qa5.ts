import { Environment } from "./environment.interface"

export const environment: Environment = {

  // environmentName: 'QA2',
  // customSiteModeDisplay: '[ QAS2 MDM ]',
  // production: true,
  // ServiceURL_Main: "https://fiesta-qas2.eapp.renesas.com/FIESTA_BACKEND/api/",
  // LocaleID: "en_US",
  // //SSO
  // clientId: "44bef92e-ba28-4619-8a1f-8251babb3f8d",
  // authority: "https://login.microsoftonline.com/53d82571-da19-47e4-9cb4-625a166a4a2a",
  // redirectUri: "https://fiesta-qas2.eapp.renesas.com/Login",
  // postLogoutRedirectUri: "https://fiesta-qas2.eapp.renesas.com/",
  // withCedential: true,
  // enableMsal: true

  environmentName: 'QA5',
  customSiteModeDisplay: '[ MDM2.0 QAS5 ]',
  production: true,
  ServiceURL_Main: "https://mdm-qas5.eapp.renesas.com/FIESTA_BACKEND/api/",
  LocaleID: "en_US",
  //SSO
  clientId: "a60535a7-f24b-4d71-9214-474982ff10d5",
  authority: "https://login.microsoftonline.com/53d82571-da19-47e4-9cb4-625a166a4a2a",
  redirectUri: "https://mdm-qas5.eapp.renesas.com/Login",
  postLogoutRedirectUri: "https://mdm-qas5.eapp.renesas.com/",
  withCedential: true,
  enableMsal: true

}
