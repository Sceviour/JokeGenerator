using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JokeGenerator
{
    class RandomNameCall
    {
        public static dynamic GetRandomName()
        {
            return JsonConvert.DeserializeObject<dynamic>(ApiHelper.ApiClient.GetStringAsync("https://www.names.privserv.com/api/").Result);
        }
    }
}
