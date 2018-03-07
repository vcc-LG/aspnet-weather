using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using weatherApp.Models;

namespace weatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        HttpClient client = new HttpClient();

        public async Task<RootObject> GetRootObject()
        {
            var http = new HttpClient();
            var url = "http://samples.openweathermap.org/data/2.5/forecast?id=524901&appid=b6907d289e10d714a6e88b30761fae22";
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);
            return data;

        }

    }
}
