using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherService.Classes
{
    public class PolarCoordinates
    {
        public double Length { get; set; }//Lenght is Radio and is measured in kilometers
        public double Angle { get; set; }//Measured in degrees

        public PolarCoordinates()
        {
            this.Length = 0;
            this.Angle = MathUsefulFuntions.NormalizeAngle(0);
        }

        public PolarCoordinates(double length, double angle)
        {
            this.Length = length;
            this.Angle = MathUsefulFuntions.NormalizeAngle(angle);
        }

        //Throught tangent's function I convert the polar coordinates to cartesian coordinates
        public CartesianCoordinates ToCartesian()
        {
            return new CartesianCoordinates(Length * Math.Cos(Angle), Length * Math.Sin(Angle));
        }
    }
}
