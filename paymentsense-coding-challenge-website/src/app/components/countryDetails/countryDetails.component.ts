import { Component, Input } from "@angular/core";
import { Country } from "src/app/models/country.model";

@Component({
    selector: 'app-country-details',
    templateUrl: './countryDetails.component.html',
    styleUrls: ['./countryDetails.component.scss']
  })

export class CountryDetailsComponent{

    @Input() country?: Country;

    constructor(){ }

}