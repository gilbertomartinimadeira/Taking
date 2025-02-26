import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaleItemModalComponent } from './sale-item-modal.component';

describe('SaleItemModalComponent', () => {
  let component: SaleItemModalComponent;
  let fixture: ComponentFixture<SaleItemModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SaleItemModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SaleItemModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
