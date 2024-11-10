using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model;
using Trackster.Repository;

namespace Trackster.Services.MediaStateMachine
{
    public class HiddenMediaState : BaseMediaState
    {
        public HiddenMediaState(TracksterContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }

        public override Media Edit(int id)
        {
            var set = Context.Set<Media>();

            var entity = set.Find(id);

            entity.state_machine = "draft";

            Context.SaveChanges();

            return Mapper.Map<Media>(entity);
        }

        public override List<string> AllowedActions(Media entity)
        {
            return new List<string>() { nameof(Edit) };
        }
    }
}
