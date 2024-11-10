using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class UserFavorites
    {
        [Key]
        public int favorite_id { get; set; }

        [ForeignKey("user_id")]
        public virtual Users user { get; set; }
        public int user_id { get; set; }


        [ForeignKey("media_id")]
        public virtual Media media { get; set; }
        public int media_id { get; set; }
        public DateTime added_at { get; set; }
    }
}
