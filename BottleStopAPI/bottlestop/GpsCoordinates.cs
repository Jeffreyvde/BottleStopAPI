using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class GpsCoordinates
    {
        public GpsCoordinates()
        {
            Machine = new HashSet<Machine>();
        }

        public int GpsCoordinatesId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public virtual ICollection<Machine> Machine { get; set; }
    }
}
