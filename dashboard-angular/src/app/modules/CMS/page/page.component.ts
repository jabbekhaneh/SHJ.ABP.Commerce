import { ListService, PagedResultDto, LocalizationService } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { GetPagesInputDto, PageDto } from '@proxy/contracts/pages/models';
import { PageAdminService } from '@proxy/services/pages';
import { IdentityUserDto, IdentityUserService } from '@abp/ng.identity/proxy';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'
import { ConfirmationService, Confirmation, ToasterService } from '@abp/ng.theme.shared';
import { UserDto } from '@proxy/contracts/identity/Users/models';


//----------------------------
@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.scss'],
  providers: [ListService],

})

export class PageComponent implements OnInit {

  //----------------------------
  page = { items: [], totalcount: 0, filtre: '' } as PagedResultDto<PageDto>;
  selectedPage = {} as PageDto; //declare

  getPages = {} as GetPagesInputDto;
  form: FormGroup;
  isModalOpen = false;
  isModalUserDetailOpen = false;
  isModalDetailOpen=false;
  user = {} as IdentityUserDto;
  //----------------------------
  constructor(public readonly list: ListService,
    private pageAdminService: PageAdminService,
    private identityUserService: IdentityUserService,
    private localization: LocalizationService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService,
    private toaster: ToasterService) {

  }
  //----------------------------
  ngOnInit(): void {
    this.getList(this.getPages);

  }
  //----------------------------
  getList(queryFilter: GetPagesInputDto) {

    this.getPages.maxResultCount = this.list.maxResultCount;

    const pageStreamCreator = (query) => this.pageAdminService.getList(queryFilter, query);
    this.list.hookToQuery(pageStreamCreator).subscribe((response) => {
      this.page = response;
    });


  }
  //----------------------------
  Details(id: string) {
    this.pageAdminService.get(id).subscribe((response) => {
      this.isModalDetailOpen = true;
      this.selectedPage = response;
    })
  }
  //----------------------------
  onPage(event) {
    this.getPages.skipCount = event.offset;
  }

  //----------------------------
  CreatePage() {
    this.selectedPage = {} as PageDto;
    this.BuildForm();
    this.isModalOpen = true;
  }
  //----------------------------
  BuildForm() {
    this.form = this.fb.group({
      title: [this.selectedPage.title || '', Validators.required],
      content: [this.selectedPage.content || '', Validators.maxLength(500)],
      script: [this.selectedPage.script || '', Validators.maxLength(500)],
      style: [this.selectedPage.style || '', Validators.maxLength(500)],
    });
  }
  //----------------------------
  Save() {
    if (this.form.invalid) {
      return;
    }
    const request = this.selectedPage.id ?
      this.pageAdminService.update(this.selectedPage.id, this.form.value) :
      this.pageAdminService.create(this.form.value);

    request.subscribe((response) => {
      this.isModalOpen = false;
      this.toaster.success("::Successfully")
      this.form.reset();
      this.list.get();
      console.log(response);

    });
    /*
    , httpError => {

      this.form.controls.title.setErrors({ 'incorrect': true, invalid: '' });
    }
    */
  }
  //----------------------------
  EditPage(id: string) {

    this.pageAdminService.get(id).subscribe((page) => {
      this.selectedPage = page;
      this.BuildForm();
      this.isModalOpen = true;
    });
  }
  //----------------------------
  DeletePage(id: string, title: string) {

    var message = this.localization.instant('::AreYouSureToDelete');

    this.confirmation.warn(title, message).subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.pageAdminService.delete(id).subscribe(() => {
          this.toaster.success("::Successfully");
          this.list.get();
        });
      }
    });
  }
  //----------------------------
  SearchPage() {
    this.list.get();
  }
  //----------------------------
  SetAsHomePage(page: PageDto) {
    this.pageAdminService.setAsHomePage(page.id).subscribe((response) => {

      page.isHomePage ? this.toaster.warn('::RemovedSettingAsHomePage')
        : this.toaster.success('::CompletedSettingAsHomePage')
      this.list.get();
    });
  }
  //----------------------------
  Creator(id: string) {
    this.isModalUserDetailOpen = true;
    this.identityUserService.get(id).subscribe((response) => {
      this.user = response;

    });

  }
  //----------------------------
  LastModification(id: string) {
    if (id == '00000000-0000-0000-0000-000000000000')
      return 0;
    this.isModalUserDetailOpen = true;
    this.identityUserService.get(id).subscribe((response) => {
      this.user = response;
    });
  }
}
