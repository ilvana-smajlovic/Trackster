using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class RoleUpdateRequest
    {
        public int role_id { get; set; }
        public string role_name { get; set; }
    }
}
