using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class Notifications
    {
        [Key]
        public int notification_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Users user { get; set; }
        public int user_id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string notification_type { get; set; }
        public bool isSent { get; set; }
        public DateTime scheduled_time { get; set; }
        public DateTime sent_time { get; set; }
    }
}
