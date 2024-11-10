using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class Genres
    {
        [Key]
        public int genre_id { get; set; }
        public string genre_name { get; set; }
    }
}
