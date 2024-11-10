using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class MediaUpdateRequest
    {
        public int media_id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public DateTime? release_date { get; set; }
        public string? status { get; set; }
        public float? rating { get; set; }
        public string? picture { get; set; }
        public string? backdrop { get; set; }
        public int? language_id { get; set; }
        public int? streaming_service_id { get; set; }
    }
}
