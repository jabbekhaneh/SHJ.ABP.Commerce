import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { UserDto } from '@proxy/contracts/identity/Users/models';
//-----------------------------------------------------------
@Injectable({
  providedIn: 'root',
})

export class IdentityUsersService{
  apiName = 'Default';

  constructor(private restService: RestService) {}

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserDto>({
      method: 'GET',
      url: `/api/identity/users/${id}`,
    },
    { apiName: this.apiName,...config });




}

