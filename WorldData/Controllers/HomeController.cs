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
            string formSelection = Request.Form["all-filter"];
            if (formSelection == "country")
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


        [HttpPost("/cities")]
        public ActionResult CreateCity()
        {
          string formSelection = Request.Form["city-filter"];
          if (formSelection == "city-name")
          {
            string name = Request.Form["city-name-input"];
            List<City> allNames = City.FilterCityName(name);
            return View(allNames);
          }

          else if (formSelection == "city-population")
          {
            int min = int.Parse(Request.Form["city-population-min"]);
            int max = int.Parse(Request.Form["city-population-max"]);
            bool asc = bool.Parse(Request.Form["sort"]);
            List<City> allPopulations = City.FilterCityPopulation(asc, min, max);

            return View(allPopulations);
          }

          else
          {
            string name = Request.Form["city-code-input"];
            List<City> allCodes = City.FilterCountryCode(name);
            return View(allCodes);
          }
        }
    }
}
