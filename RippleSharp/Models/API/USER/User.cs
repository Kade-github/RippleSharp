using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RippleSharp.Models.API.USER
{
    public class User
    {
        public int code { get; set; }
        public string country { get; set; }
        public int id { get; set; }
        public DateTime latest_activity { get; set; }
        public int privileges { get; set; }
        public DateTime registered_on { get; set; }
        public string username { get; set; }
        public string username_aka { get; set; }
    }
}
