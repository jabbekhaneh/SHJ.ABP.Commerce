import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../shared/shared.module';
import { IdentitySecurityLogRoutingModule } from './identity-security-log-routing.module';
import { IdentitySecurityLogComponent } from './identity-security-log.component';



@NgModule({
  declarations: [
    IdentitySecurityLogComponent
  ],
  imports: [
    SharedModule,
    IdentitySecurityLogRoutingModule,

  ]
})
export class IdentitySecurityLogModule { }
