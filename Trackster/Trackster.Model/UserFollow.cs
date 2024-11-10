using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class UserFollow
    {
        [Key]
        public int follow_id { get; set; }
        [ForeignKey("follower_id")]
        public virtual Users follower { get; set; }
        public int follower_id { get; set; }
        [ForeignKey("followed_user_id")]
        public virtual Users followed_user { get; set; }
        public int followed_user_id { get; set; }
    }
}
