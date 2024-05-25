import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {

  return () => {
    routesService.add([
      {
        /*-------------------------------------
                      Home
        -------------------------------------*/
        path: '/',
        name: '::Menu:Dashboard',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      /*-------------------------------------
                      CMS
      -------------------------------------*/
      {
        name: '::Menu:CMS',
        iconClass: 'fa fa-book',
        order: 10,
        layout: eLayoutType.application,
        // requiredPolicy: 'Commerce.Pages'
      },
      {
        path: '/pages',
        name: '::Menu:Pages',
        parentName: '::Menu:CMS',
        order: 11,
        layout: eLayoutType.application,
        // requiredPolicy: 'Commerce.Pages'
      },
      {
        path: '/posts',
        name: '::Menu:Blogs',
        parentName: '::Menu:CMS',
        order: 12,
        layout: eLayoutType.application,
        // requiredPolicy: 'Commerce.Posts'
      },
      /*-------------------------------------
                  Menu:Users
      -------------------------------------*/
      {
        name: '::Menu:UserManagment',
        iconClass: 'fa fa-users',
        order: 20,
        layout: eLayoutType.application,

      },
      {
        path: '/users',
        name: '::Menu:Users',
        parentName: '::Menu:UserManagment',
        order: 21,
        layout: eLayoutType.application,
      },
      {
        path: '/identity/roles',
        name: '::Menu:Roles',
        parentName: '::Menu:UserManagment',
        order: 22,
        layout: eLayoutType.application,


      },

      /*-------------------------------------
                      Developer
      -------------------------------------*/
      {
        name: '::Menu:Support',
        iconClass: 'fa fa-support',
        order: 100,
        layout: eLayoutType.application,
      },
      {
        path: 'admin/audit-logs',
        name: '::Menu:AuditLogs',
        parentName: '::Menu:Support',
        order: 102,
        layout: eLayoutType.application,

      },
      {
        path: '/admin/security-logs',
        name: '::Menu:SecurityLogs',
        parentName: '::Menu:Support',
        order: 103,
        layout: eLayoutType.application,

      },


    ]);
  };
}
