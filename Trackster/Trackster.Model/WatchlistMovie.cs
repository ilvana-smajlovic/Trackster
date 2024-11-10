using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class WatchlistMovie
    {
        [Key]
        public int watclist_movie_id { get; set; }

        [ForeignKey("user_id")]
        public Users user { get; set; }
        public int user_id { get; set; }

        [ForeignKey("movie_id")]
        public Movies movie { get; set; }
        public int movie_id { get; set; }

        public string watch_state { get; set; }
        public int? rating { get; set; }
        public DateTime added_at { get; set; }
    }
}
