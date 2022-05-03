namespace YandexMusicApi
{
    public class User
    {
        private static string getTokenUrl = "https://oauth.yandex.com/token";
        public static string GetToken(string login, string password)
        {
            string dataPost = "grant_type=password&client_id=23cabbbdc6cd418abb4b39c32c41195d&client_secret=53bc75238f0c4d08a118e51fe9203300&username=" + login + "&password=" + password;
            string result = Post.PostReq(getTokenUrl, dataPost);
            return result;
        }
    }
}