import { Injectable } from '@angular/core';
import { City } from '../models/city';
import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class CitiesService {
  cities: City[] = [];
  constructor(private httpClient: HttpClient) {
    /*this.cities = [
      new City("101", "New York"),
      new City("101", "Atlanta"),
      new City("101", "Toronto"),
      new City("101", "California"),
    ]*/
  }

  public getCities(): Observable<City[]> {
    let headers = new HttpHeaders();
    headers = headers.append("Authorization", "Bearer token");

    return this.httpClient.get<City[]>("https://localhost:7201/api/v1/cities", { headers: headers });
  }
}
