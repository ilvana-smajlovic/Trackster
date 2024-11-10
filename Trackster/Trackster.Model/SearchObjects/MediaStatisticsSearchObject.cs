using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.SearchObjects
{
    public class MediaStatisticsSearchObject : BaseSearchObject
    {
        public int? statistic_id { get; set; }
        public int? user_id { get; set; }
        public int? media_id { get; set; }
        public int? page { get; set; }
        public int? page_size { get; set; }
        public string? order_by { get; set; }
    }
}
