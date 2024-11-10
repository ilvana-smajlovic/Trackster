using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class MediaPersonCrewRole
    {
        [Key]
        public int mediapersonrole_id { get; set; }

        [ForeignKey("media_id")]
        public virtual Media media { get; set; }
        public int media_id { get; set; }

        [ForeignKey("person_id")]
        public People person { get; set; }
        public int person_id { get; set; }

        [ForeignKey("role_id")]
        public virtual CrewRoles crew_role { get; set; }
        public int crew_role_id { get; set; }
        public string? character_name { get; set; }
    }
}
