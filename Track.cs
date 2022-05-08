using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi
{
    public class Track
    {
        private static string baseUrl = "https://api.music.yandex.net:443";

        public static JObject LikesTracks(List<string> likeTracks, string userId)
        {
            if (Token.token != "")
            {
                string urlToRequest = "/users/"+ userId + "/likes/tracks/add-multiple";
            
                var header = new List<string>();
            
                header.Add("accept: application/json");
                header.Add("Content-Type: application/x-www-form-urlencoded");
                header.Add("Authorization: OAuth " + Token.token);
            
                string likeTracksIdString = "";
                int countTracksId = likeTracks.Count;
            
                for (int i = 0; i < likeTracks.Count; i++)
                {
                    if (countTracksId - 1 == i)
                    {
                        likeTracksIdString += likeTracks[i];
                    }
                    else
                    {
                        likeTracksIdString += likeTracks[i] + ",";
                    }
                }

                string dataRequest = "track-ids=" + likeTracksIdString;
            
                string result = PostGet.PostDataAndHeaders(baseUrl + urlToRequest, dataRequest, header);
                JObject adResponse =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
                return adResponse;
            }
            else
            {
                string result = "{\"error\": \"Not token\"}";
                return Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result);
            }
        }
    }
}