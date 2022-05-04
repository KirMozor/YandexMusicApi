namespace YandexMusicApi
{
    public class Default
    {
        private static string baseUrl = "https://api.music.yandex.net:443";
        
        public static string Search(string searchRequest, int page = 0, string typeSearch = "all", bool nocorrect = false)
        {
            string urlToRequest = "/search?text=" + searchRequest + "&page=" + page + "&type=" + typeSearch + "&nococrrect=" + nocorrect;
            return PostGet.Get(baseUrl + urlToRequest);
        }
    }
}