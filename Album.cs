using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Album
    {
        private static string baseUrl = "https://api.music.yandex.net:443";

        public static JObject InformAlbum(string albumId)
        {
            string urlToRequest = "/albums/" + albumId;
            
            var header = new List<string>();
            
            header.Add("accept: application/json");

            string result = PostGet.GetWithHeaders(baseUrl + urlToRequest, header);
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }
    }
}