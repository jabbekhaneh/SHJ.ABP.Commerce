import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { IdentitySecurityLogDto, PagedAndSortedIdentitySecurityLogResultRequestDto } from '../../../contracts/identity/identity-security-logs/models';

@Injectable({
  providedIn: 'root',
})
export class IdentitySecurityLogAdminService {
  apiName = 'Default';


  getById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, IdentitySecurityLogDto>({
      method: 'GET',
      url: `/api/app/identity-security-log-admin/${id}`,
    },
      { apiName: this.apiName, ...config });


  getList = (input: PagedAndSortedIdentitySecurityLogResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<IdentitySecurityLogDto>>({
      method: 'GET',
      url: '/api/app/identity-security-log-admin',
      params: { search: input.search, startDate: input.startDate, endDate: input.endDate, userId: input.userId, userName: input.userName, applicationName: input.applicationName, identity: input.identity, action: input.action, correlationId: input.correlationId, clientId: input.clientId, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
      { apiName: this.apiName, ...config });

  constructor(private restService: RestService) { }
}
