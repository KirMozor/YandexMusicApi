namespace YandexMusicApi
{
    public class Account
    {
        private static string baseUrl = "https://api.music.yandex.net:443";

        public static string Expirements()
        {
            string urlToRequest = "/account/experiments";
            string tokenRequestHeader = "Authorization: OAuth " + Token.token;
            
            return PostGet.GetWithAuthorization(baseUrl + urlToRequest, tokenRequestHeader);
        }
    }
}