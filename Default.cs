using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Default
    {
        private static string baseUrl = "https://api.music.yandex.net:443";
        
        public static JObject Search(string searchRequest, int page = 0, string typeSearch = "all", bool nocorrect = false)
        {
            string urlToRequest = "/search?text=" + searchRequest + "&page=" + page + "&type=" + typeSearch + "&nocorrect=" + nocorrect;
            string result = PostGet.Get(baseUrl + urlToRequest);
            
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject SearchBest(string searchRequest)
        {
            string urlToRequest = "/search/suggest?part=" + searchRequest;
            
            string result = PostGet.Get(baseUrl + urlToRequest);
            
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetAllGenres()
        {
            string urlToRequest = "/genres";
            string result = PostGet.Get(baseUrl + urlToRequest);
            
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetAllFeed()
        {
            string urlToRequest = "/feed";
            var header = new List<string>();
            
            header.Add("accept: */*");
            header.Add("Authorization: OAuth " + Token.token);

            string result = PostGet.GetWithHeaders(baseUrl + urlToRequest, header);
            
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            
            return adResponse;
        }
    }
}
