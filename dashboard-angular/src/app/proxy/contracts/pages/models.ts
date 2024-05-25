import type { EntityDto, ExtensibleObject, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreatePageInputDto extends ExtensibleObject {
  title: string;
  content?: string;
  script?: string;
  style?: string;
}

export interface GetPagesInputDto extends PagedAndSortedResultRequestDto {
  filter?: string;
  creatorUsername?: string;
  lastModifierUsername?: string;
  creationStartDate?: string;
  creationEndDate?: string;
}

export interface PageDto extends EntityDto<string> {
  title?: string;
  content?: string;
  script?: string;
  style?: string;
  isHomePage: boolean;
  creationTime?: string;
  creatorId?: string;
  lastModificationTime?: string;
  lastModifierId?: string;
}

export interface UpdatePageInputDto extends EntityDto {
  title: string;
  content?: string;
  script?: string;
  style?: string;
}
