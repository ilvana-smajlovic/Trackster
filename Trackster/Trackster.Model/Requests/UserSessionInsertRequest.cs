using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class UserSessionInsertRequest
    {
        public int user_id { get; set; }
        public DateTime login_time { get; set; }
        public DateTime logout_time { get; set; }
        public string ip_address { get; set; }
    }
}
