using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RippleSharp.Models.API.USER
{
    public class Std
    {
        public int ranked_score { get; set; }
        public int total_score { get; set; }
        public int playcount { get; set; }
        public int replays_watched { get; set; }
        public int total_hits { get; set; }
        public double level { get; set; }
        public double accuracy { get; set; }
        public int pp { get; set; }
        public int global_leaderboard_rank { get; set; }
    }

    public class Taiko
    {
        public int ranked_score { get; set; }
        public int total_score { get; set; }
        public int playcount { get; set; }
        public int replays_watched { get; set; }
        public int total_hits { get; set; }
        public double level { get; set; }
        public int accuracy { get; set; }
        public int pp { get; set; }
        public int global_leaderboard_rank { get; set; }
    }

    public class Ctb
    {
        public int ranked_score { get; set; }
        public int total_score { get; set; }
        public int playcount { get; set; }
        public int replays_watched { get; set; }
        public int total_hits { get; set; }
        public double level { get; set; }
        public double accuracy { get; set; }
        public int pp { get; set; }
        public int global_leaderboard_rank { get; set; }
    }

    public class Mania
    {
        public int ranked_score { get; set; }
        public int total_score { get; set; }
        public int playcount { get; set; }
        public int replays_watched { get; set; }
        public int total_hits { get; set; }
        public double level { get; set; }
        public double accuracy { get; set; }
        public int pp { get; set; }
        public int global_leaderboard_rank { get; set; }
    }

    public class Badge
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
    }

    public class CustomBadge
    {
        public string name { get; set; }
        public string icon { get; set; }
    }

    public class SilenceInfo
    {
        public string reason { get; set; }
        public DateTime end { get; set; }
    }

    public class UserFull
    {
        public int code { get; set; }
        public int id { get; set; }
        public string username { get; set; }
        public string username_aka { get; set; }
        public DateTime registered_on { get; set; }
        public int privileges { get; set; }
        public DateTime latest_activity { get; set; }
        public string country { get; set; }
        public Std std { get; set; }
        public Taiko taiko { get; set; }
        public Ctb ctb { get; set; }
        public Mania mania { get; set; }
        public int play_style { get; set; }
        public int favourite_mode { get; set; }
        public List<Badge> badges { get; set; }
        public CustomBadge custom_badge { get; set; }
        public SilenceInfo silence_info { get; set; }
    }
}
