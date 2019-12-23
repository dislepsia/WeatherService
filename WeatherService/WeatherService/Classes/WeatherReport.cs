using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherService.Classes
{
    [BsonIgnoreExtraElements()]
    public class WeatherReport
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int DraughtDays { get; }
        public int RainDays { get; }
        public double MaxRainIntensity { get; }
        public int MaxIntensityDay { get; }
        public int OptimumDays { get; }
        public List<DayReport> WeatherPerDay { get; }

        public WeatherReport(int draughtDays, int rainDays, double maxRainIntensity, int maxIntensityDay, int optimumDays, List<DayReport> weatherPerDay)
        {
            _id = "";
            DraughtDays = draughtDays;
            RainDays = rainDays;
            MaxRainIntensity = maxRainIntensity;
            MaxIntensityDay = maxIntensityDay;
            OptimumDays = optimumDays;
            WeatherPerDay = weatherPerDay;
        }

        public static WeatherReport GenerateWeatherReport(SolarSystem system, int daysToSimulate)
        {
            var weatherList = new List<DayReport>();
            int draughtCount = 0;
            int rainCount = 0;
            int optimumCount = 0;
            for (int day = 1; day <= daysToSimulate; day++)
            {
                system.SimulateDay();

                var weatherToday = system.CalculateWeather();
                switch (weatherToday.Type)
                {
                    case Weather.WeatherType.DROUGHT:
                        draughtCount++;
                        break;
                    case Weather.WeatherType.RAINY:
                        rainCount++;
                        break;
                    case Weather.WeatherType.OPTIMUM:
                        optimumCount++;
                        break;
                }

                weatherList.Add(new DayReport(weatherToday, day));
            }


            var maxRainIntensity = weatherList.Max(r => r.Weather.RainIntensity);
            var maxIntensityDay = weatherList.Where(r => r.Weather.RainIntensity == maxRainIntensity).First().Day;

            return new WeatherReport(draughtCount, rainCount, maxRainIntensity, maxIntensityDay, optimumCount, weatherList);
        }
    }
}