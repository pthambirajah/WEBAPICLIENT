using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using webapiclient2.Models;

namespace webapiclient2
{
    public partial class ApiClient
    {
        public async Task<List<Flight>> GetTodoItems()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Flights/"));

            

            List<Flight> FlightsWithoutPrice = await GetAsync<List<Flight>>(requestUrl);
            foreach(Flight flight in FlightsWithoutPrice)
            {
                int FlightNo = flight.FlightNo;
                var priceRequestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Flights/Price/"+FlightNo+"/"));
                double SalePrice = await GetAsync<double>(priceRequestUrl);
                 
                flight.SalePrice = SalePrice;

            }
            return FlightsWithoutPrice;
        }

        public async Task<Message<Booking>> BookFlight(Booking model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Bookings/"));
            return await PostAsync<Booking>(requestUrl, model);
        }

        public async Task<Message<Passenger>> RegisterPassenger(Passenger model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Passengers/"));
            return await PostAsync<Passenger>(requestUrl, model);
            
        }

        public async Task<string> GetPassengerID()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Passengers/Last"));

            string PassengerID = await GetAsync<string>(requestUrl);

            //HttpContext.Session.SetInt32("PassengerID", PassengerID);

            return PassengerID;
        }
    }
}
