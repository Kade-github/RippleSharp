using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RippleSharp.Models.API.USER
{
    public class UserLookup
    {
        public int code { get; set; }
        public List<User> users { get; set; }
    }
}
