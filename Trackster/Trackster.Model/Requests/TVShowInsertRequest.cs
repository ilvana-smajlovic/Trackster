using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class TVShowInsertRequest
    {
        public int media_id { get; set; }
        public int? season_count { get; set; }
        public int? episode_count { get; set; }
        public int? episode_runtime { get; set; }
    }
}
