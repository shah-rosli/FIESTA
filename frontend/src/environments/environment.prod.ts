import { Environment } from "./environment.interface"

export const environment: Environment = {

  environmentName: '',
  production: true,
  ServiceURL_Main: "https://fiesta.eapp.renesas.com/FIESTA_BACKEND/api/",
  LocaleID: "en_US",
  //SSO
  clientId: "16b61611-2c0d-4213-9d2e-1aabe7bb0e03",
  authority: "https://login.microsoftonline.com/53d82571-da19-47e4-9cb4-625a166a4a2a",
  redirectUri: "https://fiesta.eapp.renesas.com/Login",
  postLogoutRedirectUri: "https://fiesta.eapp.renesas.com/",
  withCedential: true,
  enableMsal: true

}
