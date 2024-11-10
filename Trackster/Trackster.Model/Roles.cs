using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class Roles
    {
        [Key]
        public int role_id { get; set; }
        public string role_name { get; set; }
        public virtual ICollection<UserRoles> user_roles { get; set; } = new List<UserRoles>();
    }
}
