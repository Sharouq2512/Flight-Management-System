using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Pilot
    {
        public int pilotId { get; set; }
        public string pilotName { get; set; }
        public string pilotPhone { get; set; }
        public int passengerId { get; set; }
        public string licenseNumber { get; set; }
        public int flightHours { get; set; }
        public bool isAvailable { get; set; }=false;

    }
}
