using Newtonsoft.Json;
using RippleSharp.Models.API.PING;
using RippleSharp.Models.API.SCORE;
using RippleSharp.Models.API.SURPRISE_ME;
using RippleSharp.Models.API.TOKEN;
using RippleSharp.Models.API.USER;
using RippleSharp.Models.API.UTIL;
using RippleSharp.Models.PEPPY.PLAY;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace RippleSharp
{
    public enum SortSetting
    {
        Donor_expire,
        Latest_activity,
        Silence_end
    }

    public enum Mode
    {
        None = 0,
        Standern = 1,
        Takio = 2,
        CatchTheBeat = 3,
        Mania = 4
    }

    public class RippleClient
    {
        public class PeppyAPI
        {
            public Models.PEPPY.USER.User GetUser(string id,  Mode mode = Mode.None)
            {
                return JsonConvert.DeserializeObject<Models.PEPPY.USER.User>(Get("get_user?u=" + id + "&m=" + mode));
            }

            public List<Play> GetRecentPlays(string id, int limit, Mode mode = Mode.None)
            {
                return JsonConvert.DeserializeObject<List<Play>>(Get("get_user_recent?u=" + id + "&limit=" + limit + "&m=" + mode));
            }

            public List<Play> GetBestPlays(string id, int limit, Mode mode = Mode.None)
            {
                return JsonConvert.DeserializeObject<List<Play>>(Get("get_user_best?u=" + id + "&limit=" + limit + "&m=" + mode));
            }

            public List<Score> GetScores(string beatmapId, int limit = 10, Mode mode = Mode.None, string userId = "")
            {
                if (userId == "")
                    return JsonConvert.DeserializeObject<List<Score>>(Get("get_scores?b=" + beatmapId + "&limit=" + limit + "&m=" + mode));
                else
                    return JsonConvert.DeserializeObject<List<Score>>(Get("get_scores?b=" + beatmapId + "&limit=" + limit + "&m=" + mode + "&u=" + userId));
            }

            private string Get(string query)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ripple.moe/api/" + query);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                request.ContentType = "application/json; charset=utf-8";
                string json = "";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }
                return json;
            }
        }

        public class RippleAPI
        {
            public string Token { get; set; }
            
            public RippleAPI(string tkn)
            {
                Token = tkn;
            }

            public Ping Ping()
            {
                return JsonConvert.DeserializeObject<Ping>(Get("ping"));
            }

            public SurpriseMe Surpise()
            {
                return JsonConvert.DeserializeObject<SurpriseMe>(Get("surprise_me"));
            }

            public List<Token> GetTokens()
            {
                List<Token> tokens = new List<Token>();
                TokenObject tk = JsonConvert.DeserializeObject<TokenObject>(Get("tokens"));
                foreach (Token t in tk.tokens)
                {
                    tokens.Add(t);
                }
                return tokens;
            }

            public Token GetSelfToken()
            {
                return JsonConvert.DeserializeObject<Token>(Get("tokens/self"));
            }

            public void DeleteSelf()
            {
                // Why is this a get? I dont know!
                Get("tokens/self/delete");
            }

            public User GetUser(string id)
            { 
                return JsonConvert.DeserializeObject<User>(Get("users?id=" + id));
            }

            public User GetUserByName(string name)
            {
                return JsonConvert.DeserializeObject<User>(Get("users?name=" + name));
            }

            public User GetUser(string id, SortSetting sort)
            {
                return JsonConvert.DeserializeObject<User>(Get("users?id=" + id + "&sort=" + sort));
            }

            public User GetUserByName(string name, SortSetting sort)
            {
                return JsonConvert.DeserializeObject<User>(Get("users?name=" + name + "&sort=" + sort));
            }

            public User GetSelfUser()
            {
                return JsonConvert.DeserializeObject<User>(Get("users/self"));
            }
            
            public UserFull GetUserFull(string id)
            {
                return JsonConvert.DeserializeObject<UserFull>(Get("users/full?id=" + id));
            }

            public int GetUserId(string name)
            {
                return JsonConvert.DeserializeObject<UserId>(Get("users/whatid?name=" + name)).id;
            }

            public UserPage GetUserPage(string id)
            {
                return JsonConvert.DeserializeObject<UserPage>(Get("users/userpage?id=" + id));
            }

            public UserPage GetUserPageByName(string name)
            {
                return JsonConvert.DeserializeObject<UserPage>(Get("users/userpage?name=" + name));
            }

            public List<User> LookupUser(string partName)
            {
                List<User> user = new List<User>();
                UserLookup users = JsonConvert.DeserializeObject<UserLookup>(Get("users/lookup?name=" + partName));
                foreach (User u in users.users)
                {
                    user.Add(u);
                }
                return user;
            }

            public BeatmapScores GetBeatmapScores(string id, Mode mode = Mode.None)
            {
                // Dont pass md5, its not needed. If it fails, its on the api call/user input.
                return JsonConvert.DeserializeObject<BeatmapScores>(Get("scores?b="+ id + "?mode=" + mode));
            }

            private string Get(string query)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ripple.moe/api/v1/" + query);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                request.Headers["X-Ripple-Token"] = Token;
                request.ContentType = "application/json; charset=utf-8";
                string json = "";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }
                return json;
            }
        }
    }
}
