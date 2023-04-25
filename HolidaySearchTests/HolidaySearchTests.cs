using HolidaySearch;

namespace HolidaySearchTests
{
    public class HolidaySearchTests
    {
        private static IHolidaySearchService GetHolidaySearchService()
        {
            return new HolidaySearchService();
        }

        [Fact]
        public void InvalidSearchObject_ThrowsError()
        {
            var sut = GetHolidaySearchService();
            Assert.Throws<ArgumentNullException>(() => sut.FindBestValueHolidays(null));
        }
        
        [Fact]
        public void WhereSearchHasAllSpecificValues_BestValueResultShouldBeDisplayed()
        {
            var searchData = new HolidaySearch.Models.HolidaySearch(new List<string> { "MAN" }, new List<string> { "AGP" }, "2023/07/01", 7);

            var sut = GetHolidaySearchService();

            var results = sut.FindBestValueHolidays(searchData);

            Assert.Equal(2, results.BestMatchingFlight.Id);
            Assert.Equal(9, results.BestMatchingHotel.Id);
        }

        [Fact]
        public void WhereSearchHasMultipleAirportsForAnArea_BestValueResultShouldBeDisplayed()
        {
            var searchData = new HolidaySearch.Models.HolidaySearch(new List<string> { "LGW" }, new List<string> { "PMI" }, "2023/06/01", 10);

            var sut = GetHolidaySearchService();

            var results = sut.FindBestValueHolidays(searchData);

            Assert.Equal(6, results.BestMatchingFlight.Id);
            Assert.Equal(5, results.BestMatchingHotel.Id);
        }

        [Fact]
        public void WhereSearchHasAnyAirport_BestValueResultShouldBeDisplayed()
        {
            var searchData = new HolidaySearch.Models.HolidaySearch(new List<string>(), new List<string> { "LPA" }, "2022/11/10", 14);

            var sut = GetHolidaySearchService();

            var results = sut.FindBestValueHolidays(searchData);

            Assert.Equal(7, results.BestMatchingFlight.Id);
            Assert.Equal(6, results.BestMatchingHotel.Id);
        }


    }
}