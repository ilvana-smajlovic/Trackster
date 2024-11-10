using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class MediaStatistics
    {
        [Key]
        public int statistic_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Users user { get; set; }
        public int user_id { get; set; }
        [ForeignKey("media_id")]
        public virtual Media media { get; set; }
        public int media_id { get; set; }
        public int total_watch_time { get; set; }
        public DateTime last_watched_at { get; set; }
        public bool completed { get; set; }
    }
}
