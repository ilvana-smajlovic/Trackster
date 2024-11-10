using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class Tokens
    {
        [Key]
        public int token_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Users user { get; set; }
        public int user_id { get; set; }
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
