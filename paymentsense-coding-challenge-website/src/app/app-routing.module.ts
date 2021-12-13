import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CountriesComponent } from './components/countries/countries.component';
import { CountryDetailsComponent } from './components/countryDetails/countryDetails.component';

const routes: Routes = [
  { path: 'countries', component: CountriesComponent },
  { path: 'countryDetails', component: CountryDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
