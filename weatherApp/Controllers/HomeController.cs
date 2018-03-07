using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using weatherApp.Models;
using weatherApp.Services;
using weatherApp.ViewModels;

namespace weatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherservice;

        public HomeController(IWeatherService weatherService)
        {
            _weatherservice = weatherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> Weather()
        {
            var myWeather = await _weatherservice.GetRootObject();
            var weatherViewModel = new WeatherViewModel(myWeather);
            return View(weatherViewModel);
        }
    }
}
