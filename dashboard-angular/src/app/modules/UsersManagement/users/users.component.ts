import { ListService, PagedResultDto, LocalizationService } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'
import { ConfirmationService, Confirmation, ToasterService } from '@abp/ng.theme.shared';
import { UserDto, GetUserInputDto } from '@proxy/contracts/UsersManagement/users/models'
import { UserAdminService } from '@proxy/services/UsersManagement/users';
import { RoleDto } from '@proxy/contracts/UsersManagement/roles/model';
import { RolesService } from '../../../proxy/services/UsersManagement/roles/roles.services';


@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss'],
  providers: [ListService],

})


export class UsersComponent implements OnInit {

  constructor(public readonly list: ListService,
    private userAdminService: UserAdminService,
    private rolesService: RolesService,
    private localization: LocalizationService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService,
    private toaster: ToasterService
  ) { }
  //-----------------------------
  users = { item: [], totalcount: 0, filter: "" } as PagedResultDto<UserDto>
  getUsers = {} as GetUserInputDto;
  form: FormGroup;
  isModalOpen = false;
  isModalDetailOpen = false;
  isEditOpen = false;
  selectedUser = {} as UserDto;
  roles = { name: '' } as RoleDto;
  rolesUser = [];
  //-----------------------------
  ngOnInit(): void {
    this.GetAll(this.getUsers);
  }
  //----------------------------
  onPage(event) {
    this.getUsers.skipCount = event.offset;
  }
  //-----------------------------
  GetAll(queryFilter: GetUserInputDto) {
    this.getUsers.maxResultCount = this.list.maxResultCount;
    const userStreamCreator = (query) => this.userAdminService.GetAll(queryFilter, query);

    this.list.hookToQuery(userStreamCreator).subscribe((response) => {
      this.users = response;
    })
  }
  //-----------------------------
  Search() {
    this.list.get();
  }
  //-----------------------------
  BuildForm() {
    this.form = this.fb.group({
      userName: [this.selectedUser.userName || '', Validators.required, Validators.maxLength(255)],
      password: [this.selectedUser.password, Validators.required, Validators.maxLength(255)],
      phoneNumber: [this.selectedUser.phoneNumber || ''],
      name: [this.selectedUser.name || '', Validators.maxLength(255)],
      surname: [this.selectedUser.surname || '', Validators.maxLength(255)],
      email: [this.selectedUser.email || '', Validators.required],
      isActive: [this.selectedUser.isActive || true],
      lockoutEnabled: [this.selectedUser.lockoutEnabled || true],
      roleNames: [],
    });
    return this.form;
  }
  BuildEditForm() {
    this.form = this.fb.group({
      userName: [this.selectedUser.userName || '', Validators.required, Validators.maxLength(255)],
      phoneNumber: [this.selectedUser.phoneNumber || '', Validators.maxLength(11), Validators.minLength(11)],
      name: [this.selectedUser.name || '', Validators.maxLength(255)],
      surname: [this.selectedUser.surname || '', Validators.maxLength(255)],
      email: [this.selectedUser.email, Validators.required, Validators.email],
      isActive: [this.selectedUser.isActive || true],
      lockoutEnabled: [this.selectedUser.lockoutEnabled || true],
      roleNames: []
    });

    return this.form;
  }
  //-----------------------------
  Create() {

    this.selectedUser = {} as UserDto;
    this.GetRoles();
    this.BuildForm();
    this.isModalOpen = true;
  }
  //-----------------------------
  Edit(id: string) {
    this.userAdminService.GetById(id).subscribe((user) => {
      this.selectedUser = user;
      this.AssignableRoles(id);
      this.BuildGetForm();
      this.isModalOpen = true;
    });
  }
  //-----------------------------
  Save() {
    if (this.form.invalid) {
      return;
    }
    this.form.value.roleNames = this.rolesUser.filter((element, index) => {
      return this.rolesUser.indexOf(element) == index;
    });
    console.log("***************************");
    console.log(this.form.value.roleNames);
    console.log("***************************");


    const request = this.selectedUser.id ? this.userAdminService.Edit(this.selectedUser.id, this.form.value)
      : this.userAdminService.Create(this.form.value);


    request.subscribe((response) => {
      this.isModalOpen = false;
      this.toaster.success("::Successfully");
      this.form.reset();
      this.list.get();
    });

    this.isModalOpen = false;
  }

  BuildGetForm() {
    this.form = this.fb.group({
      userName: [this.selectedUser.userName || ''],
      phoneNumber: [this.selectedUser.phoneNumber || ''],
      name: [this.selectedUser.name || ''],
      surname: [this.selectedUser.surname || ''],
      email: [this.selectedUser.email],
      isActive: [this.selectedUser.isActive || true],
      lockoutEnabled: [this.selectedUser.lockoutEnabled || true]
    });
  }
  //-----------------------------
  Details(id: string) {
    this.userAdminService.GetById(id).subscribe((response) => {
      this.selectedUser = response;
      this.isModalDetailOpen = true;
    })

  }
  //-----------------------------
  GetRoles() {
    this.rolesService.All().subscribe((response) => {
      this.roles = response;
    });
  }
  //-----------------------------
  AssignableRoles(id: string) {
    this.userAdminService.AssignableRoles(id).subscribe((response) => {
      this.roles = response;
    })
  }
  //-----------------------------
  AddRoleToUser(name?: string) {
    this.rolesUser.push(name);
    return this.rolesUser.filter((element, index) => {
      return this.rolesUser.indexOf(element) == index;
    });

  }
}
