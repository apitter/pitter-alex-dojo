import { Component, OnInit, EventEmitter } from '@angular/core';
import { Country } from 'src/app/models/country.model';
import { CountriesApiService } from 'src/app/services/countries-api.service';

@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.scss']
})
export class CountriesComponent implements OnInit {

  countries: Country[] = [];
  selectedCountry?: Country;
  
  constructor( private countriesService:CountriesApiService ) { 
  }

  ngOnInit(): void {
    this.getCountries();
  }

  getCountries(): void {
    this.countriesService.getCountries().subscribe(countries => this.countries = countries);
  }

  selectCountry(country: Country): void {
    this.selectedCountry = country;    
  }

}
