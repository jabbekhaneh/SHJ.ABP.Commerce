import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuditLoggingComponent } from './audit-logging.component';

describe('AuditLoggingComponent', () => {
  let component: AuditLoggingComponent;
  let fixture: ComponentFixture<AuditLoggingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AuditLoggingComponent]
    });
    fixture = TestBed.createComponent(AuditLoggingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
