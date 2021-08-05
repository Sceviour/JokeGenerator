using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JokeGenerator
{
    class RandomJokeCall
    {
        public static string[] GetRandomJoke(string selectedCategory)
        {
            string joke = Task.FromResult(ApiHelper.ApiClient.GetStringAsync(GenerateURL(selectedCategory)).Result).Result;
            return new string[] { JsonConvert.DeserializeObject<dynamic>(joke).value };
        }
        public static string GenerateURL(string selectedCategory)
        {
            string generatedURL;

            if (!String.IsNullOrEmpty(selectedCategory))
            {
                generatedURL = "https://api.chucknorris.io/jokes/random?category="+ selectedCategory;
            }
            else
            {
                generatedURL = "https://api.chucknorris.io/jokes/random";
            }

            return generatedURL;
        }
    }
}
