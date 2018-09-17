using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;

namespace WorldData.Models
{
    public class Country
    {
      private string _countryName;
      private string _countryCode;
      private string _countryContinent;
      private string _countryRegion;
      private float _countrySurfaceArea;
      private int _countryPopulation;

      public string GetCountryName()
      {
        return _countryName;
      }
      public string GetCountryCode()
      {
        return _countryCode;
      }
      public string GetCountryContinent()
      {
        return _countryContinent;
      }
      public string GetCountryRegion()
      {
        return _countryRegion;
      }
      public float GetCountrySurfaceArea()
      {
        return _countrySurfaceArea;
      }
      public int GetCountryPopulation()
      {
        return _countryPopulation;
      }

      public Country(string countryName, string countryCode, string countryContinent, string countryRegion, float countrySurfaceArea, int countryPopulation)
      {
        _countryName = countryName;
        _countryCode = countryCode;
        _countryContinent = countryContinent;
        _countryRegion = countryRegion;
        _countrySurfaceArea = countrySurfaceArea;
        _countryPopulation = countryPopulation;
      }
      public static List<Country> GetAll()
      {
        List<Country> allCountries = new List<Country> {};
        MySqlConnection conn = DB. Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM country;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

        while(rdr.Read())
        {
          string countryCode = rdr.GetString(0);
          string countryName = rdr.GetString(1);
          string countryContinent = rdr.GetString(2);
          string countryRegion = rdr.GetString(3);
          float countrySurfaceArea = rdr.GetFloat(4);
          int countryPopulation = rdr.GetInt32(5);
          Country newCountry = new Country(countryName, countryCode, countryContinent, countryRegion, countrySurfaceArea, countryPopulation);
          allCountries.Add(newCountry);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allCountries;
      }
    }
}
