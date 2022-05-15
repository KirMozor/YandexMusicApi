using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Album
    {
        private const string BaseUrl = "https://api.music.yandex.net:443";

        public static JObject InformAlbum(string albumId)
        {
            string urlToRequest = "/albums/" + albumId;

            List<string> header = new List<string>();

            header.Add("accept: application/json");

            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);
            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetTracks(string albumId)
        {
            string urlToRequest = "/albums/" + albumId + "/with-tracks";

            List<string> header = new List<string>();

            header.Add("accept: application/json");

            string result = PostGet.GetWithHeaders(BaseUrl + urlToRequest, header);
            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject MoreInformAlbums(List<string> albumsId)
        {
            string urlToRequest = "/albums";
            List<string> header = new List<string>();

            header.Add("accept: application/json");
            header.Add("Content-Type: application/x-www-form-urlencoded");

            string albumsIdString = "";
            int countAlbumsId = albumsId.Count;

            for (int i = 0; i < albumsId.Count; i++)
                if (countAlbumsId - 1 == i)
                    albumsIdString += albumsId[i];
                else
                    albumsIdString += albumsId[i] + ",";
            string result = PostGet.PostDataAndHeaders(BaseUrl + urlToRequest, "album-ids=" + albumsIdString, header);
            JObject adResponse =
                JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }
    }
}