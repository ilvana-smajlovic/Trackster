using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class CrewRoles
    {
        [Key]
        public int crew_role_id { get; set; }
        public string crew_role_name { get; set; }
    }
}
