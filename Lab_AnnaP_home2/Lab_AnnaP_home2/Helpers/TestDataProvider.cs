using System.Collections.Generic;

namespace Lab_AnnaP_home2.Helpers
{
    public class TestDataProvider
    {
        public static IEnumerable<SearchFilter> FiltersToTest()
        {
            var rozetkaQuery = RozetkaFiltersJsonReader.GetFiltersObjectFromJson();
            return rozetkaQuery.Filters;
        }
    }
}
