using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class Reviews
    {
        [Key]
        public int review_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Users user { get; set; }
        public int user_id { get; set; }
        [ForeignKey("media_id")]
        public Media media { get; set; }
        public int media_id { get; set; }
        public int rating { get; set; }
        public string? review_text { get; set; }
        public bool? isApproved { get; set; }
        public DateTime created_at { get; set; }
    }
}
