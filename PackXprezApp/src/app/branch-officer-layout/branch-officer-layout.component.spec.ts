import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BranchOfficerLayoutComponent } from './branch-officer-layout.component';

describe('BranchOfficerLayoutComponent', () => {
  let component: BranchOfficerLayoutComponent;
  let fixture: ComponentFixture<BranchOfficerLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BranchOfficerLayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BranchOfficerLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
