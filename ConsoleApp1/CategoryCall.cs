using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JokeGenerator
{
    class CategoryCall
    {        
        public static string[] GetCategories()
        {
            dynamic result = JsonConvert.DeserializeObject<dynamic>(ApiHelper.ApiClient.GetStringAsync("https://api.chucknorris.io/jokes/categories").Result.ToString());
            string[] results = CleanUpCategoryResult(result.ToString());
            return results;

        }
        private static string[] CleanUpCategoryResult(string result)
        {
            result = result.Replace("[", "");
            result = result.Replace("]", "");
            result = result.Replace("\"", "");
            result = result.Replace(" ", "");
            result = result.Replace(System.Environment.NewLine, "");
            string[] resultsToClean = result.Split(",");
            return resultsToClean;
        }
    }
}
