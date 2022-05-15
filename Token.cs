using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Token
    {
        public static string token = "";

        private const string GetTokenUrl = "https://oauth.yandex.com/token";

        public static JObject GetToken(string login, string password)
        {
            var dataPost =
                "grant_type=password&client_id=23cabbbdc6cd418abb4b39c32c41195d&client_secret=53bc75238f0c4d08a118e51fe9203300&username=" +
                login + "&password=" + password;
            var result = PostGet.PostReq(GetTokenUrl, dataPost);

            dynamic obj = JsonConvert.DeserializeObject(result);
            token = (string) obj.access_token;
            var adResponse =
                JsonConvert.DeserializeObject<JObject>(result);

            return adResponse;
        }
    }
}