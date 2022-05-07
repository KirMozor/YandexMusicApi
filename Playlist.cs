using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Playlist
    {
        private static string baseUrl = "https://api.music.yandex.net:443";

        public static JObject GetTrack(string uid, string kind, string page = "0", string pageSize = "20")
        {
            string urlToRequest = string.Format("/users/{0}/playlists/{1}?page={2}&page-size={3}", uid, kind, page, pageSize);
            
            var header = new List<string>();
            
            header.Add("accept: application/json");
            header.Add("Content-Type: application/x-www-form-urlencoded");

            string result = PostGet.GetWithHeaders(baseUrl + urlToRequest, header);
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }
    }
}