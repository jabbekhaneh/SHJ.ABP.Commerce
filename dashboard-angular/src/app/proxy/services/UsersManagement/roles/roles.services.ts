import { RestService, Rest, } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import { GetInputRolesDto, RoleDto } from '../../../contracts/UsersManagement/roles/model'

@Injectable({
  providedIn: 'root',
})


export class RolesService {
  apiName = '/api/identity/roles/all';

  constructor(private restService: RestService) { }

  GetAll = (input: GetInputRolesDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<RoleDto>>({
      method: 'GET',
      url: this.apiName,
      params: { filter: input.filter, }
    }, { apiName: this.apiName, ...config });

  All = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, RoleDto>({
      method: 'GET',
      url: this.apiName,
    }, { apiName: this.apiName, ...config });

}
