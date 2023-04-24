using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Models
{
    public class HolidaySearch
    {
        public string DepartingFrom { get; }
        public string TravelingTo { get; }
        public string DepartureDate { get; }
        public int Duration { get; }

        public HolidaySearch(string departingFrom, string travelingTo, string departureDate, int duration)
        {
            DepartingFrom = departingFrom;
            TravelingTo = travelingTo;
            DepartureDate = departureDate;
            Duration = duration;
        }
    }
}
