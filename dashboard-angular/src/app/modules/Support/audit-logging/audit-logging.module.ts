import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../shared/shared.module';
import { AuditLoggingRoutingModule } from './audit-logging-routing.module';
import { AuditLoggingComponent } from './audit-logging.component';



@NgModule({
  declarations: [
    AuditLoggingComponent
  ],
  imports: [
    SharedModule,
    AuditLoggingRoutingModule,

  ]
})
export class AuditLoggingModule { }
