using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Account
    {
        private static string baseUrl = "https://api.music.yandex.net:443";

        public static JObject Expirements()
        {
            string urlToRequest = "/account/experiments";
            string tokenRequestHeader = "Authorization: OAuth " + Token.token;

            string result = PostGet.GetWithAuthorization(baseUrl + urlToRequest, tokenRequestHeader);
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject Promocode(string promocode, string language)
        {
            string urlToRequest = "/account/consume-promo-code";
            string dataPost = "code=" + promocode + "&language=" + language;

            var header = new List<string>();
            header.Add("accept: application/json");
            header.Add("Authorization: OAuth " + Token.token);
            header.Add("Content-Type: application/x-www-form-urlencoded");
            
            string result = PostGet.PostDataAndHeaders(baseUrl + urlToRequest, dataPost, header);
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }
    }
}