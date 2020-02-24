import { Component, OnInit } from '@angular/core';
import { WeatherDataService } from '../weather-data.service';
import {  IWeatherDetails } from '../weather-details';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss']
})
export class WeatherComponent implements OnInit {
  selectedCity: IWeatherDetails;
  cities: Object;
  wd: Object;
  nameSelected: string;
  constructor(private data: WeatherDataService) {

  }

  ngOnInit(): void {
  }
  addToFavorites(city) {
    this.data.AddToFavorites(city).subscribe();
  }

  getCurrentWeather(city) {
    this.nameSelected = city.LocalizedName;
    this.data.getCurrentWeather(city.Key).subscribe(data => this.selectedCity = data);
  }

  searchCity(term) {
    if (term == null||term == "")
      return;
    this.selectedCity = this.wd = null;
    this.data.SearchCity(term).subscribe(data => {
      this.cities = data
    });
  }
}
