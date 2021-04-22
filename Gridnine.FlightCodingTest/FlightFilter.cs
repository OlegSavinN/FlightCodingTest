using System;
using System.Collections.Generic;

namespace Gridnine.FlightCodingTest
{
    public class FlightFilter
    {
        public List<Flight> ExtractAlreadyLeft (DateTime date, IList<Flight> listFlight)
        {
            List<Flight> alreadyLeft = new List<Flight>();

            foreach(Flight flight in listFlight)
            {
                foreach(Segment segment in flight.Segments)
                {
                    if(segment.DepartureDate <= date)
                    {
                        alreadyLeft.Add(flight);
                        break;
                    }
                }
            }

            return alreadyLeft;
        }

        public List<Flight> ExtractFlightInThePast(IList<Flight> listFlight)
        {
            List<Flight> flightInThePast = new List<Flight>();

            foreach (Flight flight in listFlight)
            {
                foreach (Segment segment in flight.Segments)
                {
                    if (segment.ArrivalDate <= segment.DepartureDate)
                    {
                        flightInThePast.Add(flight);
                        break;
                    }
                }
            }

            return flightInThePast;
        }

        public List<Flight> ExtractSpentOnEath(TimeSpan limit, IList<Flight> listflights)
        {
            List<Flight> flightSpentOnEath = new List<Flight>();
            
            foreach (Flight flight in listflights)
            {
                TimeSpan waitingTime = default;

                for (int i = 1; i < flight.Segments.Count; i++)
                {
                    waitingTime += flight.Segments[i].DepartureDate.Subtract(flight.Segments[i-1].ArrivalDate);
                }

                if(waitingTime >= limit)
                {
                    flightSpentOnEath.Add(flight);
                }
            }

            return flightSpentOnEath;
        }
    }
}
