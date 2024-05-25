import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PageRoutingModule } from './page-routing.module';
import { PageComponent } from './page.component';
import { SharedModule } from '../../../shared/shared.module';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CoreModule } from '@abp/ng.core';

@NgModule({
  declarations: [
    PageComponent,

  ],
  imports: [

    //-------------------------------------
    SharedModule, PageRoutingModule,
    //-------------------------------------
    CoreModule.forChild(
      {
        localizations:
          [
            {
              culture: 'en',
              resources:
                [
                  {
                    resourceName: 'Commerce',
                    texts: {
                       PageTest: 'this is a page feature',

                    },
                  }

                ]
            }
          ]
      }
    ),
    //-------------------------------------
    ThemeSharedModule.forRoot(
      {
        validation: {
          blueprints: {
            // required: "::RequiredInput",
            // uniqueTitle: "::",
            invalid: "",

          }
        }
      }),
    //-------------------------------------

  ]
})
export class PageModule { }
