using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Token
    {
        public static string token = "";
        
        private static string getTokenUrl = "https://oauth.yandex.com/token";
        
        public static JObject GetToken(string login, string password)
        {
            string dataPost = "grant_type=password&client_id=23cabbbdc6cd418abb4b39c32c41195d&client_secret=53bc75238f0c4d08a118e51fe9203300&username=" + login + "&password=" + password;
            string result = PostGet.PostReq(getTokenUrl, dataPost);
            
            dynamic obj = JsonConvert.DeserializeObject(result);
            token = (string)obj.access_token;
            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            
            return adResponse;
        }
    }
}