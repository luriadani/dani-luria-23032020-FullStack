export interface ITempratureDetails {
  Value: number;
  Unit: string;
  UnitType: number;
}
export interface ITemperature {
    Metric: ITempratureDetails
}
export interface IWeatherDetails {
      
  WeatherText: string;
  WeatherIcon: number;
  Temperature: ITemperature;
  
}




