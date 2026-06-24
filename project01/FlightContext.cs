using project01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01
{
    public class FlightContext
    {
        public List<Passenger> Passengers { get; set; }
        public List<Pilot> Pilots { get; set; }
        public List<Flight> Flights { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Aircraft> Aircrafts { get; set; }

    }
}
