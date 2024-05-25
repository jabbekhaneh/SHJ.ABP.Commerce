import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { AuditLogDto, PagedAndSortedAuditLogDtoResultRequestDto } from '../../../contracts/identity/audit-logs/models';

@Injectable({
  providedIn: 'root',
})
export class AuditLoggingAdminService {
  apiName = 'Default';
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AuditLogDto>({
      method: 'GET',
      url: `/api/app/audit-logging-admin/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedAuditLogDtoResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<AuditLogDto>>({
      method: 'GET',
      url: '/api/app/audit-logging-admin',
      params: { startDate: input.startDate, endDate: input.endDate, httpMethod: input.httpMethod, url: input.url, userId: input.userId, userName: input.userName, applicationName: input.applicationName, clientIpAddress: input.clientIpAddress, correlationId: input.correlationId, maxExecutionDuration: input.maxExecutionDuration, minExecutionDuration: input.minExecutionDuration, hasException: input.hasException, httpStatusCode: input.httpStatusCode, includeDetails: input.includeDetails, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
