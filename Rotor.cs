using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Rotor
    {
        private const string BaseUrl = "https://api.music.yandex.net:443";

        public static JObject StationList(string language = "ru")
        {
            if (Token.token != "")
            {
                string urlToRequest = "/rotor/stations/list?language=" + language;
                List<string> header = new List<string>();

                header.Add("accept: */*");
                header.Add("Authorization: OAuth " + Token.token);

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

        public static JObject StationDashboard()
        {
            if (Token.token != "")
            {
                string urlToRequest = "/rotor/stations/dashboard";
                List<string> header = new List<string>();

                header.Add("accept: */*");
                header.Add("Authorization: OAuth " + Token.token);

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
    }
}