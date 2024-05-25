import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface IdentitySecurityLogDto extends EntityDto<string> {

  applicationName?: string
  identity?: string;
  userId?: string
  userName?: string;
  browserInfo?: string
  tenantName?: string;
  action?: string
  clientId?: string;
  correlationId?: string
  clientIpAddress?: string;
  creationTime?:string
}

export interface PagedAndSortedIdentitySecurityLogResultRequestDto extends PagedAndSortedResultRequestDto {
  search?: string;
  startDate?: string;
  endDate?: string;
  userId?: string;
  userName?: string;
  applicationName?: string;
  identity?: string;
  action?: string;
  correlationId?: string;
  clientId?: string;
}
