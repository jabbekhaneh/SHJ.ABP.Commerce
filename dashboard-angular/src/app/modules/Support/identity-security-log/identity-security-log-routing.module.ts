import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IdentitySecurityLogComponent } from './identity-security-log.component';

const routes: Routes = [{ path: '', component: IdentitySecurityLogComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IdentitySecurityLogRoutingModule { }
