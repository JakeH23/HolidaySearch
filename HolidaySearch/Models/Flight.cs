using Newtonsoft.Json;

namespace HolidaySearch.Models;

public class Flight
{
    [JsonProperty("id")]
    public int Id { get; }

    [JsonProperty("from")]
    public string DepartingFrom { get; }

    [JsonProperty("to")]
    public string TravelingTo { get; }

    [JsonProperty("price")]
    public string Price { get; }

    [JsonProperty("departure_date")]
    public string DepartureDate { get; }

    public Flight(int id, string departingFrom, string travelingTo, string price, string departureDate)
    {
        Id = id;
        DepartingFrom = departingFrom;
        TravelingTo = travelingTo;
        Price = price;
        DepartureDate = departureDate;
    }
}