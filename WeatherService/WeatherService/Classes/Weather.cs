using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherService.Classes
{
    public class Weather
    {
        public enum WeatherType
        {
            RAINY,
            OPTIMUM,
            DROUGHT,
            NORMAL
        }

        public double RainIntensity { get; }
        public WeatherType Type { get; }

        private Weather(WeatherType type, double rainIntensity)
        {
            this.Type = type;
            this.RainIntensity = rainIntensity;
        }

        public static Weather CreateNormal()
        {
            return new Weather(WeatherType.NORMAL, 0);
        }

        public static Weather CreateOptimum()
        {
            return new Weather(WeatherType.OPTIMUM, 0);
        }

        public static Weather CreateDrought()
        {
            return new Weather(WeatherType.DROUGHT, 0);
        }

        public static Weather CreateRainy(double intensity)
        {
            return new Weather(WeatherType.RAINY, intensity);
        }
    }
}
