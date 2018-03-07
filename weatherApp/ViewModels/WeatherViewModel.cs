using System;
using System.Collections.Generic;
using weatherApp.Models;

namespace weatherApp.ViewModels
{
    public class WeatherViewModel 
    {

        public string CityName { get; set; }

        public DateTime HottestDate { get; set; }

        public List<WeatherDataPoint> DataPoints { get; set; }

        public WeatherViewModel(RootObject weatherRootObject)
        {
            CityName = weatherRootObject.city.name;
            DataPoints = getListOfPoints(weatherRootObject);
        }

        private List<WeatherDataPoint> getListOfPoints(RootObject weatherRootObject)
        {
            List<WeatherDataPoint> _ListOfPoints = new List<WeatherDataPoint>();
            foreach (var item in weatherRootObject.list)
            {
                WeatherDataPoint _tempWeatherPoint = new WeatherDataPoint()
                {
                    TempMax = getTempMax(item.main.temp_max),
                    TempMin = getTempMin(item.main.temp_min),
                    Date = getDate(item.dt_txt)
                };
                _ListOfPoints.Add(_tempWeatherPoint);
            }
            return _ListOfPoints;
        }

        private double getTempMax(double temp){
            return temp - 273.15;
        }

        private double getTempMin(double temp)
        {
            return temp - 273.15;
        }

        private DateTime getDate(string dateString)
        {
            return DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }
    }


}
