namespace HolidaySearch.Models
{
    public class HolidaySearchResult
    {
        public int TotalPriceForBestMatch { get; }
        public Flight BestMatchingFlight { get; }
        public Hotel BestMatchingHotel { get; }
        public IEnumerable<Flight> AllMatchingFlights { get; }
        public IEnumerable<Hotel> AllMatchingHotels { get; }

        public HolidaySearchResult(int totalPriceForBestMatch, Flight bestMatchingFlight, Hotel bestMatchingHotel, IEnumerable<Flight> allMatchingFlights, IEnumerable<Hotel> allMatchingHotels)
        {
            TotalPriceForBestMatch = totalPriceForBestMatch;
            BestMatchingFlight = bestMatchingFlight;
            BestMatchingHotel = bestMatchingHotel;
            AllMatchingFlights = allMatchingFlights;
            AllMatchingHotels = allMatchingHotels;
        }
    }
}