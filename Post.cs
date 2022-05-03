using System;
using System.IO;
using System.Net;

namespace YandexMusicApi
{
    public class Post
    {
        private static string userAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.102 Safari/537.36";

        public static string PostReq(string url, string data)
        {
            string resultPost;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = userAgent;
            request.Method = "POST";
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            
            //записываем данные в поток запроса
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