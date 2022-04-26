using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace Lab_AnnaP_home2.Helpers
{
    public static class RozetkaFiltersJsonReader
    {

        public static RozetkaFilters GetFiltersObjectFromJson()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Lab_AnnaP_home2.Resources.rozetkaFilters.json";

            RozetkaFilters filters;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string jsonFile = reader.ReadToEnd();
                filters = JsonConvert.DeserializeObject<RozetkaFilters>(jsonFile);
            }

            return filters;
        }
    }
}
