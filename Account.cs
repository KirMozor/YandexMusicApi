using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Account
    {
        private static string baseUrl = "https://api.music.yandex.net:443";

        public static JObject Expirements()
        {
            if (Token.token != "")
            {
                string urlToRequest = "/account/experiments";
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

        public static JObject Promocode(string promocode, string language)
        {
            if (Token.token != "")
            {
                string urlToRequest = "/account/consume-promo-code";
                string dataPost = "code=" + promocode + "&language=" + language;

                var header = new List<string>();
                header.Add("accept: application/json");
                header.Add("Authorization: OAuth " + Token.token);
                header.Add("Content-Type: application/x-www-form-urlencoded");
            
                string result = PostGet.PostDataAndHeaders(baseUrl + urlToRequest, dataPost, header);
                JObject adResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            }
        }

        public static JObject ShowSettings()
        {
            if (Token.token != "")
            {
                string urlToRequest = "/account/settings";
                var header = new List<string>();
                header.Add("accept: application/json");
                header.Add("Authorization: OAuth " + Token.token);
                
                string result = PostGet.GetWithHeaders(baseUrl + urlToRequest, header);
                JObject adResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            }
        }

        public static JObject SettingsChange(string data)
        {
            if (Token.token != "")
            {
                string urlToRequest = "/account/settings";
                
                var header = new List<string>();
                header.Add("accept: application/json");
                header.Add("Authorization: OAuth " + Token.token);
                header.Add("Content-Type: application/x-www-form-urlencoded");

                string result = PostGet.PostDataAndHeaders(baseUrl + urlToRequest, data, header);
                JObject adResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
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