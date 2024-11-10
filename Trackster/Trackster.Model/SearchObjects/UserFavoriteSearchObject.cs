using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.SearchObjects
{
    public class UserFavoriteSearchObject : BaseSearchObject
    {
        public string? username { get; set; }
        public string? email { get; set; }
        public string? title { get; set; }
        public int? page { get; set; }
        public int? page_size { get; set; }
        public string? order_by { get; set; }
    }
}
