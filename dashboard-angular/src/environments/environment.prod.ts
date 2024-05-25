import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Commerce',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44332/',
    redirectUri: baseUrl,
    clientId: 'Commerce_App',
    responseType: 'code',
    scope: 'offline_access Commerce',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44376',
      rootNamespace: 'SHJ.ABP.Commerce',
    },
  },
} as Environment;
