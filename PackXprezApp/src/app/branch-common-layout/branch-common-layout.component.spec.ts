import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BranchCommonLayoutComponent } from './branch-common-layout.component';

describe('BranchCommonLayoutComponent', () => {
  let component: BranchCommonLayoutComponent;
  let fixture: ComponentFixture<BranchCommonLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BranchCommonLayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BranchCommonLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
