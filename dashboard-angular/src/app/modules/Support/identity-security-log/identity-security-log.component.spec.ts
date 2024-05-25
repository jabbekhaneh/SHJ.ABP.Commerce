import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IdentitySecurityLogComponent } from './identity-security-log.component';

describe('IdentitySecurityLogComponent', () => {
  let component: IdentitySecurityLogComponent;
  let fixture: ComponentFixture<IdentitySecurityLogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [IdentitySecurityLogComponent]
    });
    fixture = TestBed.createComponent(IdentitySecurityLogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
