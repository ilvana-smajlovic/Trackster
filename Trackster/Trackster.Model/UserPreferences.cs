using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class UserPreferences
    {
        [Key]
        public int preference_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Users user { get; set; }
        public int user_id { get; set; }
        public List<Genres> preferred_genres { get; set; }

    }
}
