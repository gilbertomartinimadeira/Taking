import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListSalesComponent } from './list-sales.component';

describe('ListSalesComponent', () => {
  let component: ListSalesComponent;
  let fixture: ComponentFixture<ListSalesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListSalesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListSalesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
