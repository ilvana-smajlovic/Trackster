using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class GenreUpdateRequest
    {
        public int genre_id { get; set; }
        public string genre_name { get; set; }
    }
}
