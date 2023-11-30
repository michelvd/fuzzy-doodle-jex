import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddVacatureComponent } from './add-vacature.component';

describe('AddVacatureComponent', () => {
  let component: AddVacatureComponent;
  let fixture: ComponentFixture<AddVacatureComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddVacatureComponent]
    });
    fixture = TestBed.createComponent(AddVacatureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
