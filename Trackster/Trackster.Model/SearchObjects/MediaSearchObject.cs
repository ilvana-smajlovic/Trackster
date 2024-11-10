using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.SearchObjects
{
    public class MediaSearchObject : BaseSearchObject
    {
        public string? title { get; set; }
        public string? status { get; set; }
        public float? rating { get; set; }
        public int? page { get; set; }
        public int? page_size { get; set; }
        public string? order_by { get; set; }
    }
}
