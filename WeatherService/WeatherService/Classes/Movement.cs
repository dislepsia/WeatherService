using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherService.Classes
{
    public class Movement
    {
        public int direction; //This atrib content the rotation's direction
        public int velocity;//This param is represent in grades per day

        public Movement()
        {
            direction = Enum.CLOCKWISE;
            velocity = 1;
        }
    }
}