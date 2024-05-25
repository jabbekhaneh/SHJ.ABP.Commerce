import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface AuditLogDto extends EntityDto<string> {
  applicationName?: string;
  userId?: string;
  userName?: string;
  tenantId?: string;
  tenantName?: string;
  impersonatorUserId?: string;
  impersonatorUserName?: string;
  impersonatorTenantId?: string;
  impersonatorTenantName?: string;
  executionTime?: string;
  executionDuration: number;
  clientIpAddress?: string;
  clientName?: string;
  clientId?: string;
  correlationId?: string;
  browserInfo?: string;
  httpMethod?: string;
  url?: string;
  exceptions?: string;
  comments?: string;
  httpStatusCode?: number;
}

export interface PagedAndSortedAuditLogDtoResultRequestDto extends PagedAndSortedResultRequestDto {
  search: string,
  startDate?: string;
  endDate?: string;
  httpMethod?: string;
  url?: string;
  userId?: string;
  userName?: string;
  applicationName?: string;
  clientIpAddress?: string;
  correlationId?: string;
  maxExecutionDuration?: number;
  minExecutionDuration?: number;
  hasException?: boolean;
  httpStatusCode?: number;
  includeDetails: boolean;
}
