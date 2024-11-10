using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.SearchObjects
{
    public class NotificationSearchObject : BaseSearchObject
    {
        public int? user_id { get; set; }
        public string? title { get; set; }  
        public string? message { get; set; }
        public string? notification_type { get; set; }
        public bool? isSent { get; set; }
        public int? page { get; set; }
        public int? page_size { get; set; }
        public string? order_by { get; set; }
    }
}
