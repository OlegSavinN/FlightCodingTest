using System;
using System.Collections.Generic;

namespace Gridnine.FlightCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightBuilder flightBuilder = new FlightBuilder();

            FlightFilter flightFilter = new FlightFilter();

            IList<Flight> flights = flightBuilder.GetFlights();
            TimeSpan limit = new TimeSpan(2, 0, 0);

            Console.WriteLine("Already Left");
            OutputMessage(flightFilter.ExtractAlreadyLeft(DateTime.Now, flights));

            Console.WriteLine("Flight in the past");
            OutputMessage(flightFilter.ExtractFlightInThePast(flights));

            Console.WriteLine("Time spend on the ground more than two hours");
            OutputMessage(flightFilter.ExtractSpentOnEath(limit, flights));

            void OutputMessage(IList<Flight> flightsList)
            {
                foreach (Flight flight in flightsList)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Flight");
                    foreach (Segment segment in flight.Segments)
                    {
                        Console.WriteLine("DepartureDate {0} - ArrivalDate {1}", segment.DepartureDate, segment.ArrivalDate);
                    }
                }
            }
        }

        
    }
}

