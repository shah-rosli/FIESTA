import { Environment } from "./environment.interface"

export const environment: Environment = {

  environmentName: 'Local Testing',
  production: false,

  // ServiceURL_Main: "https://fiesta-dev.eapp.renesas.com/FIESTA_BACKEND/api/",
  ServiceURL_Main: "https://localhost:7245/api/",
  LocaleID: "en_US",
  // SSO

  // clientId: "e3af06e8-e57c-4cad-b57b-2f2d23bf39f6", //qas2
  // authority: "https://login.microsoftonline.com/53d82571-da19-47e4-9cb4-625a166a4a2a",//qas2

  // clientId: "09f22212-43f0-4e33-a273-85794aaa5cd8", //dev2
  // authority: "https://login.microsoftonline.com/53d82571-da19-47e4-9cb4-625a166a4a2a", //dev2

  // clientId: "09f22212-43f0-4e33-a273-85794aaa5cd8", //dev2
  // authority: "https://login.microsoftonline.com/53d82571-da19-47e4-9cb4-625a166a4a2a", //dev2

  clientId: "480aa2b7-3281-4103-8b15-13a6b03bd564", //dev
  authority: "https://login.microsoftonline.com/53d82571-da19-47e4-9cb4-625a166a4a2a", //dev

  redirectUri: "http://localhost:4200/Login",
  postLogoutRedirectUri: "http://localhost:4200/",
  withCedential: false,
  enableMsal: true

}