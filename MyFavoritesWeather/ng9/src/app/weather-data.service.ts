import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IWeatherDetails } from './weather-details';

@Injectable({
  providedIn: 'root'
})
export class WeatherDataService {
    
   
  url: string = "http://localhost:60687/api/weather";
  
  constructor(private http: HttpClient) { }
  SearchCity(term) {
    var searhcUrl = this.url + "/searchCity?term=" + term.value;

    return this.http.get(searhcUrl);
  }
  AddToFavorites(cityData) {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    var favUrl:string =  this.url + "/addToFavorites";
    return this.http.put(favUrl, JSON.stringify(cityData), httpOptions);
  }
  getFavoritesCities() {
    var favUrl: string = this.url + "/getFavoritesCities";
    return this.http.get(favUrl);
  }
  getCurrentWeather(cityKey): Observable<IWeatherDetails>{
    var currentWeatherUrl: string = this.url + "/GetCurrentWeather?cityKey=" + cityKey;
    return this.http.get<IWeatherDetails>(currentWeatherUrl);
  }
  removeFromFavorites(cityId) {
    var removeUrl = this.url + "/RemoveFromFavorites";
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    return this.http.post(removeUrl, JSON.stringify(cityId), httpOptions);
  }
}
