export interface Environment {
  environmentName: string,
  customSiteModeDisplay?: string,
  production: boolean,
  ServiceURL_Main: string,
  LocaleID: string,
  clientId: string,
  authority: string,
  redirectUri: string,
  postLogoutRedirectUri: string,
  withCedential: boolean,
  enableMsal: boolean
}