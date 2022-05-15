using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace YandexMusicApi
{
    public class PostGet
    {
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
            using (WebClient webClient = new WebClient())
            {
                string response = webClient.DownloadString(url);
                return response;
            }
        }

        public static string GetWithHeaders(string url, List<string> header)
        {
            using (WebClient webClient = new WebClient())
            {
                WebHeaderCollection headers = new WebHeaderCollection();

                foreach (string i in header) headers.Add(i);
                webClient.Headers = headers;

                string response = webClient.DownloadString(url);
                return response;
            }
        }

        public static string PostDataAndHeaders(string url, string data, List<string> header)
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

            foreach (string i in header) request.Headers.Add(i);

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