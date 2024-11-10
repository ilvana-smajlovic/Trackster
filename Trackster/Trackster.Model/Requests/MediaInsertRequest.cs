using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class MediaInsertRequest
    {
        public string title { get; set; }
        public string description { get; set; }
        public DateTime release_date { get; set; }
        public string status { get; set; }
        public float rating { get; set; }
        public string? picture { get; set; }
        public string? backdrop { get; set; }
        public int language_id { get; set; }
        public int streaming_service_id { get; set; }
    }
}
