using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class AddUserRole
    {
        public int UserId { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
