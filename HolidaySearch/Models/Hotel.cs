using Newtonsoft.Json;

namespace HolidaySearch.Models;

public class Hotel
{
    [JsonProperty("id")]
    public int Id { get; }

    [JsonProperty("name")]
    public string Name { get; }

    [JsonProperty("arrival_date")]
    public string ArriveDate { get; }

    [JsonProperty("price_per_night")]
    public int PricePerNight { get; }

    [JsonProperty("local_airports")]
    public IEnumerable<string> LocalAirports { get; }

    [JsonProperty("nights")]
    public int Nights { get; }

    public Hotel(int id, string name, string arriveDate, int pricePerNight, IEnumerable<string> localAirports, int nights)
    {
        Id = id;
        Name = name;
        ArriveDate = arriveDate;
        PricePerNight = pricePerNight;
        LocalAirports = localAirports;
        Nights = nights;
    }
}