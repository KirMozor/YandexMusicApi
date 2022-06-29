using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Net.Http;

namespace YandexMusicApi
{
    public class PostGet
    {
        private static HttpClientHandler handler = new HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };
        private static HttpClient client = new HttpClient(handler);
        private const string UserAgent =
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.102 Safari/537.36";
        public static string PostReq(string url, string data)
        {
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            HttpResponseMessage resultPost;
            using (client)
            {
                resultPost = client.PostAsync(url, new StringContent(data, Encoding.UTF8)).Result;
            }
            return resultPost.Content.ReadAsStringAsync().Result;
        }
        public static string Get(string url) { return client.GetStringAsync(url).Result; }
        public static string GetWithHeaders(string url, Dictionary<string, string> header)
        {
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            foreach (var i in header) { client.DefaultRequestHeaders.Add(i.Key, i.Value); }
            return client.GetStringAsync(url).Result;
        }

        public static string PostDataAndHeaders(string url, string data, Dictionary<string, string> header)
        {
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            foreach (var i in header) { client.DefaultRequestHeaders.Add(i.Key, i.Value); }
            HttpResponseMessage resultPost;
            using (client)
            {
                resultPost = client.PostAsync(url, new StringContent(data, Encoding.UTF8)).Result;
            }
            return resultPost.Content.ReadAsStringAsync().Result;
        }
    }
}