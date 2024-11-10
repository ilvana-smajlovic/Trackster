using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class MovieUpdateRequest
    {
        public int movie_id { get; set; }
        public int media_id { get; set; }
        public int? runtime { get; set; }
    }
}
