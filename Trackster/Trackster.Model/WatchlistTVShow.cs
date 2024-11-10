using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class WatchlistTVShow
    {
        [Key]
        public int watchlist_tvshow_id { get; set; }

        [ForeignKey("user_id")]
        public Users user { get; set; }
        public int user_id { get; set; }

        [ForeignKey("tvshow_id")]
        public TVShows tvshow { get; set; }
        public int tvshow_id { get; set; }
        public string watch_state { get; set; }
        public int? rating { get; set; }
        public DateTime added_at { get; set; }
    }
}
