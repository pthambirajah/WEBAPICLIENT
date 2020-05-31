using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapiclient2.Factory;
using webapiclient2.Models;

namespace webapiclient2.Controllers
{
    public class PassengerController : Controller
    {
        private string passengerLastID = "";

        // GET: Passenger
        public ActionResult Index()
        {
            return View();
        }

        // GET: Passenger/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Passenger/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Passenger/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                string PassengerID = collection["PersonID"];

                Passenger p = new Passenger { GivenName = collection["GivenName"], Surname = collection["Surname"] };

                CreatePassenger(p);

                //GetPassengerID();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public async void CreatePassenger(Passenger p)
        {
            
            await ApiClientFactory.Instance.RegisterPassenger(p);
            
        }

        public async void GetPassengerID()
        {
           
                        
            //HttpContext.Session.SetString("PassengerID", PassengerID);
        }

        // GET: Passenger/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Passenger/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Passenger/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Passenger/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}