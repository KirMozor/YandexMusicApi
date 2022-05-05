namespace YandexMusicApi
{
    public class Default
    {
        private static string baseUrl = "https://api.music.yandex.net:443";
        
        public static string Search(string searchRequest, int page = 0, string typeSearch = "all", bool nocorrect = false)
        {
            string urlToRequest = "/search?text=" + searchRequest + "&page=" + page + "&type=" + typeSearch + "&nocorrect=" + nocorrect;
            return PostGet.Get(baseUrl + urlToRequest);
        }

        public static string SearchBest(string searchRequest)
        {
            string urlToRequest = "/search/suggest?part=" + searchRequest;
            return PostGet.Get(baseUrl + urlToRequest);
        }

        public static string GetAllGenres()
        {
            string urlToRequest = "/genres";
            return PostGet.Get(baseUrl + urlToRequest);
        }

        public static string GetAllFeed()
        {
            string urlToRequest = "/feed";
            string tokenRequestHeader = "Authorization: OAuth " + Token.token;

            return PostGet.GetWithAuthorization(baseUrl + urlToRequest, tokenRequestHeader);
        }
    }
}
