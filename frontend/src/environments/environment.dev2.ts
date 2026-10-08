import { Environment } from "./environment.interface"

export const environment: Environment = {

  environmentName: 'DEV2',
  customSiteModeDisplay: '[ MDM2.0 DEV2 ]',
  production: true,
  ServiceURL_Main: "https://mdm-dev1.eapp.renesas.com/FIESTA_BACKEND/api/",
  LocaleID: "en_US",
  //SSO
  clientId: "09f22212-43f0-4e33-a273-85794aaa5cd8",
  authority: "https://login.microsoftonline.com/53d82571-da19-47e4-9cb4-625a166a4a2a",
  redirectUri: "https://mdm-dev1.eapp.renesas.com/Login",
  postLogoutRedirectUri: "https://mdm-dev1.eapp.renesas.com/",
  withCedential: true,
  enableMsal: true
}
