using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class ReviewUpdateRequest
    {
        public int review_id { get; set; }
        public int user_id { get; set; }
        public int media_id { get; set; }
        public int rating { get; set; }
        public string? review_text { get; set; }
        public bool? isApproved { get; set; }
        public DateTime created_at { get; set; }
    }
}
