using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace YandexMusicApi
{
    public class PostGet
    {
        private static HttpClientHandler handler = new HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };
        //private static HttpClient client = new HttpClient(handler);
        private const string UserAgent =
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.102 Safari/537.36";
        public static string PostReq(string url, string data)
        {
            string resultPost;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.UserAgent = UserAgent;
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    resultPost = reader.ReadToEnd();
                }
            }
            response.Close();
            return resultPost;
        }

        public static string Get(string url)
        {
            string resultPost;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.UserAgent = UserAgent;
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    resultPost = reader.ReadToEnd();
                }
            }
            response.Close();
            return resultPost;
        }
        public static string GetWithHeaders(string url, Dictionary<string, string> header)
        {
            string resultPost;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.UserAgent = UserAgent;
            request.Method = "GET";
            foreach (var i in header)
            {
                switch (i.Key)
                {
                    case "accept":
                        request.Headers.Add(HttpRequestHeader.Accept, i.Value);
                        break;
                    case "Content-Type":
                        request.Headers.Add(HttpRequestHeader.ContentType, i.Value);
                        break;
                    case "Authorization":
                        request.Headers.Add(HttpRequestHeader.Authorization, i.Value);
                        break;
                }
            }
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    resultPost = reader.ReadToEnd();
                }
            }
            response.Close();
            return resultPost;
        }
        public static string PostDataAndHeaders(string url, string data, Dictionary<string, string> header)
        {
            string resultPost;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.UserAgent = UserAgent;
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            foreach (var i in header)
            {
                switch (i.Key)
                {
                    case "accept":
                        request.Headers.Add(HttpRequestHeader.Accept, i.Value);
                        break;
                    case "Content-Type":
                        request.Headers.Add(HttpRequestHeader.ContentType, i.Value);
                        break;
                    case "Authorization":
                        request.Headers.Add(HttpRequestHeader.Authorization, i.Value);
                        break;
                }
            }
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    resultPost = reader.ReadToEnd();
                }
            }
            response.Close();
            return resultPost;
        }
    }
}