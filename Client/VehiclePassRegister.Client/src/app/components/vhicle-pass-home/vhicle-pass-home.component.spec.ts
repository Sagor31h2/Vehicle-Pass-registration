import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VhiclePassHomeComponent } from './vhicle-pass-home.component';

describe('VhiclePassHomeComponent', () => {
  let component: VhiclePassHomeComponent;
  let fixture: ComponentFixture<VhiclePassHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VhiclePassHomeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VhiclePassHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
