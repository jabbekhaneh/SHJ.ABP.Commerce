import { EntityDto, PagedAndSortedResultRequestDto } from "@abp/ng.core";

export interface RoleDto extends EntityDto<string> {
  name: string,
  isDefault: boolean,
  isStatic: boolean,
  isPublic: boolean,
  concurrencyStamp: string,
}


export interface GetInputRolesDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}
