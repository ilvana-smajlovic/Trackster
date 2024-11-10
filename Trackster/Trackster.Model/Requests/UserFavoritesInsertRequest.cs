using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class UserFavoritesInsertRequest
    {
        public int user_id { get; set; }
        public int media_id { get; set; }
        public DateTime added_at { get; set; }
    }
}
