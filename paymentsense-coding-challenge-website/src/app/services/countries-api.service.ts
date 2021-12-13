import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Country } from '../models/country.model';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CountriesApiService {

  private _countriesUri = 'api/countries';

  constructor( private httpClient: HttpClient ) { 
  }

  getCountries(): Observable<Country[]> {
    return this.httpClient.get<Country[]>(this.buildUri(this._countriesUri))
    .pipe(
      catchError(this.handleError<Country[]>('getCountries', []))
    );
  }

  private buildUri(endpoint: string): string{
    return environment.apiUri + endpoint;
  }

  private handleError<T>(operation = 'operation', result?: T){
    return (error: any): Observable<T> => {

      // Would ideally log this somewhere
      console.log(`${operation} failed: ${error.message}`);
      console.error(error);

      return of(result as T);
    }
  }

}
