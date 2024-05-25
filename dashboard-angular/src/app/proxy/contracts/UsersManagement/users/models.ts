import { EntityDto, PagedAndSortedResultRequestDto } from "@abp/ng.core";

export interface UserDto extends EntityDto<string> {
  userName: string,
  password: string,
  name: string,
  surname: string,
  email: string,
  emailConfirmed: boolean,
  phoneNumber: string,
  phoneNumberConfirmed: boolean,
  isActive: boolean,
  lockoutEnabled: boolean,
  accessFailedCount: 0,
  lockoutEnd: string,
  concurrencyStamp: string,
  entityVersion: 3,
  lastPasswordChangeTime: string,
  isDeleted: boolean,
  deleterId: string,
  deletionTime: string,
  lastModificationTime: string,
  lastModifierId: string,
  creationTime: string,
  creatorId: string,
  roleNames: [],
}

export interface GetUserInputDto extends PagedAndSortedResultRequestDto {
  filter?: string;
  sorting: string,
}

export interface UserRolesDto extends EntityDto<string> {
  name: string,
  isDefault: boolean,
  isStatic: boolean,
  isPublic: boolean,
  isAssignable:boolean,
  concurrencyStamp: string,
}
