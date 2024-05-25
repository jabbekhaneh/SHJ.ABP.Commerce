import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto, LocalizationService } from '@abp/ng.core';
import { PagedAndSortedAuditLogDtoResultRequestDto } from '@proxy/contracts/identity/audit-logs'
import { AuditLoggingAdminService } from '@proxy/services/identity/audit-loggings';
import { AuditLogDto } from '@proxy/contracts/identity/audit-logs';


@Component({
  selector: 'app-audit-logging',
  templateUrl: './audit-logging.component.html',
  styleUrls: ['./audit-logging.component.scss'],
  providers: [ListService]
})
export class AuditLoggingComponent implements OnInit {

  //--------------------------
  constructor(public readonly list: ListService,
    private readonly service: AuditLoggingAdminService) {
  }
  //--------------------------
  isModalOpen = false;
  auditLogs = { items: [], totalcount: 0 } as PagedResultDto<AuditLogDto>;
  queryFilter = {} as PagedAndSortedAuditLogDtoResultRequestDto;
  auditLog = {} as AuditLogDto;
  //--------------------------
  ngOnInit(): void {
    this.list.maxResultCount = 50;
    this.GetList();
  }
  //--------------------------
  GetList() {

    this.queryFilter.maxResultCount = this.list.maxResultCount;
    // this.queryFilter.search = this.list.filter;
    const logsStreamCreator = (query) => this.service.getList(this.queryFilter, query);
    this.list.hookToQuery(logsStreamCreator).subscribe((response) => {
      this.auditLogs = response;
    });
  }
  //--------------------------
  Search() {
    this.GetList();
  }
  //--------------------------
  Refresh() {
    this.GetList();

  }
  //--------------------------
  onPage(event) {
    this.queryFilter.skipCount = event.offset;

  }
  ClearFilter() {
    this.queryFilter = {} as PagedAndSortedAuditLogDtoResultRequestDto;
  }
  //--------------------------
  Detail(id: string) {
    this.service.get(id).subscribe((response) => {
      this.auditLog = response;
      this.isModalOpen = true;
    })

  }
  //-
}
