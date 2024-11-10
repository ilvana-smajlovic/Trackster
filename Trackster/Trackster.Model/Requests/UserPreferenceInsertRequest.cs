using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class UserPreferenceInsertRequest
    {
        public int user_id { get; set; }
        public List<Genres> preferred_genres { get; set; }
    }
}
