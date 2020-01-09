import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BranchReceivePackageComponent } from './branch-receive-package.component';

describe('BranchReceivePackageComponent', () => {
  let component: BranchReceivePackageComponent;
  let fixture: ComponentFixture<BranchReceivePackageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BranchReceivePackageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BranchReceivePackageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
