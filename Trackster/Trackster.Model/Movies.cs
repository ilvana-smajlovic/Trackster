using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class Movies
    {
        [Key]
        public int movie_id { get; set; }
        [ForeignKey("media_id")]
        public Media media { get; set; }
        public int media_id { get; set; }
        public int? runtime { get; set; }
    }
}
