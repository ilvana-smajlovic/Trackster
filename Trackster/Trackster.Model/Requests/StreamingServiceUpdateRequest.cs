using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class StreamingServiceUpdateRequest
    {
        public int streaming_service_id { get; set; }
        public string service_name { get; set; }
        public string url { get; set; }
    }
}
