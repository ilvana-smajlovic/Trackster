using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class MediaStatisticsUpdateRequest
    {
        public int statistic_id { get; set; }
        public int user_id { get; set; }
        public int media_id { get; set; }
        public int total_watch_time { get; set; }
        public DateTime last_watched_at { get; set; }
        public bool completed { get; set; }
    }
}
