using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Artist
    {
        private static string baseUrl = "https://api.music.yandex.net:443";

        public static JObject GetTrack(string artistId, string page = "0", string pageSize = "20")
        {
            if (Token.token != "")
            {
                string urlToRequest = "/artists/" + artistId + "/tracks?page=" + page + "&page-size=" + pageSize;
            
                var header = new List<string>();
            
                header.Add("accept: */*");
                header.Add("Authorization: OAuth " + Token.token);

                string result = PostGet.GetWithHeaders(baseUrl + urlToRequest, header);
                JObject adResponse =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            }
        }

        public static JObject GetTrackIdByRating(string artistId)
        {
            if (Token.token != "")
            {
                string urlToRequest = "/artists/" + artistId + "/track-ids-by-rating";
                var header = new List<string>();
            
                header.Add("accept: */*");
                header.Add("Authorization: OAuth " + Token.token);

                string result = PostGet.GetWithHeaders(baseUrl + urlToRequest, header);
                JObject adResponse =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            }
        }

        public static JObject GetBriefInfo(string artistId)
        {
            if (Token.token != "")
            {
                string urlToRequest = "/artists/" + artistId + "/brief-info";
                var header = new List<string>();
            
                header.Add("accept: */*");
                header.Add("Authorization: OAuth " + Token.token);

                string result = PostGet.GetWithHeaders(baseUrl + urlToRequest, header);
                JObject adResponse =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            }
        }
    }
}