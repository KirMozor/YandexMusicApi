using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Artist
    {
        private const string BaseUrl = "https://api.music.yandex.net:443";

        public static JObject GetTrack(string artistId, string page = "0", string pageSize = "20")
        {
            string urlToRequest = "/artists/" + artistId + "/tracks?page=" + page + "&page-size=" + pageSize;

            List<string> header = new List<string>();

            header.Add("accept: */*");

            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);
            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetTrackIdByRating(string artistId)
        {
            string urlToRequest = "/artists/" + artistId + "/track-ids-by-rating";
            List<string> header = new List<string>();

            header.Add("accept: */*");

            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);
            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetBriefInfo(string artistId)
        {
            string urlToRequest = "/artists/" + artistId + "/brief-info";
            List<string> header = new List<string>();

            header.Add("accept: */*");

            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);
            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetDirectAlbums(string artistId, string page = "0", string pageSize = "20",
            string sortBy = "--")
        {
            string urlToRequest;
            if (sortBy == "--")
                urlToRequest = "/artists/" + artistId + "/direct-albums?page=" + page + "&page-size=" + pageSize;
            else
                urlToRequest = "/artists/" + artistId + "/direct-albums?page=" + page + "&page-size=" + pageSize +
                               "&sort-by=" + sortBy;
            List<string> header = new List<string>();

            header.Add("accept: */*");

            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);
            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject InformArtist(string artistId)
        {
            string urlToRequest = "/artists/" + artistId;
            List<string> header = new List<string>();

            header.Add("accept: */*");

            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);
            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }
    }
}