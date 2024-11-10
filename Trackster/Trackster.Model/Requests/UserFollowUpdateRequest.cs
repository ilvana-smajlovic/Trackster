using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class UserFollowUpdateRequest
    {
        public int follow_id { get; set; }
        public int follower_id { get; set; }
        public int followed_user_id { get; set; }
    }
}
