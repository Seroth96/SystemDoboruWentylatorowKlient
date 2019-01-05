import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpHandler } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { forEach } from '@angular/router/src/utils/collection';


var Headers = new HttpHeaders({ 'Content-Type': 'application/json' });

@Injectable()
export class WentylatorsApiService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }


  // Uses http.get() to load data from a single API endpoint
  getWentylators(params: any[] ) {
    let myHttpParams = new HttpParams(); //Create new HttpParams
    params.forEach(param =>
      myHttpParams.set(param.name, param.value)
    );

    this.http.get(
      this.baseUrl + 'api/SampleData/WeatherForecasts',
      {
        headers: Headers,
        params: myHttpParams,
        observe: 'response'
      }).subscribe(response => {
        console.log(response);
      },
      error => console.error(error),
      () => console.log('done')
      );
    return '';
  }

  getWentylator(params: any[]) {
    let myHttpParams = new HttpParams(); //Create new HttpParams
    params.forEach(param =>
      myHttpParams.set(param.name, param.value)
    );

    this.http.get(
      this.baseUrl + 'api/SampleData/WeatherForecasts',
      {
        headers: Headers,
        params: myHttpParams,
        observe: 'response'
      }).subscribe(response => {
        console.log(response);
      },
        error => console.error(error),
        () => console.log('done')
      );
    return '';
  }

}
