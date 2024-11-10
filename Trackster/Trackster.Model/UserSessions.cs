using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class UserSessions
    {
        [Key]
        public int session_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Users user { get; set; }
        public int user_id { get; set; }
        public DateTime login_time { get; set; }
        public DateTime logout_time { get; set; }
        public string ip_address { get; set; }
    }
}
