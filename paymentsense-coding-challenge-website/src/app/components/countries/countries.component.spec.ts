import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountriesComponent } from './countries.component';

describe('CountriesComponent', () => {
  let component: CountriesComponent;
  let fixture: ComponentFixture<CountriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CountriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('gets countries', () => {
    var countries = component.countries;
    expect(countries.length).toBeGreaterThan(0);
  })

  it('sets selected country', () => {
    var countries = component.countries;
    var selectedCountry = countries[0];
    component.selectCountry(selectedCountry);
    expect(component.selectedCountry).toBe(selectedCountry);
  })
});
