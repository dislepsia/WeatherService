using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherService.Classes
{
    public class SolarSystem
    {
        List<Planet> planetList;
        int dayCount;

        public SolarSystem(List<Planet> planetList)
        {
            if (planetList.Count != 3)
            {
                throw new ArgumentException("Planet list should have 3 planets");
            }

            this.planetList = planetList;
            this.dayCount = 0;
        }

        public void SimulateDay()
        {
            //The planets are rotated per day in a simulation
            foreach (var planet in planetList)
            {
                planet.Rotate();
            }

            dayCount++;
        }

        public Weather CalculateWeather()
        {
            if (ArePlanetsAligned())
            {
                //Check if they pass through the center.
                if (MathUsefulFuntions.LineFromTwoPointPassesOrigin(
                    planetList[0].position.polarPosition.ToCartesian(),
                    planetList[1].position.polarPosition.ToCartesian()))
                {
                    return Weather.CreateDrought();
                }
                else return Weather.CreateOptimum();
            }

            if (MathUsefulFuntions.IsPointInsideTriangle(new CartesianCoordinates(0, 0), planetList.Select(p => p.position.polarPosition.ToCartesian()).ToList()))
            {
                return Weather.CreateRainy(this.GetRainIntensity());
            }

            return Weather.CreateNormal();
        }

        public bool ArePlanetsAligned()
        {
            var diffList = GetDifferences();

            var angle = diffList[0].GetAngle();
            return diffList.All(d => MathUsefulFuntions.AreAnglesAligned(angle, d.GetAngle()));
        }

        //This function finds if the planets are aligned with each other
        private List<CartesianCoordinates> GetDifferences()
        {
            var planetCoordinates = planetList.Select(p => p.position.polarPosition.ToCartesian()).ToList();

            CartesianCoordinates coord = planetCoordinates[0];
            var diffList = new List<CartesianCoordinates>();
            for (int i = 1; i < planetCoordinates.Count; i++)
            {
                //Compare the previous planet with the current one
                diffList.Add(planetCoordinates[i] - coord);
                coord = planetCoordinates[i];
            }

            return diffList;
        }

        private List<CartesianCoordinates> GetPlanetCartesianCoordinates()
        {
            return planetList.Select(p => p.position.polarPosition.ToCartesian()).ToList();
        }

        public double GetRainIntensity()
        {
            var planetCoordinates = GetPlanetCartesianCoordinates();

            double perimeter = 0;
            var item = planetCoordinates[0];
            for (int i = 1; i < planetCoordinates.Count; i++)
            {
                perimeter += (planetCoordinates[i] - item).Length();
                item = planetCoordinates[i];
            }

            //Add the last length
            perimeter += (item - planetCoordinates[0]).Length();

            return perimeter;
        }
    }
}
