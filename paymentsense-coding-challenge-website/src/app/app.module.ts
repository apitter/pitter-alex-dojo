import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaymentsenseCodingChallengeApiService } from './services';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CountriesComponent } from './components/countries/countries.component';
import { CountryDetailsComponent } from './components/countryDetails/countryDetails.component';

@NgModule({
  declarations: [
    AppComponent,
    CountriesComponent,
    CountryDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FontAwesomeModule
  ],
  providers: [PaymentsenseCodingChallengeApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
