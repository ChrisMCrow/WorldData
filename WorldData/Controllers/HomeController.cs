using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldData.Models;

namespace WorldData.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            // List<Country> allCountries = Country.GetAll();
            return View();
        }

        [HttpPost("/table")]
        public ActionResult CreateTable()
        {
            string formSelection = Request.Form["filter"];
            if (formSelection == "country-name")
            {
                List<Country> allCountries = Country.GetAll();
                return View("CreateCountry", allCountries);
            }
            else
            {
                List<City> allCities = City.GetAll();
                return View("CreateCity", allCities);
            }
        }

        // [HttpPost("/table")]
        // public ActionResult CreateCity()
        // {
        //   List<City> allCities = City.GetAll();
        //   return View(allCities);
        // }
    }
}
