using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class PersonUpdateRequest
    {
        public int person_id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public DateTime birthday { get; set; }
        public string biography { get; set; }
        public string? picture { get; set; }
        public string gender { get; set; }
    }
}
