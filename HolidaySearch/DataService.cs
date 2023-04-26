using HolidaySearch.Models;
using Newtonsoft.Json;

namespace HolidaySearch;

public static class DataService
{
    private static readonly string LocalPath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.IndexOf($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}", StringComparison.Ordinal));

    public static IEnumerable<Flight> FlightsData()
    {
        using (StreamReader r = new StreamReader(Path.Combine(LocalPath, @"TestData\flights.json")))
        {
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Flight>>(json);
        }
    }    
        
    public static IEnumerable<Hotel> HotelsData()
    {
        using (StreamReader r = new StreamReader(Path.Combine(LocalPath, @"TestData\hotels.json")))
        {
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Hotel>>(json);
        }
    }
}