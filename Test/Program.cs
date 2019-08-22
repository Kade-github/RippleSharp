using RippleSharp;
using RippleSharp.Models.API.PING;
using RippleSharp.Models.API.SURPRISE_ME;
using RippleSharp.Models.API.TOKEN;
using RippleSharp.Models.PEPPY.PLAY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RippleSharp.RippleClient;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            RippleAPI api = new RippleAPI("apiKey");
            Ping p = api.Ping();
            Console.WriteLine("User ID | " + p.user_id);
            SurpriseMe sm = api.Surpise();
            foreach (string s in sm.cats)
            {
                Console.WriteLine("Cats | " + s);
            }
            List<Token> tokens = api.GetTokens();
            foreach (Token t in tokens)
            {
                Console.WriteLine("Token | " + t.description + " | " + t.id + " | " + t.privileges);
            }
            Console.WriteLine("Self Token | " + api.GetSelfToken().description + " | " + api.GetSelfToken().id + " | " + api.GetSelfToken().privileges);
            PeppyAPI pApi = new PeppyAPI();
            List<Play> plays = pApi.GetRecentPlays("16398", 20);
            foreach (Play pl in plays)
            {
                Console.WriteLine(pl.beatmap_id + " | " + pl.score + " | " + pl.rank);
            }
            List<Play> bestPlays = pApi.GetBestPlays("16398", 10, Mode.Standern);
            foreach (Play bestPlay in bestPlays)
            {
                Console.WriteLine("Best play | " + bestPlay.beatmap_id + " | " + bestPlay.rank + " | " + bestPlay.pp + " | " + bestPlay.score);
            }
            RippleSharp.Models.PEPPY.USER.User us = pApi.GetUser("16398");
            Console.WriteLine("^ Plays for " + us.username);
            Console.Read();
        }
    }
}
