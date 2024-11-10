using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class People
    {
        [Key]
        public int person_id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public DateTime birthday { get; set; }
        public string biography { get; set; }
        public string? picture { get; set; }
        public string gender { get; set; }
    }
}
