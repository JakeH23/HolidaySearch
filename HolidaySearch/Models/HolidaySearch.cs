namespace HolidaySearch.Models
{
    public class HolidaySearch
    {
        public IEnumerable<string> DepartingFrom { get; }
        public IEnumerable<string> TravelingTo { get; }
        public string DepartureDate { get; }
        public int Duration { get; }

        public HolidaySearch(IEnumerable<string> departingFrom, IEnumerable<string> travelingTo, string departureDate, int duration)
        {
            DepartingFrom = departingFrom;
            TravelingTo = travelingTo;
            DepartureDate = departureDate;
            Duration = duration;
        }
    }
}
