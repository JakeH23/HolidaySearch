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

        //No matching departure/arrival airport - still return holidays with date change and duration?
        [Fact]
        public void NoHolidaysMatchingSearch_ReturnsWarning()
        {

        }

        [Fact]
        public void WhereSearchHasOneMatchingResult_SingleResultShouldBeDisplayed()
        {

        }

        [Fact]
        public void WhereSearchHasMultipleMatchingResults_BestValueResultShouldBeDisplayed()
        {

        }


    }
}