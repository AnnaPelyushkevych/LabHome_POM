using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Lab_AnnaP_home2.Helpers
{
    public static class RozetkaFiltersJsonReader
    {
        public static RozetkaQueries GetFiltersObjectFromJson()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Lab_AnnaP_home2.Resources.rozetkaFilters.json";

            RozetkaQueries queries;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string jsonFile = reader.ReadToEnd();
                queries = JsonConvert.DeserializeObject<RozetkaQueries>(jsonFile);
            }

            return queries;
        }
    }
}
