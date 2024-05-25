
import { inject, Injectable } from "@angular/core";
import { HttpErrorResponse } from "@angular/common/http";
import { CustomHttpErrorHandlerService } from "@abp/ng.theme.shared";
import { CUSTOM_HTTP_ERROR_HANDLER_PRIORITY } from "@abp/ng.theme.shared";
import { ToasterService } from "@abp/ng.theme.shared";


@Injectable({ providedIn: "root" })
export class GlobalHttpErrorHandlerService  implements CustomHttpErrorHandlerService
{
  // You can write any number here, ex: 9999
  readonly priority = CUSTOM_HTTP_ERROR_HANDLER_PRIORITY.veryHigh;
  protected readonly toaster = inject(ToasterService);
  private error: HttpErrorResponse | undefined = undefined;

  // What kind of error should be handled by this service? You can decide it in this method. If error is suitable to your case then return true; otherwise return false.
  canHandle(error: unknown): boolean {
    if (error instanceof HttpErrorResponse && error.status === 400) {
      this.error = error;
      return true;
    }
    return false;
  }

  // If this service is picked from ErrorHandler, this execute method will be called.
  execute() {
    this.toaster.error(
      this.error.error?.error?.message || "Bad request!",
      "400"
    );
  }
}
