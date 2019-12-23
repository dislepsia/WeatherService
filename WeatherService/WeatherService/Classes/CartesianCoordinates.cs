using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherService.Classes
{
    public class CartesianCoordinates
    {
        public double X { get; set; }
        public double Y { get; set; }

        public CartesianCoordinates(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public PolarCoordinates ToPolar()
        {
            return new PolarCoordinates(Length(), GetAngle());
        }

        //Throught Pitagoras's Teorem I convert the cartesian coordinates in polar coordinates
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);

        }

        //Here I get the value of the angle in the interval 0;2pi
        public double GetAngle()
        {
            if (X != 0)
            {
                double modifier = 0;

                if (X > 0 && Y > 0)
                    modifier = 0;
                if (X < 0 && Y > 0)
                    modifier = Math.PI;
                if (X < 0 && Y < 0)
                    modifier = Math.PI;
                if (X > 0 && Y < 0)
                    modifier = Math.PI * 2;

                return Math.Atan(Y / X) + modifier;
            }
            else
            {
                return Y > 0 ? Math.PI / 2 : Math.PI * 1.5;
            }
        }

        //Override operators + - and equal in the cartesian operations
        public bool Equals(CartesianCoordinates other, int precision)
        {
            return X.EqualsPrecision(other.X, precision) && Y.EqualsPrecision(other.Y, precision);
        }

        public static CartesianCoordinates operator +(CartesianCoordinates p1, CartesianCoordinates p2)
        {
            return new CartesianCoordinates(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static CartesianCoordinates operator -(CartesianCoordinates p1, CartesianCoordinates p2)
        {
            return new CartesianCoordinates(p1.X - p2.X, p1.Y - p2.Y);
        }
    }
}
