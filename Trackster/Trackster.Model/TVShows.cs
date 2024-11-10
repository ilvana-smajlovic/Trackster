using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class TVShows
    {
        [Key]
        public int tvshow_id { get; set; }

        [ForeignKey("media_id")]
        public Media media { get; set; }
        public int media_id { get; set; }
        public int? season_count { get; set; }
        public int? episode_count { get; set; }
        public int? episode_runtime { get; set; }
    }
}
