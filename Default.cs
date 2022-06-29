using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Default
    {
        private const string BaseUrl = "https://api.music.yandex.net:443";

        public static JObject Search(string searchRequest, int page = 0, string typeSearch = "all",
            bool nocorrect = false)
        {
            string urlToRequest = "/search?text=" + searchRequest + "&page=" + page + "&type=" + typeSearch +
                               "&nocorrect=" + nocorrect;
            string result = PostGet.Get(BaseUrl + urlToRequest);

            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject SearchBest(string searchRequest)
        {
            string urlToRequest = "/search/suggest?part=" + searchRequest;

            string result = PostGet.Get(BaseUrl + urlToRequest);

            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetAllGenres()
        {
            string urlToRequest = "/genres";
            string result = PostGet.Get(BaseUrl + urlToRequest);

            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetAllFeed(int page = 0)
        {
            if (Token.token != "")
            {
                string urlToRequest = "/feed?page=" + page;
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("accept", "application/json");
                header.Add("Authorization", "OAuth " + Token.token);
                
                string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);

                JObject adResponse =
                    JsonConvert.DeserializeObject<JObject>(result);

                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return JsonConvert.DeserializeObject<JObject>(result);
            }
        }

        public static JObject GetChart()
        {
            string urlToRequest = "/landing3/chart";
            Dictionary<string, string> header = new Dictionary<string, string>();
            
            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);

            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);

            return adResponse;
        }

        public static JObject GetNewReleases()
        {
            if (Token.token != "")
            {
                string urlToRequest = "/landing3?blocks=new-releases";
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("accept", "application/json");
                header.Add("Authorization", "OAuth " + Token.token);
            
                string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);

                JObject adResponse =
                    JsonConvert.DeserializeObject<JObject>(result);

                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return JsonConvert.DeserializeObject<JObject>(result);
            }
        }

        public static JObject GetNewPlaylists()
        {
            if (Token.token != "")
            {
                string urlToRequest = "/landing3/new-playlists";
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("accept", "application/json");
                header.Add("Authorization", "OAuth " + Token.token);
            
                string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);

                JObject adResponse =
                    JsonConvert.DeserializeObject<JObject>(result);

                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return JsonConvert.DeserializeObject<JObject>(result);
            }
        }

        public static JObject GetPodcasts()
        {
            string urlToRequest = "/landing3/podcasts";
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("accept", "application/json");
            header.Add("Authorization", "OAuth " + Token.token);
            
            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);

            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);

            return adResponse;
        }
    }
}