using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class UserRoleInsertRequest
    {
        public int user_id { get; set; }
        public int role_id { get; set; }
    }
}
