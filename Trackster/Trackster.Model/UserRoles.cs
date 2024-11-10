using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class UserRoles
    {
        [Key]
        public int user_role_id { get; set; }

        [ForeignKey("user_id")]
        public virtual Users user { get; set; } = null!;
        public int user_id { get; set; }

        [ForeignKey("role_id")]
        public virtual Roles role { get; set; } = null!;
        public int role_id { get; set; }
        public DateTime changed_at { get; set; }

    }
}
