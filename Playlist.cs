using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Playlist
    {
        private const string BaseUrl = "https://api.music.yandex.net:443";

        public static JObject GetTrack(string uid, string kind, string page = "0", string pageSize = "20")
        {
            string urlToRequest = "/users/" + uid + "/playlists/" + kind + "?page=" + page + "&page-size=" + pageSize;

            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("accept", "application/json");
            header.Add("Content-Type", "application/x-www-form-urlencoded");

            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);
            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetPlaylistUser(string userId)
        {
            if (Token.token != "")
            {
                string urlToRequest = "/users/" + userId + "/playlists/list";
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

        public static JObject InformPlaylist(string playlistUid, string playlistKind)
        {
            string urlToRequest = "/users/" + playlistUid + "/playlists/" + playlistKind;
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("accept", "*/*");

            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);
            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }
    }
}