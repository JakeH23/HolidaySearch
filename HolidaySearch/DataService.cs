using HolidaySearch.Models;
using Newtonsoft.Json;

namespace HolidaySearch;

public static class DataService
{
    public static IEnumerable<Flight> FlightsData()
    {
        using (StreamReader r = new StreamReader("C:\\JakeCode\\HolidaySearch\\HolidaySearchTests\\TestData\\flights.json"))
        {
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Flight>>(json);
        }
    }    
        
    public static IEnumerable<Hotel> HotelsData()
    {
        using (StreamReader r = new StreamReader("C:\\JakeCode\\HolidaySearch\\HolidaySearchTests\\TestData\\hotels.json"))
        {
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Hotel>>(json);
        }
    }
}