import { Component, OnInit } from '@angular/core';
import { WeatherDataService } from '../weather-data.service';
import { IWeatherDetails } from '../weather-details';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.scss']
})
export class FavoritesComponent implements OnInit {
  selectedCity: IWeatherDetails;
  favoritesCities: Object;
  nameSelected: string;
  constructor(private data: WeatherDataService) { }

  ngOnInit(): void {
    this.loadFavoritesCities();
  }

  loadFavoritesCities() {
    this.data.getFavoritesCities().subscribe(data => {
      this.favoritesCities = data
      //console.log("selecteed city = " + this.selectedCity)
    });

  }
  removeFromFavorites(city) {
    this.data.removeFromFavorites(city.Key).subscribe(() => this.loadFavoritesCities());
  }

  getCurrentWeather(city) {
    this.nameSelected = city.LocalizedName;
    this.data.getCurrentWeather(city.Key).subscribe(data => {
      this.selectedCity = data
      //this.selectedCity.Temperature = data.Temperature
     // this.selectedCity.Temprature.Metric = data.Temprature.Metric
      console.log("selecteed city = " + JSON.stringify(data))
    });
    //console.log("selecteed city = " + this.selectedCity);
  }

}
