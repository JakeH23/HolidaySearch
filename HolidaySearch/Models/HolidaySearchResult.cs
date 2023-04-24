using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Models
{
    public class HolidaySearchResult
    {
        public double TotalPrice { get; }
        public Flight Flight { get; }
        public Hotel Hotel { get; }
        public HolidaySearchResult(double totalPrice, Flight flight, Hotel hotel)
        {
            TotalPrice = totalPrice;
            Flight = flight;
            Hotel = hotel;
        }
    }
}