import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  {
    path: 'audit-logs',
    loadChildren: () => import('./modules/Support/audit-logging/audit-logging.module').then(m => m.AuditLoggingModule)
  },
  //-------------------------- CMS
  {
    path: 'pages',
    loadChildren: () => import('./modules/CMS/page/page.module').then(m => m.PageModule)
  },
  //-------------------------- USERS
  {
    path: 'users',
    loadChildren: () => import('./modules/UsersManagement/users/users.module').then(_ => _.UsersModule)
  },
  //-------------------------- Admin
  {
    path: 'admin/audit-logs',
    loadChildren: () => import('./modules/Support/audit-logging/audit-logging.module').then(_ => _.AuditLoggingModule)
  },
  {
    path: 'admin/security-logs',
    loadChildren: () => import('./modules/Support/identity-security-log/identity-security-log.module').then(m => m.IdentitySecurityLogModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule { }
