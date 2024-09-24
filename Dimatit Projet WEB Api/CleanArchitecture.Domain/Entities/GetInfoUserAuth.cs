using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class GetInfoUserAuth
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] Roles   { get; set; }
    }
}
