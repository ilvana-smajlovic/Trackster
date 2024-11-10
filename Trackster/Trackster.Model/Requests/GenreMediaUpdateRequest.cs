using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class GenreMediaUpdateRequest
    {
        public int genre_media_id { get; set; }
        public int media_id { get; set; }
        public int genre_id { get; set; }
    }
}
