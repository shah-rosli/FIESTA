import { Environment } from "./environment.interface"

export const environment: Environment = {

  environmentName: 'QA3',
  customSiteModeDisplay: '[ MCX/ITCX ]',
  production: true,
  ServiceURL_Main: "https://mdm-qas3.eapp.renesas.com/FIESTA_BACKEND/api/",
  LocaleID: "en_US",
  //SSO
  clientId: "deef9d80-02bf-4fbe-a1ff-873d29e511fc",
  authority: "https://login.microsoftonline.com/53d82571-da19-47e4-9cb4-625a166a4a2a",
  redirectUri: "https://mdm-qas3.eapp.renesas.com/Login",
  postLogoutRedirectUri: "https://mdm-qas3.eapp.renesas.com/",
  withCedential: true,
  enableMsal: true

  // environmentName: 'QA3',
  // customSiteModeDisplay: '[ MDM2.0 QAS3 ]',
  // production: true,
  // ServiceURL_Main: "https://fiesta-qas3.eapp.renesas.com/FIESTA_BACKEND/api/",
  // LocaleID: "en_US",
  // //SSO
  // clientId: "deef9d80-02bf-4fbe-a1ff-873d29e511fc",
  // authority: "https://login.microsoftonline.com/53d82571-da19-47e4-9cb4-625a166a4a2a",
  // redirectUri: "https://fiesta-qas3.eapp.renesas.com/Login",
  // postLogoutRedirectUri: "https://fiesta-qas3.eapp.renesas.com/",
  // withCedential: true,
  // enableMsal: true

}
