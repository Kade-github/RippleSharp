using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RippleSharp.Models.API.TOKEN
{
    public class Token
    {
        public string description { get; set; }
        public int id { get; set; }
        public int privileges { get; set; }
    }

    public class TokenObject
    {
        public int code { get; set; }
        public List<Token> tokens { get; set; }
    }
}
