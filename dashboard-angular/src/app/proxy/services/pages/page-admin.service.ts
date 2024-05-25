import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreatePageInputDto, GetPagesInputDto, PageDto, UpdatePageInputDto } from '../../contracts/pages/models';

@Injectable({
  providedIn: 'root',
})
export class PageAdminService {
  apiName = 'Default';


  create = (input: CreatePageInputDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PageDto>({
      method: 'POST',
      url: '/api/app/page-admin',
      body: input,
    },
    { apiName: this.apiName,...config });


  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/page-admin/${id}`,
    },
    { apiName: this.apiName,...config });


  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PageDto>({
      method: 'GET',
      url: `/api/app/page-admin/${id}`,
    },
    { apiName: this.apiName,...config });
      

  getList = (input: GetPagesInputDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<PageDto>>({
      method: 'GET',
      url: '/api/app/page-admin',
      params: { filter: input.filter, creatorUsername: input.creatorUsername, lastModifierUsername: input.lastModifierUsername, creationStartDate: input.creationStartDate, creationEndDate: input.creationEndDate, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });


  setAsHomePage = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/page-admin/${id}/set-as-home-page`,
    },
    { apiName: this.apiName,...config });


  update = (id: string, input: UpdatePageInputDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PageDto>({
      method: 'PUT',
      url: `/api/app/page-admin/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
