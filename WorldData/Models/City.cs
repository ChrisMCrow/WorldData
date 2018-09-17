using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;

namespace WorldData.Models
{
  public class City
  {
    private int _cityId;
    private string _cityName;
    private string _countryCode;
    private int _cityPopulation;

    public int GetCityId()
    {
      return _cityId;
    }
    public string GetCityName()
    {
      return _cityName;
    }
    public string GetCountryCode()
    {
      return _countryCode;
    }
    public int GetCityPopulation()
    {
      return _cityPopulation;
    }
      public City(int cityId, string cityName, string countryCode, int cityPopulation)
      {
        _cityId = cityId;
        _cityName = cityName;
        _countryCode = countryCode;
        _cityPopulation = cityPopulation;
      }
      public static List<City> GetAll()
      {
        List<City> allCities = new List<City> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM city;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
            int cityId = rdr.GetInt32(0);
            string cityName = rdr.GetString(1);
            string countryCode = rdr.GetString(2);
            int cityPopulation = rdr.GetInt32(3);
            City newCity = new City(cityId, cityName, countryCode, cityPopulation);
            allCities.Add(newCity);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allCities;
      }
    }
}
