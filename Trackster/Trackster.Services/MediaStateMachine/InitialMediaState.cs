using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model;
using Trackster.Model.Requests;
using Trackster.Repository;

namespace Trackster.Services.MediaStateMachine
{
    public class InitialMediaState : BaseMediaState
    {
        public InitialMediaState(TracksterContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }

        public override Media Insert(MediaInsertRequest request)
        {
            var set = Context.Set<Media>();
            var entity = Mapper.Map<Media>(request);
            entity.state_machine = "draft";
            set.Add(entity);
            Context.SaveChanges();

            return Mapper.Map<Media>(entity);
        }

        public override List<string> AllowedActions(Media entity)
        {
            return new List<string>() { nameof(Insert) };
        }

    }
}
