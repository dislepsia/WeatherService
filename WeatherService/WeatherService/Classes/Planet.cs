using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherService.Classes
{
    public class Planet
    {
        public Position position;
        public Movement movement;
        double dayRotation;

        public Planet(int radio, int direction, int velocity)
        {
            this.position = new Position();
            this.movement = new Movement();

            //The radius is measured in kilometers
            this.position.polarPosition.Length = radio;
            //Sense
            this.movement.direction = direction;
            //Velocity
            this.movement.velocity = velocity;
            //Movement of a planet in degrees per day
            this.dayRotation = MathUsefulFuntions.ToRadians(velocity);
        }

        public void Rotate()
        {
            //Rotation of a planet per day
            this.position.polarPosition.Angle += this.dayRotation * movement.velocity;
        }
    }
}