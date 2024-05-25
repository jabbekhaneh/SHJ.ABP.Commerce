import { RestService, Rest, } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { GetUserInputDto, UserDto, UserRolesDto } from '../../../contracts/UsersManagement/users/models'

@Injectable({
  providedIn: 'root',
})

export class UserAdminService {
  apiName = '/api/identity/users';
  apiName2 = 'api/app/user-admin/';

  constructor(private restService: RestService) { }


  GetAll = (input: GetUserInputDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<UserDto>>({
      method: 'GET',
      url: this.apiName,
      params: { filter: input.filter, }
    }, { apiName: this.apiName, ...config });



  Create = (input: UserDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserDto>({
      method: 'POST',
      url: this.apiName,
      body: input,
    },
      { apiName: this.apiName, ...config });

  GetById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserDto>({
      method: 'GET',
      url: this.apiName + `/${id}`,
    },
      { apiName: this.apiName, ...config });

  GetUserRoles = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserRolesDto>({
      method: 'GET',
      url: this.apiName + `/${id}` + '/roles',
    },
      { apiName: this.apiName, ...config });
  //api/app/user-admin
  AssignableRoles = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserRolesDto>({
      method: 'GET',
      url: this.apiName2 + `${id}` + '/assignable-roles',
    },
      { apiName: this.apiName, ...config });
  Edit = (id: string, input: UserDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserDto>({
      method: 'PUT',
      url: this.apiName + '/' + id,
      body: input,
    },
      { apiName: this.apiName, ...config });










}
