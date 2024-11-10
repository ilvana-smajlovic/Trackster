using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public string password_salt { get; set; }
        public string profile_picture { get; set; }
        public string bio { get; set; }
        public DateTime? created_at { get; set; }

        [ForeignKey("role_id")]
        public virtual ICollection<UserRoles> user_roles { get; set; } = new List<UserRoles>();
        public int role_id { get; set; }
        public bool? status { get; set; }
    }
}
