using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class TokenUpdateRequest
    {
        public int token_id { get; set; }
        public int user_id { get; set; }
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
