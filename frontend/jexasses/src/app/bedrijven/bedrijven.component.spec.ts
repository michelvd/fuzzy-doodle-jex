import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BedrijvenComponent } from './bedrijven.component';

describe('BedrijvenComponent', () => {
  let component: BedrijvenComponent;
  let fixture: ComponentFixture<BedrijvenComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BedrijvenComponent]
    });
    fixture = TestBed.createComponent(BedrijvenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
