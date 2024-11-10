using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class GenreMedia
    {
        [Key]
        public int genremedia_id { get; set; }

        [ForeignKey("media_id")]
        public virtual Media media { get; set; }
        public int media_id { get; set; }

        [ForeignKey("genre_id")]
        public virtual Genres genre { get; set; }
        public int genre_id { get; set; }
    }
}
