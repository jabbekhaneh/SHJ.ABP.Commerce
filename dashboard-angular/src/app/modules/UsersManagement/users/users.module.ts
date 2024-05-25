import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { SharedModule } from '../../../shared/shared.module';

import { UsersRoutingModule } from './users-routing.module'
import { UsersComponent } from './users.component';
import { CoreModule } from '@abp/ng.core';

@NgModule({
  declarations: [UsersComponent],
  imports: [
    //-------------------------------------
    SharedModule, UsersRoutingModule,
    //-------------------------------------
    CoreModule.forChild({
      localizations: []
    }),
    //-------------------------------------
    ThemeSharedModule.forRoot({

      validation: {
        blueprints: {
          // required: "::RequiredInput",
          // uniqueTitle: "::",
          invalid: "",

        }
      }
    })
  ],
})

export class UsersModule { }
