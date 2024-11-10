using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.SearchObjects
{
    public class PersonSearchObject : BaseSearchObject
    {
        public string? name { get; set; }
        public string? last_name { get; set; }
        public string? gender { get; set; }
        public int? page { get; set; }
        public int? page_size { get; set; }
        public string? order_by { get; set; }
    }
}
