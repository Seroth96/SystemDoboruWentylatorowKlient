import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpHandler } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { forEach } from '@angular/router/src/utils/collection';


var Headers = new HttpHeaders({ 'Content-Type': 'application/json' });

@Injectable()
export class WentylatorsApiService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }


  // Uses http.get() to load data from a single API endpoint
  getWentylators(params?: any[]) {
    let myHttpParams = new HttpParams(); //Create new HttpParams
    if (params) {
      params.forEach(param =>
        myHttpParams = myHttpParams.set(param.name, param.value)
      );
     // console.log("params", myHttpParams);
    }

    return this.http.get(
      this.baseUrl + 'api/Wentylators/GetWentylators',
      {
        headers: Headers,
        params: myHttpParams,
        observe: 'response'
      });
  }

  getWentylator(params: any[]) {
    let myHttpParams = new HttpParams(); //Create new HttpParams
    if (params) {
      params.forEach(param =>
        myHttpParams = myHttpParams.set(param.name, param.value)
      );
      //console.log("params", myHttpParams);
    }
    return this.http.get(
      this.baseUrl + 'api/Wentylators/GetWentylator',
      {
        headers: Headers,
        params: myHttpParams,
        observe: 'response'
      });
  }

  getNatures(params?: any[]) {
    let myHttpParams = new HttpParams(); //Create new HttpParams
    if (params) {
      params.forEach(param =>
        myHttpParams = myHttpParams.set(param.name, param.value)
      );
    }   

    return this.http.get(
      this.baseUrl + 'api/Natures',
      {
        headers: Headers,
        params: myHttpParams,
        observe: 'response'
      });
  }

  getApproximationValues(params?: any[]) {
    let myHttpParams = new HttpParams(); //Create new HttpParams
    if (params) {
      params.forEach(param =>
        myHttpParams = myHttpParams.set(param.name, param.value)
      );
    }

    return this.http.get(
      this.baseUrl + 'api/Chebyshev/GetApproximationValues',
      {
        headers: Headers,
        params: myHttpParams,
        observe: 'response'
      });
  }

}
