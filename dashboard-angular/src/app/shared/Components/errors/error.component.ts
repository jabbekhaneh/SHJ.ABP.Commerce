import { ChangeDetectionStrategy, Component, ViewEncapsulation } from '@angular/core';
import { ValidationErrorComponent } from '@abp/ng.theme.lepton-x';

@Component({
  selector: 'app-error',
  template: `
   <h1>ERROR</h1>
    <div
      class="font-weight-bold font-italic px-1 invalid-feedback"
      *ngFor="let error of abpErrors; trackBy: trackByFn"
    >
      {{ error.message | abpLocalization: error.interpoliteParams }}
    </div>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None
})
export class ErrorComponent extends ValidationErrorComponent { }
