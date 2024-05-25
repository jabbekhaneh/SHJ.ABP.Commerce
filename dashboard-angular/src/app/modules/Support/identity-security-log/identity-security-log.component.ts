import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { IdentitySecurityLogAdminService } from '@proxy/services/identity/identity-security-logs';
import { IdentitySecurityLogDto, PagedAndSortedIdentitySecurityLogResultRequestDto } from '@proxy/contracts/identity/identity-security-logs';


@Component({
  selector: 'app-identity-security-log',
  templateUrl: './identity-security-log.component.html',
  styleUrls: ['./identity-security-log.component.scss'],
  providers: [ListService]
})
export class IdentitySecurityLogComponent implements OnInit {

  constructor(public readonly list: ListService,
    private service: IdentitySecurityLogAdminService) {
  }
  isModalOpen = false;
  SecurityLogs = { items: [], totalcount: 0 } as PagedResultDto<IdentitySecurityLogDto>;
  securitylog = {} as IdentitySecurityLogDto;
  queryFilter = {} as PagedAndSortedIdentitySecurityLogResultRequestDto;
  //---------------------------
  ngOnInit(): void {
    this.list.maxResultCount = 50;
    this.GetList();
  }
  //---------------------------
  GetList() {

    this.queryFilter.maxResultCount = this.list.maxResultCount;
    const securityLogStreamCreator = (query) => this.service.getList(this.queryFilter, query);
    this.list.hookToQuery(securityLogStreamCreator).subscribe((response) => {
      this.SecurityLogs = response;
    });
  }
  //---------------------------
  Search() {
    this.GetList();
  }
  //---------------------------
  onPage(event) {
    this.queryFilter.skipCount = event.offset;

  }
  //---------------------------
  Detail(id: string) {
    this.service.getById(id).subscribe((response) => {
      this.securitylog = response;
    });
    this.isModalOpen = true;


  }
  //---------------------------
}
