import { AccountConfigModule } from '@abp/ng.account/config';
import { CoreModule } from '@abp/ng.core';
import { registerLocale } from '@abp/ng.core/locale';
import { IdentityConfigModule } from '@abp/ng.identity/config';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { TenantManagementConfigModule } from '@abp/ng.tenant-management/config';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { FeatureManagementModule } from '@abp/ng.feature-management';
import { AbpOAuthModule } from '@abp/ng.oauth';
import { ThemeLeptonXModule } from '@abp/ng.theme.lepton-x';
import { SideMenuLayoutModule } from '@abp/ng.theme.lepton-x/layouts';
import { AccountLayoutModule } from '@abp/ng.theme.lepton-x/account';
import { SharedModule } from './shared/shared.module';
//------------------------------------------------
import { ErrorComponent } from './shared/Components/errors/error.component';
import { handleHttpErrors } from './shared/handlers/http-error-handler';
import { HTTP_ERROR_HANDLER, CUSTOM_ERROR_HANDLERS } from '@abp/ng.theme.shared';
import { GlobalHttpErrorHandlerService } from './shared/services/global-http-error-handler.service';




@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
      localizations: [
        //----------
        {
          culture: 'en',
          resources: [{
            resourceName: 'Commerce',
            texts: {

            },
          }]
        },
        //----------
        {
          culture: 'fa',
          resources: [{
            resourceName: 'faResource',
            texts: {

            },
          }]
        },
        //----------
      ]

    }),
    AbpOAuthModule.forRoot(),
    ThemeSharedModule.forRoot(),
    AccountConfigModule.forRoot(),
    IdentityConfigModule.forRoot(),
    TenantManagementConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),

    FeatureManagementModule.forRoot(),
    ThemeLeptonXModule.forRoot(),
    SideMenuLayoutModule.forRoot(),
    AccountLayoutModule.forRoot(),
    SharedModule,

  ],
  declarations: [AppComponent, ErrorComponent],
  providers: [APP_ROUTE_PROVIDER,
    {
      provide: HTTP_ERROR_HANDLER,
      useValue: handleHttpErrors
    },
    {
      provide: CUSTOM_ERROR_HANDLERS,
      useExisting: GlobalHttpErrorHandlerService,
      multi: true,
    }
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
