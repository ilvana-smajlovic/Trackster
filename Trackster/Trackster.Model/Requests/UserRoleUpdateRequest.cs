using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class UserRoleUpdateRequest
    {
        public int user_role_id { get; set; }
        public int user_id { get; set; }
        public int role_id { get; set; }
    }
}
