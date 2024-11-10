using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackster.Model.Requests
{
    public class LanguageUpdateRequest
    {
        public int language_id { get; set; }
        public string language_name { get; set; }
    }
}
