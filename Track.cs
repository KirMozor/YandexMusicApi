using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Track
    {
        private const string BaseUrl = "https://api.music.yandex.net:443";

        public static JObject LikesTracks(List<string> likeTracks, string userId)
        {
            if (Token.token != "")
            {
                string urlToRequest = "/users/" + userId + "/likes/tracks/add-multiple";
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("accept", "application/json");
                header.Add("Content-Type", "application/x-www-form-urlencoded");
                header.Add("Authorization", "OAuth " + Token.token);

                string likeTracksIdString = "";
                int countTracksId = likeTracks.Count;

                for (int i = 0; i < likeTracks.Count; i++)
                    if (countTracksId - 1 == i)
                        likeTracksIdString += likeTracks[i];
                    else
                        likeTracksIdString += likeTracks[i] + ",";

                string dataRequest = "track-ids=" + likeTracksIdString;

                string result = PostGet.PostDataAndHeaders(BaseUrl + urlToRequest, dataRequest, header);
                JObject adResponse =
                    JsonConvert.DeserializeObject<JObject>(result);
                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return JsonConvert.DeserializeObject<JObject>(result);
            }
        }

        public static JObject RemoveLikesTracks(List<string> likeTracks, string userId)
        {
            if (Token.token != "")
            {
                string urlToRequest = "/users/" + userId + "/likes/tracks/remove";
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("accept", "application/json");
                header.Add("Content-Type", "application/x-www-form-urlencoded");
                header.Add("Authorization", "OAuth " + Token.token);

                string removeTracksIdString = "";
                int countTracksId = likeTracks.Count;

                for (int i = 0; i < likeTracks.Count; i++)
                    if (countTracksId - 1 == i)
                        removeTracksIdString += likeTracks[i];
                    else
                        removeTracksIdString += likeTracks[i] + ",";

                string dataRequest = "track-ids=" + removeTracksIdString;

                string result = PostGet.PostDataAndHeaders(BaseUrl + urlToRequest, dataRequest, header);
                JObject adResponse =
                    JsonConvert.DeserializeObject<JObject>(result);
                return adResponse;
            }

            else
            {
                string result = "{\"error\": \"Not token\"}";
                return JsonConvert.DeserializeObject<JObject>(result);
            }
        }

        public static JObject GetLikesTrack(string userId)
        {
            string urlToRequest = "/users/" + userId + "/likes/tracks";
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("accept", "application/json");

            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);

            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetInformTrack(List<string> idTracks)
        {
            string urlToRequest = "/tracks";
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("accept", "application/json");
            header.Add("Content-Type", "application/x-www-form-urlencoded");

            string tracksIdString = "";
            int countTracksId = idTracks.Count;

            for (int i = 0; i < idTracks.Count; i++)
                if (countTracksId - 1 == i)
                    tracksIdString += idTracks[i];
                else
                    tracksIdString += idTracks[i] + ",";

            string dataRequest = "track-ids=" + tracksIdString + "&with-positions=false";
            string result = PostGet.PostDataAndHeaders(BaseUrl + urlToRequest, dataRequest, header);
            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetDownloadInfo(string trackId)
        {
            string urlToRequest = "/tracks/" + trackId + "/download-info";
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("accept", "application/json");

            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);

            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetDownloadInfoWithToken(string trackId)
        {
            if (Token.token != "")
            {
                string urlToRequest = "/tracks/" + trackId + "/download-info";
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("accept", "application/json");
                header.Add("Authorization", "OAuth " + Token.token);

                string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);

                dynamic adResponse = JsonConvert.DeserializeObject(result);
                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return JsonConvert.DeserializeObject<JObject>(result);
            }
        }

        private static Dictionary<string, string> GetXml(string vvod)
        {
            XDocument doc = XDocument.Parse(vvod);
            IEnumerable<XElement> el = doc.Root.Elements();
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (XElement i in el) result.Add(i.Name.ToString(), i.Value);

            return result;
        }

        public static string GetDirectLink(string downloadInfoUrl, string codec = "mp3")
        {
            string resultGetXml = PostGet.Get(downloadInfoUrl);
            Console.WriteLine(resultGetXml);

            Dictionary<string, string> xmlResult = GetXml(resultGetXml);

            string host = xmlResult["host"];
            string path = xmlResult["path"];
            string ts = xmlResult["ts"];
            string s = xmlResult["s"];

            string secret = $"XGRlBW9FXlekgbPrRHuSiA{path.Substring(1, path.Length - 1)}{s}";
            MD5 md5 = MD5.Create();
            byte[] md5Hash = md5.ComputeHash(Encoding.UTF8.GetBytes(secret));
            HMACSHA1 hmacsha1 = new HMACSHA1(); 
            byte[] hmasha1Hash = hmacsha1.ComputeHash(md5Hash);
            string sign = BitConverter.ToString(hmasha1Hash).Replace("-", "").ToLower();

            return $"https://{host}/get-{codec}/{sign}/{ts}/{path}";
        }

        public static JObject GetTrackSimilar(string trackId)
        {
            string urlToRequest = "/tracks/" + trackId + "/similar";
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("accept", "application/json");

            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);

            dynamic adResponse = JsonConvert.DeserializeObject(result);
            return adResponse;
        }

        public static JObject GetDislikesTracks(string userId)
        {
            if (Token.token != "")
            {
                string urlToRequest = "/users/" + userId + "/dislikes/tracks";
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("accept", "application/json");
                header.Add("Authorization", "OAuth " + Token.token);

                string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);

                dynamic adResponse = JsonConvert.DeserializeObject(result);
                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return JsonConvert.DeserializeObject<JObject>(result);
            }
        }

        public static JObject GetSupplement(string trackId)
        {
            string urlToRequest = "/tracks/" + trackId + "/supplement";
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("accept", "application/json");
            
            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);

            dynamic adResponse = JsonConvert.DeserializeObject(result);
            return adResponse;
        }
    }
}