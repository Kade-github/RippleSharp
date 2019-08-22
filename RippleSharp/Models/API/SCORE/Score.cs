using RippleSharp.Models.API.USER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RippleSharp.Models.API.SCORE
{
    public class Score
    {
        public double accuracy { get; set; }
        public string beatmap_md5 { get; set; }
        public int completed { get; set; }
        public int count_100 { get; set; }
        public int count_300 { get; set; }
        public int count_50 { get; set; }
        public int count_geki { get; set; }
        public int count_katu { get; set; }
        public int count_miss { get; set; }
        public bool full_combo { get; set; }
        public int id { get; set; }
        public int max_combo { get; set; }
        public int mods { get; set; }
        public int play_mode { get; set; }
        public double pp { get; set; }
        public int score { get; set; }
        public DateTime time { get; set; }
        public User user { get; set; }
    }
}
