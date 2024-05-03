import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyRentalAgreementsComponent } from './my-rental-agreements.component';

describe('MyRentalAgreementsComponent', () => {
  let component: MyRentalAgreementsComponent;
  let fixture: ComponentFixture<MyRentalAgreementsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyRentalAgreementsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyRentalAgreementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
