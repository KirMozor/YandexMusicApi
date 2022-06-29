using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Account
    {
        private const string BaseUrl = "https://api.music.yandex.net:443";

        public static JObject Expirements()
        {
            if (Token.token != "")
            {
                string urlToRequest = "/account/experiments";
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("accept", "*/*");
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

        public static JObject Promocode(string promocode, string language)
        {
            if (Token.token != "")
            {
                string urlToRequest = "/account/consume-promo-code";
                string dataPost = "code=" + promocode + "&language=" + language;

                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("accept", "application/json");
                header.Add("Authorization", "OAuth " + Token.token);
                header.Add("Content-Type", "application/x-www-form-urlencoded");

                string result = PostGet.PostDataAndHeaders(BaseUrl + urlToRequest, dataPost, header);
                JObject adResponse = JsonConvert.DeserializeObject<JObject>(result);
                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return JsonConvert.DeserializeObject<JObject>(result);
            }
        }

        public static JObject ShowSettings()
        {
            if (Token.token != "")
            {
                string urlToRequest = "/account/settings";
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("accept", "application/json");
                header.Add("Authorization", "OAuth " + Token.token);

                string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);
                JObject adResponse = JsonConvert.DeserializeObject<JObject>(result);
                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return JsonConvert.DeserializeObject<JObject>(result);
            }
        }

        public static JObject SettingsChanged(string data)
        {
            if (Token.token != "")
            {
                string urlToRequest = "/account/settings";

                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("accept", "application/json");
                header.Add("Authorization", "OAuth " + Token.token);
                header.Add("Content-Type:", "application/x-www-form-urlencoded");

                string result = PostGet.PostDataAndHeaders(BaseUrl + urlToRequest, data, header);
                JObject adResponse = JsonConvert.DeserializeObject<JObject>(result);
                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return JsonConvert.DeserializeObject<JObject>(result);
            }
        }

        public static JObject ShowInformAccount()
        {
            if (Token.token != "")
            {
                string urlToRequest = "/account/status";

                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("accept", "application/json");
                header.Add("Authorization", "OAuth " + Token.token);

                string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);
                JObject adResponse = JsonConvert.DeserializeObject<JObject>(result);
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