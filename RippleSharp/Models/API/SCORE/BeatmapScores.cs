using RippleSharp.Models.API.USER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RippleSharp.Models.API.SCORE
{
    public class BeatmapScores
    {
        public int code { get; set; }
        public List<Score> scores { get; set; }
    }
}
