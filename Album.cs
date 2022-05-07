using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Album
    {
        private static string baseUrl = "https://api.music.yandex.net:443";

        public static JObject InformAlbum(string albumId)
        {
            string urlToRequest = "/albums/" + albumId;
            
            var header = new List<string>();
            
            header.Add("accept: application/json");

            string result = PostGet.GetWithHeaders(baseUrl + urlToRequest, header);
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject GetTracks(string albumId)
        {
            string urlToRequest = "/albums/" + albumId + "/with-tracks";
            
            var header = new List<string>();
            
            header.Add("accept: application/json");

            string result = PostGet.GetWithHeaders(baseUrl + urlToRequest, header);
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }

        public static JObject MoreInformAlbums(List<string> albumsId)
        {
            string urlToRequest = "/albums";
            var header = new List<string>();
            
            header.Add("accept: application/json");
            header.Add("Content-Type: application/x-www-form-urlencoded");

            string albumsIdString = "";
            int countAlbumsId = albumsId.Count;
            
            for (int i = 0; i < albumsId.Count; i++)
            {
                if (countAlbumsId - 1 == i)
                {
                    albumsIdString += albumsId[i];
                }
                else
                {
                    albumsIdString += albumsId[i] + ",";
                }
            }
            string result = PostGet.PostDataAndHeaders(baseUrl + urlToRequest, "album-ids=" + albumsIdString, header);
            JObject adResponse =
                Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            return adResponse;
        }
    }
}