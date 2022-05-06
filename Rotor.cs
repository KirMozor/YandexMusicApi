using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Rotor
    {
        private static string baseUrl = "https://api.music.yandex.net:443";

        public static JObject StationList(string language = "ru")
        {
            if (Token.token != "")
            {
                string urlToRequest = "/rotor/stations/list?language=" + language;
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