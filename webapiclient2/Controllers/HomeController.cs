using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using webapiclient2.Factory;
using webapiclient2.Models;
using webapiclient2.Utility;

namespace webapiclient2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<MySettingsModel> appSettings;
        private string passengerLastID = "";

        public HomeController(ILogger<HomeController> logger, IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            _logger = logger;
        }

       
        public async Task<IActionResult> IndexAsync()
        {
            var data = await ApiClientFactory.Instance.GetTodoItems();
            return View(data);
        }

        [HttpGet]
        public async void Buy(int FlightNo, double SalePrice)
        {
            passengerLastID = await ApiClientFactory.Instance.GetPassengerID();
            int PassengerID = int.Parse(passengerLastID);
                //int.Parse(HttpContext.Session.GetString("PassengerID"));
            Booking newBooking = new Booking { FlightNo = FlightNo, PersonID = PassengerID, SalePrice = SalePrice};

            await ApiClientFactory.Instance.BookFlight(newBooking);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
