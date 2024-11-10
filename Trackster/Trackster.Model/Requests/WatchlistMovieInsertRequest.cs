using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class WatchlistMovieInsertRequest
    {
        public int user_id { get; set; }
        public int movie_id { get; set; }
        public string watch_state { get; set; }
        public int? rating { get; set; }
        public DateTime added_at { get; set; }
    }
}
