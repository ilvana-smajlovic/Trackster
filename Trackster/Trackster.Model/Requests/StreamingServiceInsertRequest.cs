using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class StreamingServiceInsertRequest
    {
        public string service_name { get; set; }
        public string url { get; set; }
    }
}
