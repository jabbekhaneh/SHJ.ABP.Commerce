import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuditLoggingComponent } from './audit-logging.component';

const routes: Routes = [{ path: '', component: AuditLoggingComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuditLoggingRoutingModule { }
