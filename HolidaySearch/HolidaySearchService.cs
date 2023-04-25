using HolidaySearch.Models;

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

            return null;
        }
    }
}