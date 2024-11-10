using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class MediaPersonRoleUpdateRequest
    {
        public int mediapersonrole_id { get; set; }
        public int media_id { get; set; }
        public int person_id { get; set; }
        public int role_id { get; set; }
        public string? character_name { get; set; }
    }
}
