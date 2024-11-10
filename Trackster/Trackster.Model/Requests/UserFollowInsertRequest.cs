using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class UserFollowInsertRequest
    {
        public int follower_id { get; set; }
        public int followed_user_id { get; set; }
    }
}
