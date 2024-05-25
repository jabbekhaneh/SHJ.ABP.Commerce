import type { EntityDto, ExtensibleObject, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface UserDto extends  EntityDto<string> {
  id: string,
  creationTime?: string,
  lastModifierId?: string,
  isDeleted?: false,
  deleterId?: string,
  deletionTime?: string,
  tenantId: string,
  userName: string,
  name: string,
  surname?: string,
  email?: string,
  emailConfirmed: true,
  phoneNumber?: string,
  phoneNumberConfirmed: true,
  isActive: true,
  lockoutEnabled: true,
  lockoutEnd?: string,
  concurrencyStamp?: string,
  entityVersion?: 0,
  lastPasswordChangeTime?: string,
}
