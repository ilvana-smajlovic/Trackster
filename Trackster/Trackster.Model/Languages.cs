using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class Languages
    {
        [Key]
        public int language_id { get; set; }
        public string language_name { get; set; }
    }
}
