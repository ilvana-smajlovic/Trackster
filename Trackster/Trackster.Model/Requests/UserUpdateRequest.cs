using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class UserUpdateRequest
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string password_repeat { get; set; }
        public string profile_picture { get; set; }
        public string bio { get; set; }
        public DateTime? created_at { get; set; }
        public bool? status { get; set; }

    }
}
