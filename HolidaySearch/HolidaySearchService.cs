using HolidaySearch.Models;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace HolidaySearch
{
    public interface IHolidaySearchService
    {
        HolidaySearchResult FindBestValueHolidays(Models.HolidaySearch search);
    }

    public class HolidaySearchService : IHolidaySearchService
    {
        private static readonly IEnumerable<Flight> Flights = DataService.FlightsData();
        private static readonly IEnumerable<Hotel> Hotels = DataService.HotelsData();

        public HolidaySearchResult FindBestValueHolidays(Models.HolidaySearch search)
        {
            if (search == null)
            {
                throw new ArgumentNullException("Invalid Search Information Provided.");
            }

            var inRangeFlights = InRangeFlights(search.DepartureDate, search.Duration);

            //if no flights in range check all flights for further matching criteria
            var matchingFlights = MatchingFlights(search, inRangeFlights.Any() ? inRangeFlights : Flights);
            var matchingHotels = MatchingHotels(search);

            //TODO - need checks around there being no flights/hotels
            var flights = matchingFlights.Select(flight => Flights.Single(x => x.Id == flight.Key)).ToList();
            var hotels = matchingHotels.Select(hotel => Hotels.Single(x => x.Id == hotel.Key)).ToList();

            //TODO - need checks around there being no flights/hotels
            var bestFlight = BestValueFlight(matchingFlights);
            var bestHotel = BestValueHotel(matchingHotels);

            //TODO - precautionary checks that flight has price property set
            var bestHotelPrice = int.Parse(bestFlight.Price) + (bestHotel.PricePerNight * search.Duration);

            return new HolidaySearchResult(bestHotelPrice, bestFlight, bestHotel, flights, hotels);
        }

        private static IEnumerable<Flight> InRangeFlights(string departureDate, int duration)
        {
            var dateTimeDepart = DateTime.ParseExact(departureDate, "yyyy/MM/dd",
                System.Globalization.CultureInfo.InvariantCulture);

            //Create valid range based of flights shown - using duration of holiday as basis of this
            var lowestDate = dateTimeDepart.AddDays(-duration);
            var highestDate = dateTimeDepart.AddDays(duration);

            var inRangeFlights = new List<Flight>();

            foreach (var flight in Flights)
            {
                var flightDepart = DateTime.ParseExact(flight.DepartureDate, "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture);

                if ((lowestDate <= flightDepart) && (flightDepart <= highestDate))
                {
                    inRangeFlights.Add(flight);
                }
            }

            return inRangeFlights;
        }

        private static Flight BestValueFlight(Dictionary<int, int> matchingFlights)
        {
            var idsOfBestMatched = matchingFlights.Where(x => x.Value == matchingFlights.Values.Max()).Select(x => x.Key).ToList();

            var flights = Flights.Where(x => idsOfBestMatched.Any(y => y == x.Id));

            return flights.OrderBy(x => int.Parse(x.Price)).FirstOrDefault();
        }

        private static Hotel BestValueHotel(Dictionary<int, int> matchingHotels)
        {
            var idsOfBestMatched = matchingHotels.Where(x => x.Value == matchingHotels.Values.Max()).Select(x => x.Key).ToList();

            var hotels = Hotels.Where(x => idsOfBestMatched.Any(y => y == x.Id));

            return hotels.OrderBy(x => x.PricePerNight).FirstOrDefault();
        }

        private static Dictionary<int, int> MatchingFlights(Models.HolidaySearch search, IEnumerable<Flight> inRangeFlights)
        {
            var flightMatchDictionary = new Dictionary<int, int>();

            foreach (var flight in inRangeFlights)
            {
                if (search.TravelingTo.Contains(flight.TravelingTo))
                {
                    flightMatchDictionary.Add(flight.Id, 1);
                }

                if (search.DepartingFrom.Contains(flight.DepartingFrom))
                {
                    if (flightMatchDictionary.ContainsKey(flight.Id))
                    {
                        flightMatchDictionary[flight.Id]++;
                    }
                    else
                    {
                        flightMatchDictionary.Add(flight.Id, 1);
                    }
                }
            }

            return flightMatchDictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        private static Dictionary<int, int> MatchingHotels(Models.HolidaySearch search)
        {
            var hotelMatchDictionary = new Dictionary<int, int>();

            foreach (var hotel in Hotels)
            {
                if (hotel.LocalAirports.Any(x => search.TravelingTo.Any(y => y == x)))
                {
                    hotelMatchDictionary.Add(hotel.Id, 1);
                }

                if (search.Duration == hotel.Nights)
                {
                    if (hotelMatchDictionary.ContainsKey(hotel.Id))
                    {
                        hotelMatchDictionary[hotel.Id]++;
                    }
                    else
                    {
                        hotelMatchDictionary.Add(hotel.Id, 1);
                    }
                }

                //TODO - could to acceptable date range on these dates too
                if (search.DepartureDate == hotel.ArriveDate)
                {
                    if (hotelMatchDictionary.ContainsKey(hotel.Id))
                    {
                        hotelMatchDictionary[hotel.Id]++;
                    }
                    else
                    {
                        hotelMatchDictionary.Add(hotel.Id, 1);
                    }
                }
            }

            return hotelMatchDictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}