import { ContentProjectionService, PROJECTION_STRATEGY, LocalizationService } from '@abp/ng.core';
import { ToasterService, ConfirmationService } from '@abp/ng.theme.shared';
import { HttpErrorResponse } from '@angular/common/http';
import { Injector } from '@angular/core';
import { of, EMPTY, throwError } from 'rxjs';
import { ErrorComponent } from '../Components/errors/error.component';

export function handleHttpErrors(injector: Injector, httpError: HttpErrorResponse) {

  console.error(httpError)

  const toaster = injector.get(ToasterService);
  const localization = injector.get(LocalizationService);
  const confirmation = injector.get(ConfirmationService);
  var code = httpError.error.error.code;


  //-----------------------------------------------------
  if (httpError.status === 403) {

    if (code != null) {

      var errorTitle = localization.instant("::Error403");
      var errorMessage = localization.instant('::' + code);

      confirmation.error('', errorMessage);
      return EMPTY;
    }

  }
  //-----------------------------------------------------

  // if (httpError.status === 403) {

  //   // var errorCode = httpError.error?.error?.code;
  //   // var message = localization.instant('::' + errorCode);
  //   // toaster.error( ":  "+ message || 'Bad request!', '403');

  //   return EMPTY;
  // }

  // if (httpError.status === 404) {

  //   const contentProjection = injector.get(ContentProjectionService);
  //   contentProjection.projectContent(PROJECTION_STRATEGY.AppendComponentToBody(ErrorComponent));
  //   return;
  // }

  return throwError(httpError);
}
