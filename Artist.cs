using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Artist
    {
        private static string baseUrl = "https://api.music.yandex.net:443";

        public static JObject GetTrack(string artistId, string page = "0", string pageSize = "20")
        {
            string urlToRequest = "/artists/" + artistId + "/tracks?page=" + page + "&page-size=" + pageSize;
            
            var header = new List<string>();
            
            header.Add("accept: */*");
                
            string result = PostGet.GetWithHeaders(baseUrl + urlToRequest, header);
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetTrackIdByRating(string artistId)
        {
            string urlToRequest = "/artists/" + artistId + "/track-ids-by-rating";
            var header = new List<string>();
            
            header.Add("accept: */*");

            string result = PostGet.GetWithHeaders(baseUrl + urlToRequest, header);
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetBriefInfo(string artistId)
        {
            string urlToRequest = "/artists/" + artistId + "/brief-info";
            var header = new List<string>();
            
            header.Add("accept: */*");

            string result = PostGet.GetWithHeaders(baseUrl + urlToRequest, header);
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetDirectAlbums(string artistId, string page = "0", string pageSize = "20", string sortBy = "--")
        {
            string urlToRequest;
            if (sortBy == "--")
            {
                urlToRequest = "/artists/" + artistId + "/direct-albums?page=" + page + "&page-size=" + pageSize;
            }
            else
            {
                urlToRequest = "/artists/" + artistId + "/direct-albums?page=" + page + "&page-size=" + pageSize + "&sort-by=" + sortBy;
            }
            var header = new List<string>();
            
            header.Add("accept: */*");

            string result = PostGet.GetWithHeaders(baseUrl + urlToRequest, header);
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }
    }
}