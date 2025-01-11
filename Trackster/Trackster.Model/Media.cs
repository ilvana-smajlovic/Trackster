using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model
{
    public class Media
    {
        [Key]
        public int media_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime release_date { get; set; }
        public string status { get; set; }
        public float rating { get; set; }
        public string? picture { get; set; }
        public string? backdrop { get; set; }

        [ForeignKey("language_id")]
        public virtual Languages language { get; set; }
        public int language_id { get; set; }

        [ForeignKey("streaming_service_id")]
        public virtual StreamingServices streaming_service { get; set; }
        public int streaming_service_id { get; set; }
        public string trailerUrl { get; set; }
        public bool? state { get; set; }
        public string? state_machine { get; set; }
    }
}
