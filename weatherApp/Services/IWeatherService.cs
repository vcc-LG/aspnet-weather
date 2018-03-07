using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using weatherApp.Models;

namespace weatherApp.Services
{
    public interface IWeatherService
    {

        Task<RootObject> GetRootObject();

    }
}
