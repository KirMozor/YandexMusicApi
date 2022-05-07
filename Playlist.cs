using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Playlist
    {
        private static string baseUrl = "https://api.music.yandex.net:443";

        public static JObject GetTrack(string uid, string kind, string page = "0", string pageSize = "20")
        {
            string urlToRequest = "/users/" + uid + "/playlists/" + kind + "?page=" + page + "&page-size=" + pageSize;
            
            var header = new List<string>();
            
            header.Add("accept: application/json");
            header.Add("Content-Type: application/x-www-form-urlencoded");

            string result = PostGet.GetWithHeaders(baseUrl + urlToRequest, header);
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetPlaylistUser(string userId)
        {
            if (Token.token != "")
            {
                string urlToRequest = "/users/" + userId + "/playlists/list";
                var header = new List<string>();

                header.Add("accept: application/json");
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