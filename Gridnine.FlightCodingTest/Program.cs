﻿using System;
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

            OutputMessage(flightFilter.ExtractAlreadyLeft(DateTime.Now, flights));
            OutputMessage(flightFilter.ExtractFlightInThePast(flights));
            OutputMessage(flightFilter.ExtractSpentOnEath(, flights));

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

