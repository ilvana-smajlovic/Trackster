using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.SearchObjects
{
    public class GenreMediaSearchObject : BaseSearchObject
    {
        public int? media_id { get; set; }
        public string? title { get; set; }
        public int? genre_id { get; set; }
        public string? genre_name { get; set; }
        public int? page { get; set; }
        public int? page_size { get; set; }
        public string? order_by { get; set; }
    }
}
