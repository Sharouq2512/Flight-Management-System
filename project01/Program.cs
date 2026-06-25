using project01.Models;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;


namespace project01
{
    public class Program
    {

        //system storage
        public static FlightContext context = new FlightContext
        {
            Passengers = new List<Passenger>(),
            Pilots = new List<Pilot>(),
            Flights = new List<Flight>(),
            Bookings = new List<Booking>(),
            Aircrafts = new List<Aircraft>()
        };
        //=====================================================
        //01 Register a Passenger
        public static void RegisterPassenger()
        {
            Console.WriteLine("\n************* Register New Passenger ****************");

            Console.Write("Enter passenger name: ");
            string passengerName = Console.ReadLine();

            Console.Write("Enter passenger email: ");
            string passengerEmail = Console.ReadLine();

            Console.Write("Enter passenger phone number: ");
            string passengerPhone = Console.ReadLine();

            Console.Write("Enter passenger passport number: ");
            string passportNumber = Console.ReadLine();

            Console.Write("Enter passenger nationality: ");
            string nationality = Console.ReadLine();

            

            int passengerId = context.Passengers.Count + 1;

            context.Passengers.Add(

                new Passenger
                {
                    passengerId= passengerId,
                    passengerName= passengerName,
                    passengerEmail= passengerEmail,
                    passengerPhone= passengerPhone,
                    passportNumber= passportNumber,
                    nationality= nationality,


                }

                );

            Console.WriteLine($"Passenger registered successfully. Assigned ID: {passengerId}");
        }

        //==================================================
        //02 Add an Aircraft
        public static void AddAircraft()
        {
            Console.WriteLine("\n*************  Add an Aircraft ****************");

            Console.Write("Enter Aircraft model name: ");
            string model = Console.ReadLine();

            Console.Write("Enter Total number of passenger seats on this aircraft: ");
            int totalSeats = int.Parse(Console.ReadLine());

            

            int aircraftId = context.Aircrafts.Count + 1;

            context.Aircrafts.Add(

                new Aircraft    
                {
                    aircraftId = aircraftId,
                    model = model,
                    totalSeats = totalSeats,
                    isOperational = true,


                }

                );

            Console.WriteLine($"Aircraft registered successfully. Assigned ID: {aircraftId}");
        
        }
        //=============================================
        //03 Register a Pilot
        public static void RegisterPilot()
        {
            Console.WriteLine("\n************* Register a Pilot ****************");

            Console.Write("Enter pilot name: ");
            string pilotName = Console.ReadLine();

            Console.Write("Enter  Contact number: ");
            string pilotPhone = Console.ReadLine();

            Console.Write("Enter  Official aviation license number: ");
            string licenseNumber = Console.ReadLine();

            Console.Write("Enter  Total logged flight hours: ");
            int flightHours = int.Parse(Console.ReadLine());





            int pilotId = context.Pilots.Count + 1;

            context.Pilots.Add(

                new Pilot
                {
                    pilotId = pilotId,
                    pilotName = pilotName,
                    pilotPhone = pilotPhone,
                    licenseNumber = licenseNumber,
                    flightHours = flightHours,
                    isAvailable = true,


                }

                );

            Console.WriteLine($"Pilot registered successfully. Assigned ID: {pilotId}");
        }


        //========================================================
        //04 View All Flights
        public static void ViewAllFlights()
        {
            Console.WriteLine("\n************* View All Flights ****************");
            if (context.Flights.Count == 0)
            {
                Console.WriteLine("No flights available yet.");
                return;
            }

            foreach (Flight f in context.Flights)
            {
                Console.WriteLine($"ID:{f.flightId} | " +
                                    $"Code:{f.flightCode} | " +
                                    $"From:{f.origin} | " +
                                    $"To:{f.destination} | " +
                                    $"Date:{f.departureDate} | " +
                                    $"Date:{f.departureTime} | " +
                                    $"Date:{f.flightDuration} | " +
                                    $"Seats:{f.availableSeats} | " +
                                    $"Price:{f.ticketPrice} | " +
                                    $"Status:{f.status}"
                                  );
            }
        }

        //========================================================

        //05 Schedule a Flight
        public static void ScheduleFlight()
        {
            Console.WriteLine("\n************* Schedule a Flight ****************");

            Console.WriteLine("List of aircrafts available:");
            List<Aircraft> AvaAircraft = context.Aircrafts.Where(a => a.isOperational == true).ToList();


            foreach (Aircraft a in AvaAircraft)
            {
                Console.WriteLine(
                    $"ID: {a.aircraftId} | Model: {a.model} | Seats: {a.totalSeats}"
                );
            }
            Console.WriteLine("==  ==  ==  ==  ==  ==  ==  ==  ==  ==");

            Console.Write("Enter Aircraft ID: ");
            int aircraftId = int.Parse(Console.ReadLine());

            Aircraft aircraft =context.Aircrafts.FirstOrDefault(a => a.aircraftId == aircraftId);

            if (aircraft == null)
            {
                Console.WriteLine("Aircraft not found.");
                return;
            }
            //============
            Console.WriteLine("List of Pilots available:");
            List<Pilot> AvaPilot = context.Pilots.Where(p => p.isAvailable==true).ToList();


            foreach (Pilot p in AvaPilot)
            {
                Console.WriteLine(
                    $"ID: {p.pilotId} | pilot Name: {p.pilotName} | license Number: {p.licenseNumber} |" +
                    $" pilot Phone: {p.pilotPhone} | flight Hours: {p.flightHours}"
                );
            }


            Console.Write("Enter Pilot ID: ");
            int pilotId = int.Parse(Console.ReadLine());

            Pilot pilot =context.Pilots.FirstOrDefault(p => p.pilotId == pilotId);

            if (pilot == null)
            {
                Console.WriteLine("Pilot not found.");
                return;
            }


            Console.Write("Enter Origin: ");
            string origin = Console.ReadLine();

            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine();

            Console.Write("Enter Departure Date: ");
            string departureDate = Console.ReadLine();

            Console.Write("Enter Departure Time: ");
            string departureTime = Console.ReadLine();

            Console.Write("Enter flight duration: ");
            string flightDuration = Console.ReadLine();

            Console.Write("Enter Ticket Price: ");
            decimal ticketPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Available seats: ");
            int availableSeats = int.Parse(Console.ReadLine());



            int flightId = context.Flights.Count + 1;
            string flightCode = $"OA{200 + flightId}";

            context.Flights.Add(
                new Flight
                {
                    flightId = flightId,
                    flightCode = flightCode,
                    aircraftId = aircraftId,
                    pilotId = pilotId,
                    origin = origin,
                    destination = destination,
                    departureDate = departureDate,
                    departureTime = departureTime,
                    ticketPrice = ticketPrice,
                    availableSeats = availableSeats,
                    status = "Scheduled"
                });

            pilot.isAvailable = false;
            aircraft.isOperational = false;

            Console.WriteLine($"Flight created successfully. ID = {flightId} ,flight Code = {flightCode} ");
        }
        //========================================================
        //06 Book a Flight
        public static void BookFlight()
        {
            Console.WriteLine("\n************* Book A Flight ****************");
            Console.WriteLine("Enter Passenger Id:");
            int passengerId = int.Parse(Console.ReadLine());
            Passenger passenger = context.Passengers.FirstOrDefault(a => a.passengerId == passengerId);

            if (passenger == null)
            {
                Console.WriteLine("Passenger not found.");
                return;
            }

            Console.Write("Enter Destination: ");
            string yourDestination = Console.ReadLine().ToLower();

            List<Flight> matched = context.Flights.Where(d => d.destination.ToLower() == yourDestination && d.availableSeats>0).ToList();

            foreach (Flight f in matched)
            {
                Console.WriteLine($"Flight Id:{f.flightId} | " + 
                                    $"From:{f.origin} | " +
                                    $"To:{f.destination} | " +
                                    $"Date:{f.departureDate} | " +
                                    $"Date:{f.departureTime} | " +
                                    $"Date:{f.flightDuration} | " +
                                    $"Seats:{f.availableSeats} | " +
                                    $"Price:{f.ticketPrice} | ");
            }

            Flight flight = context.Flights.FirstOrDefault(f => f.destination == yourDestination);

            if (flight == null)
            {
                Console.WriteLine("destination not found.");
                return;
            }

            //=============
            Console.WriteLine("Enter Flight Id you want:");
            int flightId = int.Parse(Console.ReadLine());
            Flight trip = context.Flights.FirstOrDefault(a => a.flightId == flightId);

            if (trip == null)
            {
                Console.WriteLine("Flight not found.");
                return;
            }

            int bookingId = context.Bookings.Count + 1;
            string seatNumber= $"SNO"+ context.Bookings.Count + 100;
            context.Bookings.Add(

                new Booking
                {

                    bookingId = bookingId,
                    passengerId = passengerId,
                    flightId = flightId,
                    seatNumber= seatNumber,
                    bookingDate =flight.departureDate,
                    totalPrice = flight.ticketPrice,
                    status = "Confirmed",


                }

                );
            flight.availableSeats--;
            
            Console.WriteLine($"Booking Id:{bookingId} | " +
                                    $"passenger Id:{passengerId} | " +
                                    $"flight Id:{flightId} | " +
                                    $"seat Number:{seatNumber} | " +
                                    $"booking Date:{flight.departureDate} | " +
                                    $"total Price:{flight.ticketPrice} | " +
                                    $"status:{"Confirmed"} | ");
        }

        
        //========================================================
        //07 Cancel a Booking
        public static void CancelBooking()
        {

            Console.WriteLine("\n************* Cancel Booking ****************");

            Console.Write("Enter booking ID to cancel: ");
            int bookingId = int.Parse(Console.ReadLine());

            Booking booking = context.Bookings.FirstOrDefault(b => b.bookingId == bookingId);
            if (booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            Flight flight = context.Flights.FirstOrDefault(f => f.flightId == booking.flightId);   


            booking.status= "Cancelled";

            flight.status = "Scheduled";
            flight.availableSeats++;

            Console.WriteLine($"Booking {bookingId} has been cancelled and the flight {flight.flightId} is now available again.");
        }
        
        //========================================================    
        //08 Depart a Flight
        public static void DepartFlight()
        {
            Console.WriteLine("\n************* Depart Flight ****************");
            

        }
        //========================================================
        //09 Cancel a Flight
        public static void CancelFlight()
        {
            Console.WriteLine("\n************* Cancel Flight ****************");
            Console.Write("Enter Flight ID to cancel: ");
            int flightId = int.Parse(Console.ReadLine());

            Flight flight = context.Flights.FirstOrDefault(f => f.flightId == flightId);
            flight.status = "Cancelled";
            List<Booking> matched = context.Bookings.Where(b => b.flightId == flightId && b.status == "Confirmed").ToList();
            foreach (Booking b in matched)
            {
            
                b.status = "Cancelled";
                Flight f = context.Flights.FirstOrDefault(f => f.flightId == b.flightId);
                
                f.availableSeats++;
              

                Pilot p = context.Pilots.FirstOrDefault(p => p.pilotId == flight.pilotId);
                
               p.isAvailable = true;
                
                Console.WriteLine("Number of cancelled booking:", matched.Count);


            }


                if (flight == null)
            {
                Console.WriteLine("Flight not found.");
                return;
            }

            flight.status = "Cancelled";

            
            Console.WriteLine($"Flight {flightId} has been cancelled.");

        }

        //========================================================
        //10 Passenger Booking History
        public static void PassengerBookingHistory()
        {
            Console.WriteLine("\n************* Passenger Booking History ****************");

            Console.Write("Enter Passenger ID: ");
            int passengerId = int.Parse(Console.ReadLine());

            Passenger passenger = context.Passengers.FirstOrDefault(p => p.passengerId == passengerId);

            if (passenger == null)
            {
                Console.WriteLine("Passenger not found.");
                return;
            }

            List<Booking> passengerBookings = context.Bookings.Where(b => b.passengerId == passengerId).ToList();

            if (passengerBookings.Count == 0)
            {
                Console.WriteLine("This passenger has no bookings.");
                return;
            }

            decimal totalSpent = 0;

            Console.WriteLine($"\nPassenger: {passenger.passengerName}");
            Console.WriteLine("==============================================================");

            foreach (Booking booking in passengerBookings)
            {
                Flight flight = context.Flights.FirstOrDefault(f => f.flightId == booking.flightId);

                if (flight != null)
                {
                    Console.WriteLine(
                        $"Flight Code: {flight.flightCode} | " +
                        $"From: {flight.origin} | " +
                        $"To: {flight.destination} | " +
                        $"Departure Date: {flight.departureDate} | " +
                        $"Seat Number: {booking.seatNumber} | " +
                        $"Price Paid: {booking.totalPrice} | " +
                        $"Status: {booking.status}"
                    );

                    if (booking.status == "Confirmed")
                    {
                        totalSpent += booking.totalPrice;
                    }
                }
            }

            Console.WriteLine("==============================================================");
            Console.WriteLine($"Total Amount Spent (Confirmed Bookings Only): {totalSpent}");


        }

        //========================================================
        //11 Flight Revenue & Load Factor Report
        public static void FlightRevenueAndLoadFactorReport()
        {

        }
















        static void Main(string[] args)
        {

            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("   Flight Management System");
                Console.WriteLine("========================================");
                Console.WriteLine(" 1  - Register Passenger");
                Console.WriteLine(" 2  - Add Aircraft");
                Console.WriteLine(" 3  - Register Pilot");
                Console.WriteLine(" 4  - View All Flights");
                Console.WriteLine(" 5  - Schedule a Flight");
                Console.WriteLine(" 6  - Book a Flight");
                Console.WriteLine(" 7  - Cancel a Booking");
                Console.WriteLine(" 8  - Depart a Flight");
                Console.WriteLine(" 9  - Cancel a Flight");
                Console.WriteLine(" 10 - Passenger Booking History");
                Console.WriteLine(" 11 - Flight Revenue & Load Factor Report");
                Console.WriteLine(" 0  - Exit");
                Console.WriteLine("========================================");
                Console.Write("Select option: ");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: RegisterPassenger(); break;
                    case 2: AddAircraft(); break;
                    case 3: RegisterPilot(); break;
                    case 4: ViewAllFlights(); break;
                    case 5: ScheduleFlight(); break;
                    case 6: BookFlight(); break;
                    case 7: CancelBooking(); break;
                    case 8: DepartFlight(); break;
                    case 9: CancelFlight(); break;
                    case 10: PassengerBookingHistory(); break;
                    case 11: FlightRevenueAndLoadFactorReport(); break;
                    case 0: exit = true; break;
                    default: Console.WriteLine("Invalid option. Please try again."); break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }
    }
}
