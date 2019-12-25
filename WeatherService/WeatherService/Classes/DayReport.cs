using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherService.Classes
{
    public class DayReport
    {
        public Weather Weather { get; set; }
        public int Day { get; set; }

        public DayReport(Weather weather, int day)
        {
            Weather = weather;
            Day = day;
        }
    }
}