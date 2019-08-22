using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RippleSharp.Models.API.PING
{
    public class Ping
    {
        public int code { get; set; }
        public string message { get; set; }
        public int privileges { get; set; }
        public string privileges_string { get; set; }
        public int user_id { get; set; }
        public int user_privileges { get; set; }
        public string user_privileges_string { get; set; }
    }
}
