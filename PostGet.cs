using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace YandexMusicApi
{
    public class PostGet
    {
        private static string userAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.102 Safari/537.36";

        public static string PostReq(string url, string data)
        {
            string resultPost;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = userAgent;
            request.Method = "POST";
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);

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
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
                return response;
            } 
        }

        public static string GetWithAuthorization(string url, string tokenRequestHeader)
        {
            if (Token.token != "")
            {
                string acceptHeader = "accept: */*";
                using (var webClient = new WebClient())
                {
                    var header = new WebHeaderCollection();
                    header.Add(acceptHeader);
                    header.Add(tokenRequestHeader);
                
                    webClient.Headers = header;
                
                    var response = webClient.DownloadString(url);
                    return response;
                } 
            }
            else
            {
                return "Not token";
            }
        }

        public static string PostDataAndHeaders(string url, string data, List<string> header)
        {
            string resultPost;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = userAgent;
            request.Method = "POST";
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            foreach (var i in header)
            {
                request.Headers.Add(i);
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